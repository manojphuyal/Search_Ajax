using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Repository
{

        public interface IRepository<T> where T : class
        {
            void Add(T obj);
            void Edit(T obj);
            void Delete(T obj);
            List<T> List();
            T getbyId(int? id);
        }
}