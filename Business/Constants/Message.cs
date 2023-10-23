using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        // Araba işlemleri
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarAddError = "Araba eklenirken bir hata oluştu.";
        public static string CarUpdated = "Araba bilgileri güncellendi.";
        public static string CarUpdateError = "Araba güncellenirken bir hata oluştu.";
        public static string CarDeleted = "Araba başarıyla silindi.";
        public static string CarDeleteError = "Araba silinirken bir hata oluştu.";
        public static string CarsListed = "Arabalar başarıyla listelendi.";
        public static string CarsListError = "Arabalar listelenirken bir hata oluştu.";
        public static string CarDetailListed = "Arabalar detaylı olarak listelendi.";
        public static string CarByColorListed = "Araba rengine göre listelendi.";

        // Kullanıcı işlemleri
        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UserAddError = "Kullanıcı eklenirken bir hata oluştu.";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi.";
        public static string UserUpdateError = "Kullanıcı güncellenirken bir hata oluştu.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        public static string UserDeleteError = "Kullanıcı silinirken bir hata oluştu.";
        public static string UsersListed = "Kullanıcılar başarıyla listelendi.";
        public static string UsersListError = "Kullanıcılar listelenirken bir hata oluştu.";
        public static string UserListed = "Kullanıcı başarıyla listelendi.";

        // Müşteri işlemleri
        public static string CustomerAdded = "Müşteri başarıyla eklendi.";
        public static string CustomerAddError = "Müşteri eklenirken bir hata oluştu.";
        public static string CustomersListed = "Müşteriler başarıyla listelendi.";
        public static string CustomersListError = "Müşteriler listelenirken bir hata oluştu.";
        public static string CustomerListed = "Müşteri başarıyla listelendi.";
        public static string CustomerDetailListed = "Müşteri bilgileri detaylı olarak listelendi.";

        // Araba kiralama işlemleri
        public static string RentalAdded = "Araba kiralama işlemi başarıyla tamamlandı.";
        public static string RentalAddError = "Araba kiralama işlemi sırasında bir hata oluştu.";
        public static string RentalUpdated = "Araba kiralama işlemi başarıyla güncellendi.";
        public static string RentalUpdateError = "Araba kiralama işlemi güncellenirken bir hata oluştu.";
        public static string RentalDeleted = "Araba kiralama işlemi başarıyla silindi.";
        public static string RentalDeleteError = "Araba kiralama işlemi silinirken bir hata oluştu.";
        public static string RentalsListed = "Kiralanan arabalar başarıyla listelendi.";
        public static string RentalsListError = "Kiralanan arabalar listelenirken bir hata oluştu.";
        public static string RentalListed = "Kiralanan araba başarıyla listelendi.";
        public static string RentalDetailListed = "Kiralama bilgileri detaylı olarak listelendi.";
        public static string ReturnDateMissing = "Teslim tarihi belirtilmemiş.";

        // Araba Resim işlemleri
        public static string CarImageAdded = "Araba resmi başarıyla eklendi.";
        public static string CarImageAddError = "Araba resmi eklenirken bir hata oluştu.";
        public static string CarImageUpdated = "Araba resmi başarıyla güncellendi.";
        public static string CarImageUpdateError = "Araba resmi güncellenirken bir hata oluştu.";
        public static string CarImageDeleted = "Araba resmi başarıyla silindi.";
        public static string CarImageDeleteError = "Araba resmi silinirken bir hata oluştu.";
        public static string CarImageCountError = "Bir arabanın en fazla {0} resmi olabilir.";
        public static string CarImagesListed = "Araba için resimler başarıyla listelendi.";
        public static string CarImagesListError = "Araba için resimler listelenirken bir hata oluştu.";
    }
}
