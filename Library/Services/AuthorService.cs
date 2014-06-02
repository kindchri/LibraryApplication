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
    /// The authorService class containing the opperations to be made with authors.
    /// </summary>
    public class AuthorService : IService<Author>
    {
        private AuthorRepository authorRepo;
        
        public event EventHandler Updated;

        /// <summary>
        /// OnUpdated, runs the eventhandler if the eventhandler aint null.
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
        /// The construct for the AuthorService class, defines the EventHandler and AuthorRepo.
        /// </summary>
        /// <param name="updated">Eventhandler</param>
        /// <param name="repo4">AuthorRepository</param>
        public AuthorService(AuthorRepository repo)
        {
            authorRepo = repo;
        }

        /// <summary>
        /// The Add method, used to add an author to the database
        /// </summary>
        /// <param name="item">Author to add.</param>
        public void Add(Author item)
        {
            authorRepo.Add(item);
            OnUpdated(EventArgs.Empty);
        }

        /// <summary>
        /// The Remove method, required by the interface but not implemented due to not being a requirement of the project work.
        /// </summary>
        /// <param name="item">Item to find and remove</param>
        public void Remove(Author item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Method to edit author
        /// </summary>
        /// <param name="item">author to edit</param>
        public void Edit(Author item)
        {
            var authortoedit = authorRepo.Find(item.Id);
            authorRepo.Edit(authortoedit);
        }
        /// <summary>
        /// The find method, used to find a specific author in the database
        /// </summary>
        /// <param name="item">Author to find</param>
        /// <returns>The Author if it is found</returns>
        public Author Find(int id)
        {
            return authorRepo.Find(id);
        }

        /// <summary>
        /// Searches for an author by the authorname
        /// </summary>
        /// <param name="searchItem">Authorname to search for</param>
        /// <returns>The author with the given name.</returns>
        public Author CustomSearch(string searchItem)
        {
            if (authorRepo.All().Where(a => a.Name == searchItem).First() != null)
            {
                return authorRepo.All().Where(a => a.Name == searchItem).First();
            }
            else
            {
                throw new InputNotFoundException();
            }
        }

        /// <summary>
        /// The all method, returns all Authors in the database.
        /// </summary>
        /// <returns>Enumerable of all Authors in the Database.</returns>
        public IEnumerable<Author> All()
        {
            return authorRepo.All();
        }
    }
}
