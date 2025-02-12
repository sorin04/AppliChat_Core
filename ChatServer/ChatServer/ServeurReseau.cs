﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OutilsChat;
using System.Diagnostics;

namespace ChatServer
{
    public delegate void ClientEvent(ServeurReseau sender, ClientReseau clt);

    public class ServeurReseau
    {
        private Thread threadEcoute;
        private Thread threadDispatch;
        private Mutex accessMessages;
        private Mutex accessClients;
        private AutoResetEvent signalementMessage;
        private AutoResetEvent demandeSortie;

        private bool running;
        private IPEndPoint ep;
        private TcpListener ecoute;
        private int autoInc;

        private List<ClientReseau> clients;
        private Stack<OutilsChat.Message> messages;

        public ClientEvent OnClientAccept;
        public ClientEvent OnClientClose;

        /// <summary>
        /// Creation d'un serveur réseau
        /// </summary>
        /// <param name="adresseIP">Adresse à écouter, Null ou Vide pour toutes les adresses</param>
        /// <param name="port">Port à écouter</param>
        public ServeurReseau(String adresseIP, int port)
        {
            if (!String.IsNullOrEmpty(adresseIP))
            {
                String[] elements = adresseIP.Split('.');
                if (elements.Length != 4)
                    throw new Exception("Il faut 4 éléments dans une adresse IP");
                //
                byte[] elts = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    String element = elements[i];
                    byte elt = Convert.ToByte(element);
                    elts[i] = elt;
                }
                //
                IPAddress ipaddd = new IPAddress(elts);
                //
                this.ep = new IPEndPoint(ipaddd, port);
            }
            else
            {
                this.ep = new IPEndPoint(IPAddress.Any, port);
            }
            ecoute = new TcpListener(this.ep);
            running = false;
            this.accessMessages = new Mutex();
            this.accessClients = new Mutex();
            this.signalementMessage = new AutoResetEvent(false);
            this.demandeSortie = new AutoResetEvent(false);
        }

        public void Start()
        {
            // On met l'écoute dans un Thread
            ThreadStart PointEntree = new ThreadStart(this.Ecoute);
            threadEcoute = new Thread(PointEntree);
            threadEcoute.Start();
            // et le dispatch dans un autre
            PointEntree = new ThreadStart(this.Dispatch);
            threadDispatch = new Thread(PointEntree);
            threadDispatch.Start();

        }

        private void Dispatch()
        {
            WaitHandle[] attente = new WaitHandle[2];
            attente[0] = this.signalementMessage;
            attente[1] = this.demandeSortie;

            while (true)
            {
                // Attente d'un signal : message ou demande de sortie
                int who = AutoResetEvent.WaitAny(attente, Timeout.Infinite);

                if (who == 1)
                {
                    // Sortie demandée, fermeture des clients
                    this.accessClients.WaitOne();
                    foreach (ClientReseau clt in this.clients)
                    {
                        clt.Stop();
                    }
                    this.accessClients.ReleaseMutex();
                    break;
                }

                // Traitement des messages
                this.accessMessages.WaitOne();

                OutilsChat.Message msg;
                while (this.messages.Count > 0)
                {
                    msg = this.messages.Pop();

                    // Si c'est un fichier
                    if (msg.Data.StartsWith("FILE|"))
                    {
                        string[] parts = msg.Data.Split('|');
                        if (parts.Length >= 3)
                        {
                            string fileType = parts[1];
                            string base64File = parts[2];

                            byte[] fileData = Convert.FromBase64String(base64File);

                            // Gérer le fichier (ici on peut l'enregistrer ou l'envoyer à d'autres clients)
                            // Exemple : Sauvegarder le fichier sur le serveur
                            string fileName = "received_file." + fileType;
                            File.WriteAllBytes(fileName, fileData);

                            // Vous pouvez aussi envoyer ce fichier à d'autres clients si nécessaire
                            this.accessClients.WaitOne();
                            foreach (ClientReseau clt in this.clients)
                            {
                                if (clt.Id != msg.Id) // Ne pas renvoyer au client qui a envoyé le fichier
                                {
                                    // Envoi du message avec fichier
                                    clt.Ecrire($"FILE|{fileType}|{base64File}");
                                }
                            }
                            this.accessClients.ReleaseMutex();
                        }
                    }
                    else
                    {
                        // Si ce n'est pas un fichier, envoyer le message comme d'habitude
                        this.accessClients.WaitOne();
                        foreach (ClientReseau clt in this.clients)
                        {
                            if (clt.Id != msg.Id)
                            {
                                clt.Ecrire(msg.Data);
                            }
                        }
                        this.accessClients.ReleaseMutex();
                    }
                }
                this.accessMessages.ReleaseMutex();
            }
        }

        private void Ecoute()
        {
            this.ecoute.Start();
            //
            this.clients = new List<ClientReseau>();
            this.messages = new Stack<OutilsChat.Message>();
            //
            this.running = true;
            this.autoInc = 0;
            //
            while (true)
            {
                try
                {
                    // Récupération du Client
                    TcpClient client = this.ecoute.AcceptTcpClient();
                    // Lancement d'un Thread avec ce Client
                    ClientReseau clientNetwork = new ClientReseau(client);
                    clientNetwork.AccessMessages = this.accessMessages;
                    clientNetwork.Messages = this.messages;
                    clientNetwork.SignalementMessage = this.signalementMessage;
                    clientNetwork.Serveur = this;
                    clientNetwork.Start();
                    clientNetwork.Id = this.autoInc++;
                    //
                    this.accessClients.WaitOne();
                    clients.Add(clientNetwork);
                    this.accessClients.ReleaseMutex();
                    // En cas d'erreur de traitement du sous-traitant
                    // On remonte l'erreur
                    if (this.OnClientAccept != null)
                        this.OnClientAccept(this, clientNetwork);
                    
                }
                catch (InvalidOperationException e)
                {
                    // On remonte l'erreur
                    throw;
                }
                catch (Exception e)
                {
                    // Mmm pas bon, peut etre une fermeture du TcpListener ??
                    // On pouse les infos dans la fenêtre du DEBUG si il y en a un...
                    Trace.WriteLine(e.Message);
                    //et on s'en va
                    break;
                }
            }
            this.running = false;
        }

        public void Stop()
        {
            if (this.running)
            {
                // Il faut arrêter le Thread
                // On va donc fermer le listener
                this.ecoute.Stop();
                // Et on demande la sortie du Dispatch
                this.demandeSortie.Set();
            }
        }

        public void RemoveClient(int id)
        {
            this.accessClients.WaitOne();
            //
            ClientReseau clt = this.clients.Find(x => x.Id == id);
            if (clt != null)
                clients.Remove(clt);
            this.accessClients.ReleaseMutex();
            //
            if (clt != null)
            {
                try
                {
                    if (this.OnClientClose != null)
                        this.OnClientClose(this, clt);
                }
                catch (InvalidOperationException e)
                {
                    // On remonte l'erreur
                    throw;
                }
            }
        }



    }
}
