using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    // Alegeti care din urmatoarele animale este animal domestic / cal
    /// <summary>
    /// Interaction logic for QuestionPage4.xaml
    /// </summary>
    public partial class QuestionPage4 : Page
    {
        static string imgSource = TestGradinita.Gradinita.dirSource + "q5/img";
        static Timer TTimer = null;
        public int score = 10;
        public int wrongAnswers = 0;

        public QuestionPage4()
        {
            InitializeComponent();
            userImage.Source = new BitmapImage(new Uri(Gradinita.currentUser.ImgSource));
            // Timer ----------------
            TTimer = new Timer(
                        new TimerCallback(NextQuestion),
                        null,
                        50000,
                        50000);
            //-----------------------

            // Define the Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            grid_s.ColumnDefinitions.Add(gridCol1);
            grid_s.ColumnDefinitions.Add(gridCol2);

            // Define the Rows
            RowDefinition gridRow1 = new RowDefinition();
            RowDefinition gridRow2 = new RowDefinition();
            gridRow1.Height = new GridLength(310);
            gridRow2.Height = new GridLength(310);
            grid_s.RowDefinitions.Add(gridRow1);
            grid_s.RowDefinitions.Add(gridRow2);

            for (int i = 1; i <= 4; ++i)
            {
                Image pers = CreateImage(i);

                if (i == 4) // correct
                {
                    pers.MouseDown += (s, e) =>
                    {
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.Play();
                        Thread.Sleep(3000);
                        TTimer.Dispose();
                        this.NavigationService.Navigate(new QuestionPage5());
                    };
                }
                else
                {
                    pers.MouseDown += (s, e) =>
                    {
                        wrongAnswers++;
                        Gradinita.WrongAnswerSound.Play();
                        Thread.Sleep(3000);
                    };
                }

                int a = (i - 1) / 2;
                int b = (i - 1) % 2;
                Grid.SetRow(pers, (i - 1) / 2);
                Grid.SetColumn(pers, (i - 1) % 2);

                grid_s.Children.Add(pers);
            }

            string s1 = Gradinita.dirSource + "iarna.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@s1);
            player.Play();
        }

        private void NextQuestion(object state)
        {
            this.Dispatcher.Invoke(() =>
            {
                TTimer.Dispose();
                this.NavigationService.Navigate(new QuestionPage5());
            });
        }

        private Image CreateImage(int Id)
        {
            Image img = new Image();
            img.Width = 400;
            img.Height = 400;
            ImageSource img_season = new BitmapImage(new Uri(imgSource + Id.ToString() + ".jpg"));
            img.Source = img_season;
            return img;
        }
    }
}
