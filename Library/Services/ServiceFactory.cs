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
    /// Factory for services
    /// </summary>
    public class ServiceFactory
    {
        RepositoryFactory repoFactory = new RepositoryFactory();
        BookCopyRepository bookCopyRepo;
        BookRepository bookRepo;
        AuthorRepository authorRepo;
        LoanRepository loanRepo;
        MemberRepository memberRepo;

        /// <summary>
        /// Constructor for servicefactory
        /// </summary>
        public ServiceFactory()
        {
            bookCopyRepo = repoFactory.GetBookCopyrepository();
            bookRepo = repoFactory.GetBookRepository();
            authorRepo = repoFactory.GetAuthorRepository();
            loanRepo = repoFactory.GetLoanRepository();
            memberRepo = repoFactory.GetMemberRepository();
        }

        /// <summary>
        /// Returns bookservice
        /// </summary>
        /// <returns></returns>
        public BookService GetBookService()
        {
            return new BookService(bookRepo);
        }

        /// <summary>
        /// Returns loanservice
        /// </summary>
        /// <returns></returns>
        public LoanService GetLoanService()
        {
            return new LoanService(loanRepo, memberRepo,bookCopyRepo);
        }

        /// <summary>
        /// Returns memberservice
        /// </summary>
        /// <returns></returns>
        public MemberService GetMemberService()
        {
            return new MemberService(memberRepo);
        }

        /// <summary>
        /// returns bookcopyservice
        /// </summary>
        /// <returns></returns>
        public BookCopyService GetBookCopyService()
        {
            return new BookCopyService(bookCopyRepo);
        }

        /// <summary>
        /// returns authorservice
        /// </summary>
        /// <returns></returns>
        public AuthorService GetAuthorService()
        {
            return new AuthorService(authorRepo);
        }

        /// <summary>
        /// returns searchservice
        /// </summary>
        /// <returns></returns>
        public SearchService GetSearchService()
        {
            return new SearchService(loanRepo);
        }
    }
}
