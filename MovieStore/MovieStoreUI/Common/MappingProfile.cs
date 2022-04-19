using System.Linq;
using AutoMapper;
using MovieStoreUI.Application.ActorOperations.Commands.CreateActor;
using MovieStoreUI.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreUI.Application.ActorOperations.Queries.GetActors;
using MovieStoreUI.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreUI.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            /* Actor Mapping Operations Start */
            CreateMap<Actor, ActorsViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src => src.FirstName + " " + src.LastName))
             .ForMember(dest=>dest.Movies, opt=>opt.MapFrom(src=>src.MovieActors.Select(ma => ma.Movie).ToList()));
             CreateMap<Movie, ActorsViewModel.MovieActorViewModel>();

            CreateMap<Actor, ActorDetailViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest=>dest.Movies, opt=>opt.MapFrom(src=>src.MovieActors.Select(ma => ma.Movie).ToList()));
            CreateMap<Movie, ActorDetailViewModel.MovieActorViewModel>();
            CreateMap<CreateActorViewModel, Actor>();
            /* Actor Mapping Operations End */


            /* Director Mapping Operations Start */
            CreateMap<CreateDirectorViewModel, Director>();
            CreateMap<Director, DirectorDetailViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest=>dest.Movies, opt=>opt.MapFrom(src =>src.Movies.ToList()));
            CreateMap<Movie, DirectorDetailViewModel.MovieList>();

            CreateMap<Director, GetDirectorsViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.Movies, opt=>opt.MapFrom(src =>src.Movies.ToList()));
            CreateMap<Movie, GetDirectorsViewModel.MovieList>();
            /* Director Mapping Operations End */

            /* Movie Mapping Operations Start */
            CreateMap<CreateMovieViewModel, Movie>();
            /* Movie Mapping Operations End */
        }
    }
}