using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET api/user
        public UserModel Get()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserDataAccess userDataAccess = new UserDataAccess();

            return userDataAccess.GetUserById(userId).First();
        }

        // GET api/user/"guid"
        [Route("{userId}")]
        public UserModel Get(string userId)
        {
            UserDataAccess userDataAccess = new UserDataAccess();

            return userDataAccess.GetUserById(userId).First();
        }
    }
}
