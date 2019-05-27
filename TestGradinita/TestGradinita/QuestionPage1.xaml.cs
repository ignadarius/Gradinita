using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace TestGradinita
{
    /// <summary>
    /// Interaction logic for QuestionPage1.xaml
    /// </summary>
    public partial class QuestionPage1 : Page
    {
        static string imgSource = "C:/Users/Admin/Desktop/master_an_1_semestru_2/copii/Gradinita/TestGradinita/resources/q1/img";
        static Timer TTimer = null;
        public QuestionPage1()
        {
            InitializeComponent();
            userImage.Source = new BitmapImage(new Uri((TestGradinita.Gradinita.UserImage.Source as BitmapImage).UriSource.AbsolutePath));

            // Timer ----------------
            TTimer = new Timer(
                        new TimerCallback(NextQuestion),
                        null,
                        45000,
                        45000);
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

                if (i == 3) // correct
                {
                    pers.MouseDown += (s, e) =>
                    {
                        TestGradinita.Gradinita.score++;
                        this.NavigationService.Navigate(new QuestionPage());
                    };
                }
                else
                {
                    pers.MouseDown += (s, e) =>
                    {
                        TestGradinita.Gradinita.wrongAnswers++;
                        this.NavigationService.Navigate(new QuestionPage1()); // go to netx question?
                    };
                }
                    
                int a = (i - 1) / 2;
                int b = (i - 1) % 2;
                Grid.SetRow(pers, (i - 1) / 2);
                Grid.SetColumn(pers, (i - 1) % 2);

                grid_s.Children.Add(pers);
            }
        }

        private void NextQuestion(object state)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.NavigationService.Navigate(new QuestionPage());
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
