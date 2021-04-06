using Microsoft.EntityFrameworkCore;
using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Episode;
using Swellow.Model.SqlModel.LocalData;
using Swellow.Model.SqlModel.Middle;
using Swellow.Model.SqlModel.People;
using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.View;
using Swellow.Model.SqlModel.Works;
using Swellow.Model.SqlModel.Works.Film;
using Swellow.Model.SqlModel.Works.Television;
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

        // Asp用下面
        public SwellowDbContext(DbContextOptions<SwellowDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ========中间件========
            // <影视作品，演员>
            modelBuilder.Entity<WorkCast>().HasKey(WorkCast => new { WorkCast.WorkId, WorkCast.CastId });
            modelBuilder.Entity<WorkCast>()
                        .HasOne(WorkCast => WorkCast.Work)
                        .WithMany(Work => Work.WorkCasts)
                        .HasForeignKey(WorkCast => WorkCast.WorkId);
            modelBuilder.Entity<WorkCast>()
                        .HasOne(WorkCast => WorkCast.Cast)
                        .WithMany(Cast => Cast.WorkCasts)
                        .HasForeignKey(WorkCast => WorkCast.CastId);

            // <影视作品，特征>
            modelBuilder.Entity<WorkGenre>().HasKey(WorkGenre => new { WorkGenre.WorkId, WorkGenre.GenreId });
            modelBuilder.Entity<WorkGenre>()
                        .HasOne(WorkGenre => WorkGenre.Work)
                        .WithMany(Work => Work.WorkGenres)
                        .HasForeignKey(WorkGenre => WorkGenre.WorkId);
            modelBuilder.Entity<WorkGenre>()
                        .HasOne(WorkGenre => WorkGenre.Genre)
                        .WithMany(Genre => Genre.WorkGenres)
                        .HasForeignKey(WorkGenre => WorkGenre.GenreId);

            // <影视作品，发行商>
            modelBuilder.Entity<WorkCompany>().HasKey(WorkCompany => new { WorkCompany.WorkId, WorkCompany.CompanyId });
            modelBuilder.Entity<WorkCompany>()
                        .HasOne(WorkCompany => WorkCompany.Work)
                        .WithMany(Work => Work.WorkCompanys)
                        .HasForeignKey(WorkCompany => WorkCompany.WorkId);
            modelBuilder.Entity<WorkCompany>()
                        .HasOne(WorkCompany => WorkCompany.Company)
                        .WithMany(Company => Company.WorkCompanys)
                        .HasForeignKey(WorkCompany => WorkCompany.CompanyId);

            // <影视作品，标签>
            modelBuilder.Entity<WorkTag>().HasKey(vt => new { vt.WorkId, vt.TagId });
            modelBuilder.Entity<WorkTag>()
                        .HasOne(WorkTag => WorkTag.Work)
                        .WithMany(Work => Work.WorkTags)
                        .HasForeignKey(WorkTag => WorkTag.WorkId);
            modelBuilder.Entity<WorkTag>()
                        .HasOne(WorkTag => WorkTag.Tag)
                        .WithMany(Tag => Tag.WorkTags)
                        .HasForeignKey(WorkTag => WorkTag.TagId);


            // 文件夹路径
            modelBuilder.Entity<VideoFolder>()
                        .HasOne(MeidaDirectory => MeidaDirectory.Library)
                        .WithMany(Library => Library.Directorys)
                        .HasForeignKey(MeidaDirectory => MeidaDirectory.LibraryId);

            // 视频 的 外键 IdSeries、IdLibrary
            modelBuilder.Entity<Work>()
                        .HasOne(Work => Work.Library)
                        .WithMany(Library => Library.Works)
                        .HasForeignKey(Mix => Mix.LibraryId);
            modelBuilder.Entity<Work>()
                        .HasOne(Work => Work.Series)
                        .WithMany(Series => Series.Works)
                        .HasForeignKey(Work => Work.SeriesId);
        }


        // 1 媒体库
        public DbSet<Library> Librarys { get; set; }

        // 2 影视作品
        public DbSet<Work> Works { get; set; }

        // 3 电视剧
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        // 4 电影
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CD> CDs { get; set; }

        // 3 演职人员
        public DbSet<Cast> Casts { get; set; }
        // 4 <影视作品，演员>
        public DbSet<WorkCast> WorkCasts { get; set; }

        // 6 特征
        public DbSet<Genre> Genres { get; set; }
        // <影视作品，特征>
        public DbSet<WorkGenre> WorkGenres { get; set; }

        // 8 标签
        public DbSet<Tag> Tags { get; set; }
        // <影视作品，标签>
        public DbSet<WorkTag> WorkTags { get; set; }

        // 10 制作公司
        public DbSet<Company> Companys { get; set; }
        // <影视作品，制作公司>
        public DbSet<WorkCompany> WorkCompanys { get; set; }

        // 14 系列
        public DbSet<Series> Serieses { get; set; }
    }
}
