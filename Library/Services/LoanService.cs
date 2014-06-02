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
    /// The LoanService class, containing all opperations to be made with Loans
    /// </summary>
    public class LoanService : IService<Loan>
    {       
        LoanRepository loanRepo;
        MemberRepository memberRepo;
        BookCopyRepository bookCopyRepo;

        public event EventHandler Updated;

        /// <summary>
        /// The OnUpdated method, checks if the eventhandler isn't null and runs it
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
        /// The contructor of the LoanService class, setting the different repositories and the Eventhandler
        /// </summary>
        /// <param name="updated">Eventhandler</param>
        /// <param name="repo">LoanRepository</param>
        /// <param name="repo2">BookCopyRepository</param>
        /// <param name="repo3">MemberRepository</param>
        /// <param name="repo5">BookRepository</param>
        public LoanService(LoanRepository repo, MemberRepository repo2, BookCopyRepository repo3)
        {         
            loanRepo = repo;
            memberRepo = repo2;
            bookCopyRepo = repo3;
        }

      



        /// <summary>
        /// The add method, used to make a Loan
        /// </summary>
        /// <param name="item">Loan to make</param>
        public void Add(Loan item)
        {
            

                    //item.BookCopy.IsLoaned = true;
                    //bookCopyRepo.Edit(item.BookCopy);

                    loanRepo.Add(item);
                    item.Member.Loans.Add(item);

                    OnUpdated(EventArgs.Empty);
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        throw new NoMemberFoundException();
            //    }
            //}
            //catch (InvalidOperationException)
            //{
            //    throw new NoCopyAvailableException();
            //}
        }

        /// <summary>
        /// The Remove method, used to return a loan.
        /// </summary>
        /// <param name="item">Loan to return</param>
        public void Remove(Loan item)
        {
            var bookCopy = bookCopyRepo.All().Where(bc => bc.IsLoaned == true && bc.Id == item.BookCopy.Id).First();
            item.Returned = DateTime.Today;
            bookCopy.IsLoaned = false;
            loanRepo.Edit(item);
            var member = memberRepo.All().Where(m => m == item.Member).First();
            member.Loans.Remove(item);
            memberRepo.Edit(member);

            OnUpdated(EventArgs.Empty);
        }
        /// <summary>
        /// Edit method for loans
        /// </summary>
        /// <param name="item">loan to edit</param>
        public void Edit(Loan item)
        {
            var loantoedit = loanRepo.Find(item.Id);
            loanRepo.Edit(loantoedit);
        }
        /// <summary>
        /// The Find method, searches for a loan by ID
        /// </summary>
        /// <param name="id">ID to search for</param>
        /// <returns>The loan if found</returns>
        public Loan Find(int id)
        {
           return loanRepo.Find(id);
        }

        /// <summary>
        /// The customSearch class, used to search for the first loan with a specific booktitle.
        /// </summary>
        /// <param name="searchItem">Booktitle</param>
        /// <returns>The loan if found.</returns>
        public Loan CustomSearch(string searchItem)
        {
            if (loanRepo.All().Where(l => l.BookCopy.Book.Title == searchItem) != null)
            {
                return loanRepo.All().Where(l => l.BookCopy.Book.Title == searchItem).First();
            }
            else
            {
                throw new InputNotFoundException();
            }
        }

        /// <summary>
        /// The All method, used to return all Loans in the database
        /// </summary>
        /// <returns>IEnumerable of all Loans</returns>
        public IEnumerable<Loan> All()
        {
            return loanRepo.All();
        }
    }
}
