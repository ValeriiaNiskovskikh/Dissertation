using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.SharedInterfaces;
using Dapper;
using ExternalResources.Db.Providers;

namespace ExternalResources.Db
{
    public class PgDomainRepository : IDomainRepository
    {
        private readonly IPgConnectionProvider _pgConnectionProvider;

        public PgDomainRepository(IPgConnectionProvider pgConnectionProvider)
        {
            _pgConnectionProvider = pgConnectionProvider;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public IEnumerable<SourceModel> GetSources()
        {
            const string command = "select id from dwh.source";

            string[] GetIds()
            {
                using (var connection = _pgConnectionProvider.GetOpenConnection())
                {
                    return connection.Query<string>(command).ToArray();
                }
            }

            var sourceModels = GetIds().AsParallel().Select(GetSource).ToArray();

            return sourceModels;
        }

        public SourceModel GetSource(string id)
        {
            const string command = "select * from dwh.source where id = :id";

            SourceModel GetBaseModel()
            {
                using (var connection = _pgConnectionProvider.GetOpenConnection())
                {
                    return connection.QueryFirst<SourceModel>(command, new {id});
                }
            }

            var result = GetBaseModel();
            result.Resources = GetResources(id).ToArray();
            return result;
        }

        public IEnumerable<ResourceModel> GetResources()
        {
            const string command = "select * from dwh.resource";
            using (var connection = _pgConnectionProvider.GetOpenConnection())
            {
                return connection.Query<ResourceModel>(command);
            }
        }

        public IEnumerable<ResourceModel> GetResources(string sourceId)
        {
            const string command =
                "select r.* from dwh.resource r inner join dwh.source s on r.id = ANY (s.resource_ids) ";
            using (var connection = _pgConnectionProvider.GetOpenConnection())
            {
                return connection.Query<ResourceModel>(command).ToArray();
            }
        }


        public IEnumerable<StatisticModel> GetStatistic(string sourceId)
        {
            var resources = GetResources(sourceId).ToArray();
            var source = GetSource(sourceId);
            var statisticForSource = FindStatisticForSource(sourceId);
            return statisticForSource.AsParallel().Select(
                statisticDbModel =>
                    new StatisticModel()
                    {
                        CreatedOn = statisticDbModel.createdOn,
                        Id = statisticDbModel.id,
                        Resource = resources.First(r => r.Id == statisticDbModel.resourceId),
                        Source = source,
                        User = GetUser(statisticDbModel.login),
                        Value = statisticDbModel.value
                    }
            ).ToArray();
        }

        private (double value, string id, string login, string resourceId, DateTime createdOn)[] FindStatisticForSource(
            string sourceId)
        {
            const string command = "select s.value, s.id, u.login, s.resource_id, s.created_on from dwh.statistic s inner join dwh.user u on s.user_id = u.id";
            using (var connection = _pgConnectionProvider.GetOpenConnection())
            {
                return connection
                    .Query<(double value, string id, string login, string resourceId, DateTime createdOn)>(command,
                        new {sourceId})
                    .ToArray();
            }
        }


        public UserModel GetUser(string login)
        {
            const string command = "select * from dwh.user where login = :login";
            using (var connection = _pgConnectionProvider.GetOpenConnection())
            {
                return connection.QueryFirstOrDefault<UserModel>(command, new {login});
            }
        }

        public UserModel GetUser(string login, string encryptPassword)
        {
            var user = GetUser(login);
            return user?.Password == encryptPassword ? user : null;
        }
    }
}