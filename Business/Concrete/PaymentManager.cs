﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager :IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager( IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult();
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult();
        }
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult();
        }
        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }
        public IResult Pay(Payment payment)
        {
            return new SuccessResult(Messages.PaymentSuccess);
        }
        public IDataResult<Payment> GetById(int paymentId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == paymentId));
        }
        public IDataResult<List<Payment>> GetAllByUserId(int userId)
        {
            var result = _paymentDal.GetAll(p => p.UserId == userId);
            return new SuccessDataResult<List<Payment>>(result);
        }

    }
}
