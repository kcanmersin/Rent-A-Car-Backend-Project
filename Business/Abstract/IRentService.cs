using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentService
    {
        IDataResult<List<Rent>> GetAll();
        IDataResult<Rent> GetById(int id);
        IResult Add(Rent rent);
    }
}
