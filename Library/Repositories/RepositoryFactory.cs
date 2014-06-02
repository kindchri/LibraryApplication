using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Models;

namespace Library.Repositories
{
    /// <summary>
    /// A factory that handles instantiation of repository objects.
    /// </summary>
    class RepositoryFactory 
    {

        LibraryContext _context;

        public RepositoryFactory() {
            _context = ContextSingelton.GetContext();
        }

        public BookRepository GetBookRepository()
        {
            return new BookRepository(_context);
        }

        public AuthorRepository GetAuthorRepository()
        {
            return new AuthorRepository(_context);
        }

        public BookCopyRepository GetBookCopyrepository()
        {
            return new BookCopyRepository(_context);
        }

        public LoanRepository GetLoanRepository()
        {
            return new LoanRepository(_context);
        }

        public MemberRepository GetMemberRepository()
        {
            return new MemberRepository(_context);
        }

        
        // add factory methods for your repositories here..

    }
}
