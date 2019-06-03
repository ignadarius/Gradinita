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
using System.Windows.Controls.Primitives;
using System.Threading;

namespace TestGradinita
{
    /// <summary>
    /// Interaction logic for DADQuestion.xaml
    /// </summary>
    public partial class DADQuestion : Page
    {
        static int cnt = 0;
        private int score = 20;
        private int wrongAnswers = 0;
        static Timer TTimer = null;
        public DADQuestion()
        {
            InitializeComponent();
            TTimer = new Timer(
                       new TimerCallback(NextQuestion),
                       null,
                       50000,
                       50000);
            userImage.Source = new BitmapImage(new Uri(Gradinita.currentUser.ImgSource));
            nr1.Source = new BitmapImage(new Uri(Gradinita.dirSource + "cf8.png"));
            //Gradinita.OrdoneazaNumerele.Play();

            nr1.MouseLeftButtonDown += (s, e) =>
            {
                Image img = s as Image;

                DataObject data = new DataObject(DataFormats.Text, img.Source);

                DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);

            };
            nr1.Height = 150;
            nr1.Width = 150;
            nr2.Source = new BitmapImage(new Uri(Gradinita.dirSource + "cf1.png"));
            nr2.MouseLeftButtonDown += (s, e) =>
            {
                Image img = s as Image;

                DataObject data = new DataObject(DataFormats.Text, img.Source);

                DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);

            };
            nr2.Height = 150;
            nr2.Width = 150;
            nr3.Source = new BitmapImage(new Uri(Gradinita.dirSource + "cf6.png"));
            nr3.MouseLeftButtonDown += (s, e) =>
            {
                Image img = s as Image;

                DataObject data = new DataObject(DataFormats.Text, img.Source);

                DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);

            };
            nr3.Height = 150;
            nr3.Width = 150;
            img1.Source = new BitmapImage(new Uri(Gradinita.dirSource + "plh.png"));
            img1.Drop += (s, e) =>
            {

                Image img = e.Source as Image;
                BitmapImage source = (BitmapImage)e.Data.GetData(DataFormats.Text);

                if (source.UriSource.AbsolutePath == Gradinita.dirSource + "cf1.png")
                {
                    img.Source = source;
                    cnt++;
                    if (cnt == 3)
                    {
                        TTimer.Dispose();
                        Thread.Sleep(1000);
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.Play();
                        Thread.Sleep(3000);
                        this.NavigationService.Navigate(new QuestionPage());
                    }
                }
                else
                {
                    wrongAnswers++;
                    Gradinita.WrongAnswerSound.Play();
                }
            };
            img1.Height = 150;
            img1.Width = 150;
            img2.Source = new BitmapImage(new Uri(Gradinita.dirSource + "plh.png"));
            img2.Drop += (s, e) =>
            {

                Image img = e.Source as Image;
                BitmapImage source = (BitmapImage)e.Data.GetData(DataFormats.Text);

                if (source.UriSource.AbsolutePath == Gradinita.dirSource + "cf6.png")
                {
                    img.Source = source;
                    cnt++;
                    if (cnt == 3)
                    {
                        TTimer.Dispose();
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.Play();
                        Thread.Sleep(3000);
                        this.NavigationService.Navigate(new QuestionPage());
                    }
                }
                else
                {
                    wrongAnswers++;
                    Gradinita.WrongAnswerSound.Play();
                }
            };
            img2.Height = 150;
            img2.Width = 150;
            img3.Source = new BitmapImage(new Uri(Gradinita.dirSource + "plh.png"));
            img3.Drop += (s, e) =>
            {

                Image img = e.Source as Image;
                BitmapImage source = (BitmapImage)e.Data.GetData(DataFormats.Text);
                
                if (source.UriSource.AbsolutePath == Gradinita.dirSource + "cf8.png")
                {
                    img.Source = source;
                    cnt++;
                    if (cnt == 3)
                    {
                        TTimer.Dispose();
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.Play();
                        Thread.Sleep(3000);

                        this.NavigationService.Navigate(new QuestionPage());
                    }
                }
                else
                {
                    wrongAnswers++;
                    Gradinita.WrongAnswerSound.Play();
                }
            };
            img3.Height = 150;
            img3.Width = 150;

        }

        private Image CreateImage(string source)
        {
            Image Mole = new Image();
            Mole.Width = 100;
            Mole.Height = 100;
            ImageSource MoleImage = new BitmapImage(new Uri(source));
            Mole.Source = MoleImage;
            return Mole;
        }

       
        private void continueDrag(object sender, QueryContinueDragEventArgs e)
        {
            
        }

        private void NextQuestion(object state)
        {
            this.Dispatcher.Invoke(() =>
            {
                TTimer.Dispose();
                this.NavigationService.Navigate(new QuestionPage());
            });
        }

    }
}
