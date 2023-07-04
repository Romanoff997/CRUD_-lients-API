//using AutoMapper.QueryableExtensions;
//using AutoMapper;
//using SimplifyLink.Domain.Entities;
//using SimplifyLink.Models;
//using SimplifyLink.Services.Interface;

//namespace SimplifyLink.Services
//{
//    public class MappingServiceNative: IMapingService
//    {
//        private readonly IMapper _mapper;
//        public MappingServiceNative(IMapper mapper)
//        {
//            _mapper = mapper;

//        }

//        public  IQueryable<LinkViewModel> GetLinkViews(IQueryable<LinkModel> Links)
//        {
//            return Links.ProjectTo<LinkViewModel>(_mapper.ConfigurationProvider);
//        }
//    }
//}