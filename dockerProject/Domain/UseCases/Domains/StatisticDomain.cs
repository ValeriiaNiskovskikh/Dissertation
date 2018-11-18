using Core.Models;
using UseCases.Models;

namespace UseCases.Domains
{
    public class StatisticDomain : IStatisticDomain
    {
        public UseCaseAnswer<SourceModel> Create(CreateStatisticModel[] models)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IStatisticDomain
    {
        UseCaseAnswer<SourceModel> Create(CreateStatisticModel[] models);
    }
}