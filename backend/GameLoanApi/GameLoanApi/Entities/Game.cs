﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Console { get; set; }
    }
}