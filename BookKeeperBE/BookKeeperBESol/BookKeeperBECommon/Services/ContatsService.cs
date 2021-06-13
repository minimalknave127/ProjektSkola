﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeperBECommon.BusinessObjects;
using BookKeeperBECommon.Repos;

namespace BookKeeperBECommon.Services
{
    public class ContatsService
    {
<<<<<<< HEAD
        private InvoiceRepoMysql ContactRepo;



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
            Contact searchCriteriaAsUser = new Contact { Username = $"*{usernamePattern}*" };
            //User searchCriteriaAsUser = new User { Username = usernamePattern };
            return this.ContactRepo.FindList(searchCriteriaAsUser);
        }



        public IList<Contact> SearchContact(Contact contact)
        {
            if ((contact.ID == 0) && (contact.Username == null))
            {
                // Empty user-search criteria.
                return GetListOfContact();
            }
            if ((contact.ID == 0) && (contact.Username != null))
            {
                // Only the Username property has been set.
                return FindListOfUsers(contact.Username);
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
            Contact userToDelete = new Contact { ID = id };
            Contact userToDeleteFound = this.ContactRepo.Load(userToDelete);
            this.ContactRepo.Remove(userToDelete);
            return userToDeleteFound;
        }
=======
>>>>>>> 814bf976c4303d06e8292c8305e4368165ba4a16
    }
}
