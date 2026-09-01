namespace MyTodo.Domain.Entities;

/// <summary>
/// Represents a high-level area of a user's life, such as Health, Career, or Relationships.
/// </summary>
public class LifeArea
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAtUtc { get; set; }
}
