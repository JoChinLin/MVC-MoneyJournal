using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoneyJournal.Models.EntityModels;
using MoneyJournal.Models.ViewModels;
using MoneyJournal.Services;

namespace MoneyJournal.Controllers
{
    public class HomeController : Controller
    {
        private List<MoneyUsage> dataInit = null;
        private AccountingService _accountingService = null;
        public HomeController()
        {

            if (dataInit == null)
            {
                dataInit = this.GetMoneyUsageData();
            }
            if (_accountingService == null)
            {
                _accountingService=new AccountingService();
                
            }
        }

        public ActionResult Index()
        {
            var dataList = new List<MoneyUsage>();

            dataList = _accountingService.GetAccountingDataList();

            return View(dataList);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        private List<MoneyUsage> GetMoneyUsageData()
        {


            var types = new string[] { "支出", "收入" };

            var resultList = new List<MoneyUsage>();

            for (var i = 1; i < 101; i++)
            {
                var randomGen = new RandomGenerator();

                var data = new MoneyUsage();

                data.CostType = types[randomGen.RandomCostType(i)];

                data.CostDate = randomGen.RandomCostDate(i);

                data.Amount = randomGen.RandomAmount(i);

                resultList.Add(data);
            }

            return resultList;
        }


    }
    public enum CostCategoryEnum
    {
        支出 = 0,
        收入 = 1
    }

    internal class RandomGenerator
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public int RandomAmount(int num)
        {
            lock (syncLock)
                return random.Next(100, 30000);

        }

        public DateTime RandomCostDate(int num)
        {
            DateTime start = new DateTime(2018, 1, 1);
            var range = (DateTime.Today - start).Days;

            var max = 0;
            var min = 0;
            if (range > num)
            {
                max = range;
                min = num;
            }
            else
            {
                max = num;
                min = range;
            }
            var date = start.AddDays(random.Next(min, max));


            lock (syncLock)
                return date;

        }
        public int RandomCostType(int num)
        {
            lock (syncLock)
                return random.Next(0, 2);

        }
    }


}