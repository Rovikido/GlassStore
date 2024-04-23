using GlassStore.Server.Domain.Models.Glass;
using GlassStore.Server.Domain.Models.User;
using GlassStore.Server.Repositories.Interfaces;
using GlassStore.Server.Servise.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlassStore.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserServise userServise;
        private readonly iBaseRepository<Glasses> glasses;

        public TestController(UserServise userServise, iBaseRepository<Glasses> glasses)
        {
            this.userServise = userServise;
            this.glasses = glasses;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                //await userServise.AddOrder(new Orders()
                //{
                //    Glasses = (await glasses.GetFirstAsync(1)).data.ToList(),
                //});

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
