using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLoanDomain.Entities
{
    [Table("friends_user")]
    public class FriendUser : BaseEntity
    {
        [Column("name_friend")]
        public string NameFriend { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }
        public User User { get; set; }
        public List<GameLent> GamesBorrowed { get; set; }
    }
}
