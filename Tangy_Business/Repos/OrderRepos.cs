using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.Repos.IRepos;
using Tangy_Models;

namespace Tangy_Business.Repos
{
    public class OrderRepos : IOrderRepos
    {
        public Task<OrderHeaderDTO> CancelOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> Create(OrderDTO objDTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetAll(string? userId = null, string? status = null)
        {
            throw new NotImplementedException();
        }

        public Task<OrderHeaderDTO> MarkPaymentSuccessful(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderHeaderDTO> UpdateHeader(OrderHeaderDTO objDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderStatus(int orderId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
