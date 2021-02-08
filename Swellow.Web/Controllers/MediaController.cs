using Microsoft.AspNetCore.Mvc;
using Swellow.Data.SqlModel.People;
using Swellow.Data.SqlModel.Property;
using Swellow.Data.SqlModel.View;
using Swellow.Data.SqlModel.Works;
using Swellow.Data.Worker;
using Swellow.Web.ModelComponents;
using Swellow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Web.Controllers
{
    public class MediaController : Controller
    {
        private readonly ViewModelWorker _viewModelWorker;

        public MediaController(ViewModelWorker viewModelWorker)
        {
            _viewModelWorker = viewModelWorker;
        }

        // 媒体库首页
        public IActionResult Home()
        {
            List<LibraryPreview> libraryPreviews = new List<LibraryPreview>();
            foreach (Library library in _viewModelWorker.GetAllLibrarys())
            {
                LibraryPreview libraryPreview = new LibraryPreview
                {
                    Id = library.Id,
                    Name = library.Name,
                    PathPicture = library.PathPicture,
                };
                libraryPreviews.Add(libraryPreview);
            };

            HomeViewModel homeViewModel = new HomeViewModel
            {
                LibraryPreviews = libraryPreviews,
            };
            return View(homeViewModel);
        }


        //媒体库详情
        //GET: LibraryController/Details/5
        public ActionResult Library(int id)
        {
            IEnumerable<Video> videos = _viewModelWorker.GetVideosByLibraryId(id);
            List<VideoPreview> videoPreviews = new List<VideoPreview>();
            foreach (Video video in videos)
            {
                VideoPreview videoPreview = new VideoPreview
                {
                    Id = video.Id,
                    Title = video.Title,
                    PathPoster = video.PathPoster,
                    Year = video.Year,
                    Type = video.Type,
                };
                videoPreviews.Add(videoPreview);
            };
            LibraryViewModel libraryViewModel = new LibraryViewModel
            {
                LibraryName = _viewModelWorker.GetLibraryNameById(id),
                VideoPreviews = videoPreviews,
            }; ;
            return View(libraryViewModel);
        }


        // GET: VideoController/Details/5
        public ActionResult Movie(int id)
        {
            Movie movie = _viewModelWorker.GetMovieById(id);
            IEnumerable<Cast> actors = movie.VideoActors.Select(VideoActor => VideoActor.Cast);
            IEnumerable<Cast> directors = movie.VideoDirectors.Select(VideoActor => VideoActor.Cast);
            IEnumerable<Genre> genres = movie.VideoGenres.Select(VideoGenre => VideoGenre.Genre);
            MovieViewModel movieViewModel = new MovieViewModel
            {
                Movie = movie,
                Actors = actors,
                Directors = directors,
                Genres = genres,
            };
            return View(movieViewModel);
        }


        public ActionResult Cast(int id)
        {
            Cast cast = _viewModelWorker.GetCastById(id);
            IEnumerable<Video> videosActed = cast.VideoActors.Select(VideoActor=>VideoActor.Video);
            List<VideoPreview> videoActedPreviews = new List<VideoPreview>();
            foreach (Video video in videosActed)
            {
                VideoPreview videoActedPreview = new VideoPreview
                {
                    Id = video.Id,
                    Title = video.Title,
                    PathPoster = video.PathPoster,
                    Year = video.Year,
                    Type = video.Type,
                };
                videoActedPreviews.Add(videoActedPreview);
            };
            IEnumerable<Video> videosDirected = cast.VideoDirectors.Select(VideoDirector => VideoDirector.Video);
            List<VideoPreview> videoDirectedPreviews = new List<VideoPreview>();
            foreach (Video video in videosDirected)
            {
                VideoPreview videoDirectedPreview = new VideoPreview
                {
                    Id = video.Id,
                    Title = video.Title,
                    PathPoster = video.PathPoster,
                    Year = video.Year,
                    Type = video.Type,
                };
                videoDirectedPreviews.Add(videoDirectedPreview);
            };
            CastDetailViewModel castDetailViewModel = new CastDetailViewModel
            {
                Cast = cast,
                VideoActedPreviews = videoActedPreviews,
                VideoDirectedPreviews = videoDirectedPreviews,
            };
            return View(castDetailViewModel);
        }
    }
}
