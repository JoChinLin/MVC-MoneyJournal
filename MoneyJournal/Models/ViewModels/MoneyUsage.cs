using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyJournal.Models.ViewModels
{
    public class MoneyUsage
    {
        public string CostType { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CostDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public int Amount { get; set; }

        public string Remark { get; set; }
    }
}