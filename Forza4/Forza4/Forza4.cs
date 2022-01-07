using System;
using System.Collections.Generic;
using System.Text;

namespace Forza4
{
    class forza4
    {
        int[,] griglia;
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
