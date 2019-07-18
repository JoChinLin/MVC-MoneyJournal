using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyJournal.Controllers;
using MoneyJournal.Models.EntityModels;
using MoneyJournal.Models.ViewModels;

namespace MoneyJournal.Services
{
    public class AccountingService
    {
        public List<MoneyUsage> GetAccountingDataList()
        {
            var result = new List<MoneyUsage>();
            using (var db = new AccountBookDbContext())
            {
                var query = db.AccountBook.Select(s => new MoneyUsage()
                {
                    CostType = ((CostCategoryEnum)s.Categoryyy).ToString(),
                    CostDate = s.Dateee,
                    Amount = s.Amounttt
                });

                result = query.ToList();
            }

            return result;
        }
    }
}