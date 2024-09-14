using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;

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
        }
    }
}
