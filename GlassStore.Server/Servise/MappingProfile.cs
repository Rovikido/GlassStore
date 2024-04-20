using AutoMapper;
using GlassStore.Server.Domain.Models.Auth;
using GlassStore.Server.Domain.Models.User;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GlassStore.Server.Servise
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Accounts, UserInfo>();
        }
    }
}
