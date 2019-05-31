using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace TestGradinita
{
    /// <summary>
    /// Interaction logic for Introducere.xaml
    /// </summary>
    public partial class Introducere : Page
    {
        Timer TTimer = null;

        public Introducere()
        {
            InitializeComponent();
            userImage.Source = new BitmapImage(new Uri(Gradinita.currentUser.ImgSource));

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Gradinita.dirSource + "galaxy.png", UriKind.RelativeOrAbsolute));
            gridIntroducere.Background = ib; 


            // Timer ----------------
            TTimer = new Timer(
                        new TimerCallback(StartTest),
                        null,
                        1000,
                        1);
            //-----------------------


        }

        private void StartTest(object state)
        {
            this.Dispatcher.Invoke(() =>
            {
                TTimer.Dispose();
                string s1 = Gradinita.dirSource + "start.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@s1);
                player.PlaySync();

                this.NavigationService.Navigate(new QuestionPage());
               
            });
        }





    }
}
