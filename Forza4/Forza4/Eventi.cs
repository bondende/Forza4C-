using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Forza4
{
    class Eventi
    {
        MainWindow m;
        forza4 forza;
        double boardWidth = 500;
        double boardHeight = 430;
        double boardX = 0;
        double boardY = 0;
        bool vittoria = false;
        //Connessione connect;
        public Eventi(MainWindow m/*,Connessione connect*/)
        {
            forza = new forza4(System.Windows.Media.Brushes.Red, System.Windows.Media.Brushes.Green);
            this.m = m;
            boardX = m.gridCanvas.Width / 2 - boardWidth / 2;
            boardY = 0;
            m.nome1.Text = forza.getPlayer1Name();
            m.nome1.Foreground = forza.getColore1();
            m.nome2.Text = forza.getPlayer2Name();
            m.nome2.Foreground = System.Windows.Media.Brushes.Black;
            //this.connect = connect;
            m.ButtonClick += InserisciGettone;
            m.Restart += Resetta;
            m.DrawCanvas += drawBoard;
            //connect.Start += Start;
        }

        private void InserisciGettone(int colonna)
        {
            if (!vittoria)
            {
                bool turno = forza.getTurno();
                Ellipse myCircle = new Ellipse();
                if (turno)
                {
                    myCircle.Fill = forza.getColore1();
                    forza.inserisciGettone(1, colonna);
                    m.nome1.Foreground = System.Windows.Media.Brushes.Black;
                    m.nome2.Foreground = forza.getColore2();
                }
                else
                {
                    myCircle.Fill = forza.getColore2();
                    forza.inserisciGettone(2, colonna);
                    m.nome1.Foreground = forza.getColore1();
                    m.nome2.Foreground = System.Windows.Media.Brushes.Black;
                }

                myCircle.Width = 60;
                myCircle.Height = 60;
                Canvas.SetLeft(myCircle, boardX + 10 + 70 * forza.ultimoX);
                Canvas.SetTop(myCircle, boardY + 10 + 70 * forza.ultimoY);
                m.gridCanvas.Children.Add(myCircle);
                if (forza.controlloVittoria())
                {
                    vittoria = true;
                    m.txtVittoria.Visibility = System.Windows.Visibility.Visible;
                    if (turno)
                        m.txtVittoria.Text = forza.getPlayer1Name() + " ha vinto";
                    else
                        m.txtVittoria.Text = forza.getPlayer2Name() + " ha vinto";
                    m.btnReset.Visibility = System.Windows.Visibility.Visible;
                }
            }
            

        }
        
        private void Resetta()
        {
            vittoria = false;
            forza.svuota();
            m.txtVittoria.Visibility = System.Windows.Visibility.Hidden;
            m.btnReset.Visibility = System.Windows.Visibility.Hidden;
            m.gridCanvas.Children.Clear();
            m.nome1.Foreground = forza.getColore1();
            m.nome2.Foreground = System.Windows.Media.Brushes.Black;
            drawBoard();
        }

        private void drawBoard()
        {
            Rectangle myRectangle = new Rectangle();
            myRectangle.Fill = System.Windows.Media.Brushes.Blue;

            myRectangle.Width = boardWidth;
            myRectangle.Height = boardHeight;           
            Canvas.SetLeft(myRectangle, boardX);
            Canvas.SetTop(myRectangle, boardY);
            m.gridCanvas.Children.Add(myRectangle);
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Ellipse myCircle = new Ellipse();
                    myCircle.Fill = System.Windows.Media.Brushes.White;
                    myCircle.Width = 60;
                    myCircle.Height = 60;
                    Canvas.SetLeft(myCircle, boardX + 10 + 70 * j);
                    Canvas.SetTop(myCircle, boardY + 10 + 70 * i);
                    m.gridCanvas.Children.Add(myCircle);
                }
            }
        }

        /*
        private void Start()
        {
           
        }*/
    }
}
