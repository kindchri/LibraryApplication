///Version 1.0
///Written by Tobias Keijser and Christoffer Kindesjö
/// 2013-10-31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Library.Models
{
    /// <summary>
    /// The book class
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        [Required]
        public virtual Author Author { get; set; }
        public string Description { get; set; }
        public virtual List<BookCopy> Copies { get; set; }

        /// <summary>
        /// The Override of the ToString method for the book class
        /// </summary>
        /// <returns>Returns the book title and ammount of avalible copies</returns>
        public override string ToString()
        {
            return Title + "     " + "Available copies: " + Copies.Where(b => b.IsLoaned == false).Count().ToString();
        }
    }
}
