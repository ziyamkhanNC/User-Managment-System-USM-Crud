using System.ComponentModel.DataAnnotations;

namespace USMFrontend.Models;

public class UpdateUserDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Range(1, 120)]
    public int Age { get; set; }
}