using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal _rentdal;
        public RentManager(IRentDal rentdal)
        {
            _rentdal = rentdal;
        }

        public IResult Add(Rent rent)
        {
            var rentalcheck = _rentdal.Get(r => r.CarId == rent.CarId && r.ReturnDate == null);
            if (rentalcheck == null)
            {
                _rentdal.Add(rent);
                return new SuccessResult(Messages.RentAdded);

            }
            else
            {
                return new ErrorResult(Messages.CarAlreadyRented);

            }
        }

        public IDataResult<List<Rent>> GetAll()
        {
            return new SuccessDataResult<List<Rent>>(_rentdal.GetAll());
        }

        public IDataResult<Rent> GetById(int id)
        {
            return new SuccessDataResult<Rent>(_rentdal.Get(c => c.Id == id));
        }
        public IResult Delete(Rent rent)
        {
            _rentdal.Delete(rent);
            return new SuccessResult();
        }

        public IResult Update(Rent rent)
        {
            _rentdal.Update(rent);
            return new SuccessResult();
        }
    }
}
