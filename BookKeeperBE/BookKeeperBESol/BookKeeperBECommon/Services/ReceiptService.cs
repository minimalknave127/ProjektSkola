using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeperBECommon.BusinessObjects;
using BookKeeperBECommon.Repos;

namespace BookKeeperBECommon.Repos
{
    public class ReceiptService
    {
        private ReceiptRepoMysql userRepo;



        public ReceiptService()
        {
            // Temporary solution.
            this.userRepo = new ReceiptRepoMysql();
        }



        public IList<Receipt> GetListOfUsers()
        {
            return this.userRepo.GetList();
        }



        public IList<Receipt> FindListOfUsers(string usernamePattern)
        {
            Receipt searchCriteriaAsUser = new Receipt { Username = $"*{usernamePattern}*" };
            //User searchCriteriaAsUser = new User { Username = usernamePattern };
            return this.userRepo.FindList(searchCriteriaAsUser);
        }



        public IList<Receipt> SearchUsers(Receipt user)
        {
            if ((user.ID == 0) && (user.Username == null))
            {
                // Empty user-search criteria.
                return GetListOfUsers();
            }
            if ((user.ID == 0) && (user.Username != null))
            {
                // Only the Username property has been set.
                return FindListOfUsers(user.Username);
            }
            return this.userRepo.FindList(user);
        }



        public bool ExistsUser(int id)
        {
            Receipt userToCheck = new Receipt { ID = id };
            bool exists = this.userRepo.Exists(userToCheck);
            return exists;
        }



        public Receipt LoadUser(int id)
        {
            Receipt userToLoad = new Receipt { ID = id };
            Receipt userLoaded = this.userRepo.Load(userToLoad);
            return userLoaded;
        }



        //public void SaveUser(User user)
        public Receipt SaveUser(Receipt user)
        {
            Receipt userToReturn = user;
            if (user.ID == 0)
            {
                this.userRepo.Add(user);
                // Find all users with the given username.
                List<Receipt> listOfUsersToProcess = (List<Receipt>)this.userRepo.FindList(user);
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
        public Receipt DeleteUser(int id)
        {
            Receipt userToDelete = new Receipt { ID = id };
            Receipt userToDeleteFound = this.userRepo.Load(userToDelete);
            this.userRepo.Remove(userToDelete);
            return userToDeleteFound;
        }
    }
}
