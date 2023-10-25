using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

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

            var resultRules = BusinessRules.Run(CheckImageCountCorrect(createCarImage.CarId, 5),
                                                IsFileValidForUpload(createCarImage.File));
            if (resultRules != null)
            {
                return new ErrorResult(resultRules.Message);
            }
            var resultUpload = _fileHelper.Upload(createCarImage.File);

            if (resultUpload.Success)
            {
                carImage.CarId = createCarImage.CarId;
                carImage.ImagePath = resultUpload.Data;
                carImage.Date = DateTime.Now;

                _carImageDal.Add(carImage);

                return new SuccessResult(Messages.CarImageAdded);
            }
            return new ErrorResult(Messages.CarImageAddError);
        }
        public IResult Delete(int id)
        {
            var carImage = _carImageDal.Get(x => x.Id == id);

            if (carImage != null)
            {
                if (!string.IsNullOrEmpty(carImage.ImagePath))
                {
                    var resultDelete = _fileHelper.Delete(carImage.ImagePath);

                    if (resultDelete.Success)
                    {
                        _carImageDal.Delete(carImage);

                        return new SuccessResult(Messages.CarImageDeleted);
                    }
                }
            }
            return new ErrorResult(Messages.CarImageDeleteError);
        }
        public IResult Update(UpdateCarImageDto updateCarImage)
        {
            var resultRules = BusinessRules.Run(IsFileValidForUpload(updateCarImage.File));
            if (resultRules != null)
            {
                return new ErrorResult(resultRules.Message);
            }
            var carImage = _carImageDal.Get(x => x.Id == updateCarImage.Id);

            if (carImage != null)
            {
                var resultUpdate = _fileHelper.Update(updateCarImage.File, carImage.ImagePath);

                if (resultUpdate.Success)
                {
                    carImage.CarId = updateCarImage.CarId;
                    carImage.ImagePath = resultUpdate.Data;
                    carImage.Date = DateTime.Now;

                    _carImageDal.Update(carImage);

                    return new SuccessResult(Messages.CarImageUpdated);
                }
            }
            return new ErrorResult(Messages.CarImageUpdateError);
        }
        public IDataResult<List<CarImageDetail>> GetByCarId(int id)
        {
            List<CarImageDetail> carImageDetailList = new List<CarImageDetail>();

            var carImageList = _carImageDal.GetAll(x => x.CarId == id);

            if (carImageList != null && carImageList.Count > 0)
            {
                foreach (var carImage in carImageList)
                {
                    string base64EncodedImage = string.Empty;

                    var result = _fileHelper.ConvertFileToBase64(carImage.ImagePath);
                    
                    if (result.Success)
                    {
                        base64EncodedImage = result.Data;
                    }
                    carImageDetailList.Add(new CarImageDetail
                    {
                        CarId = carImage.CarId,
                        Base64EncodedImage = base64EncodedImage
                    });
                }
                return new SuccessDataResult<List<CarImageDetail>>(carImageDetailList, Messages.CarImagesListed);
            }
            else
            {
                var defaultCarImage = DefaultCarImage(id);
                return new SuccessDataResult<List<CarImageDetail>>(defaultCarImage, string.Format(Messages.DefaultCarImageReturned, id));
            }
        }
        private List<CarImageDetail> DefaultCarImage(int id)
        {
            List<CarImageDetail> carImageDetails = new List<CarImageDetail>
            {
                new CarImageDetail
                {
                    CarId = id,
                    Base64EncodedImage = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCAGKArwDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD8qqKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAK6PwZ8P9a8ff23/AGNbxz/2Npk2r3nmSrHtt4sbyu4jc3zDCjk9hXOV9yf8Ev8AwdqPir/hfX2FVfHgS6tYdybtt3LnyGHuNklAHw3RQaKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooAJOAMmgAop0kbwyNHIrI6kqysMEEdQRTaACv09/4JTovg34VeI/EE8n2RNX8TWts8gXJe1toi0xP+ypuVz9a/MKv08/ZH8K395+zBFa2cjQvH4Z8TTHurTT/YXib6hePwFAH54/F7wrL4H+KvjDw/NF5D6Zq91aeWBgKElZQB+AFcjXu/7cNr5X7T/ji6VWVL68NwNxyxP3GJ9yyMfxrwigAoop3lOIhIUYRklQ+OCRjIz68j86AG0UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAfWvgn4NzftkfB3VNd0f7HF8S/B8UFtegyCJtVtQhWKSQdN4VNvm5ySh35BDL8r61ot/4d1S503VLOawv7dtktvcIUdD15B9iD7g17f+xP8XJPhL8b7GWTfJpurQtYXMKNtLNkSQlf9sSom36kdCa+s/20vgLpXx0+Gln8RfAiWV1quj2KzyjTCpS/sSoO5VAz8hLFQMgDcnYAAH5oV+u//BMiESfs2tLcyo7XV/d2MSyRhtobYq9xx8jV+RH3Wr9cP+CYMceqfs4xnDXDw+JHsdiAHySQHV/YgPxn1+lAH54/tfCRP2k/iBG8pmWPVZVjY/3DhlH6147XrX7WNwlx+0d8QxHJ5qQ6xPbBwQc+Wdn81Pv61H+zX8BdS/aE+JVpoFqXt9MhH2nU71cAW9uvLEE8Bj0Ge5z2oA6f9lj9kjxF+0Z4jilMbaX4StiZb3VJiIw8an5liJHJ4ILYIXvk4U8P8cPHNj4s8Vpp+g29vY+EtBRtO0e1tARH5Idi0pJ5dpGJYu3zEbc9K/RD9q74ueHPgr8EdW8K+EksrHUH02LTraGzcbraOXzIVdiMctD55T0xI4yTmvyqoAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAHwTyWs0c0LtFLGwdJEOCrA5BB7HNfZP7Bf7SF54c8R/8ACD6rcrcLfNIdH+1t+7aWRt0toxPCiYklCeFkPPEjGvjOn29xJazxzRO0csbB0dTggg5BFAHu37YPwXh+FXxGXUNIc3HhnxCrX9hKU2lCW/ewsP4XRjgr2/Ovvr/gkKRffAHxDDCW8218XC5kDKNuPs0OAPrz+QrybwTpth+2V+yXr/mRpceK9DZJr0KuZ4btV2rdJ6rLGPnH8TIxzk5Hpv8AwSG1S28PfCbxpY3e6K7TxdDG6Odm3/R1GSDzwVbI+lAH5vftDzJqX7QXxHe23skviXUCm8YY5uX6j1r7h+Gdnpn7Gf7OGp32ssj6xqlvHc6rCOJTLIpNtYRsORIwyzn+BFJ6lM+bfsw/A+H4xftfeOdelshfaRomv317HHdJm3aQXEjRmQ9CFO0lfcE+h8c/bC+MUPxJ+JV3pejXbXHhnRp5IoJegu7gtma5I/2m4HoioOgFAHknjTx7rnj/AF3UtW1q+kurrULn7VMucJv27VCr0CqoCqP4VAArn6KKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAorrvhj8KPFHxg8SJofhXSptTvdpkkK4WOCMcl5HYhUUAHkkdK9J+MvwN8K/A3wbaw6h4ifxP421Jj5UelkLp1pGpG9i7DfOR93cAqFi20tsJIBQ/ZN+PF58A/ipBqyOz6VfRGz1C0LkJNGeQGHseh7ZNfoFpPwqvPh34mvtU8Gz3CaB4v1HT7+PbtOy3mSRXYkngIUGc9M4ya/Jb+Gv1h/Y1+IWo6t8KbCw1Q3Gq2tnp1tptjMiDcs0qsRuycfKFUD1xk9aAPLPjR4kH7IXwFuPCmlyTQeM/HMUt5d3YfbJDBM5IVcH5TtdifoOctx+eFe6fth+NNW8cfFiPUNYummuksY4TDtIWHazAqM8nJGTnnnHYV5N4LbQP+EosF8UJeNoMknl3bafIEnjQ8eYm5WBK53bSOcY4zmgDEor6K+KX7Guu+GdFu/EngvUI/HHhm3QTz/ZVC31lEcEGaAE5XniSMsjAg5GcD51oAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAK6r4b/Du/wDiP4gj0+1P2e2Uqbm8aMusKk4HyjlnYkKqDlmIArL8J+F9Q8aeIrHRtLtzc3t3JsRAcAADLMx/hVVBYk9ACa/Sv4Q/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wGF3HzOEkdkAPzVor3b9pL4A6r8N/El5cDT5II9zGeHZjaRncwGOBwSeOgJ42uE8JoAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACnwwyXM0cMSNJLIwREUZLMTgAD1plfSf7JXwN/4TrUF1u5ha5t1mNvFHuMalgMsC/wDAMZLyDPloDjLumAD2n9kr9n+00DR9O1fxBHa/bLvN3HG43RpCpIa4m55jU5RRwGYt2yy+eftkftWf8LI1GLw34Wnki8F6awW0GcHUJVJ/0uQf3Axby19SzkD5QNL9qj9o2y023m+HHh8GeHcqa/eW+LcXHlqVW0QL/q4lGF2D7q5X7zSE/HN5dSX1zJPKcyOcnAwB6ADsAOAPagCNmLsWYlmJySTkmkoooAK/XD/gmbqi+HP2Z7eWRreJr3WLoRfaJAu9gVCBf9ondx7V+R/Xiv1d/wCCeegx6h+z74aS5s/tscOuQXUePl8qTz7n5sk84Xaf+BdDQB8BftfWv2P9pj4ixAbV/taRlyc/KQpB/EEV4/Xr/wC1rDJH+0F4seXHmSyQyNgYwxgj3DGT0YEfhXkFABXQ+CPGmpeB9es9T029nsLm2mWeG5tjiSCRfuyJ7joQeGBKng1z1FAH6l+GPiZ4a/aq+FQn1eKK18T6XGkesW9qpLRLj5L227mIgZKHJAXHJTD/AAD8fPhNffC3xtd28sMIsZmEkElpzCVYblK8n5WHzLzjGcdDWZ8Kfi5qvwl8SafrmlFxf2EoeJlkKh4icyQv6q2AR3VgGHNfbfiTSfDf7T3wrj13RLZUttnkfZflV7CZjuaEnosO85U9IXZcDypDgA/OqitPxNoMvhjX7/SpyTNaTNC25ChyPVTyD6jsazKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAK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vizoWrsw+yNBCAw2GNh55kDKehUlcnpyK+OP2Bv2sJfg34kuPCeuPHdeGdYARIro/JHKGBABP3C2OG7OENfrZ4A0nTNSude17SQLvS9VsPPTMXlyblyro5/vMNhwenrgigD8uv2ef2Sda+I3xAvvFmrhm06HUBBLHExSa5nB+WyibHDPgB5RkJGHPXFepft9fH/RvhZ4P074ZeFpIJ9Vjt2t7iaHhIgG5KLklY9xbYCcthSeAM+4ftCftAaJ+yp8M5LWD7NdeKzbyKP3IRfPlX7sa/3vnO4/worZJLGvxq8TeJNQ8Xa7e6vqly93f3chlllkOSSTmgDNkkaR2d2LMxyWPUmkoooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAVirAg4I5BFfqv/wAEo/jhJeeAfidpOvapc3dxpcc2vtJdSEhYio80J6cqG+rcCvyor6Q/Y3+K8Hwxi+JqTsyjV/DNzp42gn7+MngewoA8n+MXxH1L4lePNf1S8v7u7trrU7m9hjun3GIysMgemAqL9FFcPTpZDNK7nqzFj+NNoAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKmt7y4s/M8ieSDzEMb+W5Xcp6qcdR7VDRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFAH/9k="
                }
            };
            return carImageDetails;
        }
        private IResult CheckImageCountCorrect(int carId, int countLimit)
        {
            var result = _carImageDal.GetAll().Where(x => x.CarId == carId).Count();
            if (result >= countLimit)
            {
                return new ErrorResult(string.Format(Messages.CarImageCountError, countLimit));
            }
            return new SuccessResult();
        }
        private IResult IsFileValidForUpload(IFormFile file)
        {
            var result = file.Length > 0;
            if (!result)
            {
                return new ErrorResult(Messages.FileValidForUpload);
            }
            return new SuccessResult();
        }
    }
}
