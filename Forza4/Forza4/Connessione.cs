using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace Forza4
{
    class Connessione
    {
         Condivisa c;
        public Connessione(ref Condivisa c)
        {
            this.c = c;
        }

        public void Ricezione()
        {     
            while (true)
            {
                UdpClient client = new UdpClient();
                IPEndPoint riceveEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataReceived = client.Receive(ref riceveEP);
                String risposta = Encoding.ASCII.GetString(dataReceived);

                string[] tmp = risposta.Split(";");
                if(tmp[0] == "STR")
                {
                    //un giocatore sta tentando di avviare una partita 
                    Invio("YES");
                }
                else if(tmp[0] == "YES")
                {
                    //un giocatore accetta di giocare 
                    Invio("YES");   
                }
                else if (tmp[0] == "INV")
                {
                    //un giocatore ci invia la sua giocata
                    c.posizione = Int32.Parse(tmp[1]);
                    if(tmp[2] == "true")
                    {
                        //partita finita 
                        Invio("RIV");
                    }
                }
                else if (tmp[0] == "RIV")
                {
                    //un giocatore tenta di rigiocare 
                    Invio("RIN");
                }
                else if (tmp[0] == "RIY")
                {
                    //un giocatore accetta di rigiocare 
                }
                else if (tmp[0] == "RIN")
                {
                    //un giocatore non accetta di rigiocare 
                }
                else if (tmp[0] == "CLS")
                {
                    //un giocatore chiude la connessione
                    c.nicknameAvv = "";
                    c.posizione = 0;
                    c.turno = false;
                }


            }
        }

        public void Invio(String comando)
        {
            UdpClient client = new UdpClient();
            string invio = comando+";" + c.nickname + ";" + "giallo";
            byte[] data = Encoding.ASCII.GetBytes(invio);
            client.Send(data, data.Length, "localhost", 2003);
        }

        public event startEventHandler Start;
        public delegate void startEventHandler();
    }

}
