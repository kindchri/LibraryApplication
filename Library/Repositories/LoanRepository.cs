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
    /// The LoanRepository class, containing CURD-opperations for loans.
    /// </summary>
    public class LoanRepository : IRepository<Loan, int>
    {
        LibraryContext _context;

        /// <summary>
        /// The Constructor for the LoanRepository class, setting the context to input context.
        /// </summary>
        /// <param name="context">LibraryContext to set as Context</param>
        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The add method, adds a Loan item to the database
        /// </summary>
        /// <param name="item">Loan to add in the database</param>
        public void Add(Loan item)
        {
            _context.BookLoans.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// The remove method that removes a loan from the database if it is currently in the database
        /// </summary>
        /// <param name="item">ITem to find and remove</param>
        public void Remove(Loan item)
        {
            if (_context.BookLoans.Contains(item))
            {
                _context.BookLoans.Remove(item);
            }
        }

        /// <summary>
        /// The find method that searches for a specific loan in the database
        /// </summary>
        /// <param name="id">LoanID to searchfor</param>
        /// <returns>The loan if it is found.</returns>
        public Loan Find(int id)
        {
            var loantoFind = _context.BookLoans.Where(l => l.Id == id);
            return loantoFind.First();
        }

        /// <summary>
        /// The Edit method, edits an existing Loan in the database
        /// </summary>
        /// <param name="item">The loan to inject instead of the old loan</param>
        public void Edit(Loan item)
        {
            Loan oldLoan = _context.BookLoans.Find(item.Id);
            oldLoan = item;
            _context.SaveChanges();
        }

        /// <summary>
        /// The All method, used to get all loans in the database.
        /// </summary>
        /// <returns>an Enumerable of all Loans in the database.</returns>
        public IEnumerable<Loan> All()
        {
            return _context.BookLoans;
        }
    }
}