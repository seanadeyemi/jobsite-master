using JobPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPlatform
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByUserName(string username);

   }

    

    public class UserRepo : IUserRepository
    {
        private ApplicationDbContext context;

        public UserRepo()
        {
            context = new ApplicationDbContext();
        }

        public User GetUserByUserName(string username)
        {
            ApplicationUser aUser = context.Users.FirstOrDefault(u => u.UserName == username);


            User user = new User {
                 Name  = aUser.UserName,
                  Career = aUser.CareerField,
                   Id = aUser.Id,
                    State = aUser.State

            };
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<ApplicationUser> users = context.Users;
            List<User> userList = new List<User>();
           foreach(ApplicationUser appUser in users)
            {
                userList.Add(new User { Career = appUser.CareerField, Name = appUser.UserName, State = appUser.State });
            }


            return userList;
         
        }
    }
}