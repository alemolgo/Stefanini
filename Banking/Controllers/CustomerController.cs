using Banking.Models.Entities;
using System;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Controllers
{
    public class CustomerController : Controller
    {
        public string baseUrl = "http://localhost:50293/api/";
        // GET: Customer
        public ActionResult Customer()
        {
            var customerObj = new Customer();

            if (string.IsNullOrEmpty(Request.Form["customerId"]))
                return Content("<p>" + "Debe registrar el codigo de cliente" + "</p>");
            int Customerid = Convert.ToInt32(Request.Form["customerId"]);

            customerObj = GetParialCustomer(Customerid);
            if (string.IsNullOrEmpty(customerObj.firstName))
                return Content("<p>" + "El cliente no existe" + "</p>");

            var accountList = GetAccountList(Customerid);
            if (accountList.Count == 0)
                return Content("<p>" + "El cliente no tiene cuentas asociadas" + "</p>");

            //customerObj.accountList = accountList;

            var accountA = from acc in accountList
                           where acc.accounCode == "A"
                           select acc;
            customerObj.bankAName = accountA.FirstOrDefault().bankId.ToString();
            customerObj.bankABalance = accountA.FirstOrDefault().balance;

            var accountB = from acc in accountList
                           where acc.accounCode == "B"
                           select acc;
            customerObj.bankBName = accountB.FirstOrDefault().bankId.ToString();
            customerObj.bankBBalance = accountB.FirstOrDefault().balance;

            var accountC = from acc in accountList
                           where acc.accounCode == "C"
                           select acc;
            customerObj.bankCName = accountC.FirstOrDefault().bankId.ToString();
            customerObj.bankCBalance = accountC.FirstOrDefault().balance;

            return View(customerObj);
        }

        private Customer GetParialCustomer(int Customerid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.GetAsync("Customers" + "/" + Customerid);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var customerRead = result.Content.ReadAsStringAsync().Result;
                    var customer = JsonConvert.DeserializeObject<Customer>(customerRead.ToString());
                    return customer;
                }

                else
                {
                    //return error
                }
                return new Customer();
            }
        }
        private List<Account> GetAccountList(int customerId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.GetAsync("Accounts");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var AccountRead = result.Content.ReadAsStringAsync().Result;
                    var accountsList = JsonConvert.DeserializeObject<List<Account>>(AccountRead.ToString());

                    var currentAccount = from acc in accountsList
                                         where acc.customerId == customerId
                                         select acc;

                    return currentAccount.ToList();
                }
                else
                {
                    //return error
                }
                return new List<Account>();
            }
        }
        
        public ActionResult Index()
        {
            return View();
        }


    }
}