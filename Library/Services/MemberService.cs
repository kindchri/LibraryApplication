///Version 1.1
///Written by Tobias Keijser and Christoffer Kindesjö
/// 2013-11-09
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
    /// The MemberService class, containing all operations to do with members.
    /// </summary>
    public class MemberService : IService<Member>
    {

        private MemberRepository memberRepo;

        public event EventHandler Updated;

        /// <summary>
        /// The OnUpdated method, checks if the eventhandler isn't null and runs it.
        /// </summary>
        /// <param name="e">Event trigger.</param>
        protected virtual void OnUpdated(EventArgs e)
        {
            EventHandler updateHandler = Updated;
            if (updateHandler != null)
            {
                updateHandler(this, e);
            }
        }

        /// <summary>
        /// The Constructor of the MemberService,  setting the eventhandler and MemberReository
        /// </summary>
        /// <param name="updated"></param>
        /// <param name="repo3"></param>
        public MemberService(MemberRepository repo)
        {
            memberRepo = repo;
        }

        /// <summary>
        /// The Add method, adding a member to the Database
        /// </summary>
        /// <param name="item">member to add</param>
        public void Add(Member item)
        {
            if (item.Name.Length == 0 || !item.Name.Contains(' '))
            {
                throw new InvalidInputException();
            }
            memberRepo.Add(item);
            OnUpdated(EventArgs.Empty);
        }

        /// <summary>
        /// Required by the interface but not implemented since it aint required for the Project Work
        /// </summary>
        /// <param name="item">Member to remove</param>
        public void Remove(Member item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Edit method for members
        /// </summary>
        /// <param name="item">member to edit</param>
        public void Edit(Member item)
        {
            var membertoedit = memberRepo.Find(item.Id);
            memberRepo.Edit(membertoedit);
        }

        /// <summary>
        /// The Find method, searches for a memberID
        /// </summary>
        /// <param name="id">ID to search for</param>
        /// <returns>The member if it exists</returns>
        public Member Find(int id)
        {
            return memberRepo.Find(id);
        }

        /// <summary>
        /// the customSearch method, searching for a member on their socialsecuritynumber
        /// </summary>
        /// <param name="searchItem">Socialsecuritynumber to search for</param>
        /// <returns>The member if it's found</returns>
        public Member CustomSearch(string searchItem)
        {
            if (memberRepo.All().Where(m => m.SocialSecurityNr == searchItem) != null)
            {
                return memberRepo.All().Where(m => m.SocialSecurityNr == searchItem).First();
            }
            else
            {
                throw new InputNotFoundException();
            }
        }

        /// <summary>
        /// The All method, used to get all members in the database
        /// </summary>
        /// <returns>Ienumerable of all members in the database</returns>
        public IEnumerable<Member> All()
        {
            return memberRepo.All();
        }
    }
}
