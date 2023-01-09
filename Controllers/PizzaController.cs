using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet]
    public IEnumerable<Pizza> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public Pizza? GetById(int id) => PizzaService.Get(id);

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        var result = PizzaService.Add(pizza);

        return result ? CreatedAtAction("CREATE", pizza) : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        pizza.Id = id;
        var result = PizzaService.Update(pizza);

        return result ? CreatedAtAction("UPDATE", pizza) : BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        PizzaService.Delete(id);

        return NoContent();
    }
}