namespace Fitness.Services.Data.Gyms
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;
    using Fitness.Web.ViewModels.Gym;

    public interface IGymsService
    {
        IEnumerable<T> GetAllGyms<T>();

        Task CreateGymAsync(string userId, CreateInputModel inputModel);

        T GetGymById<T>(string gymId);

        Task UpdateGymAsync(string id, EditInputModel inputModel);

        Task DeleteGymAsync(string gymId);
    }
}
