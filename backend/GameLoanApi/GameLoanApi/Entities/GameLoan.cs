using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Entities
{
    public class GameLoan
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdGame { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
