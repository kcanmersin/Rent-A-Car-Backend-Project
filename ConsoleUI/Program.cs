using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RentManager rentManager = new RentManager(new EfRentDal());

            var result3 = rentManager.Delete(new Rent { CarId = 2, CustomerId = 3, RentDate = new DateTime(2021, 12, 1) });
            Console.WriteLine(result3.Message);

          
        }
    }
}
