using System.ComponentModel.DataAnnotations.Schema;

namespace GameLoanApi.Entities
{
    [Table("games_user")]
    public class GameUser: BaseEntity
    {
        public string Title { get; set; }
        public string Console { get; set; }
        [Column("id_user")]
        public int IdUser { get; set; }
        public User UserOwner { get; set; }

        public GameLent Loaned { get; set; }
    }
}
