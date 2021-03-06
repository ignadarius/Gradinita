﻿using System;
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
    /// Interaction logic for QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        List<Question> Questions;

        static Timer TTimer = null;

        public int wrongAnswers = 0;
        public int score = 10;

        public QuestionPage()
        {
            InitializeComponent();

            LoadQuestions();

            // Timer ----------------
            TTimer = new Timer(
                        new TimerCallback(NextQuestion),
                        null,
                        50000,
                        50000);

            userImage.Height = 100;
            userImage.Width = 100;
            userImage.Source = new BitmapImage(new Uri(Gradinita.currentUser.ImgSource));
            Loaded += ComponentLoaded;

            // Create Columns

            ColumnDefinition gridCol1 = new ColumnDefinition();

            ColumnDefinition gridCol2 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(gridCol1);

            grid.ColumnDefinitions.Add(gridCol2);

            // Create Rows

            RowDefinition gridRow1 = new RowDefinition();

            gridRow1.Height = new GridLength(310);

            RowDefinition gridRow2 = new RowDefinition();

            gridRow2.Height = new GridLength(310);

            grid.RowDefinitions.Add(gridRow1);

            grid.RowDefinitions.Add(gridRow2);

            LoadAnswerOptions(Questions[0]);
        }

        private void ComponentLoaded(object sender, RoutedEventArgs e)
        {

        }

        public void LoadAnswerOptions(Question question)
        {
            int i = 0;
            foreach (var imgSource in question.Images)
            {
                Image answer = CreateImage(imgSource);

                answer.MouseDown += (s, e) =>
                {
                    // TestGradinita.Gradinita.UserImage = s as Image;
                    Image chosenImage = s as Image;
                    if (imgSource.Equals(question.CorrectImage))
                    {
                        Gradinita.currentUser.Score += score - wrongAnswers;
                        TestGradinita.Gradinita.CorrectAnswerSound.PlaySync();
                        TTimer.Dispose();
                        this.NavigationService.Navigate(new QuestionPage1());
                    }  
                    else
                    {
                        wrongAnswers++;
                        Gradinita.WrongAnswerSound.Play();
                    }
                    
                };
                Grid.SetRow(answer, (++i - 1) / 2);
                Grid.SetColumn(answer, (i - 1) % 2);
                grid.Children.Add(answer);

                question.SoundDescription.Play();
            }
        }

        private Image CreateImage(String imgSource)
        {
            Image Mole = new Image();
            Mole.Width = 250;
            Mole.Height = 250;
            ImageSource MoleImage = new BitmapImage(new Uri(imgSource));
            Mole.Source = MoleImage;
            Mole.Margin = new Thickness(10, 10, 10, 10) ;
            return Mole;
        }

        void LoadQuestions()
        {
            Questions = new List<Question>();
            string s3 = TestGradinita.Gradinita.dirSource + "mingi.wav";
            System.Media.SoundPlayer soundDescription = new System.Media.SoundPlayer(@s3);

            List<String> images = new List<String>();
            images.Add(TestGradinita.Gradinita.dirSource + "q1-1.jpg");
            images.Add(TestGradinita.Gradinita.dirSource + "q1-2.jpg");
            images.Add(TestGradinita.Gradinita.dirSource + "q1-3.jpg");
            images.Add(TestGradinita.Gradinita.dirSource + "q1-4.jpg");

            String correctImage = TestGradinita.Gradinita.dirSource +"q1-2.jpg";

            Questions.Add(new Question(soundDescription, images, correctImage));
        }

        private void NextQuestion(object state)
        {
            this.Dispatcher.Invoke(() =>
            {
                TTimer.Dispose();
                TestGradinita.Gradinita.timpExpirat.PlaySync();
                this.NavigationService.Navigate(new QuestionPage1());
            });
        }
    }

    public partial class Question
    {
        public System.Media.SoundPlayer SoundDescription { get; }
        public List<String> Images { get; }
        public String CorrectImage { get; }

        public Question(System.Media.SoundPlayer soundDescription, List<String> images, String correctImage)
        {
            SoundDescription = soundDescription;
            Images = images;
            CorrectImage = correctImage;
        }
    }
}