using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApp.Models;
using System.Text;

namespace PasswordGeneratorApp.Controllers
{
    public class PasswordGeneratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GeneratePassword()
        {
            // Instantiate the PasswordGeneratorModel class.
            PasswordGeneratorModel model = new PasswordGeneratorModel();

            // Return the view.
            return View(model);
        }

        [HttpPost]
        public IActionResult GeneratePassword(PasswordGeneratorModel model)
        {
            //// Validate the model.
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            // Generate a random password based on the user-specified options.
            string password = GenerateRandomPassword(model);

            model.GeneratedPassword = password;

            // Return the generated password.
            return View(model);
        }

        private string GenerateRandomPassword(PasswordGeneratorModel model)
        {
            // Create a StringBuilder object to store the generated password.
            StringBuilder password = new StringBuilder();

            // Generate a random number between 1 and the specified password length.
            int length = model.Length;

            // Create a list of all of the possible characters.
            List<char> possibleCharacters = new List<char>();

            if (model.IncludeUppercaseLetters)
            {
                possibleCharacters.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
            }

            if (model.IncludeLowercaseLetters)
            {
                possibleCharacters.AddRange("abcdefghijklmnopqrstuvwxyz".ToCharArray());
            }

            if (model.IncludeNumbers)
            {
                possibleCharacters.AddRange("0123456789".ToCharArray());
            }

            if (model.IncludeSymbols)
            {
                possibleCharacters.AddRange("!@#$%^&*()".ToCharArray());
            }

            // Iterate over the specified password length.
            for (int i = 0; i < length; i++)
            {
                // Generate a random number between 0 and the number of possible characters.
                int randomNumber = new Random().Next(0, possibleCharacters.Count);

                // Add the character at the specified index to the password.
                password.Append(possibleCharacters[randomNumber]);
            }

            // Return the generated password.
            return password.ToString();
        }
    }
}
