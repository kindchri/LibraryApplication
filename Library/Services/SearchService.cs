///Version 1.1
///Written by Tobias Keijser and Christoffer Kindesjö
/// 2013-11-09
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Repositories;
using Library.Models;
using Library.Helpers;

namespace Library.Services
{
    public class SearchService
    {
        LoanRepository loanRepo;

        /// <summary>
        /// Constructor for searchservice
        /// </summary>
        /// <param name="repo">loanrepo</param>
        public SearchService(LoanRepository repo)
        {
            loanRepo = repo;
        }

        /// <summary>
        /// Method that returns active loans
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Loan> CheckActiveLoans()
        {
            var activeLoans = loanRepo.All().Where(l => l.Returned == null);
            return activeLoans;
        }

        /// <summary>
        /// Method that returns loans that are overdue
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Loan> CheckLoansOverdue()
        {
            var loansOverDue = loanRepo.All().Where(l => l.ToReturn < DateTime.Today.Date && l.Returned == null);
            return loansOverDue;
        }

        /// <summary>
        /// Method that returns loans overdue for spec members
        /// </summary>
        /// <param name="memberssn"></param>
        /// <returns></returns>
        public IEnumerable<Loan> CheckMemberLoansOverdue(string memberssn)
        {
            var loansOverDue = CheckLoansOverdue().Where(l => l.Member.SocialSecurityNr == memberssn);
            return loansOverDue;
        }

        /// <summary>
        /// Returns active loans for spec members
        /// </summary>
        /// <param name="membernumber"></param>
        /// <returns></returns>
        public IEnumerable<Loan> CheckMemberActiveLoans(string membernumber)
        {
            var loans = CheckActiveLoans().Where(i => i.Member.SocialSecurityNr == membernumber);
            return loans;
        }
    }
}
