using System.Collections.Generic;
using Core.Models;

namespace Core.SharedInterfaces
{
    public interface IDomainRepository
    {
        IEnumerable<SourceModel> GetSources();
        SourceModel GetSource(string id);
        IEnumerable<ResourceModel> GetResources();
        IEnumerable<ResourceModel> GetResources(string sourceId);
        IEnumerable<StatisticModel> GetStatistic(string sourceId);
        UserModel GetUser(string login);
        UserModel GetUser(string login, string encryptPassword);
    }
}