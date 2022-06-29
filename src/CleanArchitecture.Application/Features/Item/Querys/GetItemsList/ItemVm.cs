﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.Common;

namespace CleanArchitecture.Application.Features.Item.Querys.GetItemsList
{
    public class ItemVm : BaseApplicationModel
    {
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
