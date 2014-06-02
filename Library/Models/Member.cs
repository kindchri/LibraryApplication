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
    /// The member class
    /// </summary>
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SocialSecurityNr { get; set; }
        public string Name { get; set; }
        //A member can have many loans, one-to-many
        public virtual List<Loan> Loans { get; set; }
    }
}
