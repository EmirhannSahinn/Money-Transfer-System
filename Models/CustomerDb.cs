using Bogus;

namespace money_transfer_system.Models
{
    //Simulation of database
    public static class CustomerDb
    {
        public static List<Customer> Customers = new List<Customer>();

        public static void InitializeDb(int number)
        {
            if (Customers.Count == 0)
            {
                for (int i = 1; i <= number; i++)
                {
                    var customer = new Faker<Customer>()
                        .RuleFor(c => c.Id, f => i)
                        .RuleFor(c => c.Name, f => f.Name.FullName())
                        .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name))
                        .RuleFor(c => c.Money, f => f.Random.Float(100000, 500000));

                    Customers.Add(customer);
                }

            }

        }
    }
}
