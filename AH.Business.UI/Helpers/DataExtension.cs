using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AH.Core;
using AH.Business.UI;
using AH.Core.Services;
using AH.Business.Models;
using System.Web.Mvc;

namespace AH.Business.UI.Helpers
{
    public static class DataExtension
    {
        static IRepository repository;
        static DataExtension()
        {
            repository = AH.Core.Container.AHSContainer.ResolverRepository();
        }

        public static T Data<T>(object primaryKey) where T : class
        {
            return repository.Get<T>(primaryKey);
        }

        public static List<T> Datas<T>(Func<T, bool> where = null) where T : class
        {
            return where == null ?
                repository.Query<T>().ToList() :
                repository.Query<T>().Where(where).ToList();
        }

        public static List<T> Datas<T>(int pageIndex, int pageSize, out int totalCount, Func<T, bool> where = null) where T : class
        {
            IEnumerable<T> ms;
            ms = where == null ?
                repository.Query<T>() :
                repository.Query<T>().Where(where);

            totalCount = ms.Count();
            pageIndex--;
            return ms.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public static MvcHtmlString SiteProfile(this HtmlHelper htmlHelper, string key)
        {
            var sp = repository.Query<SiteProfile>().FirstOrDefault(x => x.ProfileKey.Equals(key));

            return sp == null ? new MvcHtmlString("") : new MvcHtmlString(sp.ProfileValue);
        }

        public static List<SiteProfile> SiteProfiles(this HtmlHelper htmlHelper, string key)
        {
            return Datas<SiteProfile>(x => x.ProfileKey.Equals(key));
        }
    }
}