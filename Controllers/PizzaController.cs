using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaService _service;

    public PizzaController(PizzaService service)
    {
        this._service = service;
    }

    [HttpGet]
    public IEnumerable<Pizza> GetAll() => _service.GetAll();

    [HttpGet("{id}")]
    public Pizza? GetById(int id) => _service.Get(id);

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        var pizzaCreated = _service.Add(pizza);

        return pizzaCreated != null ? CreatedAtAction("CREATE", pizzaCreated) : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        pizza.Id = id;
        var result = _service.Update(pizza);

        return result ? CreatedAtAction("UPDATE", pizza) : BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);

        return NoContent();
    }
}