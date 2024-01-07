using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryOOP.Library
{
    class Book
    {
        private Guid _uniqueID { get; set; } 
        private string _title { get; set; } 
        private string _category { get; set; }
        private Author _author { get; set; } 
        private bool _isAvailable { get; set; } 
        private DateTime _borrowDate { get; set; } 
        private DateTime _returnDate { get; set; }

        public Guid UniqueID()
        {
            return _uniqueID;
        }
        public string Title() 
        {
            return _title;
        }

        public bool IsAvailable()
        {
            return _isAvailable;
        }

        public void GiveOutBook()
        {
            _borrowDate = DateTime.UtcNow;
            _isAvailable = false;
        }

        public void ReturnToShelf()
        {
            _returnDate = DateTime.UtcNow;
            _isAvailable = true;
        }
       public Book(Author author, string title, string category)
       {
            _author = author;
            _title = title;
            _category = category;
            _isAvailable = true;
            _uniqueID = Guid.NewGuid();
       }
    }

    
}