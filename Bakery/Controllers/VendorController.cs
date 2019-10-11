using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
        return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName)
    {
        Vendor newVendor  = new Vendor (vendorName);
        return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Vendor selectedVendor = Vendor.Find(id);
        List<Order> vendorOrders = selectedVendor.Orders;
        model.Add("vendor", selectedVendor);
        model.Add("orders", vendorOrders);
        return View(model);
    }

    // This one creates new Items within a given Category, not new Categories:
    [HttpPost("/categories/{categoryId}/orders")]
    public ActionResult Create(int vendorId, string orderName, string orderDescription, int price, string date)
    {
    Dictionary<string, object> model = new Dictionary<string, object>();
    Vendor foundVendor= Vendor.Find(vendorId);
    Order newOrder = new Order(orderName, orderDescription, price, date);
    foundVendor.AddOrder(newOrder);
    List<Order> vendorOrders = foundVendor.Orders;
    model.Add("orders", vendorOrders);
    model.Add("vendor", foundVendor);
    return View("Show", model);
    }

  }
}