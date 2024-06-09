using Microsoft.AspNetCore.Mvc;
using money_transfer_system.Models;

namespace money_transfer_system.Controllers
{
    public class CustomersController : Controller
    {
        public CustomersController()
        {
            CustomerDb.InitializeDb(15);
        }

        public IActionResult Index()
        {
            var customers = CustomerDb.Customers.OrderBy(p => p.Id).ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var maxId = CustomerDb.Customers.Max(p => p.Id) + 1;

            customer.Id = maxId;

            if (ModelState.IsValid)
            {
                CustomerDb.Customers.Add(customer);

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int customerId)
        {
            var customer = CustomerDb.Customers.FirstOrDefault(p => p.Id == customerId);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {

            if (ModelState.IsValid)
            {
                var toBeRemoved = CustomerDb.Customers.FirstOrDefault(p => p.Id == customer.Id);

                CustomerDb.Customers.Remove(toBeRemoved);

                CustomerDb.Customers.Add(customer);

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int customerId)
        {
            var customer = CustomerDb.Customers.FirstOrDefault(p => p.Id == customerId);

            CustomerDb.Customers.Remove(customer);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Transfer(int customerId)
        {
            return View();

        }

        [HttpPost]
        public IActionResult Transfer(TransferModel model)
        {

            if (ModelState.IsValid)
            {
                var fromCustomer = CustomerDb.Customers.FirstOrDefault(p => p.Id == model.FromCustomerId);
                var toCustomer = CustomerDb.Customers.FirstOrDefault(p => p.Id == model.ToCustomerId);

                if (fromCustomer == null)
                {
                    ModelState.AddModelError("FromCustomerId", "Sender customer ID not found.");
                }

                if (toCustomer == null)
                {
                    ModelState.AddModelError("ToCustomerId", "Recipient customer ID not found.");
                }

                if (fromCustomer != null && toCustomer != null)
                {
                    if (fromCustomer.Money < model.Amount)
                    {
                        ModelState.AddModelError("Amount", "Insufficient funds.");
                        return View(model);
                    }

                    fromCustomer.Money -= model.Amount;
                    toCustomer.Money += model.Amount;

                    return RedirectToAction("Index");
                }
            }

            return View(model);

        }
    }
}