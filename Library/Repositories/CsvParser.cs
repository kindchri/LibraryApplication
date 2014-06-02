using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Library.Models;

namespace Library.Repositories
{
    class CsvParser
    {
        List<Book> bookList = new List<Book>();
        Dictionary<String, Author> authorList = new Dictionary<String, Author>();

        public IEnumerable<Book> GetBooks()
        {
            return bookList;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authorList.Values;
        }

        public void ParseCsv()
        {
            var path = Application.StartupPath + "/../../Files/library.csv";
            var lines = File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"));

            foreach (string line in lines)
            {
                var items = line.Split(new string[] { ";" }, StringSplitOptions.None);

                string key = items[2] + items[3];

                if (!authorList.ContainsKey(key))
                {
                    Author author;
                    author = new Author { Name = items[2] + " " + items[3]};
                    authorList.Add(items[2] + items[3], author);
                }
                Book bookToAdd = new Book { Title = items[1], Author = authorList.Where(a => a.Key == items[2] + items[3]).First().Value, Isbn = items[0], Description = items[4], Copies = new List<BookCopy>()};
                bookList.Add(bookToAdd);
            }
        }
    }
}
