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
        public QuestionPage2()
        {
            InitializeComponent();
            userImage.Source = new BitmapImage(new Uri((TestGradinita.Gradinita.UserImage.Source as BitmapImage).UriSource.AbsolutePath));


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
                TestGradinita.Gradinita.score++;
                TestGradinita.Gradinita.CorrectAnswerSound.PlaySync();
                this.NavigationService.Navigate(new QuestionPage());
            };

            i1.MouseDown += (s, e) =>
            {
                TestGradinita.Gradinita.wrongAnswers++;
                TestGradinita.Gradinita.WrongAnswerSound.Play();
            };

            i2.MouseDown += (s, e) =>
            {
                TestGradinita.Gradinita.wrongAnswers++;
                TestGradinita.Gradinita.WrongAnswerSound.Play();
            };

            i3.MouseDown += (s, e) =>
            {
                TestGradinita.Gradinita.wrongAnswers++;
                TestGradinita.Gradinita.WrongAnswerSound.Play();
            };

            i4.MouseDown += (s, e) =>
            {
                TestGradinita.Gradinita.wrongAnswers++;
                TestGradinita.Gradinita.WrongAnswerSound.Play();
            };

        }

        private void NextQuestion(object state)
        {
            this.Dispatcher.Invoke(() =>
            {
                TestGradinita.Gradinita.timpExpirat.PlaySync();
                Uri pageFunctionUri = new Uri("QuestionPage.xaml", UriKind.RelativeOrAbsolute);
                this.NavigationService.Navigate(pageFunctionUri);
            });
        }
    }
}
