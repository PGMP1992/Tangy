using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service.IService
{
    public interface ICartService
    {
        Task Decrement(Cart Cart);
        Task Increment(Cart Cart);
    }
}
