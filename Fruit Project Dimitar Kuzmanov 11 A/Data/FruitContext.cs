using Fruit_Project_Dimitar_Kuzmanov_11_A.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Project_Dimitar_Kuzmanov_11_A.Data
{
    public class FruitContext : DbContext
    {
        public FruitContext() : base("name=FruitContext")
        {

        }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitType> FruitTypes { get; set; }
    }
}
