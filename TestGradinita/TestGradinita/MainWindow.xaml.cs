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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Gradinita
    {
        public static Image UserImage;

        public static int score;
        public static int wrongAnswers;

        public static string dirSource = "C:/Users/Admin/Desktop/master_an_1_semestru_2/copii/Gradinita/TestGradinita/resources/";

        // gresit/corect 
        public static string s1 = dirSource + "corect.wav";
        public static string s2 = dirSource + "gresit.wav";

        public static System.Media.SoundPlayer CorrectAnswerSound = new System.Media.SoundPlayer(@s1);
        public static System.Media.SoundPlayer WrongAnswerSound = new System.Media.SoundPlayer(@s2);
    };

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MyWindow_Loaded;
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Login());
        }
    }
}
