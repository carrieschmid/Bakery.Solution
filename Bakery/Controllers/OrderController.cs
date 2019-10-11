using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;

namespace Bakery.Controllers
{
  public class OrderController : Controller
  {
    [HttpGet("/vendors/{vendorName}/orders/new")]
    public ActionResult New(string vendorName)
    {
      Vendor vendor = Vendor.Find(vendorName);
      return View(vendor);
    }

    [HttpGet("/vendor/{vendorName}/orders/{orderName}")]
    public ActionResult Show(string vendorName, string orderName)
    {
      Order order = Order.Find(orderName);
      Vendor vendor = Vendor.Find(vendorName);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }

    [HttpPost("/orders/delete")]
    public ActionResult DeleteAll()
    {
      Order.ClearAll();
      return View();
    }

  }
}