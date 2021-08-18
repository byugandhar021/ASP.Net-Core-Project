namespace Fitness.Web.ViewModels.Exercise
{
    using System.Collections.Generic;

    public class AllViewModel
    {
        public string Id { get; set; }

        public IEnumerable<SingleViewModel> Exercises { get; set; }
    }
}
