using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HereosBank.Models
{
    public class ApplicationRoles: IdentityRole
    {
        public ApplicationRoles() : base() { }
        public ApplicationRoles(string name) : base(name) { }
        // extra properties here 
    }
}