using System.ComponentModel.DataAnnotations;

namespace GameLoanDomain.Dtos
{
    public class FriendToAddDto
    {
        [Required]
        public string NameFriend { get; set; }

        [Required]
        public int IdUser { get; set; }
    }
}
