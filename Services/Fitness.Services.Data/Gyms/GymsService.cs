namespace Fitness.Services.Data.Gyms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Repositories;
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;

    public class GymsService : IGymsService
    {
        private readonly IDeletableEntityRepository<Gym> gymRepository;

        public GymsService(IDeletableEntityRepository<Gym> gymRepository)
        {
            this.gymRepository = gymRepository;
        }

        public Task CreateGymAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteGymById(string gymId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAllGyms<T>()
        {
            var gyms = this.gymRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<T>()
                .ToList();

            return gyms;
        }

        public Gym GetGymById(string gymId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateGymAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
