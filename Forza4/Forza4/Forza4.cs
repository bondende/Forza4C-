using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Forza4
{
    class forza4
    {
        int[,] griglia;
        public int ultimoX;
        public int ultimoY;
        public bool turno;
        SolidColorBrush colore1;
        SolidColorBrush colore2;
        string player1;
        string player2;

       
        public forza4(){
            ultimoX = 0;
            ultimoY = 0;
            turno = true;
            colore1 = null;
            colore2 = null;
            player1 = "";
            player2 = "";
            griglia = new int[7, 6];
            for (int i=0;i<7;i++)
            {
                for (int j=0;j<6;j++)
                {
                    griglia[i, j] = 0;
                }
            }
        }

        public forza4(SolidColorBrush a, SolidColorBrush b)
        {
            ultimoX = 0;
            ultimoY = 0;
            turno = true;
            colore1 = a;
            colore2 = b;
            player1 = "giocatore 1";
            player2 = "giocatore 2";
            griglia = new int[7, 6];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    griglia[i, j] = 0;
                }
            }
        }

        public bool getTurno()
        {
            bool tmp = turno;
            turno = !turno;
            return tmp;
        }

        public SolidColorBrush getColore1()
        {
            return colore1;
        }

        public SolidColorBrush getColore2()
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

        public void svuota()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    griglia[i, j] = 0;
                }
            }
            resetTurno();
        }

        public bool inserisciGettone(int n,int j)
        {
            bool errore = true;
            for(int i = 5; i >= 0&&errore; i--)
            {
                if (griglia[j, i] == 0)
                {
                    griglia[j, i] = n;
                    ultimoX = j;
                    ultimoY = i;
                    errore = false;
                }
            }
            return errore;
        }

        public bool controlloVittoria()
        {
            bool vittoria = false;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((griglia[j, i]==1|| griglia[j, i]==2)&&griglia[j, i] == griglia[j + 1, i]&& griglia[j, i] == griglia[j + 2, i] && griglia[j, i] == griglia[j + 3, i])
                        vittoria = true;
                }
            }
            if (!vittoria)
            {
                for (int j = 0; j < 7; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if ((griglia[j, i] == 1 || griglia[j, i] == 2) && griglia[j, i] == griglia[j, i + 1] && griglia[j, i] == griglia[j, i + 2] && griglia[j, i] == griglia[j, i + 3])
                            vittoria = true;
                    }
                }
            }
            if (!vittoria)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if ((griglia[j, i] == 1 || griglia[j, i] == 2) && griglia[j, i] == griglia[j+1, i + 1] && griglia[j, i] == griglia[j+2, i + 2] && griglia[j, i] == griglia[j+3, i + 3])
                            vittoria = true;
                    }
                }
            }
            if (!vittoria)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if ((griglia[j+3, i] == 1 || griglia[j+3, i] == 2) && griglia[j+3, i] == griglia[j + 2, i + 1] && griglia[j+3, i] == griglia[j + 1, i + 2] && griglia[j+3, i] == griglia[j, i + 3])
                            vittoria = true;
                    }
                }
            }


            return vittoria;
        }

        public string getGriglia()
        {
            string tmp = "";
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    tmp += griglia[j, i].ToString() + ";";
                }
                tmp += "\n";
            }
            return tmp;
        }

    }
}
