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

namespace TestGradinita
{
    /// <summary>
    /// Interaction logic for Score.xaml
    /// </summary>
    public partial class Score : Page
    {
        public Score()
        {
            InitializeComponent();
            userImage.Source = new BitmapImage(new Uri((TestGradinita.Gradinita.UserImage.Source as BitmapImage).UriSource.AbsolutePath));
            List<Image> l = new List<Image>();
            l.Add(s1);
            l.Add(s2);
            l.Add(s3);
            l.Add(s4);
            l.Add(s5);
            for (int i=1;i<=TestGradinita.Gradinita.score%6;++i)
            {
                l[i - 1].Source = new BitmapImage(new Uri(TestGradinita.Gradinita.dirSource + "steluta.jpg"));
            }

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestGradinita.Gradinita.dirSource+"scor.wav");
            player.Play();
        }
    }
}
