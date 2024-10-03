namespace Infrastructure.Dtos;

public class ClientContactDto
{
    public string? UserName { get; set; }
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Message { get; set; }
}