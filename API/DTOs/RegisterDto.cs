using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Please Enter Your Name!!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email!!")]
        [EmailAddress(ErrorMessage = "Invalid Email!!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password!!")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,20}$", ErrorMessage = "Password must be at least 4 characters, no more than 20 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.")]
        public string password { get; set; }
        [Required(ErrorMessage = "Please Enter Your Age!!")]
        [Range(18,100,ErrorMessage = "You have to be 18+ to be able to register")]
        public int Age { get; set; }
    }
}

// Data Validation
// https://www.simplilearn.com/tutorials/asp-dot-net-tutorial/data-annotation-attributes-in-asp-dot-net-mvc
// https://www.roundthecode.com/dotnet/data-annotation-model-validation-aspnet-core

// Regex
//https://regexlib.com/Search.aspx?k=password

// Users
//=================================
//{
//    "userName":"Karim Ali",
//    "password":"Karim123",
//    "Email":"k@hotmail.com",
//    "Age":26
//}
//{
//    "userName":"Marawan Ali",
//    "password":"Marawan123",
//    "Email":"m@hotmail.com",
//    "Age":22
//}
//{
//    "userName":"Moataz Ali",
//    "password":"Moataz123",
//    "Email":"moa@hotmail.com",
//    "Age":18
//}
//{
//    "userName":"Rana Youssef",
//    "password":"Rana123",
//    "Email":"r@hotmail.com",
//    "Age":25
//}

