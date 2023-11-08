namespace Business.Constants
{
    public class Messages
    {
        #region en-US
        //Car operations
        public static string CarAdded = "Car has been added successfully.";
        public static string CarAddError = "An error occurred while adding the car.";
        public static string CarUpdated = "Car information has been updated.";
        public static string CarUpdateError = "An error occurred while updating the car.";
        public static string CarDeleted = "Car has been deleted successfully.";
        public static string CarDeleteError = "An error occurred while deleting the car.";
        public static string CarsListed = "Cars have been listed successfully.";
        public static string CarsListError = "An error occurred while listing the cars.";
        public static string CarDetailListed = "Cars have been listed in detail.";
        public static string CarByColorListed = "Cars listed by color.";

        // User operations
        public static string UserAdded = "User has been added successfully.";
        public static string UserAddError = "An error occurred while adding the user.";
        public static string UserUpdated = "User information has been updated.";
        public static string UserUpdateError = "An error occurred while updating the user.";
        public static string UserDeleted = "User has been deleted successfully.";
        public static string UserDeleteError = "An error occurred while deleting the user.";
        public static string UsersListed = "Users have been listed successfully.";
        public static string UsersListError = "An error occurred while listing the users.";
        public static string UserListed = "User has been listed successfully.";        
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Incorrect password";
        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "This user already exists";
        public static string UserRegistered = "User successfully registered";
        public static string AccessTokenCreated = "Access token successfully created";

        // Customer operations
        public static string CustomerAdded = "Customer has been added successfully.";
        public static string CustomerAddError = "An error occurred while adding the customer.";
        public static string CustomersListed = "Customers have been listed successfully.";
        public static string CustomersListError = "An error occurred while listing the customers.";
        public static string CustomerListed = "Customer has been listed successfully.";
        public static string CustomerDetailListed = "Customer information has been listed in detail.";

        // Car rental operations
        public static string RentalAdded = "Car rental process has been successfully completed.";
        public static string RentalAddError = "An error occurred during the car rental process.";
        public static string RentalUpdated = "Car rental process has been successfully updated.";
        public static string RentalUpdateError = "An error occurred while updating the car rental process.";
        public static string RentalDeleted = "Car rental process has been successfully deleted.";
        public static string RentalDeleteError = "An error occurred while deleting the car rental process.";
        public static string RentalsListed = "Rented cars have been listed successfully.";
        public static string RentalsListError = "An error occurred while listing the rented cars.";
        public static string RentalListed = "Rented car has been listed successfully.";
        public static string RentalDetailListed = "Rental information has been listed in detail.";
        public static string ReturnDateMissing = "Return date is not specified.";
        
        // Car image operations
        public static string CarImageAdded = "Car image has been added successfully.";
        public static string CarImageAddError = "An error occurred while adding the car image.";
        public static string CarImageUpdated = "Car image has been updated successfully.";
        public static string CarImageUpdateError = "An error occurred while updating the car image.";
        public static string CarImageDeleted = "Car image has been deleted successfully.";
        public static string CarImageDeleteError = "An error occurred while deleting the car image.";
        public static string CarImageCountError = "A car can have a maximum of {0} images.";
        public static string CarImagesListed = "Images for the car have been listed successfully.";
        public static string CarImagesListError = "An error occurred while listing images for the car.";
        public static string DefaultCarImageReturned = "No image found for the car with ID {0}, a default image has been returned.";

        public static string AuthorizationDenied = "Unauthorized";
        #endregion

        #region tr-TR
        /*
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
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

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
        public static string DefaultCarImageReturned = "{0} ID'li arabaya ait resim bulunamadığı için varsayılan bir resim getirilmiştir.";
        public static string FileValidForUpload = "Yüklenen dosya boş veya geçersiz.";
        */
        #endregion tr-TR
    }
}
