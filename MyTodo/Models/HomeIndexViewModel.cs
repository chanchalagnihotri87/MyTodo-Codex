using MyTodo.Domain.Entities;

namespace MyTodo.Models;

public class HomeIndexViewModel
{
    public IReadOnlyList<LifeArea> LifeAreas { get; init; } = [];
}
