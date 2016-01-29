using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_6_7
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MobileContext db = new MobileContext())
            {
                Phone phone = new Phone { Name = "iPhone 6S", Price = 680 };
                db.Phones.Add(phone);
                db.SaveChanges();
                Console.WriteLine("Id - {0}, Price - {1}", phone.Id, phone.Price);
            }
            Console.ReadLine();
        }
    }
}
