﻿using Tangy_Models;

namespace Tangy_Business.Repos.IRepos
{
    public interface IOrderRepos
    {
        public Task<OrderDTO> Get(int id);
        public Task<IEnumerable<OrderDTO>> GetAll( string? userId = null, string? status  = null);
        public Task<OrderDTO> Create(OrderDTO objDTO);
        public Task<int> Delete(int id);

        public Task<OrderHeaderDTO> UpdateHeader(OrderHeaderDTO objDTO);
        public Task<OrderHeaderDTO> MarkPaymentSuccessful(int id);
        public Task<bool> UpdateOrderStatus(int orderId, string status);

        public Task<OrderHeaderDTO> CancelOrder(int id);
    }
}
