namespace Tangy_DataAccess.ViewModels

{
    public class Order
    {
        public OrderHeader OrderHeader { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }

    }
}
