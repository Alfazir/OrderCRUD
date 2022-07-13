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
    public class OrderRepository:IRepository<Order>
    {
        private EFContext _context;

        public OrderRepository (EFContext context)
        {
            this._context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public Order Get (int id)
        {
            return _context.Orders.Find(id);
        }

        public void Create (Order order)
        {
            _context.Orders.Add(order);
        }

        public void Update ( Order order)
        {
            _context.Entry(order).State=EntityState.Modified;
        }

        public IEnumerable<Order> Find (Func<Order,Boolean> predicate)
        {
            return _context.Orders.Where(predicate).ToList();
        }

        public void Delete (int id)
        {
            Order order = _context.Orders.Find(id);
            if (order != null)
                _context.Orders.Remove(order);
        }
    }
}
