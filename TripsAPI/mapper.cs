using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.Entities;
using TripsAPI.InputModels;

namespace TripsAPI
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            #region Order
            CreateMap<TripInputModel, Trip>()
                .ForMember(dto => dto.Id, mem => mem.Ignore())
                .ForMember(dto => dto.DateCreated, mem => mem.Ignore()); 
            #endregion

            // #region Order
            //CreateMap<ProductItemViewModel, ProductItem>()
            //.ForMember(dto => dto.Id, mem => mem.Ignore())
            //  .ForMember(dto => dto.UserId, mem => mem.Ignore());
            //CreateMap<ProductItem, GetProductItemViewModel>();
            //#endregion

            //CreateMap<FileModel, ProductItem>()
            //    .ForMember(dto => dto.Id, mem => mem.Ignore())
            //    .ForMember(dto => dto.ProductForm, mem => mem.Ignore())
            //    .ForMember(dto => dto.ProductCategory, mem => mem.Ignore())
            //    .ForMember(dto => dto.Picture, mem => mem.Ignore());


            //#region Order
            //CreateMap<DeleteProductItemViewModel, ProductItem>()
            //.ForMember(dto => dto.Id, mem => mem.Ignore())
            //  .ForMember(dto => dto.ProductCategoryId, mem => mem.Ignore())
            //  .ForMember(dto => dto.UserId, mem => mem.Ignore());
            //CreateMap<ProductItem, DeleteProductItemViewModel>();
            //#endregion

            //#region Order
            //CreateMap<PostProductItemViewModel, ProductItem>()
            //.ForMember(dto => dto.Id, mem => mem.Ignore())
            //  //.ForMember(dto => dto.ProductCategoryId, mem => mem.Ignore())
            //  .ForMember(dto => dto.UserId, mem => mem.Ignore());
            //CreateMap<ProductItem, PostProductItemViewModel>();
            //#endregion

            //#region Order
            //CreateMap<PutProductItemViewModel, ProductItem>()
            //.ForMember(dto => dto.Id, mem => mem.Ignore())
            //  .ForMember(dto => dto.UserId, mem => mem.Ignore())
            //  .ForMember(dto => dto.ProductCategory, mem => mem.Ignore())
            //  .ForMember(dto => dto.ProductForm, mem => mem.Ignore());
            //#endregion


            //CreateMap<ProductItem, AddToCartCreated>()
            //    .ForMember(dto => dto.ProductItemId, mem => mem.MapFrom(x => x.Id));

            //CreateMap<SuperAdminCreated, SuperAdmin>();
            //CreateMap<SuperAdminCreated, ProductItem>();
            //CreateMap<SuperAdmin, LineListDTO>()
            //     .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(x => x.Category.Name));

        }
    }
}
