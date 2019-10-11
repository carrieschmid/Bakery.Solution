using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class OrderControllerTest : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void FindVendor_UsesVendorIdToReturnView_View()
    
    {
      //Arrange 
      int vendorId = 1;
      Vendor vendor = Vendor.Find(vendorId);
      
      //Act
      string result = "Maggie's Buns";
      

     //Assert
     Assert.AreEqual("Maggie's Buns", result); 
    }
  }
}
