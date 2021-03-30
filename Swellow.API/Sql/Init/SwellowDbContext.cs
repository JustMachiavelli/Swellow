using Microsoft.EntityFrameworkCore;
using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Episode;
using Swellow.Model.SqlModel.LocalFile;
using Swellow.Model.SqlModel.Middle;
using Swellow.Model.SqlModel.People;
using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.View;
using Swellow.Model.SqlModel.Works;
using System.Collections.Generic;

namespace Swellow.API.Sql.Init
{
    public class SwellowDbContext : DbContext
    {
        // 单数据库用下面
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SwellowDb");
        //}

        // MVC用下面
        public SwellowDbContext(DbContextOptions<SwellowDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Video、Movie、Tv仍然只采用一个Video，以Type属性区分；他们继承的豆瓣等Id共用列。
            modelBuilder.Entity<Work>().HasDiscriminator<WorkType>("Type")
                                        .HasValue<Work>(WorkType.Video)
                                        .HasValue<Movie>(WorkType.Movie)
                                        .HasValue<Tv>(WorkType.Tv);
            modelBuilder.Entity<Movie>().Property(Movie => Movie.DoubanId).HasColumnName("IdDouban");
            modelBuilder.Entity<Movie>().Property(Movie => Movie.ImdbId).HasColumnName("IdImdb");
            modelBuilder.Entity<Movie>().Property(Movie => Movie.TmdbId).HasColumnName("IdTmdb");
            modelBuilder.Entity<Tv>().Property(Video => Video.DoubanId).HasColumnName("IdDouban");
            modelBuilder.Entity<Tv>().Property(Video => Video.ImdbId).HasColumnName("IdImdb");
            modelBuilder.Entity<Tv>().Property(Video => Video.TmdbId).HasColumnName("IdTmdb");

            // ========设置联合主键========
            // <影视作品，演员>
            modelBuilder.Entity<VideoActor>().HasKey(VideoActor => new { VideoActor.VideoId, VideoActor.CastId });
            modelBuilder.Entity<VideoActor>()
                        .HasOne(VideoActor => VideoActor.Video)
                        .WithMany(Video => Video.VideoActors)
                        .HasForeignKey(VideoActor => VideoActor.VideoId);
            modelBuilder.Entity<VideoActor>()
                        .HasOne(VideoActor => VideoActor.Cast)
                        .WithMany(Actor => Actor.VideoActors)
                        .HasForeignKey(VideoActor => VideoActor.CastId);

            // <影视作品，导演>
            modelBuilder.Entity<VideoDirector>().HasKey(vd => new { vd.VideoId, vd.CastId });
            modelBuilder.Entity<VideoDirector>()
                        .HasOne(VideoDirector => VideoDirector.Video)
                        .WithMany(Video => Video.VideoDirectors)
                        .HasForeignKey(VideoDirector => VideoDirector.VideoId);
            modelBuilder.Entity<VideoDirector>()
                        .HasOne(VideoDirector => VideoDirector.Cast)
                        .WithMany(Cast => Cast.VideoDirectors)
                        .HasForeignKey(VideoDirector => VideoDirector.CastId);

            // <影视作品，特征>
            modelBuilder.Entity<WorkGenre>().HasKey(VideoGenre => new { VideoGenre.VideoId, VideoGenre.GenreId });
            modelBuilder.Entity<WorkGenre>()
                        .HasOne(VideoGenre => VideoGenre.Video)
                        .WithMany(Video => Video.WorkGenres)
                        .HasForeignKey(VideoGenre => VideoGenre.VideoId);
            modelBuilder.Entity<WorkGenre>()
                        .HasOne(VideoGenre => VideoGenre.Genre)
                        .WithMany(Genre => Genre.VideoGenres)
                        .HasForeignKey(VideoGenre => VideoGenre.GenreId);

            // <影视作品，发行商>
            modelBuilder.Entity<VideoPublisher>().HasKey(VideoPublisher => new { VideoPublisher.VideoId, VideoPublisher.PublisherId });
            modelBuilder.Entity<VideoPublisher>()
                        .HasOne(VideoPublisher => VideoPublisher.Video)
                        .WithMany(Video => Video.VideoPublishers)
                        .HasForeignKey(VideoPublisher => VideoPublisher.VideoId);
            modelBuilder.Entity<VideoPublisher>()
                        .HasOne(VideoPublisher => VideoPublisher.Publisher)
                        .WithMany(Publisher => Publisher.VideoPublishers)
                        .HasForeignKey(VideoPublisher => VideoPublisher.PublisherId);

            // <影视作品，制作商>
            modelBuilder.Entity<WorkCompany>().HasKey(vs => new { vs.VideoId, vs.StudioId });
            modelBuilder.Entity<WorkCompany>()
                        .HasOne(VideoStudio => VideoStudio.Video)
                        .WithMany(Video => Video.VideoStudios)
                        .HasForeignKey(VideoStudio => VideoStudio.VideoId);
            modelBuilder.Entity<WorkCompany>()
                        .HasOne(VideoStudio => VideoStudio.Studio)
                        .WithMany(Studio => Studio.VideoCompanys)
                        .HasForeignKey(VideoStudio => VideoStudio.StudioId);

            // <影视作品，标签>
            modelBuilder.Entity<WorkTag>().HasKey(vt => new { vt.VideoId, vt.TagId });
            modelBuilder.Entity<WorkTag>()
                        .HasOne(VideoTag => VideoTag.Video)
                        .WithMany(Video => Video.WorkTags)
                        .HasForeignKey(VideoTag => VideoTag.VideoId);
            modelBuilder.Entity<WorkTag>()
                        .HasOne(VideoTag => VideoTag.Tag)
                        .WithMany(Tag => Tag.VideoTags)
                        .HasForeignKey(VideoTag => VideoTag.TagId);

            // <电影CD, 电影>
            modelBuilder.Entity<CD>()
                        .HasOne(EpisodeMovie => EpisodeMovie.Movie)
                        .WithMany(Movie => Movie.EpisodeMovies)
                        .HasForeignKey(EpisodeMovie => EpisodeMovie.MovieId);

            // <电视剧单集，电视剧>
            modelBuilder.Entity<Episode>()
                        .HasOne(EpisodeTv => EpisodeTv.Tv)
                        .WithMany(Tv => Tv.EpisodeTvs)
                        .HasForeignKey(EpisodeTv => EpisodeTv.TvId);

            // 文件夹路径
            modelBuilder.Entity<MeidaDirectory>()
                        .HasOne(PathDirectory => PathDirectory.Library)
                        .WithMany(Library => Library.Directorys)
                        .HasForeignKey(PathDirectory => PathDirectory.LibraryId);

            // 视频 的 外键 IdSeries、IdLibrary
            modelBuilder.Entity<Work>()
                        .HasOne(Video => Video.Library)
                        .WithMany(Library => Library.Videos)
                        .HasForeignKey(Video => Video.LibraryId);
            modelBuilder.Entity<Work>()
                        .HasOne(Video => Video.Series)
                        .WithMany(Series => Series.Videos)
                        .HasForeignKey(Video => Video.SeriesId);
        }


