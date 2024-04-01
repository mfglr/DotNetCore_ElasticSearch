using Microsoft.AspNetCore.Http;
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


        [HttpGet("{firstName}/{page}")]
        public async Task<IActionResult> TermQuery(string firstName,int page)
        {
            return Ok(await _repository.TermQuery(firstName,page));
        }

    }
}
