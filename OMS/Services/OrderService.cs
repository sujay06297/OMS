using OMS.Interfaces;
using OMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMS.Services
{
    public class OrderService : IOrderService
    {
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        IRepository<Orders> repOders;
        public OrderService(IRepository<Orders> rep)
        {
            repOders = rep;
        }

        public List<Orders> GetOrderInfo()
        {
            try
            {
                return repOders.GetAll().ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }

        public Orders GetOrderDetail(int id)
        {
            try
            {
                return repOders.GetById(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }

        public void CreateOrder(Orders order)
        {
            try
            {
                repOders.Create(order);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }

        public void DeleteOrder(int id)
        {
            try
            {
                var order = repOders.GetById(id);
                repOders.Delete(order);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }

        public void UpdateOrder(Orders order)
        {
            try
            {
                repOders.Update(order);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw;
            }
        }

    }
}