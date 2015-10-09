using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using ParkingSpace.DataAccess.Context;
using ParkingSpace.DataAccess;
using ParkingSpace.Models;
using ParkingSpace.Services.Core;
using ParkingSpace.DataAccess.Core;

namespace ParkingSpace.Services {
  public class App : RootClass {

    public bool TestingMode { get; private set; }

    public App(bool testing = false)
      : base(testing) {

      this.TestingMode = testing;
    }

    protected override DbContext NewDbContext() {
      return new ParkingSpaceDb();
    }

    protected override void RegisterServices() {
      this.AddService<ParkingTicket, ParkingTicketService, ParkingTicketRepository>();
    }

    protected override void RegisterServicesForUnitTests() {
      this.AddService<ParkingTicket, ParkingTicketService, FakeRepository<ParkingTicket>>();
    }

    public ParkingTicketService ParkingTickets {
      get {
        return this.Services<ParkingTicket, ParkingTicketService>();
      }
    }
  }
}