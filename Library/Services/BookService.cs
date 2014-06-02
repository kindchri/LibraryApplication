///Version 1.1
///Written by Tobias Keijser and Christoffer Kindesjö
/// 2013-11-09
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Models;
using Library.Repositories;
using Library.Helpers;

namespace Library.Services
{
    /// <summary>
    /// The BookService class, containing all opperations to be made with books.
    /// </summary>
    public class BookService : IService<Book>
    {
        private BookRepository bookRepo;

        public event EventHandler Updated;

        /// <summary>
        /// The OnUpdated method, that checks if the eventhandler is null, if not it runs it.
        /// </summary>
        /// <param name="e">Event trigger.</param>
        protected virtual void OnUpdated(EventArgs e)
        {
            EventHandler updateHandler = Updated;
            if (updateHandler != null)
            {
                updateHandler(this, e);
            }
        }

        /// <summary>
        /// The contructor for the BookService class, setting the eventhandler and BookRepository
        /// </summary>
        /// <param name="updated">Eventhandler</param>
        /// <param name="repo5">BookRepository</param>
        public BookService(BookRepository repo)
        {
            bookRepo = repo;
        }

        /// <summary>
        /// The add method, used to add a book to the database
        /// </summary>
        /// <param name="item">Book to add</param>
        public void Add(Book item)
        {
            bookRepo.Add(item);
            OnUpdated(EventArgs.Empty);
        }

        /// <summary>
        /// The remove method, removes a book from the Database
        /// </summary>
        /// <param name="item">Book to remove</param>
        public void Remove(Book item)
        {
            bookRepo.Remove(item);
            OnUpdated(EventArgs.Empty);
        }
        /// <summary>
        /// Method to edit a book
        /// </summary>
        /// <param name="item">book to edit</param>
        public void Edit(Book item)
        {
            var booktoedit = bookRepo.Find(item.Id);
            bookRepo.Edit(booktoedit);
        }

        /// <summary>
        /// The find method, used to find a book in the Ddatabase
        /// </summary>
        /// <param name="item">ID to search for</param>
        /// <returns>The book if it is found in the DB.</returns>
        public Book Find(int id)
        {
            return bookRepo.Find(id);
        }

        /// <summary>
        /// the customSearch method, used to find a book based on its ISBN.
        /// </summary>
        /// <param name="searchItem">ISBN</param>
        /// <returns>Book with the ISBN if it exists</returns>
        public Book CustomSearch(string searchItem)
        {
            if (bookRepo.All().Where(b => b.Isbn == searchItem) != null)
            {
                return bookRepo.All().Where(b => b.Isbn == searchItem).First();
            }
            else
            {
                throw new InputNotFoundException();
            }
        }

        /// <summary>
        /// The All method, used to get all books in the database
        /// </summary>
        /// <returns>IEnumerable of all books in the dataase</returns>
        public IEnumerable<Book> All()
        {
            return bookRepo.All();
        }
    }
}
