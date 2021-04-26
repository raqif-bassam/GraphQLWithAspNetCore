using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeGraphServer.Database;
using TimeGraphServer.Models;

namespace TimeGraphServer.GraphQL
{
    public class Query
    {
        private readonly TimeGraphContext dbContext;
        private readonly IServiceScopeFactory service;

        public Query(TimeGraphContext dbContext, IServiceScopeFactory serviceScopeFactory)
        {
            this.dbContext = dbContext;
            this.service = serviceScopeFactory;
        }

        public IQueryable<Project> Projects()
        {
            return this.dbContext.Projects;
        }
        public IQueryable<TimeLog> TimeLogs()
        {
            //return this.dbContext.TimeLogs;
            var task = Task.Run(async () =>
            {
                using (var scope = service.CreateScope())
                {
                    var db = scope.ServiceProvider.GetService<TimeGraphContext>();
                    var test = db.TimeLogs;
                }

            });
        }
    }
}
