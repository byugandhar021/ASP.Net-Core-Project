namespace Fitness.Services.Data.Gyms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Repositories;
    using Fitness.Data.Models;
    using Fitness.Services.Mapping;
    using Fitness.Web.ViewModels.Gym;

    public class GymsService : IGymsService
    {
        private readonly IDeletableEntityRepository<Gym> gymRepository;

        public GymsService(IDeletableEntityRepository<Gym> gymRepository)
        {
            this.gymRepository = gymRepository;
        }

        public async Task CreateGymAsync(string userId, CreateInputModel inputModel)
        {
            var gym = new Gym
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                Location = inputModel.Location,
                WorkTime = inputModel.WorkTime,
                ImageUrl = inputModel.ImageUrl,
                UserId = userId,
            };

            await this.gymRepository.AddAsync(gym);
            await this.gymRepository.SaveChangesAsync();
        }

        public async Task DeleteGymAsync(string gymId)
        {
            var gym = this.gymRepository
                .All()
                .FirstOrDefault(x => x.Id == gymId);
            this.gymRepository.Delete(gym);
            await this.gymRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllGyms<T>()
        {
            var gyms = this.gymRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();

            return gyms;
        }

        public T GetGymById<T>(string gymId)
        {
            var gym = this.gymRepository
                .AllAsNoTracking()
                .Where(x => x.Id == gymId)
                .To<T>()
                .FirstOrDefault();

            return gym;
        }

        public async Task UpdateGymAsync(string id, EditInputModel inputModel)
        {
            var gym = this.gymRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            gym.Name = inputModel.Name;
            gym.Description = inputModel.Description;
            gym.Location = inputModel.Location;
            gym.WorkTime = inputModel.WorkTime;
            gym.ImageUrl = inputModel.ImageUrl;

            await this.gymRepository.SaveChangesAsync();
        }
    }
}
