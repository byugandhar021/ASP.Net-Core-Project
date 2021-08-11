namespace Fitness.Services.Data.Diets
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Data.Models;
    using Fitness.Web.ViewModels.Diet;

    public interface IDietsService
    {
        IEnumerable<Diet> GetAllDiets();

        Task CreateDietAsync(string userId, CreateInputModel createInputModel);

        Diet GetDietById(string dietId);

        Task UpdateDietAsync(EditInputModel editInputModel);

        Task DeleteDietById(string dietId);
    }
}
