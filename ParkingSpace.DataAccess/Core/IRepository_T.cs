using System;
using System.Linq;

namespace ParkingSpace.DataAccess.Core {
  public interface IRepository<T> : IRepository, IDisposable where T : class {

    IQueryable<T> Query(Func<T, bool> predicate);

    T Add(T item);

    T Remove(T item);

    int SaveChanges();

  }
}
