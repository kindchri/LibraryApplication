///Version 1.0
///Written by Tobias Keijser and Christoffer Kindesjö
/// 2013-10-31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Models;

namespace Library.Repositories
{
    /// <summary>
    /// The Bookcopy Repository class
    /// </summary>
    public class BookCopyRepository : IRepository<BookCopy, int>
    {
        LibraryContext _context;

        /// <summary>
        /// The constructor of the BookCopy Repository, setting the context.
        /// </summary>
        /// <param name="context">LibraryContext to use as context</param>
        public BookCopyRepository(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The add method, adding a bookcopy to the database
        /// </summary>
        /// <param name="item">BookCopy to add</param>
        public void Add(BookCopy item)
        {
            _context.BookCopies.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// The remove method, removing an existing bookcopy from the database
        /// </summary>
        /// <param name="item">BookCopy to remove</param>
        public void Remove(BookCopy item)
        {
            if (_context.BookCopies.Find(item.Id) != null)
            {
                _context.BookCopies.Remove(item);
            }
        }

        /// <summary>
        /// The find method, used to find a specific bookcopy in the database
        /// </summary>
        /// <param name="id">Id of the bookcopy to find</param>
        /// <returns>The bookcopy searched for if it exists</returns>
        public BookCopy Find(int id)
        {
            var booktoFind = _context.BookCopies.Where(c => c.Id == id);
            return booktoFind.First();
        }

        /// <summary>
        /// The edit method, used to edit an existing BookCopy in the database
        /// </summary>
        /// <param name="item">Updated item</param>
        public void Edit(BookCopy item)
        {
            BookCopy oldCopy = _context.BookCopies.Find(item.Id);
            oldCopy = item;
            _context.SaveChanges();
        }

        /// <summary>
        /// The all method, returning an enumerable of all BookCopies.
        /// </summary>
        /// <returns>An enumerable representation of all BookCopies in the Database</returns>
        public IEnumerable<BookCopy> All()
        {
            return _context.BookCopies;
        }
    }
}