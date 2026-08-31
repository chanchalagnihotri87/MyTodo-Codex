using Microsoft.AspNetCore.Mvc;
using MyTodo.Data;
using MyTodo.Domain.Entities;
using MyTodo.Models;

namespace MyTodo.Controllers;

public class LifeAreasController : Controller
{
    private readonly TodoContext _context;

    public LifeAreasController(TodoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateLifeAreaViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateLifeAreaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var lifeArea = new LifeArea
        {
            Name = model.Name.Trim(),
            Description = string.IsNullOrWhiteSpace(model.Description) ? null : model.Description.Trim()
        };

        _context.LifeAreas.Add(lifeArea);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = $"{lifeArea.Name} was created.";
        return RedirectToAction("Index", "Home");
    }
}
