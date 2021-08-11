namespace Fitness.Web.ViewModels.Diet
{
    using System.Collections.Generic;

    using Fitness.Data.Models;

    public class AllViewModel
    {
        public IEnumerable<Diet> Diets { get; set; }
    }
}
