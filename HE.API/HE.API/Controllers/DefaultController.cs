using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HE.DataAccess;

namespace HE.API.Controllers
{
    public class DefaultController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();
    }
}
