using ParkingSpace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSpace.Web.Printing {
  public interface IParkingTicketPrinter {

    void Print(ParkingTicket ticket, object args = null);

  }
}
