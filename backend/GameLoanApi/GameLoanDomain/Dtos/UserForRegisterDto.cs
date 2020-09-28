using System;
using System.ComponentModel.DataAnnotations;

namespace GameLoanDomain.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 caracters")]
        public string Password { get; set; }
        public DateTime Created { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
        }
    }
}
