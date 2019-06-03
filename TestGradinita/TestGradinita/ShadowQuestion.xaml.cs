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
    public partial class ShadowQuestion : Page
    {
        static int cnt = -1;
        private int score = 30;
        private int wrongAnswers = 0;
        static Timer TTimer = null;
        public ShadowQuestion()
        {
            InitializeComponent();
            TTimer = new Timer(
                       new TimerCallback(NextQuestion),
                       null,
                       50000,
                       50000);
            userImage.Source = new BitmapImage(new Uri(Gradinita.currentUser.ImgSource));
            f1.Source = new BitmapImage(new Uri(Gradinita.dirSource + "f1.png"));
            //Gradinita.OrdoneazaNumerele.Play();

            f1.MouseLeftButtonDown += (s, e) =>
            {
                Image img = s as Image;

                DataObject data = new DataObject(DataFormats.Text, img.Source);

                DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);

            };
            f1.Height = 150;
            f1.Width = 150;
            f2.Source = new BitmapImage(new Uri(Gradinita.dirSource + "f2.png"));
            f2.MouseLeftButtonDown += (s, e) =>
            {
                Image img = s as Image;

                DataObject data = new DataObject(DataFormats.Text, img.Source);

                DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);

            };
            f2.Height = 150;
            f2.Width = 150;
            f3.Source = new BitmapImage(new Uri(Gradinita.dirSource + "f3.png"));
            f3.MouseLeftButtonDown += (s, e) =>
            {
                Image img = s as Image;

                DataObject data = new DataObject(DataFormats.Text, img.Source);

                DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);

            };
            f3.Height = 150;
            f3.Width = 150;
            f4.Source = new BitmapImage(new Uri(Gradinita.dirSource + "f4.png"));
            f4.MouseLeftButtonDown += (s, e) =>
            {
                Image img = s as Image;

                DataObject data = new DataObject(DataFormats.Text, img.Source);

                DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);

            };
            f4.Height = 150;
            f4.Width = 150;
            s1.Source = new BitmapImage(new Uri(Gradinita.dirSource + "s1.png"));
            s1.Drop += (s, e) =>
            {

                Image img = e.Source as Image;
                BitmapImage source = (BitmapImage)e.Data.GetData(DataFormats.Text);

                if (source.UriSource.AbsolutePath == Gradinita.dirSource + "f1.png")
                {
                    img.Source = source;
                    f1.Visibility = Visibility.Collapsed;
                    cnt++;
                    if (cnt == 3)
                    {
                        TTimer.Dispose();
                        Thread.Sleep(1000);
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.Play();
                        Thread.Sleep(3000);
                        this.NavigationService.Navigate(new DADQuestion());
                    }
                }
                else
                {
                    wrongAnswers++;
                    Gradinita.WrongAnswerSound.Play();
                }
            };
            s1.Height = 150;
            s1.Width = 150;
            s2.Source = new BitmapImage(new Uri(Gradinita.dirSource + "s2.png"));
            s2.Drop += (s, e) =>
            {

                Image img = e.Source as Image;
                BitmapImage source = (BitmapImage)e.Data.GetData(DataFormats.Text);

                if (source.UriSource.AbsolutePath == Gradinita.dirSource + "f2.png")
                {
                    img.Source = source;
                    f2.Visibility = Visibility.Collapsed;
                    cnt++;
                    if (cnt == 3)
                    {
                        TTimer.Dispose();
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.Play();
                        Thread.Sleep(3000);
                        this.NavigationService.Navigate(new DADQuestion());
                    }
                }
                else
                {
                    wrongAnswers++;
                    Gradinita.WrongAnswerSound.Play();
                }
            };
            s2.Height = 150;
            s2.Width = 150;
            s3.Source = new BitmapImage(new Uri(Gradinita.dirSource + "s3.png"));
            s3.Drop += (s, e) =>
            {

                Image img = e.Source as Image;
                BitmapImage source = (BitmapImage)e.Data.GetData(DataFormats.Text);

                if (source.UriSource.AbsolutePath == Gradinita.dirSource + "f3.png")
                {
                    img.Source = source;
                    f3.Visibility = Visibility.Collapsed;
                    cnt++;
                    if (cnt == 3)
                    {
                        TTimer.Dispose();
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.Play();
                        Thread.Sleep(3000);

                        this.NavigationService.Navigate(new DADQuestion());
                    }
                }
                else
                {
                    wrongAnswers++;
                    Gradinita.WrongAnswerSound.Play();
                }
            };
            s3.Height = 150;
            s3.Width = 150;

            s4.Source = new BitmapImage(new Uri(Gradinita.dirSource + "s4.png"));
            s4.Drop += (s, e) =>
            {

                Image img = e.Source as Image;
                BitmapImage source = (BitmapImage)e.Data.GetData(DataFormats.Text);

                if (source.UriSource.AbsolutePath == Gradinita.dirSource + "f4.png")
                {
                    img.Source = source;
                    f4.Visibility = Visibility.Collapsed;
                    cnt++;
                    if (cnt == 3)
                    {
                        TTimer.Dispose();
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.Play();
                        Thread.Sleep(3000);

                        this.NavigationService.Navigate(new DADQuestion());
                    }
                }
                else
                {
                    wrongAnswers++;
                    Gradinita.WrongAnswerSound.Play();
                }
            };
            s4.Height = 150;
            s4.Width = 150;

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
                this.NavigationService.Navigate(new DADQuestion());
            });
        }

    }
}
