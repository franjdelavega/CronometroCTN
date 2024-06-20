using System;
using System.Windows;
using System.Windows.Threading;

namespace CronometroCTN
{
    /*
     * PRUEBA .NET PARA CTN
     * DESARROLLADOR: FRANCISCO JOSÉ DE LA VEGA GARCÍA
     * FECHA INICIO: 20/06/2024
     * FECHA FIN: 21/06/2024
     * 
     *DEBES REALIZAR UN DESARROLLO USANDO WPF, C# Y PRINCIPIOS SOLID DE UN CRONÓMETRO DONDE SE VISUALIZAN
     *“HORAS::MINUTOS::SEGUNDOS” CON TRES BOTONES:
     *- START: ARRANCA EL CRONÓMETRO.
     *- PAUSE: PAUSA EL CRONÓMETRO.
     *- STOP: PARA EL CRONÓMETRO Y REINICIA EL CONTADOR DEL CRONÓMETRO. 
     */


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region VARIABLES
        private DispatcherTimer dt = new DispatcherTimer();
        private TimeSpan timeElapsed;
        private bool isPaused;
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Método principal de la app
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += DtInstant;

            timeElapsed = TimeSpan.Zero;
            isPaused = false;
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Evento CLICK del botón "START" que arrancará o continuará el cronometro 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!dt.IsEnabled || isPaused)
            {
                dt.Start();
                isPaused = false;
            }
        }

        /// <summary>
        /// Evento CLICK del botón "PAUSE" que pausará el cronometro pero no lo reiniciará
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if (dt.IsEnabled)
            {
                isPaused = true;
            }
        }

        /// <summary>
        /// Evento CLICK del botón "STOP" que parará y reiniciará el cronometro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            dt.Stop();
            timeElapsed = TimeSpan.Zero;
            TxtTime.Text = "00:00:00";
            isPaused = false;
        }

        /// <summary>
        /// Método que es llamado por el vento principal ("MainWindow")
        /// que crea un "instante" que es el que modifica en texto mostrado por el cronometro
        /// segundo a segundo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtInstant(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
                TxtTime.Text = timeElapsed.ToString(@"hh\:mm\:ss");
            }
        }
        #endregion
    }
}
