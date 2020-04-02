using LibraryDomain;
using LibraryDomain.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Author> authors
            = new ObservableCollection<Author>();
        public MainWindow()
        {
            InitializeComponent();
            authorsDataGrid.DataContext = authors;
            using (LibraryContext db = new LibraryContext())
            {
                db.Authors.ToList().ForEach(
                    a => {
                        Console.WriteLine(a.FirstName + " " + a.LastName);
                        authors.Add(a);
                    }
                );
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (LibraryContext db = new LibraryContext())
            {
                Author author =
                    db.Authors.Add(
                        new Author() { FirstName = firstName.Text, LastName = lastName.Text }
                    );
                db.SaveChanges();
                authors.Add(author);
            }
        }
    }
}
