using DinasCardapio.Domain.Commands;
using DinasCardapio.Domain.Handlers;
using DinasCardapio.Domain.Repositories;
using DinasCardapio.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DinasCardapio.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("v1/products")]
        public IActionResult Post([FromBody] CreateProductCommand command)
        {
            var handler = new ProductHandler(_repository);
            var result = (CommandResult) handler.Handle(command);
            return Created($"v1/products/{result.Data?.Id}", new ResultViewModel<ProductViewModel>(new ProductViewModel(result.Data)));
        }

        [HttpGet("v1/products/{id:Guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var product = _repository.GetAsync(id);
            if (!product.Errors.Any())
                return Ok(product);

            return NotFound(product);
        }

        [HttpGet("v1/products/{type:int}")]
        public IActionResult Get([FromRoute] int type)
        {
            return Ok(_repository.GetAsync(type));
        }

        [HttpGet("v1/products")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAsync());
        }
    }
}
