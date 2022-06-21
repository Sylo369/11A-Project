using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Project_Dimitar_Kuzmanov_11_A.Data.Models
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int FruitTypeId { get; set; }
        public FruitType FruitType { get; set; }
    }
}
