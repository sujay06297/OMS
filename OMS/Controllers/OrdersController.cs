using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OMS.Interfaces;
using OMS.Models;

namespace OMS.Controllers
{
    public class OrdersController : Controller
    {
        IOrderService orderService;
        public OrdersController(IOrderService os) {
            orderService = os;
        }

        private OMSModel db = new OMSModel();

        public ActionResult Index()
        {
            return View(orderService.GetOrderInfo());
        }

        public ActionResult Details(int id)
        {
            Orders orders = orderService.GetOrderDetail(id);

            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                orderService.CreateOrder(orders);
                return RedirectToAction("Index");
            }

            return View(orders);
        }

        public ActionResult Edit(int id)
        {
            Orders orders = orderService.GetOrderDetail(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                orderService.UpdateOrder(orders);
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        public ActionResult Delete(int id)
        {
            orderService.DeleteOrder(id);

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
