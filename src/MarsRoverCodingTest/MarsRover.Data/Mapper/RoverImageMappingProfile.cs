using MarsRover.Data.DTO;
using MarsRover.Data.Model;

namespace MarsRover.Data.Mapper
{
    public class RoverImageMappingProfile : AutoMapper.Profile
    {
        public RoverImageMappingProfile()
        {
            CreateMap<Photo, RoverImageDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImgSrc.AbsoluteUri))
                .ForMember(dest => dest.CameraName, opt => opt.MapFrom(src => src.Camera.Name))
                .ForMember(dest => dest.RoverName, opt => opt.MapFrom(src => src.Rover.Name))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => GetFilePath(src)))
                ;
        }

        private string GetFilePath(Photo src)
        {
            string filename = System.IO.Path.GetFileName(src.ImgSrc.LocalPath);
            return $"{src.EarthDate.ToString("yyyy-MM-dd")}_{src.Rover.Name}_{src.Camera.Name}_{filename}";
        }

    }
}
