﻿using AutoMapper;
using PhotoGalleryNgCoreApi.Entities;
using PhotoGalleryNgCoreApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryNgCoreApi.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Photo, PhotoViewModel>()
                .ForMember(vm => vm.Uri, map => map.MapFrom(p => "/images/" + p.Uri));

            Mapper.CreateMap<Album, AlbumViewModel>()
                .ForMember(vm => vm.TotalPhotos, map => map.MapFrom(a => a.Photos.Count))
                .ForMember(vm => vm.Thumbnail, map => map.MapFrom(a => (a.Photos != null && a.Photos.Count > 0) ? "/images/" + a.Photos.First().Uri : "/images/thumbnail-default.png"));
        }
    }
}
