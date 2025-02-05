using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BibliotekaKsiazek.MVVM.Model;

namespace BibliotekaKsiazek.MVVM.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private Book _selectedBook;
        public ObservableCollection<Book> Books;

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(Book));
            }
        }

        public MainPageViewModel()
        {
            Books = new ObservableCollection<Book>()
            {
                new() { Id=1, Title="Pan Tadeusz", Author="Adam Mickiewicz", Description = "Fajna książka", Price = 24.50, Rate = 4.7, Amount = 20 },
                new() { Id=2, Title="Lalka", Author="Bolesław Prus", Description = "Klasyka literatury polskiej", Price = 30.00, Rate = 4.8, Amount = 15 },
                new() { Id=3, Title="Krzyżacy", Author="Henryk Sienkiewicz", Description = "Powieść historyczna", Price = 28.00, Rate = 4.6, Amount = 10 },
                new() { Id=4, Title="Quo Vadis", Author="Henryk Sienkiewicz", Description = "Powieść historyczna", Price = 35.00, Rate = 4.9, Amount = 12 },
                new() { Id=5, Title="Faraon", Author="Bolesław Prus", Description = "Powieść historyczna", Price = 32.00, Rate = 4.5, Amount = 8 },
                new() { Id=6, Title="Potop", Author="Henryk Sienkiewicz", Description = "Powieść historyczna", Price = 40.00, Rate = 4.7, Amount = 5 },
                new() { Id=7, Title="Chłopi", Author="Władysław Reymont", Description = "Powieść społeczna", Price = 25.00, Rate = 4.4, Amount = 18 },
                new() { Id=8, Title="Zbrodnia i kara", Author="Fiodor Dostojewski", Description = "Powieść psychologiczna", Price = 27.00, Rate = 4.8, Amount = 22 },
                new() { Id=9, Title="Mistrz i Małgorzata", Author="Michaił Bułhakow", Description = "Powieść fantastyczna", Price = 29.00, Rate = 4.9, Amount = 14 },
                new() { Id=10, Title="W pustyni i w puszczy", Author="Henryk Sienkiewicz", Description = "Powieść przygodowa", Price = 22.00, Rate = 4.6, Amount = 25 }
            };

            SelectedBook = Books[0];
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
