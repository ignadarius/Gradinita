using System;
using System.Threading;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        static string imgSource = "D:/Master-Guran/Gradinita/TestGradinita/resources/p";

        public Login()
        {
            InitializeComponent();

            Loaded += ComponentLoaded;
            ColumnDefinition gridCol1 = new ColumnDefinition();

            ColumnDefinition gridCol2 = new ColumnDefinition();

            ColumnDefinition gridCol3 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(gridCol1);

            grid.ColumnDefinitions.Add(gridCol2);

            grid.ColumnDefinitions.Add(gridCol3);



            // Create Rows

            RowDefinition gridRow1 = new RowDefinition();

            gridRow1.Height = new GridLength(210);

            RowDefinition gridRow2 = new RowDefinition();

            gridRow2.Height = new GridLength(210);

            RowDefinition gridRow3 = new RowDefinition();   

            gridRow3.Height = new GridLength(210);

            grid.RowDefinitions.Add(gridRow1);

            grid.RowDefinitions.Add(gridRow2);

            grid.RowDefinitions.Add(gridRow3);
            LoadCharacters();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\Master-Guran\Gradinita\TestGradinita\resources\alegePersonaj.wav");
            player.Play();
        }

        private void ComponentLoaded(object sender,RoutedEventArgs e)
        {
        
        }



        public void LoadCharacters()
        {
            for(int i=1;i<9;++i)
            {
                Image pers = CreateImage(i);

                pers.MouseDown += (s, e) =>
                {
                    TestGradinita.Gradinita.UserImage = s as Image;
                    this.NavigationService.Navigate(new QuestionPage());
                    
                };
                Grid.SetRow(pers, (i -1) / 3);
                Grid.SetColumn(pers, (i -1) % 3);

                grid.Children.Add(pers);
            }
        }

        private Image CreateImage(int Id)
        {
            Image Mole = new Image();
            Mole.Width = 200;
            Mole.Height = 200;
            ImageSource MoleImage = new BitmapImage(new Uri(imgSource+Id.ToString()+".jpg"));
            Mole.Source = MoleImage;
            return Mole;
        }
    }
}
