using System.ComponentModel.DataAnnotations;

namespace GameLoanDomain.Dtos
{
    public class GameReturnedDto
    {
        [Required]
        public int IdGame { get; set; }
    }
}
