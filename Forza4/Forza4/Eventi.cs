using System;
using System.Collections.Generic;
using System.Text;

namespace Forza4
{
    class Eventi
    {
        MainWindow m;
        forza4 forza4;
        public Eventi(MainWindow m)
        {

            m.ButtonClick += InserisciGettone;

        }

        private void InserisciGettone(int colonna)
        {
            
        }
    }
}
