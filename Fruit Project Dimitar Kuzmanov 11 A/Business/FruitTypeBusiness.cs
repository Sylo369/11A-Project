using Fruit_Project_Dimitar_Kuzmanov_11_A.Data;
using Fruit_Project_Dimitar_Kuzmanov_11_A.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Project_Dimitar_Kuzmanov_11_A.Business
{
    class FruitTypeBusiness
    {
        private FruitContext fruitTypeContext = new FruitContext();
        public List<FruitType> GetAllTypes()
        {
            return fruitTypeContext.FruitTypes.ToList();
        }
        public string GetType(int id)
        {
            return fruitTypeContext.FruitTypes.Find(id).Name;
        }


    }
}
