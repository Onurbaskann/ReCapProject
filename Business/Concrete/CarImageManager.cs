using Business.Abstract;
using Core.Constants;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(CreateCarImageDto createCarImage)
        {
            CarImage carImage = new CarImage();
            if (CheckImageCountCorrect(createCarImage.CarId,5))
            {
                return new ErrorResult();
            }
            if (createCarImage.File.Length > 0)
            {
                var result = _fileHelper.Upload(createCarImage.File);

                carImage.CarId = createCarImage.CarId;
                carImage.ImagePath = result.Data;
                carImage.Date = DateTime.Now;

                _carImageDal.Add(carImage);

                return new SuccessResult(Message.SuccessAddedCarImage);
            }
            return new ErrorResult(Message.ErrorAddedCarImage);
        }
        public IResult Delete(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                var result = _fileHelper.Delete(path);

                if (result.Success)
                {
                    var isImageExistingAtPath = _carImageDal.Get(x => x.ImagePath == path);

                    if (isImageExistingAtPath != null)
                    {
                        _carImageDal.Delete(isImageExistingAtPath);

                        return new SuccessResult("İşlem başarılı");
                    }
                }
            }
            return new ErrorResult();
        }
        public IResult Update(UpdateCarImageDto updateCarImage)
        {
            if (updateCarImage.File.Length > 0)
            {
                var carImage = _carImageDal.Get(x => x.Id == updateCarImage.Id);

                if (carImage != null)
                {
                    var result = _fileHelper.Update(updateCarImage.File, carImage.ImagePath);

                    carImage.CarId = updateCarImage.CarId;
                    carImage.ImagePath = result.Data;
                    carImage.Date = DateTime.Now;

                    _carImageDal.Update(carImage);

                    return new SuccessResult(Message.SuccessUpdatedCarImage);
                }
            }
            return new ErrorResult(Message.ErrorUpdatedCarImage);
        }
        public bool CheckImageCountCorrect(int carId, int countLimit)
        {
            return _carImageDal.GetAll().Where(x => x.CarId == carId).Count() > countLimit;
        }
    }
}
