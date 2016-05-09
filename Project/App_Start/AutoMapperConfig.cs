using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Project.Model.Models;
using Project.Model.ViewModels;

namespace Project.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Content, ContentViewModel>()
                    .ForMember(dest=>dest.Folder,opt => opt.MapFrom(src=>src.Folder));

                cfg.CreateMap<Folder, FolderViewModel>();

            });
        }
    }
}