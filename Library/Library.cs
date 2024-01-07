using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace LibraryOOP.Library
{
    class Library
    {
        private ICollection<Book> _books;
        public Library()
        {
            _books = new List<Book>();
            _books.Add(new Book(new Author("Author 1", "10/01/1990"), "Title 1", "Cat 1"));
            _books.Add(new Book(new Author("Author 2", "10/02/1990"), "Title 2", "Cat 2"));
            _books.Add(new Book(new Author("Author 3", "10/03/1990"), "Title 3", "Cat 3"));
            _books.Add(new Book(new Author("Author 4", "10/04/1990"), "Title 4", "Cat 4"));
            _books.Add(new Book(new Author("Author 5", "10/05/1990"), "Title 5", "Cat 5"));
            _books.Add(new Book(new Author("Author 6", "10/06/1990"), "Title 6", "Cat 6"));
            _books.Add(new Book(new Author("Author 7", "10/07/1990"), "Title 7", "Cat 7"));
            _books.Add(new Book(new Author("Author 8", "10/08/1990"), "Title 8", "Cat 8"));
            _books.Add(new Book(new Author("Author 9", "10/09/1990"), "Title 9", "Cat 9"));
            _books.Add(new Book(new Author("Author 10", "10/10/1990"), "Title 10", "Cat 10"));
        }

        public void AddBook(Book bookToAdd) 
        {
            _books.Add(bookToAdd);
        }

        public bool CheckIfBookIsAvailable(string title) 
        {
            Book bookToBorrow = _books.FirstOrDefault(b => b.Title().ToLower() == title.ToLower() && b.IsAvailable()); 

            if(bookToBorrow is null) 
            {
                return false;
            }

            return true;
        }

        public bool CheckIfUniqueIdIsAvailable(string uniqueID) 
        {
            Book bookToReturn = _books.FirstOrDefault(b => b.UniqueID().ToString() == uniqueID);

            if(bookToReturn is null)
            {
                return false;
            }

            return true;
        }

        public bool BorrowBook(string title) 
        {
            Book bookToBorrow = _books.FirstOrDefault(b => b.Title().ToLower() == title.ToLower() && b.IsAvailable());

            if(bookToBorrow is not null) 
            {
                // bookToBorrow
                bookToBorrow.GiveOutBook();
                return true;
            }
            return false;
        }

        public bool ReturnBook(string uniqueID) 
        {
            Book bookToReturn = _books.FirstOrDefault(b => b.UniqueID().ToString() == uniqueID);

            if(bookToReturn is not null)
            {
                bookToReturn.ReturnToShelf();
            }

            return false;
        }
    }
}