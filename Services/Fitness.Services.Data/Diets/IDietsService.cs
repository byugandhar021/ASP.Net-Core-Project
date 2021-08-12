namespace Fitness.Services.Data.Diets
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness.Web.ViewModels.Diet;

    public interface IDietsService
    {
        IEnumerable<T> GetAllDiets<T>();

        Task CreateDietAsync(string userId, CreateInputModel createInputModel);

        T GetDietById<T>(string dietId);

        Task UpdateDietAsync(EditInputModel editInputModel);

        Task DeleteDietByIdAsync(string dietId);
    }
}
