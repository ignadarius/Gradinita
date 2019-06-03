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

namespace TestGradinita
{
    /// <summary>
    /// Interaction logic for QuestionPage2.xaml
    /// </summary>
    public partial class QuestionPage2 : Page
    {
        static Timer TTimer = null;

        public int wrongAnswers = 0;
        public int score = 10;

        public QuestionPage2()
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

            pui.Source = new BitmapImage(new Uri(Gradinita.dirSource + "q3/greiere.jpg"));
            mama.Source = new BitmapImage(new Uri(Gradinita.dirSource + "q3/mama2.png"));
            i1.Source = new BitmapImage(new Uri(Gradinita.dirSource + "q3/albina_pui.jpg"));
            i2.Source = new BitmapImage(new Uri(Gradinita.dirSource + "q3/fluture.jpg"));
            i3.Source = new BitmapImage(new Uri(Gradinita.dirSource + "q3/furnica.jpg"));
            i4.Source = new BitmapImage(new Uri(Gradinita.dirSource + "q3/f.jpg"));

            mama.MouseDown += (s, e) =>
            {
               // TODO : SET SOUND FOR "ACEASTA ESTE MAMA"
                //TestGradinita.Gradinita.CorrectAnswerSound.PlaySync();
             
            };

            pui.MouseDown += (s, e) =>
            {
                Gradinita.currentUser.Score += score - wrongAnswers;
                TestGradinita.Gradinita.CorrectAnswerSound.PlaySync();
                TTimer.Dispose();
                this.NavigationService.Navigate(new QuestionPage3());
            };

            i1.MouseDown += (s, e) =>
            {
                wrongAnswers++;
                Gradinita.WrongAnswerSound.Play();
            };

            i2.MouseDown += (s, e) =>
            {
                wrongAnswers++;
                Gradinita.WrongAnswerSound.Play();
            };

            i3.MouseDown += (s, e) =>
            {
                wrongAnswers++;
                Gradinita.WrongAnswerSound.Play();
            };

            i4.MouseDown += (s, e) =>
            {
                wrongAnswers++;
                Gradinita.WrongAnswerSound.Play();
            };

        }

        private void NextQuestion(object state)
        {
            this.Dispatcher.Invoke(() =>
            {
                TTimer.Dispose();
                this.NavigationService.Navigate(new QuestionPage3());
            });
        }
    }
}
