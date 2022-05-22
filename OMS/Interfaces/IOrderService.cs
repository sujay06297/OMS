using OMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Interfaces
{
    public interface IOrderService
    {
        List<Orders> GetOrderInfo();

        Orders GetOrderDetail(int id);

        void CreateOrder(Orders order);

        void DeleteOrder(int id);

        void UpdateOrder(Orders order);
    }
}
