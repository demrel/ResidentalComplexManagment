﻿using ResidentalComplexManagment.Application.Models;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models.Residents
{
    public class ResidentAddDebtItemsVM
    {
        public List<ResidentDebtItemDTOListItem> DebtItems { get; set; }
        public string ResidentId {get; set;}
    }
}