        // 1 媒体库
        public DbSet<Library> Librarys { get; set; }

        // 2 影视作品
        public DbSet<Work> Videos { get; set; }
        // 电影【虚表】
        public DbSet<Movie> Movies { get; set; }
        // 电视剧【虚表】
        public DbSet<Tv> Tvs { get; set; }

        // 3 演职人员
        public DbSet<Cast> Casts { get; set; }

        // 4 <影视作品，演员>
        public DbSet<VideoActor> VideoActors { get; set; }
        // 5 <影视作品，导演>
        public DbSet<VideoDirector> VideoDirectors { get; set; }

        // 6 特征
        public DbSet<Genre> Genres { get; set; }
        // 7 <影视作品，特征>
        public DbSet<WorkGenre> VideoGenres { get; set; }

        // 8 标签
        public DbSet<Tag> Tags { get; set; }
        // 9 <影视作品，标签>
        public DbSet<WorkTag> VideoTags { get; set; }

        // 10 制作公司
        public DbSet<Company> Studios { get; set; }
        // 11 <影视作品，制作公司>
        public DbSet<WorkCompany> VideoStudios { get; set; }

        // 12 发行公司
        public DbSet<Publisher> Publishers { get; set; }
        // 13 <影视作品，发行公司>
        public DbSet<VideoPublisher> VideoPublishers { get; set; }

        // 14 系列
        public DbSet<Series> Serieses { get; set; }
    }
}
