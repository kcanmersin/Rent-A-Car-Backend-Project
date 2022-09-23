using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {

                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                             CarName = c.CarName,
                             BrandName = b.BrandName,
                             ColorName = co.ColorName,
                             DailyPrice = c.DailyPrice,
                             ModelYear = c.ModelYear,
                             Description=c.Description,
                             UnitsInStock=c.UnitsInStock,
                             CarId=c.CarId,
                             BrandId=c.BrandId,
                             ColorId=c.ColorId,
                             ImagePath = (from img in context.CarImages
                                              where img.CarId == c.CarId
                                              select img.ImagePath).FirstOrDefault()
                             };
                return filter != null ? result.Where(filter).ToList() : result.ToList();

            }

        }
        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var res = from c in context.Cars
                          join color in context.Colors
                          on c.ColorId equals color.ColorId
                          join bra in context.Brands

                          on c.BrandId equals bra.BrandId
                          where bra.BrandId == brandId
                          select new CarDetailDto
                          {
                              CarId = c.CarId,
                              CarName = c.CarName,
                              BrandName = bra.BrandName,
                              ColorName = color.ColorName,
                              Description = c.Description,
                              DailyPrice = c.DailyPrice,
                              ModelYear = c.ModelYear

                          };



                return res.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var res = from c in context.Cars
                          join color in context.Colors
                          on c.ColorId equals color.ColorId
                          join bra in context.Brands

                          on c.BrandId equals bra.BrandId
                          where color.ColorId == colorId
                          select new CarDetailDto
                          {
                              CarId = c.CarId,
                              CarName = c.CarName,
                              BrandName = bra.BrandName,
                              ColorName = color.ColorName,
                              Description = c.Description,
                              DailyPrice = c.DailyPrice,
                              ModelYear = c.ModelYear

                          };



                return res.ToList();

            }
        }
        public List<CarDetailDto> GetCarDetailsByColorAndBrandId(int colorId, int brandId)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var res = from c in context.Cars
                          join color in context.Colors
                          on c.ColorId equals color.ColorId
                          join bra in context.Brands

                          on c.BrandId equals bra.BrandId
                          where color.ColorId == colorId && bra.BrandId == brandId
                          select new CarDetailDto
                          {
                              CarId = c.CarId,
                              CarName = c.CarName,
                              BrandName = bra.BrandName,
                              ColorName = color.ColorName,
                              Description = c.Description,
                              DailyPrice = c.DailyPrice,
                              ModelYear = c.ModelYear

                          };



                return res.ToList();

            }
        }

    }
}
