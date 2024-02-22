using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }

        public IActionResult GetAll()
        {
            var allPies = pieRepository.AllPies;
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pie = pieRepository.AllPies.FirstOrDefault(x => x.PieId == id);

            if (pie is null)
                return NotFound();

            return Ok(pie);
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody]string query)
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if(!string.IsNullOrWhiteSpace(query))
            {
                pies = pieRepository.SearchPies(query);
            }

            return new JsonResult(pies);
        }
    }
}
