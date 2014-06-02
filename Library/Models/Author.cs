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
    /// The Author class
    /// </summary>
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // A author may have written several books, one-to-many
        public virtual ICollection<Book> Books { get; set; }
    }
}
