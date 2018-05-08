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
using MoviesLib.Entities;
using MoviesLib.Services;

namespace Pmdb.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MovieService MovieServiceBeheer = new MovieService();

            ComboCollectieOpvullen();
            MovieServiceBeheer.ImporteerSorteerFilms("SELECT * FROM Movies");
            lstMovies.ItemsSource = MovieService.filmLijst;
            lstMovies.Items.Refresh();

            grdSortOptions.Visibility = Visibility.Hidden;

            SetImage(imgSortBtn, "sort.png");
            SetImage(imgSearchBtn, "search.png");
            SetImage(imgTitleASC, "sort_alpha_ASC.png");
            SetImage(imgYearASC, "sort_num_ASC.png");
            SetImage(imgRatingASC, "sort_num_ASC.png");
            SetImage(imgMetaASC, "sort_num_ASC.png");
            SetImage(imgTitleDESC, "sort_alpha_DESC.png");
            SetImage(imgYearDESC, "sort_num_DESC.png");
            SetImage(imgRatingDESC, "sort_num_DESC.png");
            SetImage(imgMetaDESC, "sort_num_DESC.png");

            imgCover.Source = new BitmapImage(new Uri(@"https://images-na.ssl-images-amazon.com/images/M/MV5BNDcyZmFjY2YtN2I1OC00MzU3LWIzZGEtZDA5N2VlNDJjYWI3L2ltYWdlXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_SX300.jpg"));
        }

        void ComboCollectieOpvullen()
        {
            cmbCollection.Items.Add("All Movies");
            cmbCollection.Items.Add("Favorites");
            cmbCollection.Items.Add("Watched");
            cmbCollection.Items.Add("Unwatched");
            cmbCollection.SelectedIndex = 0;
        }













        void SetImage(Image imageButton, string imageFile)
        {
            imageButton.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/"+imageFile));
        }

        //EVENT HANDLERS


        // Scrollbar in listbox zichtbaar/hidden maken
        private void lstMovies_MouseEnter(object sender, MouseEventArgs e)
        {
            ScrollViewer.SetVerticalScrollBarVisibility(lstMovies, ScrollBarVisibility.Visible);
        }

        private void lstMovies_MouseLeave(object sender, MouseEventArgs e)
        {
            ScrollViewer.SetVerticalScrollBarVisibility(lstMovies, ScrollBarVisibility.Hidden);
        }


        // sorting actions
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MovieService.filmLijst.Any())
            {
                MovieService.filmLijst.Clear();
            }
            MovieService MovieServiceBeheer = new MovieService();
            MovieServiceBeheer.ImporteerSorteerFilms("SELECT * FROM Movies ORDER BY TITLE DESC");
            lstMovies.ItemsSource = MovieService.filmLijst;
            lstMovies.Items.Refresh();
        }



        private void imgSortBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            
            if (grdSortOptions.Visibility == Visibility.Visible)
            {
                SetImage(imgSortBtn, "exit_SEL.png");
            }
            else
            {
                SetImage(imgSortBtn, "sort_selected.png");
            }
            //Mouse.OverrideCursor = Cursors.Hand;
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void imgSortBtn_MouseLeave(object sender, MouseEventArgs e)
        {

            if (grdSortOptions.Visibility == Visibility.Visible)
            {
                SetImage(imgSortBtn, "exit.png");
            }
            else
            {
                SetImage(imgSortBtn, "sort.png");
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void imgSortBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (grdSortOptions.Visibility == Visibility.Visible)
            {
                grdSortOptions.Visibility = Visibility.Hidden;
                SetImage(imgSortBtn, "sort.png");

            }
            else
            {
                grdSortOptions.Visibility = Visibility.Visible;
                SetImage(imgSortBtn, "exit_SEL.png");
            }

        }


        private void imgSearchBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            imgSearchBtn.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/search_selected.png"));
        }

        private void imgSearchBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            imgSearchBtn.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/search.png"));
        }



        private void imgTitleASC_MouseEnter(object sender, MouseEventArgs e)
        {
            //imgTitleASC.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/sort_alpha_ASC_SEL.png"));
            SetImage(imgTitleASC, "sort_alpha_ASC_SEL.png");
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void imgTitleASC_MouseLeave(object sender, MouseEventArgs e)
        {
            //imgTitleASC.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/sort_alpha_ASC.png"));
            SetImage(imgTitleASC, "sort_alpha_ASC.png");
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void imgTitleASC_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void imgTitleDESC_MouseEnter(object sender, MouseEventArgs e)
        {
            imgTitleDESC.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/sort_alpha_DESC_SEL.png"));
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void imgTitleDESC_MouseLeave(object sender, MouseEventArgs e)
        {
            imgTitleDESC.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/sort_alpha_DESC.png"));
            Mouse.OverrideCursor = Cursors.Arrow;

        }

        private void imgTitleDESC_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                grdSortOptions.Visibility = Visibility.Hidden;
                SetImage(imgSortBtn, "sort.png");
            }
        }
    }
}
 