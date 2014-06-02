///Version 1.0
///Written by Tobias Keijser and Christoffer Kindesjö
/// 2013-10-31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Repositories;
using Library.Models;

namespace Library.Repositories
{
    /// <summary>
    /// The MemberRepository class, containing CURD options for members
    /// </summary>
    public class MemberRepository : IRepository<Member, int>
    {
        private LibraryContext _context;

        /// <summary>
        /// The constructor for the MemberRepository Class, sets the context.
        /// </summary>
        /// <param name="context">LibraryContext to set as context</param>
        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The Add method, used to add a member to the database
        /// </summary>
        /// <param name="item">Member to add</param>
        public void Add(Member item)
        {
            _context.Members.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// The Remove method, used to remove an exisitng member from the database
        /// </summary>
        /// <param name="item">Member to find and remove</param>
        public void Remove(Member item)
        {
            if (_context.Members.Find(item.Id) != null)
            {
                _context.Members.Remove(item);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// The find method used to find a member in the database
        /// </summary>
        /// <param name="id">MemberID to search for</param>
        /// <returns></returns>
        public Member Find(int id)
        {
            var memberToFind = _context.Members.Where(l => l.Id == id);
            return memberToFind.First();
        }

        /// <summary>
        /// The Edit method used to edit an exisiting member in the database
        /// </summary>
        /// <param name="item">Edited member to inject in the database</param>
        public void Edit(Member item)
        {
            Member oldMember = _context.Members.Find(item.Id);
            oldMember = item;
            _context.SaveChanges();
        }

        /// <summary>
        /// The all method used to list all the members in the database 
        /// </summary>
        /// <returns>An enumerable of all members in the database.</returns>
        public IEnumerable<Member> All()
        {
            return _context.Members;
        }
    }
}
