using System;
using System.Collections.Generic;
using System.Text;

namespace Forza4
{
    class Eventi
    {
        MainWindow m;
        forza4 forza;
        public Eventi(MainWindow m)
        {
            forza = new forza4();
            this.m = m;
            m.ButtonClick += InserisciGettone;
        }

        private void InserisciGettone(int colonna)
        {
            forza.inserisciGettone(1,colonna);
            m.txtGriglia.Text = forza.getGriglia();
        }
    }
}
