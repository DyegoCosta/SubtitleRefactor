using AutoMapper;

namespace SubRefactor.AutoMapper
{
    public class AutoMapperConfigurator
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
                                  {
                                      x.AddProfile<DomainToViewModelProfile>();
                                      x.AddProfile<ViewModelToDomainProfile>();
                                  });
        }
    }
}