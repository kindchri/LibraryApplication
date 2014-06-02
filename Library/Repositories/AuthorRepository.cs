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
    /// The AuthorRepository class
    /// </summary>
    public class AuthorRepository : IRepository<Author, int>
    {
        private LibraryContext _context;

        /// <summary>
        /// The constructor of the class taking a Library context to set as the context.
        /// </summary>
        /// <param name="context">LibraryContext to set as the context</param>
        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The add method to add a new Author to the context.
        /// </summary>
        /// <param name="item">Author to add</param>
        public void Add(Author item)
        {
            _context.Authors.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// The All method, returning an enumerable of all authors in the database
        /// </summary>
        /// <returns>Enumerable presentation of all Authors in the database</returns>
        public IEnumerable<Author> All()
        {
            return _context.Authors;
        }

        /// <summary>
        /// The find method, used to check if an author exists in the database
        /// </summary>
        /// <param name="id">Id to search for</param>
        /// <returns>The author that was searched for</returns>
        public Author Find(int id)
        {
            var theAuthor = _context.Authors.Where(a => a.Id == id).First();
            return theAuthor;
        }

        /// <summary>
        /// The remove method, used to remove an author from the database
        /// </summary>
        /// <param name="item">Author to remove</param>
        public void Remove(Author item)
        {
            if (_context.Authors.Find(item.Id) != null)
            {
                _context.Authors.Remove(item);
            }
        }

        /// <summary>
        /// The edit method, used to edit an existing author in the database
        /// </summary>
        /// <param name="item">Author to edit</param>
        public void Edit(Author item)
        {
            Author oldAuthor = _context.Authors.Find(item.Id);
            oldAuthor = item;
            _context.SaveChanges();
        }
    }
}
