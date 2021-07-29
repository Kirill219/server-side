using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.Pet
{
    public interface IPetContext
    {
        Task<PetResponse> GetPetByIdAsync(long petId);

        Task<ResponseMessage> GetPetByIdResponseAsync(string petId);

        Task<ResponseMessage> CreatePetResponseAsync(PetRequest petRequest);

        Task<CreatePetResponse> CreatePetAsync(PetRequest petRequest);

        Task<PetResponse> DeletePetByIdAsync(long petId);

        Task<PetResponse> PutPetAsync(PetRequest petRequest);

        Task<PetResponse> PostPetAsync(PetRequest petRequest);
    }
}
