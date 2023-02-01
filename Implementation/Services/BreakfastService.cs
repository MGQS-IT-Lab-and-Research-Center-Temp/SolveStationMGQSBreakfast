using MGQSBreakfast.Contracts.Repositories;
using MGQSBreakfast.Contracts.Services;
using MGQSBreakfast.Entities;
using MGQSBreakfast.Models;
using MGQSBreakfast.Models.Response;

namespace MGQSBreakfast.Implementation.Services
{
    public class BreakfastService : IBreakfastService
    {
        private readonly IBreakfastRepository _breakFastRepository;

        public BreakfastService(IBreakfastRepository breakFastRepository)
        {
            _breakFastRepository = breakFastRepository;
        }

        public BreakfastResponseModel DeleteBreakFast(int id)
        {
            var breakfast = _breakFastRepository.GetById(id);

            if (breakfast == null)
            {
                return new BreakfastResponseModel
                {
                    Message = "Breakfast Not found!",
                    Status = false
                };
            }

            var isDeleted = _breakFastRepository.Delete(id);

            if (isDeleted == true)
            {
                return new BreakfastResponseModel
                {
                    Message = "BreakFast Succesfully deleted",
                    Status = true
                };
            }

            return new BreakfastResponseModel
            {
                Message = "Unable to delete breakfast",
                Status = false
            };

        }

        public BreakfastResponseModel GetBreakFast(int id)
        {
            var breakfast = _breakFastRepository.GetById(id);

            if (breakfast == null)
            {
                return new BreakfastResponseModel
                {
                    Message = "BreakFast not found!",
                    Status = false
                };
            }

            return new BreakfastResponseModel
            {
                Data = new BreakfastViewModel
                {
                    Id = breakfast.Id,
                    Name = breakfast.Name,
                    Description = breakfast.Description,
                    StartDateTime = breakfast.StartDateTime,
                    EndDateTime = breakfast.EndDateTime
                },

                Status = true,
                Message = "BreakFast successfully retrieved"
            };
        }

        public BreakfastResponseModel GetAllBreakFast()
        {
            throw new NotImplementedException();
        }

        public BreakfastResponseModel CreateBreakFast(CreateBreakfastViewModel request)
        {
            var isBreakFastExist = _breakFastRepository.BreakFastExist(request.Name);

            if(!isBreakFastExist)
            {
                var breakfast = new Breakfast
                {
                    Name = request.Name,
                    Description = request.Description,
                    StartDateTime = request.StartDatetime,
                    EndDateTime = request.EndDatetime
                };

                _breakFastRepository.Create(breakfast);

                return new BreakfastResponseModel
                {
                    Message = "Breakfast created successfully!",
                    Status = true
                };
            }

            return new BreakfastResponseModel
            {
                Message = $"Breakfast with {request.Name} already exist!",
                Status = false
            };
        }

        public BreakfastResponseModel UpdateBreakFast(int id, UpdateBreakfastViewModel request)
        {
            var breakfast = _breakFastRepository.GetById(id);

            if (breakfast == null)
            {
                return new BreakfastResponseModel
                {
                    Message = "Breakfast not found!!",
                    Status = true
                };
            }

            breakfast.Name = request.Name;
            breakfast.Description = request.Description;
            breakfast.StartDateTime = request.StartDateTime;
            breakfast.EndDateTime = request.EndDateTime;

            _breakFastRepository.Update(breakfast.Id);

            return new BreakfastResponseModel
            {
                Message = "BreakFast successfully updated",
                Status = true
            };

        }

    }
}
