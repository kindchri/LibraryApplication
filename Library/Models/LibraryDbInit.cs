///Version 1.0
///Written by Tobias Keijser and Christoffer Kindesjö
/// 2013-10-31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Library.Repositories;

namespace Library.Models
{
    /// <summary>
    /// Derived database strategy
    /// </summary>
    class LibraryDbInit : DropCreateDatabaseAlways<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            base.Seed(context);

            // seeding data goes here..
            CsvParser parser = new CsvParser();
            parser.ParseCsv();

            foreach (Author author in parser.GetAuthors())
            {
                context.Authors.Add(author);
            }
            context.SaveChanges();

            foreach (Book book in parser.GetBooks())
            {
                context.Books.Add(book);
            }
            context.SaveChanges();

            foreach (Book b in context.Books)
            {
                context.Authors.Where(a => a.Id == b.Author.Id).First().Books.Add(b);
            }
            context.SaveChanges();

            foreach (Book b in context.Books)
            {
                Random rdm = new Random();
                int random = rdm.Next(1,4);
                for (int i = 0; i < random ; i++)
                {
                    context.BookCopies.Add(new BookCopy { Book = b });
                }
            }
            foreach (BookCopy bc in context.BookCopies)
            {
                context.Books.Where(b => b.Id == bc.Book.Id).First().Copies.Add(bc);
            }

            context.Members.Add(new Member {Name = "Admin", SocialSecurityNr = "000000-0000"});

            context.SaveChanges();
        }
    }
}
