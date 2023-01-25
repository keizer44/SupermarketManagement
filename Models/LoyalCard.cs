using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class LoyalCard
    {
        private decimal priceWithDiscount;

        public string Info { get; set; }
        public List<Product> Products { get; set; }
        public int CardNumber { get; set; }
        public decimal TotalPrice
        {
            get
            {
                this.priceWithDiscount = this.Products.Sum(p => p.OverallPrice);

                if (this.priceWithDiscount <= 10000m)
                {
                    this.priceWithDiscount = this.priceWithDiscount - (this.priceWithDiscount / (100 * 0.03m));
                }
                else if (this.priceWithDiscount > 10000m && this.priceWithDiscount <= 50000m)
                {
                    this.priceWithDiscount = this.priceWithDiscount - (this.priceWithDiscount / (100 * 0.05m));
                }
                else if (this.priceWithDiscount > 50000m)
                {
                    this.priceWithDiscount = this.priceWithDiscount - (this.priceWithDiscount / (100 * 0.1m));
                }

                return this.priceWithDiscount;
            }
        }

        public LoyalCard()
        {
            this.Products = new List<Product>();
        }

        public override string ToString()
        {
            return $"{this.Info} - CardNumber:{this.CardNumber}";
        }
    }
}
