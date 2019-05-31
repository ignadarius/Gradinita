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
using System.Threading;
using System.IO;

namespace TestGradinita
{
    /// <summary>
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : Page
    {
        static Timer TTimer = null;
        public Score()
        {
            InitializeComponent();

            // Timer ----------------
            TTimer = new Timer(
                        new TimerCallback(NewSession),
                        null,
                        1000,
                        1000);

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Gradinita.dirSource + "galaxy.png", UriKind.RelativeOrAbsolute));
            gridScore.Background = ib;

            userImage.Source = new BitmapImage(new Uri(Gradinita.currentUser.ImgSource));
            List<Image> l = new List<Image>();
            l.Add(s1);
            l.Add(s2);
            l.Add(s3);
            l.Add(s4);
            l.Add(s5);
            for (int i=1;i<=Gradinita.currentUser.Score/10;++i)
            {
                l[i - 1].Source = new BitmapImage(new Uri(TestGradinita.Gradinita.dirSource + "star.png"));
            }

            string path = Gradinita.dirSource + "results.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(Gradinita.currentUser.Name + ":" + Gradinita.currentUser.Score.ToString());
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(Gradinita.currentUser.Name + ":" + Gradinita.currentUser.Score.ToString());
            }
        }

        private void NewSession(object state )
        {
            this.Dispatcher.Invoke(() =>
            {
                TTimer.Dispose();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestGradinita.Gradinita.dirSource + "scor.wav");
                player.PlaySync();
                Uri pageFunctionUri = new Uri("Login.xaml", UriKind.RelativeOrAbsolute);
                this.NavigationService.Navigate(pageFunctionUri);
            });
        }
    }
}
