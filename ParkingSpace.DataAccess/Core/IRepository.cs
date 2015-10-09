using System.Data.Entity;

namespace ParkingSpace.DataAccess.Core {
  public interface IRepository {
    DbContext Context { get; set; }
  }
}
