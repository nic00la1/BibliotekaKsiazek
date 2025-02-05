using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaKsiazek.MVVM.ViewModel;

namespace BibliotekaKsiazek.MVVM.View;

public partial class BookDetails : ContentPage
{
    public BookDetails(BookDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}