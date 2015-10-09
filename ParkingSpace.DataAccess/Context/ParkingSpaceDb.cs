using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingSpace.Models;

namespace ParkingSpace.DataAccess.Context {
  public class ParkingSpaceDb : DbContext {

    public DbSet<ParkingTicket> ParkingTickets { get; set; }

    public DbSet<Setting> Settings { get; set; }

  }
}