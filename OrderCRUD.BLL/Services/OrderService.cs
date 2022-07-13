using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderCRUD.BLL.DTO;
using OrderCRUD.BLL.Interfaces;
using OrderCRUD.DAL.Entities;
using OrderCRUD.DAL.Interfaces;

namespace OrderCRUD.BLL.Services
{
    public class OrderService:IOrderService
    {
        IUnitOfWork Database { get; set; }

        public  OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeOrder (OrderDTO orderDTO)
        {


            Order order = new Order
            {
              Id = orderDTO.Id,
              Date = orderDTO.Date,
              Number = orderDTO.Number,
              
            };
            Database.Orders.Create(order);
            Database.Save();

        }
        public void Dispose ()
        {
            Database.Dispose();
        }

    }
}
