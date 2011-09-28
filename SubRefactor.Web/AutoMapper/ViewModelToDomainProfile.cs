using System.Web.Security;
using AutoMapper;
using SubRefactor.Domain;
using SubRefactor.Models.Account;

namespace SubRefactor.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<RegisterViewModel, User>()
                .ForMember(u => u.Password,
                           m => m.MapFrom(
                               source =>
                               FormsAuthentication.HashPasswordForStoringInConfigFile(source.Password, "MD5")));

            Mapper.CreateMap<LogOnViewModel, User>()
                .ForMember(u => u.Password,
                           m =>
                           m.MapFrom(
                               source =>
                               FormsAuthentication.HashPasswordForStoringInConfigFile(source.Password, "MD5")));
        }
    }
}