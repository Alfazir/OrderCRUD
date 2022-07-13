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
    public class EFUnitOfWork : IUnitOfWork
    {
        private EFContext _context;
        private OrderRepository _orderRepository;
        private OrderItemRepository _orderItemRepository;

        public EFUnitOfWork(EFContext eFContext, OrderItemRepository orderItemRepository, OrderRepository orderRepository)
        {
            this._context = eFContext;
            this._orderRepository = orderRepository;
            this._orderItemRepository = orderItemRepository;
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_context);
                return _orderRepository;
            }
        }
        public IRepository<OrderItem> OrderItems
        {
            get
            {
                if (this._orderItemRepository == null)
                    _orderItemRepository = new OrderItemRepository(_context);
                return _orderItemRepository;
            }
        }
        /*   public IRepository<Provider> Providers
           {
               get
               {
                   if (_orderItemRepository == null)



               }
           }
        */

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose ()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
