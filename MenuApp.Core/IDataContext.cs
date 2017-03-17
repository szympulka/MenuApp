using System;
using System.Linq;

namespace MenuApp.Core.Entities
{
    public interface IDataContext: IDisposable
    {
        IQueryable<T> All<T>() where T : class;
        T Find<T>(params object[] keys) where T : class;
        T Add<T>(T entry) where T : class;
        T Remove<T>(T entry) where T : class;
        //T Attach<T>(T entry) where T : class;
        void SaveChanges();
    }
}
