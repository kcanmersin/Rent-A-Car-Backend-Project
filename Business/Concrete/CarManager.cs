using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Aspects.Performance;
using Core.Aspects.TransAction;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    { 
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
       /* [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        [PerformanceAspect(5)]*/
        [SecuredOperation("admin")]

        public IResult Add(Car car)
        {

            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==6)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarsListed);
        }
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), Messages.CarsListed);
            
        }

        public IDataResult<List<Car>> GetByUnitPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsListed);

        }
        public IDataResult<List<CarDetailDto>> GetCarById(int carId)
        {
            var result = _carDal.GetCarDetails(c => c.CarId == carId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(brandId));
        }
        [CacheAspect()]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(colorId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndBrandId(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorAndBrandId(colorId,brandId));
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Add(car);
            _carDal.Update(car);

            return new SuccessResult();
        }

    }
}
