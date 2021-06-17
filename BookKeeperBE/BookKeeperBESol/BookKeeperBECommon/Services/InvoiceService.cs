using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeperBECommon.BusinessObjects;
using BookKeeperBECommon.Repos;

namespace BookKeeperBECommon.Repos
{
    public class InvoiceService
    {
        private InvoiceRepoMysql userRepo;



        public InvoiceService()
        {
            // Temporary solution.
            this.userRepo = new InvoiceRepoMysql();
        }



        public IList<Invoice> GetListOfInvoices()
        {
            return this.userRepo.GetList();
        }



        public IList<Invoice> FindListOfUsers(string usernamePattern)
        {
            Invoice searchCriteriaAsUser = new Invoice { InvoiceNumber = $"*{usernamePattern}*" };
            //User searchCriteriaAsUser = new User { Username = usernamePattern };
            return this.userRepo.FindList(searchCriteriaAsUser);
        }



        public IList<Invoice> SearchUsers(Invoice invoice)
        {
            if ((invoice.ID == 0) && (invoice.InvoiceNumber == null))
            {
                // Empty user-search criteria.
                return GetListOfInvoices();
            }
            if ((invoice.ID == 0) && (invoice.InvoiceNumber != null))
            {
                // Only the Username property has been set.
                return FindListOfUsers(invoice.InvoiceNumber);
            }
            return this.userRepo.FindList(invoice);
        }



        public bool ExistsUser(int id)
        {
            Invoice userToCheck = new Invoice { ID = id };
            bool exists = this.userRepo.Exists(userToCheck);
            return exists;
        }



        public Invoice LoadUser(int id)
        {
            Invoice userToLoad = new Invoice { ID = id };
            Invoice userLoaded = this.userRepo.Load(userToLoad);
            return userLoaded;
        }



        //public void SaveUser(User user)
        public Invoice SaveUser(Invoice user)
        {
            Invoice userToReturn = user;
            if (user.ID == 0)
            {
                this.userRepo.Add(user);
                // Find all users with the given username.
                List<Invoice> listOfUsersToProcess = (List<Invoice>)this.userRepo.FindList(user);
                // Sort the list of users by their ID's in an ascending order.
                listOfUsersToProcess.Sort((u1, u2) => u1.ID - u2.ID);
                // Get the last user (with the greatest ID).
                //userToReturn = listOfUsersToProcess[0];
                userToReturn = listOfUsersToProcess[listOfUsersToProcess.Count - 1];
            }
            else
            {
                this.userRepo.Store(user);
            }
            return userToReturn;
        }



        //public void DeleteUser(int id)
        public Invoice DeleteUser(int id)
        {
            Invoice userToDelete = new Invoice { ID = id };
            Invoice userToDeleteFound = this.userRepo.Load(userToDelete);
            this.userRepo.Remove(userToDelete);
            return userToDeleteFound;
        }
    }
}
