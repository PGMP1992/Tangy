using Blazored.LocalStorage;
using Tangy_Common;
using TangyWeb_Client.Service.IService;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        public CartService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService; 
        }

        public async Task Decrement(Cart CartToDecrement)
        {
            var cart = await _localStorage.GetItemAsync<List<Cart>>(SD.Cart);

            for( int i= 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == CartToDecrement.ProductId && cart[i].ProductPriceId == CartToDecrement.ProductPriceId)
                {
                    if (cart[i].Count == 1 || cart[i].Count == 0)
                    {
                        cart.Remove(cart[i]);
                    }
                    else
                    {
                        cart[i].Count -= CartToDecrement.Count;
                    }
                }
            }
            
            await _localStorage.SetItemAsync(SD.Cart, cart);
        }

        public async Task Increment(Cart cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<Cart>>(SD.Cart);
            bool itemInCart = false;
            
            if(cart == null)
            {
                cart = new List<Cart>();
            }

            foreach ( var obj in cart)
            {
                if( obj.ProductId == cartToAdd.ProductId && obj.ProductPriceId == cartToAdd.ProductPriceId) 
                {
                    itemInCart = true;
                    obj.Count += cartToAdd.Count; 
                }
            }

            if(! itemInCart)
            {
                cart.Add(new Cart()
                {
                    ProductId = cartToAdd.ProductId,
                    ProductPriceId = cartToAdd.ProductPriceId,
                    Count = cartToAdd.Count
                });
            }

            await _localStorage.SetItemAsync(SD.Cart, cart);

        }
    }
}
