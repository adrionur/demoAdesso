using DemoAdesso.Models;
using System.Collections.Generic;

namespace DemoAdesso.DAL
{
    public interface IRepository
    {
        IEnumerable<object> GetAll();
        object GetById(int id);
        void Update(object obj);
        void Remove(object obj);
        void Add(object obj);
    }
}