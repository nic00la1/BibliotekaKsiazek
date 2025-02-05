using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BibliotekaKsiazek.MVVM.Model;
using BibliotekaKsiazek.MVVM.View;

namespace BibliotekaKsiazek.MVVM.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private Book _selectedBook;
        private ObservableCollection<Book> _books;
        private ObservableCollection<Book> _filteredBooks;
        private string _searchQuery;

        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
                FilterBooks();
            }
        }

        public ObservableCollection<Book> FilteredBooks
        {
            get => _filteredBooks;
            set
            {
                _filteredBooks = value;
                OnPropertyChanged();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterBooks();
            }
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToDetailCommand { get; }

        public MainPageViewModel()
        {
            Books = new ObservableCollection<Book>
                    {
                        new() { Id=1, Title="Pan Tadeusz", Author="Adam Mickiewicz", Description = "Fajna książka", Price = 24.50, Rate = 4.7, Amount = 20, ImagePath="pan_tadeusz.jpg" },
                        new() { Id=2, Title="Lalka", Author="Bolesław Prus", Description = "Klasyka literatury polskiej", Price = 30.00, Rate = 4.8, Amount = 15, ImagePath="lalka.jpg" },
                        new() { Id=3, Title="Krzyżacy", Author="Henryk Sienkiewicz", Description = "Powieść historyczna", Price = 28.00, Rate = 4.6, Amount = 10, ImagePath="krzyzacy.jpg" },
                        new() { Id=4, Title="Quo Vadis", Author="Henryk Sienkiewicz", Description = "Powieść historyczna", Price = 35.00, Rate = 4.9, Amount = 12, ImagePath="quo_vadis.jpg" },
                        new() { Id=5, Title="Faraon", Author="Bolesław Prus", Description = "Powieść historyczna", Price = 32.00, Rate = 4.5, Amount = 8, ImagePath="faraon.jpg" },
                        new() { Id=6, Title="Potop", Author="Henryk Sienkiewicz", Description = "Powieść historyczna", Price = 40.00, Rate = 4.7, Amount = 5, ImagePath="potop.png" },
                        new() { Id=7, Title="Chłopi", Author="Władysław Reymont", Description = "Powieść społeczna", Price = 25.00, Rate = 4.4, Amount = 18, ImagePath="chlopi.jpg" },
                        new() { Id=8, Title="Zbrodnia i kara", Author="Fiodor Dostojewski", Description = "Powieść psychologiczna", Price = 27.00, Rate = 4.8, Amount = 22, ImagePath="zbrodnia_i_kara.jpg" },
                        new() { Id=9, Title="Mistrz i Małgorzata", Author="Michaił Bułhakow", Description = "Powieść fantastyczna", Price = 29.00, Rate = 4.9, Amount = 14, ImagePath="mistrz_i_malgorzata.jpg" },
                        new() { Id=10, Title="W pustyni i w puszczy", Author="Henryk Sienkiewicz", Description = "Powieść przygodowa", Price = 22.00, Rate = 4.6, Amount = 25, ImagePath="w_pustyni_i_w_puszczy.jpg" }
                    };

            FilteredBooks = new ObservableCollection<Book>(Books);
            SelectedBook = Books[0];

            NavigateToDetailCommand = new Command<Book>(OnNavigateToDetail);
        }

        private void FilterBooks()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredBooks = new ObservableCollection<Book>(Books);
            }
            else
            {
                var lowerCaseQuery = SearchQuery.ToLower();
                FilteredBooks = new ObservableCollection<Book>(
                    Books.Where(book => book.Title.ToLower().Contains(lowerCaseQuery) ||
                                        book.Author.ToLower().Contains(lowerCaseQuery) ||
                                        book.Description.ToLower().Contains(lowerCaseQuery)));
            }
        }

        private async void OnNavigateToDetail(Book book)
        {
            if (book == null)
                return;

            var viewModel = new BookDetailsViewModel(book);
            var detailPage = new BookDetails(viewModel);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
