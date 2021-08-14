namespace Fitness.Web.ViewModels.Gym
{
    using System.Collections.Generic;

    public class AllViewModel
    {
        public IEnumerable<SingleGymViewModel> Gyms { get; set; }
    }
}
