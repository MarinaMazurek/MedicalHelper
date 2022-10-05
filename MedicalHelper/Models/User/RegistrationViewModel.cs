using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MedicalHelper.Models.User
{
    public class RegistrationViewModel
    {
        [Required]
        [EmailAddress]
        [Remote("CheckEmail", "User",
        HttpMethod = WebRequestMethods.Http.Post, ErrorMessage = "Email is already exists")]
        public string Email { get; set; }

        [Required]
        [MinLength(1)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
