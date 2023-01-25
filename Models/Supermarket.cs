using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Enums;

namespace Exam.Models
{
    public class Supermarket
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<LoyalCard> LoyalCards { get; set; }
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }

        public Supermarket(string name)
        {
            this.Name = name;
            this.Employees = new List<Employee>();
            this.LoyalCards = new List<LoyalCard>();
            this.Products = new List<Product>();
            this.Clients = new List<Client>();
        }

        public void ShowEmployeesTasks()
        {
            Console.WriteLine("Employees tasks");
            foreach (var employee in this.Employees)
            {
                Console.WriteLine(employee);
            }
        }

        public void ShowLoyalCards()
        {
            foreach (var card in this.LoyalCards)
            {
                Console.WriteLine(card);
            }
        }

        public void ShowLoyalClients()
        {
            var loyalClients = this.Clients.Where(c => c.Status.Equals(ClientStatus.Loyal));
            foreach (var client in loyalClients)
            {
                Console.WriteLine(client);
            }
        }

        public void ShowAllClients()
        {
            foreach (var client in this.Clients)
            {
                Console.WriteLine(client);
            }
        }

        public void ShowProductsForClients()
        {
            foreach (var product in this.Products)
            {
                Console.WriteLine($"[{product.Id}]{product.Name} - {product.Price}");
            }
        }

        public void ShowProductsByCategory(string category)
        {
            foreach (var product in this.Products.Where(p => p.Category.ToLower() == category.ToLower()))
            {
                Console.WriteLine(product);
            }
        }
    }
}