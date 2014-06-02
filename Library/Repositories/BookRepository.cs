using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Models;

namespace Library.Repositories
{
    public class BookRepository : IRepository<Book, int>
    {
        LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Book item)
        {
            _context.Books.Add(item);
            _context.SaveChanges();
        }
        
        public void Remove(Book item)
        {
            if (Find(item.Id) != null)
            {
                item = Find(item.Id);
                _context.Books.Remove(item);
                _context.SaveChanges();
            }
        }

        public Book Find(int id)
        {
            var booktoFind = _context.Books.Where(c => c.Id == id);
            return booktoFind.First();
        }

        public void Edit(Book item)
        {
            Book oldBook = _context.Books.Find(item.Id);
            oldBook = item;
            _context.SaveChanges();
        }

        public IEnumerable<Book> All()
        {
            return _context.Books;
        }
    }
}
