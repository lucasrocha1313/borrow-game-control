using System;
using System.ComponentModel.DataAnnotations;

namespace GameLoanDomain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
