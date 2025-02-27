﻿using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service.IService
{
    public interface ICartService
    {
        public event Action OnChange;
        Task Decrement(ShoppingCart Cart);
        Task Increment(ShoppingCart Cart);
    }
}
