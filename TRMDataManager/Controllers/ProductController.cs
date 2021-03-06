﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        public List<ProductModel> Get()
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();

            return productDataAccess.GetProducts();
        }
    }
}
