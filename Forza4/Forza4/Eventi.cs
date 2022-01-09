using System;
using System.Collections.Generic;
using System.Text;

namespace Forza4
{
    class Eventi
    {
        MainWindow m;
        forza4 forza;
        partita p;
        //Connessione connect;
        public Eventi(MainWindow m/*,Connessione connect*/)
        {
            p = new partita(1, 2);
            forza = new forza4(ref p);
            this.m = m;
            //this.connect = connect;
            m.ButtonClick += InserisciGettone;
            m.Restart += Resetta;
            //connect.Start += Start;
        }

        private void InserisciGettone(int colonna)
        {
            bool turno = p.getTurno();
            if(turno)
                forza.inserisciGettone(1, colonna);
            else
                forza.inserisciGettone(2, colonna);

            m.txtGriglia.Text = forza.getGriglia();
            if (forza.controlloVittoria())
            {
                if(turno)
                    m.txtGriglia.Text = p.getPlayer1Name() + " ha vinto";
                else
                    m.txtGriglia.Text = p.getPlayer2Name() + " ha vinto";
                m.btnRestart.Visibility = System.Windows.Visibility.Visible;
            }

        }
        
        private void Resetta()
        {
            forza.svuota();
            m.txtGriglia.Text = "";
            m.btnRestart.Visibility = System.Windows.Visibility.Hidden;
        }
        /*
        private void Start()
        {
           
        }*/
    }
}
