using System.ComponentModel.DataAnnotations;

namespace PasswordGeneratorApp.Models
{
    public class PasswordGeneratorModel
    {
        [Range(8, 50, ErrorMessage = "The password length must be at least 8 characters.")]
        public int Length { get; set; } = 12;
        public bool IncludeUppercaseLetters { get; set; } = true;
        public bool IncludeLowercaseLetters { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSymbols { get; set; } = false;
        public string GeneratedPassword { get; set; }
    }
}
