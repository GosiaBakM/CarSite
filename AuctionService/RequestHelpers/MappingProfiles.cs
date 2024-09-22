using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
            CreateMap<CarItem, AuctionDto>();
            CreateMap<CreateAuctionDto, Auction>()
                .ForMember(x => x.Item, o => o.MapFrom(s => s));
            CreateMap<CreateAuctionDto, CarItem>();
            CreateMap<AuctionDto, AuctionCreated>();;
            CreateMap<Auction, AuctionUpdated>().IncludeMembers(x => x.Item);
            CreateMap<CarItem, AuctionUpdated>();
        }
    }
}
