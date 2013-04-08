using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using NHibernate;

namespace WenSharkApp.Controllers
{
    public class SearchController : ApiController
    {
        public List<ItemEN> getSearch(string name)
        {
            ItemCEN itemCEN = new ItemCEN();
            List<ItemEN> result;

            result = itemCEN.Search(name).ToList();

            return result;
        }


    }

}
