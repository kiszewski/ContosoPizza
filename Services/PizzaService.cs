using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService


{
    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context)
    {
        this._context = context;
    }


    public IEnumerable<Pizza> GetAll() => _context.Pizzas
        .AsNoTracking()
        .ToList();

    public Pizza? Get(int id) => _context.Pizzas
        .Include(p => p.Toppings)
        .Include(p => p.Sauce)
        .AsNoTracking()
        .SingleOrDefault(p => p.Id == id);

    public Pizza Add(Pizza pizza)
    {
        _context.Add(pizza);
        _context.SaveChanges();
        return pizza;
    }

    public bool Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return false;

        _context.Remove(pizza);
        _context.SaveChanges();

        return true;
    }

    public bool Update(Pizza pizza)
    {
        _context.Update(pizza);
        _context.SaveChanges();
        return true;
    }
}