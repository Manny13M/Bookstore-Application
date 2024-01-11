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

//*** Must Add Type Entry Verification And Other Details
//*** Majority of code is finished

namespace Martinez_991673846__Midterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> bookArr = new List<Book>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsertBook_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtBookISBN.Text, out int isbn ) && double.TryParse(txtBookPrice.Text, out double price)
                    && !string.IsNullOrEmpty(cmbGenres.Text) && !string.IsNullOrEmpty(txtBookTitle.Text))
            {
                bool isbnRepeated = false;
                foreach (Book book in bookArr)
                {
                    if (book.ISBN == isbn)
                    {
                        isbnRepeated = true;
                        break;
                    }
                }

                if (!isbnRepeated)
                {
                    Book book = new Book(txtBookTitle.Text, cmbGenres.Text, isbn, price);
                    bookArr.Add(book);

                    txtBookTitle.Text = "";
                    cmbGenres.Text = "";
                    txtBookISBN.Text = "";
                    txtBookPrice.Text = "";

                    MessageBox.Show("Book Added Successfully!");
                }
                else 
                {
                    MessageBox.Show("Error occured.\nISBN number already exists, please choose a different one.");
                }
            }
            else
            {
                MessageBox.Show("Error occured.\nPlease make sure the following requirements are met:\n\nISBN number is not repeated and of type Integer.\nPrice is a number value. \nAll four field are filed in.");
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridBooks.ItemsSource = null;
            dataGridBooks.ItemsSource = bookArr;
        }

        private void btnSearchBookGenre_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSearchGenres.Text)) 
            {
                lstBooks.Items.Clear();
                bool bookFound = false;
                foreach (Book book in bookArr)
                {
                    if (book.Genre == cmbSearchGenres.Text)
                    {
                        lstBooks.Items.Add($"Title: {book.Title} -- Genre: {book.Genre} -- ISBN: {book.ISBN} -- Price: ${book.Price}");
                        bookFound = true;
                    }
                }

                if (!bookFound) 
                {
                    MessageBox.Show("Sorry, no books for that genre were found.");
                }
            }
            else 
            {
                MessageBox.Show("Please select a genre before search.");
            }
        }

        private void btnEditBook_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtEditFuncBookISBN.Text, out int isbn) && double.TryParse(txtNewBookPrice.Text, out double price)) 
            {
                bool bookFound = false;
                foreach (Book book in bookArr)
                {
                    if (book.ISBN == isbn)
                    {
                        book.Price = price;
                        MessageBox.Show("Book updated!");
                        bookFound = true;
                        txtEditFuncBookISBN.Text = "";
                        txtNewBookPrice.Text = "";
                    }
                }

                if (!bookFound)
                {
                    MessageBox.Show("Book not found");
                }
            }
            else 
            {
                MessageBox.Show("Error occured.\nPlease make sure the following requirements are met:\n\nISBN number is of type Integer.\nPrice is a number value. \nBoth fields are filed in.");
            }
            
        }

        private void btnQuitApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBackToLanding_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow landingWindow = new LoginWindow();
            landingWindow.Show();
            Close();
        }
    }
}
