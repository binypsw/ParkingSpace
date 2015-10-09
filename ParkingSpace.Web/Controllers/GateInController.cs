using ParkingSpace.Models;
using ParkingSpace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingSpace.Web.Printing;
using Rotativa;

namespace ParkingSpace.Web.Controllers {

  [RoutePrefix("gate-in")]
  public class GateInController : Controller {
    private static ParkingTicketService service;

    private IParkingTicketPrinter printer;

    static GateInController() {
      service = new ParkingTicketService();
    }

    public GateInController() {
      printer = new PDFParkingTicketPrinter();
    }

    public GateInController(IParkingTicketPrinter printer) {
      this.printer = printer;
    }

    // GET: GateIn
    [Route]
    public ActionResult Index() {
      return View();
    }

    [HttpPost]
    [Route("CreateTicket")]
    public ActionResult CreateTicket(string plateNo) {
      var ticket = service.CreateParkingTicket(plateNo);

      printer.Print(ticket, this.ControllerContext);

      TempData["newTicket"] = ticket;
      return RedirectToAction("Index");
    }

    public ActionResult OpenBarrier() {
      throw new NotImplementedException();
    }
  }
}