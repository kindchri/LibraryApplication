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
    /// The Loan class
    /// </summary>
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeofLoan { get; set; }
        public Nullable<DateTime> Returned { get; set; }
        public DateTime ToReturn { get; set; }
        [Required]
        public BookCopy BookCopy { get; set; }
        [Required]
        public Member Member { get; set; }

        /// <summary>
        /// The override of the ToString method
        /// </summary>
        /// <returns>Returns the book title and when it's supposed to be returned</returns>
        public override string ToString()
        {
            return BookCopy.Book.Title + "To be returned: " + ToReturn.ToString();
        }
    }
}
