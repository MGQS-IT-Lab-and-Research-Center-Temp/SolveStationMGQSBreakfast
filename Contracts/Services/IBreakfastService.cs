using MGQSBreakfast.Models;
using MGQSBreakfast.Models.Response;

namespace MGQSBreakfast.Contracts.Services;

public interface IBreakfastService
{
    BreakfastResponseModel CreateBreakFast(CreateBreakfastViewModel request);
    BreakfastResponseModel GetBreakFast(int id);
    BreakfastResponseModel DeleteBreakFast(int id);
    BreakfastResponseModel UpdateBreakFast(int id, UpdateBreakfastViewModel request);
    BreakfastResponseModel GetAllBreakFast();
}
