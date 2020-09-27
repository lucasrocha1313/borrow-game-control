using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Dtos
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
