using System.ComponentModel.DataAnnotations;

namespace perla_metro_main_api.Dto;

public class CreationUserRequest
{
    
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
    public string LastNames { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@perlametro\.cl$", ErrorMessage = "El correo debe ser institucional (@perlametro.cl).")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", 
        ErrorMessage = "La contraseña debe contener al menos: una mayúscula, una minúscula, un número y un carácter especial.")]
    public string Password { get; set; }


    
}