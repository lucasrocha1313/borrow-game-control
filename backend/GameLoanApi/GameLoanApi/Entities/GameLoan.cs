using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLoanApi.Entities
{
    [Table("game_loan")]
    public class GameLoan: BaseEntity
    {
        [Column("id_friend")]
        public int IdFriend { get; set; }
        [Column("id_game")]
        public int IdGame { get; set; }
        [Column("return_date")]
        public DateTime ReturnDate { get; set; }

        public FriendUser FriendWithGame{ get; set; }
        public List<GameUser> GamesLoan{ get; set; }
    }
}
