using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLoanApi.Entities
{
    [Table("games_user")]
    public class GameUser: BaseEntity
    {
        public string Title { get; set; }
        public string Console { get; set; }

        public int IdUser { get; set; }
        public User UserOwner { get; set; }

        public GameLoan Loaned { get; set; }
    }
}
