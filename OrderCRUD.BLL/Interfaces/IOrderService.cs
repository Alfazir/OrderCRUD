using OrderCRUD.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCRUD.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDTO);
       // OrderItemDTO GetOrder(int id);
       // IEnumerable<OrderDTO> GetOrders();
        void Dispose();
    }
}
