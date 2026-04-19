using Microsoft.AspNet.Identity;
using SOLUCAO_TCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOLUCAO_TCC.Controllers
{
    public abstract class UserController : Controller
    {
        // GET: User
        public string UserID
        {
            get { return User.Identity.GetUserId<string>(); }
        }

        public bool Usuario
        {
            get
            {
                if (Model1.GetPessoa(UserID) != null)
                {
                    return true;
                }
                else return false;
            }
        }

        public bool Admin
        {
            get
            {
                if (Model1.GetAdmin(UserID) != null)
                {
                    return true;
                }
                else return false;
            }
        }

    }
}