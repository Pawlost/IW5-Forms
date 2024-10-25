using AutoMapper;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Common.BL.Models.Form;

namespace FormsIW5.Api.BL.MapperProfiles;

public class FormMapperProfile : Profile
{
    public FormMapperProfile()
    {
        CreateMap<FormEntity, FormListModel>().ReverseMap();
        CreateMap<FormEntity, FormDetailModel>().ReverseMap();
    }
}
