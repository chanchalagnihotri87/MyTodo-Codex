using System.ComponentModel.DataAnnotations;

namespace MyTodo.Models;

public class EditLifeAreaViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Life area name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(1_000)]
    public string? Description { get; set; }

}
