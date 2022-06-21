using Fruit_Project_Dimitar_Kuzmanov_11_A.Data;
using Fruit_Project_Dimitar_Kuzmanov_11_A.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Project_Dimitar_Kuzmanov_11_A.Business
{
   public class FruitBusiness
    {
        private FruitContext fruitContext = new FruitContext();
        public List<Fruit> GetAll()
        {

            return fruitContext.Fruits.Include("FruitType").ToList();
        }
        public Fruit Get(int id)
        {
            Fruit find = fruitContext.Fruits.Find(id);
            if (find != null)
            {
                fruitContext.Entry(find).Reference(x => x.FruitType).Load();
            }
            return find;
        }
        public void Add(Fruit fruit)
        {
            fruitContext.Fruits.Add(fruit);
            fruitContext.SaveChanges();
        }
        public void Update(int id, Fruit fruit)
        {
            Fruit fruit1 = fruitContext.Fruits.Find(id);
            if (fruit1 == null)
            {
                return;
            }
            fruit1.Name = fruit.Name;
            fruit1.Description = fruit.Description;
            fruit1.Price = fruit1.Price;
            fruit1.FruitTypeId = fruit.FruitTypeId;
            fruitContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Fruit fruit1 = fruitContext.Fruits.Find(id);
            fruitContext.Fruits.Remove(fruit1);
            fruitContext.SaveChanges();
        }
    }
}
