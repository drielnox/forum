using drielnox.Forum.Business.Logic;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace drielnox.Forum.Transversal.DependencyInjection
{
    public static class DIContainer
    {
        private static readonly ServiceCollection _services;

        static DIContainer()
        {
            _services = new ServiceCollection();
            ConfigureServices();
        }

        private static void ConfigureServices()
        {
            _services.AddSingleton<IForumManager, ForumManager>();
            _services.AddSingleton<IDiscussionManager, DiscussionManager>();
            _services.AddSingleton<ICategoryManager, CategoryManager>();
        }

        public static IServiceProvider Build()
        {
            return _services.BuildServiceProvider();
        }
    }
}
