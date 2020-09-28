using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLoanApi.Entities
{
    [Table("users")]
    public class User: BaseEntity
    {
        public string Username { get; set; }
        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }
        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }
        public List<FriendUser> FriendsUser { get; set; }
        public List<GameUser> Games { get; set; }

        public bool Valid()
        {
            return !string.IsNullOrEmpty(Username)
                && Created != DateTime.MinValue;
        }
    }
}
