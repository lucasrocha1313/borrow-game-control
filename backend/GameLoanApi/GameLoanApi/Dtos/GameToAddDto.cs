using System;
using System.ComponentModel.DataAnnotations;

namespace GameLoanApi.Dtos
{
    public class GameToAddDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Console { get; set; }
        [Required]
        public int IdUser { get; set; }
        public DateTime Created { get; set; }

        public GameToAddDto()
        {
            Created = DateTime.Now;
        }
    }
}
