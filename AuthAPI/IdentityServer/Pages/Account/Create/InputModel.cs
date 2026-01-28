using System.ComponentModel.DataAnnotations;

namespace src.Pages.Create;

public class InputModel
{
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
    public string ReturnUrl {get;set;}
    public string RoleName { get; set; }
}
