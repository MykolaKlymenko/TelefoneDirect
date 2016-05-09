using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelefoneDictionary.Models
{
    public interface IRepository<T>
    {
        void Create(T entety);
        List<T> Read();
        T GetByPK(int key);
        void Update(T entety);
        void Delete(T entety);
    }
}