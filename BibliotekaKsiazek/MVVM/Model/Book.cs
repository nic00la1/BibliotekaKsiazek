using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKsiazek.MVVM.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Rate { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string ImagePath { get; set; }
    }
}
