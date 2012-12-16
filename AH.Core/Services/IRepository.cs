using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AH.Core.Services
{
    public interface IRepository : IDisposable
    {
        T Get<T>(object primaryKey) where T : class;

        T Load<T>(object primaryKey) where T : class;

        IQueryable<T> Query<T>() where T : class;

        object Insert(object model);

        void Update(object model);

        void Remove(object entity);

        void Remove<T>(object primaryKey) where T : class;

        void SaveOrUpdate(object entity);
    }
}
