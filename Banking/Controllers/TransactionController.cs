using Banking.Models.Entities;
using Banking.Models.Enums;
using System;
using System.Web.Mvc;

namespace Banking.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Withdrawal()
        {
            if (string.IsNullOrEmpty(Request.Form["transactionValue"]))
                return Content("<p>" + "Debe registrar el valor de la transacción" + "</p>");

            decimal transactionValue = Convert.ToDecimal(Request.Form["transactionValue"]);

            string select = Request.Form["select"].ToString();
            if (select == "item 0")
                return Content("<p>" + "Debe seleccionar el tipo de transacción" + "</p>");

            var transaction = new Transaction { amount = transactionValue, transactionType = (TransactionType)Convert.ToInt32(select.Substring(5, 1)) };

            ExcuteTransaction(transaction);
            return View();

        }
        private void ExcuteTransaction(Transaction Transaction)
        {

        }
    }
}