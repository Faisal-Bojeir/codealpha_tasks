﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Tables.Dtos
{
    public class UpdateTableDto
    {
        public string? Number { get; set; }
        public int? Seats { get; set; }
    }
}
