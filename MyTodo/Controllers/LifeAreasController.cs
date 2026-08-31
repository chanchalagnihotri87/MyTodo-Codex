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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var lifeArea = await _context.LifeAreas.FindAsync(id);
        if (lifeArea is null)
        {
            return NotFound();
        }

        return View(new EditLifeAreaViewModel
        {
            Id = lifeArea.Id,
            Name = lifeArea.Name,
            Description = lifeArea.Description,
            IsActive = lifeArea.IsActive
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditLifeAreaViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        if (string.IsNullOrWhiteSpace(model.Name))
        {
            ModelState.AddModelError(nameof(model.Name), "The life area name is required.");
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var lifeArea = await _context.LifeAreas.FindAsync(id);
        if (lifeArea is null)
        {
            return NotFound();
        }

        lifeArea.Name = model.Name.Trim();
        lifeArea.Description = string.IsNullOrWhiteSpace(model.Description) ? null : model.Description.Trim();
        lifeArea.IsActive = model.IsActive;
        lifeArea.UpdatedAtUtc = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = $"{lifeArea.Name} was updated.";
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var lifeArea = await _context.LifeAreas.FindAsync(id);
        if (lifeArea is null)
        {
            return NotFound();
        }

        return View(new DeleteLifeAreaViewModel
        {
            Id = lifeArea.Id,
            Name = lifeArea.Name,
            Description = lifeArea.Description
        });
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var lifeArea = await _context.LifeAreas.FindAsync(id);
        if (lifeArea is null)
        {
            return NotFound();
        }

        _context.LifeAreas.Remove(lifeArea);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = $"{lifeArea.Name} was deleted.";
        return RedirectToAction("Index", "Home");
    }
}
