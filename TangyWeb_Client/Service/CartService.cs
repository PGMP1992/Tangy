using Blazored.LocalStorage;
using Tangy_Common;
using TangyWeb_Client.Service.IService;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        public event Action OnChange;

        public CartService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService; 
        }

        public async Task Decrement(ShoppingCart CartToDecrement)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.Cart);

            for( int i= 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == CartToDecrement.ProductId && cart[i].ProductPriceId == CartToDecrement.ProductPriceId)
                {
                    if (cart[i].Count == 1 || CartToDecrement.Count == 0)
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
            OnChange.Invoke();
        }

        public async Task Increment(ShoppingCart cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.Cart);
            bool itemInCart = false;
            
            if(cart == null)
            {
                cart = new List<ShoppingCart>();
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
                cart.Add(new ShoppingCart()
                {
                    ProductId = cartToAdd.ProductId,
                    ProductPriceId = cartToAdd.ProductPriceId,
                    Count = cartToAdd.Count
                });
            }

            await _localStorage.SetItemAsync(SD.Cart, cart);
            OnChange.Invoke();

        }
    }
}
