using Services.DTO;
using Shared.GenericResponse;

namespace Services.Infrastructure
{
    public interface IDealerService
    {
        Task<Response<string>> GetToken();
        Task<Response<List<AccountInfoResponse>>> GetDealers(DealerModelDTO request);
    }
}
