using System;
using System.Collections.Generic;
using System.Text;

namespace Forza4
{
    class forza4
    {
        int[,] griglia;
        partita p;

        public forza4(){
            griglia = new int[7, 6];
            for (int i=0;i<7;i++)
            {
                for (int j=0;j<6;j++)
                {
                    griglia[i, j] = 0;
                }
            }
        }

        public forza4(ref partita p)
        {
            this.p = p;
            griglia = new int[7, 6];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    griglia[i, j] = 0;
                }
            }
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
            p.resetTurno();
        }

        public bool inserisciGettone(int n,int a)
        {
            bool errore = true;
            for(int i = 5; i >= 0&&errore; i--)
            {
                if (griglia[a, i] == 0)
                {
                    griglia[a, i] = n;
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
