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
    /// The BookCopyService Class, containing the opperations to be made with authors
    /// </summary>
    public class BookCopyService : IService<BookCopy>
    {
        private BookCopyRepository bookCopyRepo;
        
        public event EventHandler Updated;

        /// <summary>
        /// The OnUpdated method, if the eventhandler isn't null it runs the eventhandler
        /// </summary>
        /// <param name="e">Event trigger</param>
        protected virtual void OnUpdated(EventArgs e)
        {
            EventHandler updateHandler = Updated;
            if (updateHandler != null)
            {
                updateHandler(this, e);
            }
        }

        /// <summary>
        /// The construct of the BookCopyService class, defining the BookCopyRepository and Eventhandler
        /// </summary>
        /// <param name="updated">Eventhandler</param>
        /// <param name="repo2">BookCopyRepository</param>
        public BookCopyService(BookCopyRepository repo)
        {
            bookCopyRepo = repo;
        }

        /// <summary>
        /// The add method. Adds a bookcopy to the database 
        /// </summary>
        /// <param name="item">BookCopy to Add</param>
        public void Add(BookCopy item)
        {
            bookCopyRepo.Add(item);
            OnUpdated(EventArgs.Empty);
        }

        /// <summary>
        /// The remove method, removes a bookcopy.
        /// </summary>
        /// <param name="item">BookCopy to remove</param>
        public void Remove(BookCopy item)
        {
            var copytoremove = bookCopyRepo.Find(item.Id);
            bookCopyRepo.Remove(copytoremove);

            OnUpdated(EventArgs.Empty);
        }
        /// <summary>
        /// The Edit method, used to edit items in the database
        /// </summary>
        /// <param name="item">The bookcopy</param>
        public void Edit(BookCopy item)
        {
            var copytoedit = bookCopyRepo.Find(item.Id);
            bookCopyRepo.Edit(copytoedit);
        }
        /// <summary>
        /// The Find method, used to find a specific bookcopy in the Database
        /// </summary>
        /// <param name="item">BookCopy to find</param>
        /// <returns>The bookcopy, if found.</returns>
        public BookCopy Find(int id)
        {
            return bookCopyRepo.Find(id);
        }

        /// <summary>
        /// The cstomSearch method, searches for the first avalible bookcopy of a bookID
        /// </summary>
        /// <param name="searchItem">BookID to search for copies with</param>
        /// <returns>First avalible copy of the book with the bookID</returns>
        public BookCopy CustomSearch(string searchItem)
        {
            int id = Convert.ToInt16(searchItem);
            var bookcopy = bookCopyRepo.All().Where(b => b.Book.Id == id).First();
            return bookcopy;
        }
      
        /// <summary>
        /// The All method, returning all bookcopies in the database
        /// </summary>
        /// <returns>IEnumerable with allbookcopies in the database</returns>
        public IEnumerable<BookCopy> All()
        {
            return bookCopyRepo.All();
        }
    }
}
