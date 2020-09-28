using System;
using System.ComponentModel.DataAnnotations;

namespace GameLoanDomain.Dtos
{
    public class GameToLentDto
    {
        [Required]
        public int IdGame { get; set; }
        public DateTime Created { get; set; }

        public GameToLentDto()
        {
            Created = DateTime.Now;
        }
    }
}
