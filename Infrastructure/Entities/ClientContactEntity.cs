using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ClientContactEntity
{
    [Key]
    public string Id { get; set; } = null!;
    public string? UserName { get; set; }
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Message { get; set; }
    
}
