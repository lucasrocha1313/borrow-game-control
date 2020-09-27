using System.ComponentModel.DataAnnotations;

namespace GameLoanApi.Dtos
{
    public class GameReturnedDto
    {
        [Required]
        public int IdGame { get; set; }
    }
}
