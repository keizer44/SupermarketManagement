using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Enums;

namespace Exam.Models
{
    public class Client : Person
    {
        private decimal totalPrice;

        public int UniqueNumber { get; set; }
        public LoyalCard LoyalCard { get; set; }
        public List<Product> Products { get; set; }
        public ClientStatus Status { get; set; }
        public decimal TotalPrice
        {
            get
            {
                if (LoyalCard == null)
                {
                    totalPrice = this.Products.Sum(p => p.OverallPrice);
                }
                else
                {
                    totalPrice = this.LoyalCard.TotalPrice;
                }

                return this.totalPrice;
            }
        }

        public Client(string name, string lastName, int uniqueNumber) : base(name, lastName)
        {
            this.Products = new List<Product>();
            this.UniqueNumber = uniqueNumber;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.LastName}: Status - {this.Status}";
        }
    }
}
