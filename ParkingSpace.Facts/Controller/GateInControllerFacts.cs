using ParkingSpace.Web.Controllers;
using ParkingSpace.Web.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using ParkingSpace.Models;
using ParkingSpace.Services;

namespace ParkingSpace.Facts.Controller {
  public class GateInControllerFacts {
    public class IndexAction {
      [Fact]
      public void ShouldReturnsView() {
        var ctrl = new GateInController();
        var r = ctrl.Index();

        Assert.NotNull(r);
        Assert.IsType<ViewResult>(r);
      }
    }

    public class CreateTicketAction {

      class FakePrinter : IParkingTicketPrinter {
        public bool hasPrinted = false;
        public void Print(ParkingTicket ticket, object args = null) {
          hasPrinted = true;
        }
      }

      [Fact]
      public void ShouldCreatedPDFFile() {
        using (var app = new App(testing: true)) {
          var printer = new FakePrinter();
          var ctrl = new GateInController(printer, app);

          ctrl.CreateTicket("000");

          Assert.True(printer.hasPrinted);
        }
      }
    }

  }
}
