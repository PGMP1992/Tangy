using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Tangy_Business.Repos.IRepos;
using Tangy_Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TangyWeb_API.Controllers
{
    //[Route("api/[controller]/[action]")]
    //[ApiController]

    //public class OrderController : ControllerBase
    //{
    //    private readonly IOrderRepos _orderRepos;
    //    private readonly IEmailSender _emailSender;

    //    public OrderController(IOrderRepos orderRepos, IEmailSender emailSender)
    //    {
    //        _orderRepos = orderRepos;
    //        _emailSender = emailSender;
    //    }
    //    // GET: api/<OrderController>
    //    [HttpGet]
    //    public async Task<ActionResult> GetAll()
    //    {
    //        return Ok(await _orderRepos.GetAll());
    //    }

    //    // GET api/<OrderController>/5
    //    [HttpGet("{orderHeaderId}")]
    //    public async Task<IActionResult> Get(int? orderHeaderId)
    //    {
    //        if (orderHeaderId == null || orderHeaderId == 0)
    //        {
    //            return BadRequest(new ErrorModelDTO()
    //            {
    //                ErrorMessage = "Invalid Id",
    //                StatusCode = StatusCodes.Status400BadRequest
    //            });
    //        }

    //        var orderHeader = await _orderRepos.Get(orderHeaderId.Value);
    //        if (orderHeader == null)
    //        {
    //            return BadRequest(new ErrorModelDTO()
    //            {
    //                ErrorMessage = "Invalid Id",
    //                StatusCode = StatusCodes.Status404NotFound
    //            });
    //        }

    //        return Ok(orderHeader);
    //    }

    //    //[HttpPost]
    //    //[ActionName("Create")]
    //    //public async Task<IActionResult> Create([FromBody] StripePaymentDTO paymentDTO)
    //    //{
    //    //    paymentDTO.Order.OrderHeader.OrderDate = DateTime.Now;
    //    //    var result = await _orderRepos.Create(paymentDTO.Order);
    //    //    return Ok(result);
    //    //}

    //    //[HttpPost]
    //    //[ActionName("paymentsuccessful")]
    //    //public async Task<IActionResult> PaymentSuccessful([FromBody] OrderHeaderDTO orderHeaderDTO)
    //    //{
    //    //    var service = new SessionService();
    //    //    var sessionDetails = service.Get(orderHeaderDTO.SessionId);
    //    //    if (sessionDetails.PaymentStatus == "paid")
    //    //    {
    //    //        var result = await _orderRepos.MarkPaymentSuccessful(orderHeaderDTO.Id);
    //    //        await _emailSender.SendEmailAsync(orderHeaderDTO.Email, "Tangy Order Confirmation",
    //    //            "New Order has been created :" + orderHeaderDTO.Id);
    //    //        if (result == null)
    //    //        {
    //    //            return BadRequest(new ErrorModelDTO()
    //    //            {
    //    //                ErrorMessage = "Can not mark payment as successful"
    //    //            });
    //    //        }
    //    //        return Ok(result);
    //    //    }
    //    //    return BadRequest();
    //    //}
    //}
}
