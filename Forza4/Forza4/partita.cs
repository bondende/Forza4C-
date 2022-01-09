using System;
using System.Collections.Generic;
using System.Text;

namespace Forza4
{
    class partita
    {
        bool turno;
        int colore1;
        int colore2;
        string player1;
        string player2;

        public partita()
        {
            turno = true;
            colore1 = 0;
            colore2 = 0;
            player1 = "";
            player2 = "";
        }

        public partita(int a, int b)
        {
            turno = true;
            colore1 = a;
            colore2 = b;
            player1 = "giocatore 1";
            player2 = "giocatore 2";
        }

        public bool getTurno()
        {
            bool tmp = turno;
            turno = !turno;
            return tmp;
        }

        public int getColore1()
        {
            return colore1;
        }

        public int getColore2()
        {
            return colore2;
        }

        public void resetTurno()
        {
            turno = true;
        }

        public string getPlayer1Name()
        {
            return player1;
        }

        public string getPlayer2Name()
        {
            return player2;
        }
    }
}
