namespace Fitness.Services.Data.Gyms
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;

    public interface IGymsService
    {
        IEnumerable<T> GetAllGyms<T>();

        Task CreateGymAsync(string userId);

        Gym GetGymById(string gymId);

        Task UpdateGymAsync();

        Task DeleteGymById(string gymId);
    }
}
