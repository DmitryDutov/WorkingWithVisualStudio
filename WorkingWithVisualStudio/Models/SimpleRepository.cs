using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        //поля класса
        private static SimpleRepository sharedRepsitory = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        //свойство класса
        public static SimpleRepository SharedRepsitory => sharedRepsitory;
        //создаём метод который заполняет словарь products объектами
        public void AddProduct(Product p) => products.Add(p.Name, p);

        //конструктор класса
        public SimpleRepository()
        {
            var initialItems = new[]
            {
                  new Product{ Name="Prod-001", Price=275M }
                , new Product{ Name="Prod-002", Price=50.5M }
                , new Product{ Name="Prod-003", Price=19.5M }
                , new Product{ Name="Prod-004", Price=19.5M }
            };

            foreach (var p in initialItems )
            {
                AddProduct(p);
            }
        }

        //создаём нумерованное множество Products и заполяем значениями приватного поля (словаря)products
        public IEnumerable<Product> Products => products.Values;
    }
}

