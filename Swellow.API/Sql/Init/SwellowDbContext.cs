using Microsoft.EntityFrameworkCore;
using Swellow.Shared.SqlModel.LocalData;
using Swellow.Shared.SqlModel.MetaData.Media;
using Swellow.Shared.SqlModel.MetaData.Media.Film;
using Swellow.Shared.SqlModel.MetaData.Media.Television;
using Swellow.Shared.SqlModel.MetaData.Middle;
using Swellow.Shared.SqlModel.MetaData.Organization;
using Swellow.Shared.SqlModel.MetaData.Person;
using Swellow.Shared.SqlModel.MetaData.Property;
using Swellow.Shared.SqlModel.View;

namespace Swellow.API.Sql.Init
{
    public class SwellowDbContext : DbContext
    {
        // 单数据库用下面
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SwellowDb");
        //}

        // Asp用下面
        public SwellowDbContext(DbContextOptions<SwellowDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // =============Library相关===============
            // 所含 文件夹路径
            modelBuilder.Entity<Library>()
                        .HasMany(Library => Library.VideoFolders)
                        .WithOne(VideoFolder => VideoFolder.Library)
                        .HasForeignKey(VideoFolder => VideoFolder.LibraryId);
            // 所含 作品
            modelBuilder.Entity<Library>()
                        .HasMany(Library => Library.Works)
                        .WithOne(Work => Work.Library)
                        .HasForeignKey(Work => Work.LibraryId);


            // =============Work相关===============
            // 所含 <影视作品，演职人员>
            modelBuilder.Entity<Work>()
                        .HasMany(Work => Work.WorkCasts)
                        .WithOne(WorkCast => WorkCast.Work)
                        .HasForeignKey(WorkCast => WorkCast.WorkId);
            // 所含<影视作品，公司>
            modelBuilder.Entity<Work>()
                        .HasMany(Work => Work.WorkCompanys)
                        .WithOne(WorkCompany => WorkCompany.Work)
                        .HasForeignKey(WorkCompany => WorkCompany.WorkId);

            // 所含 <影视作品，类型>
            modelBuilder.Entity<Work>()
                        .HasMany(Work => Work.WorkGenres)
                        .WithOne(WorkGenre => WorkGenre.Work)
                        .HasForeignKey(WorkGenre => WorkGenre.WorkId);
            // 所含<影视作品，标签>
            modelBuilder.Entity<Work>()
                        .HasMany(Work => Work.WorkTags)
                        .WithOne(WorkTag => WorkTag.Work)
                        .HasForeignKey(WorkTag => WorkTag.WorkId);

            // 所含剧季
            modelBuilder.Entity<Work>()
                        .HasMany(Work => Work.Seasons)
                        .WithOne(Season => Season.Work)
                        .HasForeignKey(Season => Season.WorkId);
            // 所含Movies
            modelBuilder.Entity<Work>()
                        .HasMany(Work => Work.Movies)
                        .WithOne(Movie => Movie.Work)
                        .HasForeignKey(Movie => Movie.WorkId);

            // 所属系列
            modelBuilder.Entity<Work>()
                        .HasOne(Work => Work.Series)
                        .WithMany(Series => Series.Works)
                        .HasForeignKey(Work => Work.SeriesId);
            // 所属library
            //modelBuilder.Entity<Work>()
            //            .HasOne(Work => Work.Library)
            //            .WithMany(Library => Library.Works)
            //            .HasForeignKey(Work => Work.LibraryId);

            // ################Work相关################


            // =============Season相关===============
            // 所含 剧集
            modelBuilder.Entity<Season>()
                        .HasMany(Season => Season.Episodes)
                        .WithOne(Episode => Episode.Season)
                        .HasForeignKey(Episode => Episode.SeasonId);


            // =============Episode相关===============
            // 所含 CDs
            modelBuilder.Entity<Episode>()
                        .HasMany(Episode => Episode.CDs)
                        .WithOne(CD => CD.Episode)
                        .HasForeignKey(CD => CD.EpisodeId);


            // =============Movie相关===============
            // 所含 CDs
            modelBuilder.Entity<Movie>()
                        .HasMany(Movie => Movie.CDs)
                        .WithOne(CD => CD.Movie)
                        .HasForeignKey(CD => CD.MovieId);


        }


