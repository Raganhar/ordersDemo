﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Mvc;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;

namespace OrdersDemo.Controllers
{
    //*If you dont add <AuthUserSession> (or your subclass of it) this.AuthSession  
    public class FulfillmentController : ServiceStackController<AuthUserSession> 
    {
        [Authenticate]
        public ActionResult Index()
        {
            return View();
        }

        public override ActionResult AuthenticationErrorResult
        {
            get
            {
                if (this.AuthSession == null || this.AuthSession.IsAuthenticated == false)
                {
                    return Redirect("~/Home");
                }
                return base.AuthenticationErrorResult;
            }
        }
    }
}
