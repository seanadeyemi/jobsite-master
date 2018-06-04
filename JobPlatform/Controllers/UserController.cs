using JobPlatform.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace JobPlatform.Controllers
{
    
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly UserRepo userRepo;
        private ApplicationUserManager _userManager;
        public UserController()
        {
               userRepo = new UserRepo();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize(Roles ="ADMIN")]
        [Route("get")]
        public IEnumerable<User> Get()
        {
            return userRepo.GetUsers();

        }
        [Authorize]
        [HttpPost]
        public IHttpActionResult GetUserAccess(UserSearchViewModel usvm)
        {

            ApplicationUser user = UserManager.Users.FirstOrDefault(u => u.UserName == usvm.UserName);


            bool IsAdmin =  UserManager.IsInRole(user.Id, "ADMIN");

            if (IsAdmin)
            {
                return Ok("admin");
            }
            else
            {
                return Ok("user");
            }
        }


        [Authorize]
       
        [HttpPost, Route("getuserbyname")]
        public User GetUserByName(UserSearchViewModel usvm)
        {
           
            return userRepo.GetUserByUserName(usvm.UserName);
        }






        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
