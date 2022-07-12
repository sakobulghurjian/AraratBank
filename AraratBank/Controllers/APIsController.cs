using AraratBank.Models;
using AraratBank.Models.DataBase;
using AraratBank.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AraratBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class APIsController : ControllerBase
    {
        private readonly AppDBContext _context;
        public APIsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/APIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APIViewModel>>> GetAPIs()
        {
            if (_context.APIs == null)
            {
                return NotFound();
            }
            var list= await _context.APIs.ToListAsync();
            var vm=new List<APIViewModel>();
            foreach (var item in list)
            {
                vm.Add(new APIViewModel
                {
                    Date = item.Date,
                    URL = item.URL,
                    Method = item.Method.ToString()
                });
            }
            return vm;
        }
    }
}
