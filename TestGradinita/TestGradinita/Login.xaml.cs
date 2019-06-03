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
        static string imgSource = TestGradinita.Gradinita.dirSource + "p";

        public Login()
        {
            InitializeComponent();

            Loaded += ComponentLoaded;
            ColumnDefinition gridCol1 = new ColumnDefinition();

            ColumnDefinition gridCol2 = new ColumnDefinition();

            ColumnDefinition gridCol3 = new ColumnDefinition();
            ColumnDefinition gridCol4 = new ColumnDefinition();
            ColumnDefinition gridCol5 = new ColumnDefinition();



            grid.ColumnDefinitions.Add(gridCol1);

            grid.ColumnDefinitions.Add(gridCol2);

            grid.ColumnDefinitions.Add(gridCol3);
            grid.ColumnDefinitions.Add(gridCol4);
            grid.ColumnDefinitions.Add(gridCol5);



            // Create Rows

            RowDefinition gridRow1 = new RowDefinition();

            gridRow1.Height = new GridLength(120);

            RowDefinition gridRow2 = new RowDefinition();

            gridRow2.Height = new GridLength(120);

            RowDefinition gridRow3 = new RowDefinition();   

            gridRow3.Height = new GridLength(120);

            RowDefinition gridRow4 = new RowDefinition();

            gridRow4.Height = new GridLength(120);

            RowDefinition gridRow5 = new RowDefinition();

            gridRow5.Height = new GridLength(120);

            RowDefinition gridRow6 = new RowDefinition();

            gridRow6.Height = new GridLength(120);

            grid.RowDefinitions.Add(gridRow1);

            grid.RowDefinitions.Add(gridRow2);

            grid.RowDefinitions.Add(gridRow3);
            grid.RowDefinitions.Add(gridRow4);
            grid.RowDefinitions.Add(gridRow5);
            grid.RowDefinitions.Add(gridRow6);

            LoadCharacters();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(TestGradinita.Gradinita.dirSource+"/alegePersonaj.wav");
            player.Play();

            // initialize score
            TestGradinita.Gradinita.score = 0;
        }

        private void ComponentLoaded(object sender,RoutedEventArgs e)
        {
        
        }



        public void LoadCharacters()
        {
            int i = 1;
            foreach (KeyValuePair<string, User> entry in Gradinita.users)
            {
                if (entry.Value.IsTested)
                {
                    ++i;
                    continue;
                }
                Image pers = CreateImage(entry.Value.ImgSource);
                
                pers.MouseDown += (s, e) =>
                {
                    Image img = s as Image;

                    Gradinita.currentUser = Gradinita.users[(img.Source as BitmapImage).UriSource.AbsolutePath];
                    Gradinita.currentUser.IsTested = true;
                    this.NavigationService.Navigate(new Introducere());
                };
                Grid.SetRow(pers, (i -1) / 5);
                Grid.SetColumn(pers, (i -1) % 5);
                ++i;

                grid.Children.Add(pers);
            }
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
    }
}
