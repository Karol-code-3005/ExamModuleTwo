using AutoMapper;
using CCPolandAPI.Models.DTOS.Author;
using CCPolandAPI.Models.DTOS.Genre;
using CCPolandAPI.Models.DTOS.Material;
using CCPolandAPI.Models.DTOS.Review;
using CCPolandAPI.Models.EntityModels;

namespace CCPolandAPI.Services.AutoMapperProfiles
{
    public class APIProfiles :Profile
    {
        public APIProfiles()
        {
            //source -> target

            CreateMap<Author, AuthorLongDto>().ReverseMap();
            CreateMap<Author, AuthorShortDto>().ReverseMap();
            CreateMap<Author, AuthorModifyDto>().ReverseMap();

            CreateMap<Genre, GenreLongDto>().ReverseMap(); ;
            CreateMap<Genre, GenreShortDto>().ReverseMap(); ;
            CreateMap<Genre, GenreModifyDto>().ReverseMap();

            CreateMap<Material, MaterialLongDto>().ReverseMap();
            CreateMap<Material, MaterialShortDto>().ReverseMap();
            CreateMap<Material, MaterialModifyDto>().ReverseMap();

            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, ReviewModifyDto>().ReverseMap();


            //dodawanie nowego review?
            // updatowanie review? 
            //spr w ReviewRepo!
        }
    }
}
