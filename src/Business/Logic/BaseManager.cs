using AutoMapper;
using drielnox.Forum.Business.Logic.MapperProfiles;

namespace drielnox.Forum.Business.Logic
{
    public abstract class BaseManager
    {
        protected static readonly MapperConfiguration _mapperConfiguration;
        protected static readonly IMapper _mapper;

        static BaseManager()
        {
            _mapperConfiguration = new MapperConfiguration(x => 
            {
                x.ShouldUseConstructor = constructor => constructor.IsPublic;

                x.AddProfile<ForumProfile>();
            });

            _mapperConfiguration.AssertConfigurationIsValid();

            _mapper = _mapperConfiguration.CreateMapper();
        }
    }
}
