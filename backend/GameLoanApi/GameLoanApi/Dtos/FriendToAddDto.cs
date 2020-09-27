using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Dtos
{
    public class FriendToAddDto
    {
        [Required]
        public string NameFriend { get; set; }

        [Required]
        public int IdUser { get; set; }
    }
}
