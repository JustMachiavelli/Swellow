using Microsoft.EntityFrameworkCore;
using Swellow.Data.SqlModel.Episode;
using Swellow.Data.SqlModel.LocalFile;
using Swellow.Data.SqlModel.Middle;
using Swellow.Data.SqlModel.People;
using Swellow.Data.SqlModel.Property;
using Swellow.Data.SqlModel.View;
using Swellow.Data.SqlModel.Works;
using System.Collections.Generic;

namespace Swellow
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
            modelBuilder.Entity<Video>().HasDiscriminator(Video => Video.Type)
                                        .HasValue<Movie>("movie")
                                        .HasValue<Tv>("tv"); ;
            modelBuilder.Entity<Movie>().Property(Movie => Movie.IdDouban).HasColumnName("IdDouban");
            modelBuilder.Entity<Movie>().Property(Movie => Movie.IdImdb).HasColumnName("IdImdb");
            modelBuilder.Entity<Movie>().Property(Movie => Movie.IdTmdb).HasColumnName("IdTmdb");
            modelBuilder.Entity<Tv>().Property(Video => Video.IdDouban).HasColumnName("IdDouban");
            modelBuilder.Entity<Tv>().Property(Video => Video.IdImdb).HasColumnName("IdImdb");
            modelBuilder.Entity<Tv>().Property(Video => Video.IdTmdb).HasColumnName("IdTmdb");

            // ========设置联合组键========
            // <影视作品，演员>
            modelBuilder.Entity<VideoActor>().HasKey(VideoActor => new { VideoActor.IdVideo, VideoActor.IdCast });
            modelBuilder.Entity<VideoActor>()
                        .HasOne(VideoActor => VideoActor.Video)
                        .WithMany(Video => Video.VideoActors)
                        .HasForeignKey(VideoActor => VideoActor.IdVideo);
            modelBuilder.Entity<VideoActor>()
                        .HasOne(VideoActor => VideoActor.Cast)
                        .WithMany(Actor => Actor.VideoActors)
                        .HasForeignKey(VideoActor => VideoActor.IdCast);

            // <影视作品，导演>
            modelBuilder.Entity<VideoDirector>().HasKey(vd => new { vd.IdVideo, vd.IdCast });
            modelBuilder.Entity<VideoDirector>()
                        .HasOne(VideoDirector => VideoDirector.Video)
                        .WithMany(Video => Video.VideoDirectors)
                        .HasForeignKey(VideoDirector => VideoDirector.IdVideo);
            modelBuilder.Entity<VideoDirector>()
                        .HasOne(VideoDirector => VideoDirector.Cast)
                        .WithMany(Cast => Cast.VideoDirectors)
                        .HasForeignKey(VideoDirector => VideoDirector.IdCast);

            // <影视作品，特征>
            modelBuilder.Entity<VideoGenre>().HasKey(VideoGenre => new { VideoGenre.IdVideo, VideoGenre.IdGenre });
            modelBuilder.Entity<VideoGenre>()
                        .HasOne(VideoGenre => VideoGenre.Video)
                        .WithMany(Video => Video.VideoGenres)
                        .HasForeignKey(VideoGenre => VideoGenre.IdVideo);
            modelBuilder.Entity<VideoGenre>()
                        .HasOne(VideoGenre => VideoGenre.Genre)
                        .WithMany(Genre => Genre.VideoGenres)
                        .HasForeignKey(VideoGenre => VideoGenre.IdGenre);

            // <影视作品，发行商>
            modelBuilder.Entity<VideoPublisher>().HasKey(VideoPublisher => new { VideoPublisher.IdVideo, VideoPublisher.IdPublisher });
            modelBuilder.Entity<VideoPublisher>()
                        .HasOne(VideoPublisher => VideoPublisher.Video)
                        .WithMany(Video => Video.VideoPublishers)
                        .HasForeignKey(VideoPublisher => VideoPublisher.IdVideo);
            modelBuilder.Entity<VideoPublisher>()
                        .HasOne(VideoPublisher => VideoPublisher.Publisher)
                        .WithMany(Publisher => Publisher.VideoPublishers)
                        .HasForeignKey(VideoPublisher => VideoPublisher.IdPublisher);

            // <影视作品，制作商>
            modelBuilder.Entity<VideoStudio>().HasKey(vs => new { vs.IdVideo, vs.IdStudio });
            modelBuilder.Entity<VideoStudio>()
                        .HasOne(VideoStudio => VideoStudio.Video)
                        .WithMany(Video => Video.VideoStudios)
                        .HasForeignKey(VideoStudio => VideoStudio.IdVideo);
            modelBuilder.Entity<VideoStudio>()
                        .HasOne(VideoStudio => VideoStudio.Studio)
                        .WithMany(Studio => Studio.VideoStudios)
                        .HasForeignKey(VideoStudio => VideoStudio.IdStudio);

            // <影视作品，标签>
            modelBuilder.Entity<VideoTag>().HasKey(vt => new { vt.IdVideo, vt.IdTag });
            modelBuilder.Entity<VideoTag>()
                        .HasOne(VideoTag => VideoTag.Video)
                        .WithMany(Video => Video.VideoTags)
                        .HasForeignKey(VideoTag => VideoTag.IdVideo);
            modelBuilder.Entity<VideoTag>()
                        .HasOne(VideoTag => VideoTag.Tag)
                        .WithMany(Tag => Tag.VideoTags)
                        .HasForeignKey(VideoTag => VideoTag.IdTag);

            // <电影CD, 电影>
            modelBuilder.Entity<EpisodeMovie>()
                        .HasOne(EpisodeMovie => EpisodeMovie.Movie)
                        .WithMany(Movie => Movie.EpisodeMovies)
                        .HasForeignKey(EpisodeMovie => EpisodeMovie.IdMovie);

            // <电视剧单集，电视剧>
            modelBuilder.Entity<EpisodeTv>()
                        .HasOne(EpisodeTv => EpisodeTv.Tv)
                        .WithMany(Tv => Tv.EpisodeTvs)
                        .HasForeignKey(EpisodeTv => EpisodeTv.IdTv);

            // 文件夹路径
            modelBuilder.Entity<PathDirectory>()
                        .HasOne(PathDirectory => PathDirectory.Library)
                        .WithMany(Library => Library.PathDirectorys)
                        .HasForeignKey(PathDirectory => PathDirectory.IdLibrary);

            // 视频 的 外键 IdSeries、IdLibrary
            modelBuilder.Entity<Video>()
                        .HasOne(Video => Video.Library)
                        .WithMany(Library => Library.Videos)
                        .HasForeignKey(Video => Video.IdLibrary);
            modelBuilder.Entity<Video>()
                        .HasOne(Video => Video.Series)
                        .WithMany(Series => Series.Videos)
                        .HasForeignKey(Video => Video.IdSeries);
        }


        // 1 媒体库
        public DbSet<Library> Librarys { get; set; }

        // 2 影视作品
        public DbSet<Video> Videos { get; set; }
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
        public DbSet<VideoGenre> VideoGenres { get; set; }

        // 8 标签
        public DbSet<Tag> Tags { get; set; }
        // 9 <影视作品，标签>
        public DbSet<VideoTag> VideoTags { get; set; }

        // 10 制作公司
        public DbSet<Studio> Studios { get; set; }
        // 11 <影视作品，制作公司>
        public DbSet<VideoStudio> VideoStudios { get; set; }

        // 12 发行公司
        public DbSet<Publisher> Publishers { get; set; }
        // 13 <影视作品，发行公司>
        public DbSet<VideoPublisher> VideoPublishers { get; set; }

        // 14 系列
        public DbSet<Series> Serieses { get; set; }
    }
}
