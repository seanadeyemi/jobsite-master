using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPlatform.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Career { get; set; }
    }

    public class UserSearchViewModel
    {
        public string UserName { get; set; }

    }
}