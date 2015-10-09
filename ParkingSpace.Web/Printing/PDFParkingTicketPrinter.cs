using ParkingSpace.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingSpace.Web.Printing {
  public class PDFParkingTicketPrinter : IParkingTicketPrinter {
    public void Print(ParkingTicket ticket, object args = null) {
      var r = new ViewAsPdf("Rpt01_ParkingTicketIn", ticket);

      r.PageSize = Rotativa.Options.Size.A6;
      r.PageOrientation = Rotativa.Options.Orientation.Portrait;

      var fileName = ticket.Id + ".pdf";
      var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + fileName);

      var bytes = r.BuildPdf((ControllerContext)args);
      System.IO.File.WriteAllBytes(filePath, bytes);
    }
  }
}