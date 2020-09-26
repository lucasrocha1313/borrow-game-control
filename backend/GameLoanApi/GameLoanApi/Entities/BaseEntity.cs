using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
