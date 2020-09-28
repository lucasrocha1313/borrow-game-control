using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLoanDomain.Entities
{
    [Table("games_loaned")]
    public class GameLent : BaseEntity
    {
        [Column("id_friend")]
        public int IdFriend { get; set; }
        [Column("id_game")]
        public int IdGame { get; set; }
        [Column("return_date")]
        public DateTime? ReturnDate { get; set; } = null;

        public FriendUser FriendWithGame { get; set; }
        public List<GameUser> GamesLoan { get; set; }
    }
}
