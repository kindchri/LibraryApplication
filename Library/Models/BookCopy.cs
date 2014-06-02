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
    /// The BookCopy class
    /// </summary>
    public class BookCopy
    {
        [Required]
        public Book Book{get; set;}
        [Key]
        public int Id { get; set; }
        public bool IsLoaned { get; set; }
        public string Condition { get; set; }

        /// <summary>
        /// The override of the ToString method for a BookCopy.
        /// </summary>
        /// <returns>Returns wether a copy is loaned or in storage</returns>
        public override string ToString()
        {
            if (IsLoaned)
            { return "Book copy number " + Convert.ToString(Id) + " is currently loaned"; }
            else {return "Book copy number " + Convert.ToString(Id) + " is currently in storage";}
        }
    }
}
