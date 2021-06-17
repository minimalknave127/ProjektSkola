using System;
using System.Collections.Generic;

using BookKeeperBECommon.BusinessObjects;
using BookKeeperBECommon.Repos;

namespace BookKeeperBECommon.Services
{
    public class ContatsService
    {

        private ContactRepoMysql ContactRepo;



        public ContatsService()
        {
            // Temporary solution.
            this.ContactRepo = new ContactRepoMysql();
        }



        public IList<Contact> GetListOfContact()
        {
            return this.ContactRepo.GetList();
        }



        public IList<Contact> FindListOfContact(string usernamePattern)
        {
            Contact searchCriteriaAsUser = new Contact { Name = $"*{usernamePattern}*" };
            //User searchCriteriaAsUser = new User { Username = usernamePattern };
            return this.ContactRepo.FindList(searchCriteriaAsUser);
        }



        public IList<Contact> SearchContact(Contact contact)
        {
            if ((contact.ID == 0) && (contact.Name == null))
            {
                // Empty user-search criteria.
                return GetListOfContact();
            }
            if ((contact.ID == 0) && (contact.Name != null))
            {
                // Only the Username property has been set.
                return FindListOfContact(contact.Name);
            }
            return this.ContactRepo.FindList(contact);
        }



        public bool ExistsContact(int id)
        {
            Contact userToCheck = new Contact { ID = id };
            bool exists = this.ContactRepo.Exists(userToCheck);
            return exists;
        }



        public Contact LoadContact(int id)
        {
            Contact userToLoad = new Contact { ID = id };
            Contact userLoaded = this.ContactRepo.Load(userToLoad);
            return userLoaded;
        }



        //public void SaveUser(User user)
        public Contact SaveContact(Contact contact)
        {
            Contact userToReturn = contact;
            if (contact.ID == 0)
            {
                this.ContactRepo.Add(contact);
                // Find all users with the given username.
                List<Contact> listOfContactsToProcess = (List<Contact>)this.ContactRepo.FindList(contact);
                // Sort the list of users by their ID's in an ascending order.
                listOfContactsToProcess.Sort((u1, u2) => u1.ID - u2.ID);
                // Get the last user (with the greatest ID).
                //userToReturn = listOfUsersToProcess[0];
                userToReturn = listOfContactsToProcess[listOfContactsToProcess.Count - 1];
            }
            else
            {
                this.ContactRepo.Store(contact);
            }
            return userToReturn;
        }



        //public void DeleteUser(int id)
        public Contact DeleteContact(int id)
        {
            Contact ContactToDelete = new Contact { ID = id };
            Contact userToDeleteFound = this.ContactRepo.Load(ContactToDelete);
            this.ContactRepo.Remove(ContactToDelete);
            return userToDeleteFound;
        }

    }
}
