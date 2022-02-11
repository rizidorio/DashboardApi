using Dashboard.Domain.Interface.Service;
using Dashboard.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dashboard.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IOrderService _service;

        public DashboardController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("listOrders")]
        [Authorize]
        public async Task<IActionResult> List(OrderFilterModel filter)
        {
            return new ResponseController().Response(await _service.GetAll(filter));
        }
    }
}
