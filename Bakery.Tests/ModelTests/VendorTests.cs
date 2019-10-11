using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;
using System.Collections.Generic;
using System;

namespace Bakery.Tests
{
  [TestClass]
  public class CategoryTest : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }
  

  [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      Vendor newVendor = new Vendor("test vendor");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

  [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Category";
      Vendor newVendor = new Vendor(name);

      //Act
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

  [TestMethod]
  public void GetId_ReturnsCategoryId_Int()
  {
    //Arrange
    string name = "Test Category";
    Vendor newVendor = new Vendor(name);

    //Act
    int result = newVendor.Id;

    //Assert
    Assert.AreEqual(1, result);
  }

  [TestMethod]
  public void GetAll_ReturnsAllCategoryObjects_VendorList()
  {
    //Arrange
    string name01 = "Maagie's Buns";
    string name02 = "Cake Place";
    Vendor newVendor1 = new Vendor(name01);
    Vendor newVendor2 = new Vendor(name02);
    List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

    //Act
    List<Vendor> result = Vendor.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }

  [TestMethod]
  public void Find_ReturnsCorrectVendor_Vendor()
  {
    //Arrange
    string name01 = "Maagie's Buns";
    string name02 = "Cake Place";
    Vendor newVendor1 = new Vendor(name01);
    Vendor newVendor2 = new Vendor(name02);

    //Act
    Vendor result = Vendor.Find(2);

    //Assert
    Assert.AreEqual(newVendor2, result);
  }

  [TestMethod]
  public void AddOrder_AssociatesOrderWithVendor_OrderList()
  {
    //Arrange
    string name = "Maggie's Buns";
    string description = "cinnamon buns";
    int price = 30;
    string date = "Oct, 11 2019";
    Order newOrder = new Order(name, description, price, date);
    List<Order> newList = new List<Order> { newOrder };
    string vendorName = "Maggie's Buns";
    Vendor newVendor = new Vendor(vendorName);
    newVendor.AddOrder(newOrder);

    //Act
    List<Order> result = newVendor.Orders;

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }

  }
}