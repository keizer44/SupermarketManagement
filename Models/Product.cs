using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Enums;

namespace Exam.Models
{
    public class Product
    {
        private static int id;

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OverallPrice
        {
            get
            {
                return this.Price * (decimal)this.Quantity;
            }
        }
        public int Quantity { get; set; }
        public string ExpireDate { get; set; }
        public string Category { get; set; }

        public Product(string name, decimal price, int quantity, string expireDate, string category)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.ExpireDate = expireDate;
            this.Category = category;
            this.Id = id++;
        }

        public override string ToString()
        {
            return $"[{this.Id}]{this.Name} - Price:{this.Price}lv, Quantity{this.Quantity}, Expire Date:{this.ExpireDate}, Category:{this.Category}\nOverall Price:{this.OverallPrice}";
        }
    }
}
