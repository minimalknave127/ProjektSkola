using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookKeeperBECommon.BusinessObjects;
using BookKeeperBECommon.Repos;

namespace BookKeeperBECommon.Services
{
    public class StatementService
    {
        private StatementRepoMysql StatementRepo;



        public StatementService()
        {
            // Temporary solution.
            this.StatementRepo = new StatementRepoMysql();
        }



        public IList<Statement> GetListOfUsers()
        {
            return this.StatementRepo.GetList();
        }



        public IList<Statement> FindListOfUsers(string usernamePattern)
        {
            Statement searchCriteriaAsUser = new Statement { StatementNumber = $"*{usernamePattern}*" };
            //User searchCriteriaAsUser = new User { Username = usernamePattern };
            return this.StatementRepo.FindList(searchCriteriaAsUser);
        }



        public IList<Statement> SearchUsers(Statement Statement)
        {
            if ((Statement.ID == 0) && (Statement.StatementNumber == null))
            {
                // Empty user-search criteria.
                return GetListOfUsers();
            }
            if ((Statement.ID == 0) && (Statement.StatementNumber != null))
            {
                // Only the Username property has been set.
                return FindListOfUsers(Statement.StatementNumber);
            }
            return this.StatementRepo.FindList(Statement);
        }



        public bool ExistsUser(int id)
        {
            Statement userToCheck = new Statement { ID = id };
            bool exists = this.StatementRepo.Exists(userToCheck);
            return exists;
        }



        public Statement LoadUser(int id)
        {
            Statement userToLoad = new Statement { ID = id };
            Statement userLoaded = this.StatementRepo.Load(userToLoad);
            return userLoaded;
        }



        //public void SaveUser(User user)
        public Statement SaveUser(Statement Statement)
        {
            Statement userToReturn = Statement;
            if (Statement.ID == 0)
            {
                this.StatementRepo.Add(Statement);
                // Find all users with the given username.
                List<Statement> listOfUsersToProcess = (List<Statement>) this.StatementRepo.FindList(Statement);
                // Sort the list of users by their ID's in an ascending order.
                listOfUsersToProcess.Sort((u1, u2) => u1.ID - u2.ID);
                // Get the last user (with the greatest ID).
                //userToReturn = listOfUsersToProcess[0];
                userToReturn = listOfUsersToProcess[listOfUsersToProcess.Count - 1];
            }
            else
            {
                this.StatementRepo.Store(Statement);
            }
            return userToReturn;
        }



        //public void DeleteUser(int id)
        public Statement DeleteUser(int id)
        {
            Statement userToDelete = new Statement { ID = id };
            Statement userToDeleteFound = this.StatementRepo.Load(userToDelete);
            this.StatementRepo.Remove(userToDelete);
            return userToDeleteFound;
        }

    }
}
