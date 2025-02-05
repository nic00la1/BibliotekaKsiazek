using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaKsiazek.MVVM.Model;

namespace BibliotekaKsiazek.MVVM.ViewModel
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel()
        {

        }
        public Book SelectedBook { get; set; }

        public BookDetailsViewModel(Book selectedBook)
        {
            SelectedBook = selectedBook;
        }
    }
}
