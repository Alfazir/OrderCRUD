using OrderCRUD.DAL.Interfaces;
using OrderCRUD.DAL.Entities;
using OrderCRUD.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCRUD.DAL.Repositories
{
    public class OrderItemRepository:IRepository<OrderItem>
    {
        private EFContext _context;

        public OrderItemRepository (EFContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderItem> GetAll ()
        {
            return _context.OrderItems;
        }

        public OrderItem Get (int id)
        {
            return _context.OrderItems.Find(id);
        }

        public void Create (OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
        }
        public void Update (OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
        }

        public IEnumerable<OrderItem> Find (Func<OrderItem, Boolean> predicate)
        {
            return _context.OrderItems.Where(predicate).ToList();
        }
        public void Delete (int id)
        {
            OrderItem orderItem = _context.OrderItems.Find(id);
            if (orderItem != null)
                _context.OrderItems.Remove(orderItem);
        }

    }
}