        // 1 媒体库
        public DbSet<Library> Librarys { get; set; }

        // 2 影视作品
        public DbSet<Work> Works { get; set; }

        // 3 电视剧
        public DbSet<Season> Seasons { get; set; }
        // 4 剧季
        public DbSet<Episode> Episodes { get; set; }

        // 5 电影
        public DbSet<Movie> Movies { get; set; }

        // 6 单集CD
        public DbSet<CD> CDs { get; set; }

        // 7 演职人员
        public DbSet<Cast> Casts { get; set; }
        // 8 <影视作品，演员>
        public DbSet<WorkCast> WorkCasts { get; set; }

        // 9 制作公司
        public DbSet<Company> Companys { get; set; }
        // 10 <影视作品，制作公司>
        public DbSet<WorkCompany> WorkCompanys { get; set; }

        // 11 特征
        public DbSet<Genre> Genres { get; set; }
        // 12<影视作品，特征>
        public DbSet<WorkGenre> WorkGenres { get; set; }

        //13 标签
        public DbSet<Tag> Tags { get; set; }
        // 14<影视作品，标签>
        public DbSet<WorkTag> WorkTags { get; set; }

        // 15 系列
        public DbSet<Series> Serieses { get; set; }
    }
}


//// =============4个中间件===============
//// <影视作品，演职人员>
//modelBuilder.Entity<WorkCast>().HasKey(WorkCast => new { WorkCast.WorkId, WorkCast.CastId });
//modelBuilder.Entity<WorkCast>()
//            .HasOne(WorkCast => WorkCast.Work)
//            .WithMany(Work => Work.WorkCasts)
//            .HasForeignKey(WorkCast => WorkCast.WorkId);
//modelBuilder.Entity<WorkCast>()
//            .HasOne(WorkCast => WorkCast.Cast)
//            .WithMany(Cast => Cast.WorkCasts)
//            .HasForeignKey(WorkCast => WorkCast.CastId);

//// <影视作品，公司>
//modelBuilder.Entity<WorkCompany>().HasKey(WorkCompany => new { WorkCompany.WorkId, WorkCompany.CompanyId });
//modelBuilder.Entity<WorkCompany>()
//            .HasOne(WorkCompany => WorkCompany.Work)
//            .WithMany(Work => Work.WorkCompanys)
//            .HasForeignKey(WorkCompany => WorkCompany.WorkId);
//modelBuilder.Entity<WorkCompany>()
//            .HasOne(WorkCompany => WorkCompany.Company)
//            .WithMany(Company => Company.WorkCompanys)
//            .HasForeignKey(WorkCompany => WorkCompany.CompanyId);

//// <影视作品，特征>
//modelBuilder.Entity<WorkGenre>().HasKey(WorkGenre => new { WorkGenre.WorkId, WorkGenre.GenreId });
//modelBuilder.Entity<WorkGenre>()
//            .HasOne(WorkGenre => WorkGenre.Work)
//            .WithMany(Work => Work.WorkGenres)
//            .HasForeignKey(WorkGenre => WorkGenre.WorkId);
//modelBuilder.Entity<WorkGenre>()
//            .HasOne(WorkGenre => WorkGenre.Genre)
//            .WithMany(Genre => Genre.WorkGenres)
//            .HasForeignKey(WorkGenre => WorkGenre.GenreId);

//// <影视作品，标签>
//modelBuilder.Entity<WorkTag>().HasKey(vt => new { vt.WorkId, vt.TagId });
//modelBuilder.Entity<WorkTag>()
//            .HasOne(WorkTag => WorkTag.Work)
//            .WithMany(Work => Work.WorkTags)
//            .HasForeignKey(WorkTag => WorkTag.WorkId);
//modelBuilder.Entity<WorkTag>()
//            .HasOne(WorkTag => WorkTag.Tag)
//            .WithMany(Tag => Tag.WorkTags)
//            .HasForeignKey(WorkTag => WorkTag.TagId);
//// ################4个中间件################