using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace AlyTaloSovellus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Lights TalonValaistus = new Lights();
        public Sauna OmaSauna = new Sauna();
        public Thermostat TalonLampo = new Thermostat();
        public DispatcherTimer SaunaAjastin = new DispatcherTimer();
        public char celsius;
        MediaPlayer mplayer = new MediaPlayer();
        int TalonLampoLuku;
        private int mittari = 0;

        public MainWindow()
        {
            InitializeComponent();
            TalonValaistus.Dimmer = "0";
            TalonValaistus.Switched = false;
            SaunaAjastin.Tick += SaunanLampo_Tick;
            SaunaAjastin.Interval = new TimeSpan(0, 0, 1);

        }



        
        private void SaunanLampo_Tick(object sender, EventArgs e)
        {
            if (OmaSauna.Switched == true)
            {

                if (mittari < 5)
                {
                    mittari++;
                }

            }
            else
            {
                if (mittari > 0)
                {

                    mittari--;

                }
                else
                {
                    SaunaAjastin.Stop();
                }

            }
            lblLampotila.Content = mittari.ToString() + "°C";

        }

        private void valonTila1_Click(object sender, RoutedEventArgs e)
        {
            TalonValaistus.täysivalo();
            {
                if (TalonValaistus.Dimmer == "100")
                {
                    mplayer.Open(new Uri("Clickon.wav", UriKind.Relative));
                    mplayer.Play();
                    TalonValot.Text = "Kirkas";
                }
            }
        }

        private void valonTila2_Click(object sender, RoutedEventArgs e)
        {
            TalonValaistus.kaksiKolmasOsa();
            {
                if (TalonValaistus.Dimmer == "66")
                {
                    mplayer.Open(new Uri("Clickon.wav", UriKind.Relative));
                    mplayer.Play();
                    TalonValot.Text = "Puolivalot";
                }
            }
        }

        private void valonTila3_Click(object sender, RoutedEventArgs e)
        {
            TalonValaistus.kolmasOsaValot();
            {
                if (TalonValaistus.Dimmer == "33")
                {
                    mplayer.Open(new Uri("Clickon.wav", UriKind.Relative));
                    mplayer.Play();
                    TalonValot.Text = "Hämärä";
                }
            }

        }

        private void valonTila4_Click(object sender, RoutedEventArgs e)
        {
            mplayer.Open(new Uri("Clickoff.wav", UriKind.Relative));
            mplayer.Play();
            TalonValaistus.Switched = false;
            TalonValaistus.Dimmer = "Pois";
            TalonValot.Text = TalonValaistus.Dimmer;
        }

        private void BtnSauna_Click(object sender, RoutedEventArgs e)
        {
            if (OmaSauna.Switched == true)
            {
                mplayer.Open(new Uri("Tick.wav", UriKind.Relative));
                mplayer.Play();
                SaunaAjastin.Start();
                OmaSauna.saunaOff();
                saunanTila.Text = "";
            }
            else
            {
                SaunaAjastin.Start();
                mplayer.Open(new Uri("kiuas.wav", UriKind.Relative));
                mplayer.Play();
                OmaSauna.saunaOn();
                saunanTila.Text = "Sauna on päällä";
            }


        }



        private void Btnlampo_Click(object sender, RoutedEventArgs e)
        {
            mplayer.Open(new Uri("fuzzy.wav", UriKind.Relative));
            mplayer.Play();
            TalonLampo.LampoSaato(Int32.Parse(haluttuLampo.Text));
            // TalonLampo.Temperature = Int32.Parse(haluttuLampo.Text);
            nykyinenLampo.Text = haluttuLampo.Text + "°C";
            haluttuLampo.Text = "";
        }

        private void haluttuLampo_TextChanged(object sender, TextChangedEventArgs e)
        {
            haluttuLampo.MaxLength = 2;
            haluttuLampo.MinLines = 1;
            if (Int32.TryParse(haluttuLampo.Text, out TalonLampoLuku))
            {
                if (TalonLampoLuku > 30)
                    MessageBox.Show("Talon maksimilämpö on 30°C turvallisuuden vuoksi.");
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(haluttuLampo.Text, "[^0-9]"))
            {
                MessageBox.Show("Talon lämmön asettamiseksi kelpaa vain numerot!");
                haluttuLampo.Text = haluttuLampo.Text.Remove(haluttuLampo.Text.Length - 1);

               


            }

        }

    
     }
    }

    









