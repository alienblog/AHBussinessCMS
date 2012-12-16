using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NH = NHibernate;
using NHibernate.Linq;
using AH.Core.Orm;

namespace AH.Core.Services
{
    public class Repository : IRepository
    {
        private NH.ISession session;
        private bool useNHibernateManager = true;

        public Repository()
        {
            session = NHibernateManager.GetCurrentSession();
            useNHibernateManager = false;
        }

        public Repository(NH.ISession session)
        {
            this.session = session;
            useNHibernateManager = false;
        }

        public NH.ISession Session
        {
            get
            {
                if (useNHibernateManager)
                {
                    return session;
                }
                else
                {
                    return NHibernateManager.GetCurrentSession();
                }
            }
        }

        public T Get<T>(object primaryKey) where T : class
        {
            return session.Get<T>(primaryKey);
        }

        public T Load<T>(object primaryKey) where T : class
        {
            return session.Load<T>(primaryKey);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return session.Query<T>();
        }

        public object Insert(object model)
        {
            var m = session.Save(model);
            session.Flush();
            return m;
        }

        public void Update(object model)
        {
            session.Update(model);
            session.Flush();
        }

        public void Remove(object entity)
        {
            session.Delete(entity);
            session.Flush();
        }

        public void Remove<T>(object primaryKey) where T : class
        {
            var m = Get<T>(primaryKey);
            Remove(m);
        }

        public void SaveOrUpdate(object entity)
        {
            session.SaveOrUpdate(entity);
            session.Flush();
        }

        public void Dispose()
        {
            if (this.session != null)
            {
                this.session.Flush();
                CloseSession();
            }
        }

        private void CloseSession()
        {
            session.Close();
            session.Dispose();
            session = null;
        }
    }
}
