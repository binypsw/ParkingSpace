using ParkingSpace.Models;
using ParkingSpace.Services;
using ParkingSpace.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ParkingSpace.Facts.Services {
  public class ParkingTicketServiceFacts {
    public class GeneralUsage {

      [Fact]
      public void HasdefaultValues() {
        var s = new ParkingTicketService();
        Assert.Equal(0, s.GateId);
        Assert.Equal(1, s.NextId);
      }

    }

    public class CreateParkingTicketMethod {
      private readonly ITestOutputHelper output;

      public CreateParkingTicketMethod(ITestOutputHelper output) {
        this.output = output;
      }

      [Fact]
      public void ReturnParkingTicket() {
        var s = new ParkingTicketService();

        var t = s.CreateParkingTicket("1122");


        Assert.NotNull(t);
        Assert.Equal("1122", t.PlateNumber);
      }

      [Fact]
      public void NewTicket_CheckDate() {
        var s = new ParkingTicketService();
        var dt = DateTime.Now;
        SystemTime.SetDateTime(dt);

        var t = s.CreateParkingTicket("1122");

        Assert.NotEqual(default(DateTime), t.DateIn);
        Assert.Equal(dt, t.DateIn);
        Assert.Null(t.DateOut);
      }

      [Fact]
      public void NewTicket_HasAutoRunningId() {
        var s = new ParkingTicketService();
        int gateId1 = s.GateId;
        int nextId1 = s.NextId;
        var ticket1 = s.CreateParkingTicket("23");
        var ticketId1 = $"{gateId1:00}-{nextId1:00000}";

        displayTicket(ticket1);

        Assert.Equal(ticketId1, ticket1.Id);

        int gateId2 = s.GateId;
        int nextId2 = s.NextId;
        var s2 = new ParkingTicketService();
        var ticket2 = s.CreateParkingTicket("24");
        var ticketId2 = $"{gateId2:00}-{nextId2:00000}";

        displayTicket(ticket2);

        Assert.Equal(nextId1 + 1, nextId2);
        Assert.Equal(ticketId2, ticket2.Id);
      }

      [Fact]
      public void NewTicket_UsesGateIdFromService() {
        var s = new ParkingTicketService();
        var ticket = s.CreateParkingTicket("23");
        Assert.Equal(s.GateId, ticket.GateId);
      }

      private void displayTicket(ParkingTicket t) {
        output.WriteLine("TICKET!!!");
        output.WriteLine($"Id:      {t.Id}");
        output.WriteLine($"Gate:    {t.GateId}");
        output.WriteLine($"Plate:   {t.PlateNumber}");
        output.WriteLine($"Date In: {t.DateIn}");
      }
    }
  }
}
