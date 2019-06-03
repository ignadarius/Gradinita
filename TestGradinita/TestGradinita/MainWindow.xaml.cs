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
using System.IO;

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

        public static string dirSource = "D:/Master-Guran/Gradinita/TestGradinita/resources/";

        // gresit/corect 
        public static string s1 = dirSource + "corect.wav";
        public static string s2 = dirSource + "gresit.wav";
        public static Dictionary<string,User> users = new Dictionary<string,User>();
        public static User currentUser;

        public static System.Media.SoundPlayer CorrectAnswerSound = new System.Media.SoundPlayer(@s1);
        public static System.Media.SoundPlayer WrongAnswerSound = new System.Media.SoundPlayer(@s2);
        public static System.Media.SoundPlayer timpExpirat = new System.Media.SoundPlayer(@dirSource + "expirat.wav");
        public static System.Media.SoundPlayer OrdoneazaNumerele = new System.Media.SoundPlayer(dirSource + "ordoneaza.wav");
    };

    public class User
    {
        public User(string name, string source)
        {
            Name = name;
            ImgSource = source;
            Score = 0;
            isTested = false;
        }
       
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public bool IsTested
        {
            get
            {
                return isTested;
            }

            set
            {
                isTested = value;
            }
        }

        public string ImgSource
        {
            get
            {
                return imgSource;
            }

            set
            {
                imgSource = value;
            }
        }

        private string name;
        private int score;
        private bool isTested;
        private string imgSource;
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
            Loaded += MyWindow_Loaded;
            File.Delete(Gradinita.dirSource + "results.txt");
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Login());
        }

        public void LoadUsers()
        {
            User u1 = new User("TUDOR R.-A", Gradinita.dirSource + "p1.png");
            Gradinita.users.Add(u1.ImgSource, u1);

            User u2 = new User("ANAIS", Gradinita.dirSource + "p2.png");
            Gradinita.users.Add(u2.ImgSource, u2);

            User u3 = new User("SARA-MARIA", Gradinita.dirSource + "p3.png");
            Gradinita.users.Add(u3.ImgSource, u3);

            User u4 = new User("HOREA", Gradinita.dirSource + "p4.png");
            Gradinita.users.Add(u4.ImgSource, u4);

            User u5 = new User("DARIUS", Gradinita.dirSource + "p5.png");
            Gradinita.users.Add(u5.ImgSource, u5);

            User u6 = new User("SOPHIA C.", Gradinita.dirSource + "p6.png");
            Gradinita.users.Add(u6.ImgSource, u6);

            User u7 = new User("ILINCA", Gradinita.dirSource + "p7.png");
            Gradinita.users.Add(u7.ImgSource, u7);
            User u8 = new User("ANA B.", Gradinita.dirSource + "p8.png");
            Gradinita.users.Add(u8.ImgSource, u8);
            User u9 = new User("MIHAI", Gradinita.dirSource + "p9.png");
            Gradinita.users.Add(u9.ImgSource, u9);
            User u10 = new User("LORENA", Gradinita.dirSource + "p10.png");
            Gradinita.users.Add(u10.ImgSource, u10);
            User u11 = new User("ANA D.", Gradinita.dirSource + "p11.png");
            Gradinita.users.Add(u11.ImgSource, u11);
            User u12 = new User("ELENA", Gradinita.dirSource + "p12.png");
            Gradinita.users.Add(u12.ImgSource, u12);
            User u13 = new User("VLAD", Gradinita.dirSource + "p13.png");
            Gradinita.users.Add(u13.ImgSource, u13);
            User u14 = new User("SOFIA O.", Gradinita.dirSource + "p14.png");
            Gradinita.users.Add(u14.ImgSource, u14);
            User u15 = new User("MATEI A.", Gradinita.dirSource + "p15.png");
            Gradinita.users.Add(u15.ImgSource, u15);

            User u16 = new User("VICTOR", Gradinita.dirSource + "p16.png");
            Gradinita.users.Add(u16.ImgSource, u16);

            User u17 = new User("AURORA", Gradinita.dirSource + "p17.png");
            Gradinita.users.Add(u17.ImgSource, u17);
            User u18 = new User("JASMINE", Gradinita.dirSource + "p18.png");
            Gradinita.users.Add(u18.ImgSource, u18);
            User u19 = new User("PATRICIA", Gradinita.dirSource + "p19.png");
            Gradinita.users.Add(u19.ImgSource, u19);

            User u20 = new User("ANTONIA Ș.", Gradinita.dirSource + "p20.png");
            Gradinita.users.Add(u20.ImgSource, u20);
            User u21 = new User("NATALIA", Gradinita.dirSource + "p21.png");
            Gradinita.users.Add(u21.ImgSource, u21);
            User u22 = new User("MATEi P.", Gradinita.dirSource + "p22.png");
            Gradinita.users.Add(u22.ImgSource, u22);
            User u23 = new User("ANDRA", Gradinita.dirSource + "p23.png");
            Gradinita.users.Add(u23.ImgSource, u23);

            User u24 = new User("ANTONIA B.", Gradinita.dirSource + "p24.png");
            Gradinita.users.Add(u24.ImgSource, u24);

            User u25 = new User("MATEI L.", Gradinita.dirSource + "p25.png");
            Gradinita.users.Add(u25.ImgSource, u25);
            User u26 = new User("TUDOR M.-B.", Gradinita.dirSource + "p26.png");
            Gradinita.users.Add(u26.ImgSource, u26);
        }
    }
}
