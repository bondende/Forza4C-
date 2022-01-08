using System;
using System.Collections.Generic;
using System.Text;

namespace Forza4
{
    class Eventi
    {
        MainWindow m;
        forza4 forza;
        Connessione connect;
        public Eventi(MainWindow m,Connessione connect)
        {
            forza = new forza4();
            this.m = m;
            this.connect = connect;
            m.ButtonClick += InserisciGettone;
            m.Restart += Resetta;
            connect.Start += Start;
        }

        private void InserisciGettone(int colonna)
        {
            int turno = forza.getTurno();
            forza.inserisciGettone(turno, colonna);
            m.txtGriglia.Text = forza.getGriglia();
            if (forza.controlloVittoria())
            {
                m.txtGriglia.Text = "giocatore " + turno.ToString() + " ha vinto";
                m.btnRestart.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void Resetta()
        {
            forza.svuota();
            m.txtGriglia.Text = "";
            m.btnRestart.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Start()
        {
           
        }
    }
}
