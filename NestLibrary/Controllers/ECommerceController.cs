using Microsoft.AspNetCore.Mvc;
using NestLibrary.Repositories;

namespace NestLibrary.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ECommerceController : ControllerBase
    {
        private readonly ECommerceRespository _repository;

        public ECommerceController(ECommerceRespository repository)
        {
            _repository = repository;
        }


        [HttpGet("{firstName}/{page=0}")]
        public async Task<IActionResult> TermQuery(string firstName,int page)
        {
            return Ok(await _repository.TermQuery(firstName,page));
        }

        [HttpPost("{page=0}")]
        public async Task<IActionResult> GetByNames(List<string> names, int page)
        {
            return Ok(await _repository.GetByNames(names, page));
        }

        [HttpGet("{name}/{page = 0}")]
        public async  Task<IActionResult> Prefix(string name,int page)
        {
            return Ok(await _repository.Prefix(name,page));
        }


    }
}
