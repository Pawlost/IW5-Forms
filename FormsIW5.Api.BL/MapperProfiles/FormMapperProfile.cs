using AutoMapper;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Api.BL.MapperProfiles;

public class FormMapperProfile : Profile
{
    public FormMapperProfile()
    {
        CreateMap<FormEntity, FormListModel>();
        CreateMap<FormEntity, FormDetailModel>().ReverseMap();
        CreateMap<FormCreateModel, FormEntity>();
    }
}
