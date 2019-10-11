using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class OrderTest : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
        Order newOrder = new Order("test", "test", 5, "test");
        Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string name = "Maggie's Buns";
      string description = "cinnamon buns";
      int price = 30;
      string date = "Oct, 11 2019";
      Order newOrder = new Order(name, description, price, date);
      string result = newOrder.Description;
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange 
      string name = "Maggie's Buns";
      string description = "cinnamon buns";
      int price = 30;
      string date = "Oct, 11 2019";
      Order newOrder = new Order(name, description, price, date);

      //Act
      string updatedDescription = "chocolate buns";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

     //Assert
     Assert.AreEqual(updatedDescription, result); 
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      //Arrange
      List<Order> newList = new List<Order> { };
      //Act
      List<Order> result = Order.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      //Arrange
      string name = "Maggie's Buns";
      string description01 = "cinnamon buns";
      string description02 = "chocolate buns";
      int price = 30;
      string date = "Oct, 11 2019";
      Order newOrder1 = new Order(name, description01, price, date);
      Order newOrder2 = new Order(name, description02, price, date);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };
      //Act
      List<Order> result = Order.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    
    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturns_Int()
    {
        //Arrange
        string name = "Maggie's Buns";
        string description = "cinnamon buns";
        int price = 30;
        string date = "Oct, 11 2019";
        Order newOrder = new Order(name, description, price, date);

        //Act
        int result = newOrder.Id;

        //Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
        //Arrange
        string name = "Maggie's Buns";
      string description01 = "cinnamon buns";
      string description02 = "chocolate buns";
      int price = 30;
      string date = "Oct, 11 2019";
      Order newOrder1 = new Order(name, description01, price, date);
      Order newOrder2 = new Order(name, description02, price, date);

      //Act
      Order result = Order.Find(2);

      //Assert
      Assert.AreEqual(newOrder2, result);
    }
  }
}