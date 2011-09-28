using AutoMapper;
using SubRefactor.Models.Account;

namespace SubRefactor.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Domain.User, RegisterViewModel>();
            Mapper.CreateMap<Domain.User, LogOnViewModel>();
        }
    }
}