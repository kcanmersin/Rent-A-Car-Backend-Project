using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added!";
        public static string CarUpdated = "Car updated!";
        public static string CarDeleted = "Car deleted!";
        public static string CarsListed = "Cars Listed!";
        public static string CarNameInvalid = "Car name invalid";
        public static string MaintanceTime = "System on maintance";
        public static string RentAdded = "Car rented";
        public static string CarAlreadyRented = "Car already rented.";
        public static string AuthorizationDenied = "Authorization Denied!!!";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
        public static string PaymentSuccess = "Payment Succesfull";

        
    }
}
