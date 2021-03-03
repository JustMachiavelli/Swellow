using Swellow.Shared.SqlModel.LocalFile;
using Swellow.Shared.SqlModel.Middle;
using Swellow.Shared.SqlModel.People;
using Swellow.Shared.SqlModel.Property;
using Swellow.Shared.SqlModel.View;
using Swellow.Shared.SqlModel.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swellow.Shared
{
    public class DbInitializer
    {
        public static void Initialize(SwellowDbContext context)
        {
            context.Database.EnsureCreated();

            // 如果LibraryPreviews有数据了，就不初始化数据库。
            if (context.Librarys.Any())
            {
                return;   // DB has been seeded
            }

            AddLibrary(context);
            // ==== Library ====
            Library librarySF = context.Librarys.FirstOrDefault(library => library.Name == "科幻");
            Library libraryComic = context.Librarys.FirstOrDefault(library => library.Name == "动漫");

            Movie movielldq = new Movie
            {
                Type = "movie",
                Title = "流浪地球(2019)",
                TitleOrigin = "流浪地球",
                TitleOriginZh = "流浪地球",
                Plot = "近未来，科学家们发现太阳急速衰老膨胀，短时间内包括地球在内的整个太阳系都将被太阳所吞没。为了自救，人类提出一个名为“流浪地球IdDouban”的大胆计划，即倾全球之力在地球表面建造上万座发动机和转向发动机，推动地球离开太阳系，用2500年的时间奔往另外一个栖息之地。中国航天员刘培强（吴京 饰）在儿子刘启四岁那年前往国际空间站，和国际同侪肩负起领航者的重任。转眼刘启（屈楚萧 饰）长大，他带着妹妹朵朵（赵今麦 饰）偷偷跑到地表，偷开外公韩子昂（吴孟达 饰）的运输车，结果不仅遭到逮捕，还遭遇了全球发动机停摆的事件。为了修好发动机，阻止地球坠入木星，全球开始展开饱和式营救，连刘启他们的车也被强征加入。在与时间赛跑的过程中，无数的人前仆后继，奋不顾身，只为延续百代子孙生存的希望……",
                PlotOrigin = "",
                Runtime = 150,
                Year = "2019",
                Date = "2019-01-01",
                Score = 79,
                Region = "中国大陆",
                IdImdb = "tt7605074",
                IdTmdb = "535167",
                IdDouban = "26266893",
                Series = new Series { Name = "刘慈欣作品" },
                Library = librarySF,
            };
            movielldq.VideoDirectors = GetVideoDirectors(context, new string[] { "郭帆" });
            movielldq.VideoActors = GetVideoActors(context, new string[] { "吴京", "屈楚萧", "赵今麦", "吴孟达" });
            movielldq.VideoStudios = GetVideoStudios(context, new string[] { "郭帆文化传媒（北京）有限公司", "北京京西文化旅游股份有限公司" });
            movielldq.VideoPublishers = GetVideoPublishers(context, new string[] { "中国电影股份有限公司", "北京京西文化旅游股份有限公司", });
            movielldq.VideoGenres = GetVideoGenres(context, new string[] { "犯罪", "惊悚", "剧情" });
            movielldq.VideoTags = GetVideoTags(context, new string[] { "城市", "地铁", "癫狂" });

            Movie moviexc = new Movie
            {
                Type = "movie",
                Title = "小丑(2019)",
                TitleOrigin = "Joker",
                TitleOriginZh = "小丑",
                Plot = "湿冷无望的哥谭市，卑微的亚瑟·弗兰克（华金·菲尼克斯 Joaquin Phoenix 饰）依靠扮演小丑赚取营生。与之相依为命的母亲患有精神疾病，而亚瑟深记母亲的教诲，无论遭受怎样的挫折都笑对人生，却因此让自己背负着莫大的压力，濒临崩溃。他梦想成为一名脱口秀演员，怎奈生活一次次将失望狠狠地砸在他的头上。不仅如此，他因意外丢掉了工作，偶然瞥见母亲的秘密，又使他心中燃起对那个与之地位悬殊却从未谋面的父亲的殷切渴望。命运习惯了事与愿违，空荡荡的地铁内，悲伤的小丑在无法自已的癫狂笑声中大开杀戒……",
                PlotOrigin = "",
                Runtime = 150,
                Year = "2019",
                Date = "2019-08-31",
                Score = 79,
                Region = "美国",
                IdImdb = "tt7605074",
                IdTmdb = "535167",
                IdDouban = "26266893",
                Series = new Series { Name = "漫威宇宙" },
                Library = librarySF,
            };
            moviexc.VideoDirectors = GetVideoDirectors(context, new string[] { "托德·菲利普斯" });
            moviexc.VideoActors = GetVideoActors(context, new string[] { "华金·菲尼克斯", "罗伯特·德尼罗", "马克·马龙", "莎姬·贝兹", "谢伊·惠格姆" });
            moviexc.VideoStudios = GetVideoStudios(context, new string[] { "华纳兄弟公司", "DC Comics", "美国威秀影片公司", "Bron Studios", "DC Comics", "22 & Indiana Pictures" });
            moviexc.VideoPublishers = GetVideoPublishers(context, new string[] { "华纳兄弟公司", "Karo Premiere", "Tanweer Alliances", "Bron Studios", "NOS Audiovisuais", });
            moviexc.VideoGenres = GetVideoGenres(context, new string[] { "犯罪", "惊悚", "剧情" });
            moviexc.VideoTags = GetVideoTags(context, new string[] { "城市", "地铁", "癫狂" });

            Movie moviejsc = new Movie
            {
                Type = "movie",
                Title = "寄生虫(2019)",
                TitleOrigin = "기생충",
                TitleOriginZh = "寄生虫",
                Plot = "基宇（崔宇植 饰）出生在一个贫穷的家庭之中，和妹妹基婷（朴素丹 饰）以及父母在狭窄的地下室里过着相依为命的日子。一天，基宇的同学上门拜访，他告诉基宇，自己在一个有钱人家里给他们的女儿做家教，太太是一个头脑简单出手又阔绰的女人，因为自己要出国留学，所以将家教的职位暂时转交给基宇。就这样，基宇来到了朴社长（李善均 饰）家中，并且见到了他的太太（赵汝贞 饰），没过多久，基宇的妹妹和父母也如同寄生虫一般的进入了朴社长家里工作。然而，他们的野心并没有止步于此，基宇更是和大小姐坠入了爱河。随着时间的推移，朴社长家里隐藏的秘密渐渐浮出了水面。",
                PlotOrigin = "",
                Runtime = 150,
                Year = "2019",
                Date = "2019-05-21",
                Score = 87,
                Region = "韩国",
                IdImdb = "tt6751668",
                IdTmdb = "535167",
                IdDouban = "27010768",
                Series = new Series { Name = "未知系列" },
                Library = librarySF,
            };
            moviejsc.VideoDirectors = GetVideoDirectors(context, new string[] { "奉俊昊" });
            moviejsc.VideoActors = GetVideoActors(context, new string[] { "宋康昊", "李善均", "赵茹珍", "崔宇植", "朴素丹" });
            moviejsc.VideoStudios = GetVideoStudios(context, new string[] { "CJ Entertainment", "Barunson E&A", });
            moviejsc.VideoPublishers = GetVideoPublishers(context, new string[] { "CJ Entertainment", });
            moviejsc.VideoGenres = GetVideoGenres(context, new string[] { "剧情", "喜剧",});
            moviejsc.VideoTags = GetVideoTags(context, new string[] { "上班族", "家庭", "城市" });

            Movie moviegqzq = new Movie
            {
                Type = "movie",
                Title = "名侦探柯南剧场版20：绀青之拳(2019)",
                TitleOrigin = "名探偵コナン 紺青の拳",
                TitleOriginZh = "名侦探柯南剧场版20：绀青之拳",
                Plot = "“名侦探柯南系列”第23部动画剧场版，票房和口碑也屡破纪录。作为平成年代最后一部柯南电影，首次将案件发生地设立在海外，基德时隔四年后再度回归，与柯南合体展开行动。故事围绕着19世纪末与海盗船一同沉入海底、世界上最大的蓝宝石“绀青之拳”展开。",
                PlotOrigin = "",
                Runtime = 110,
                Year = "2019",
                Date = "2019-04-12",
                Score = 59,
                Region = "日本",
                IdImdb = "tt9501310",
                IdTmdb = "535167",
                IdDouban = "30208010",
                Series = new Series { Name = "未知系列" },
                Library = libraryComic,
            };
            moviegqzq.VideoDirectors = GetVideoDirectors(context, new string[] { "永冈智佳" });
            moviegqzq.VideoActors = GetVideoActors(context, new string[] { "高山南", "山口胜平", "山崎和佳奈", "小山力也", "绪方贤一" });
            moviegqzq.VideoStudios = GetVideoStudios(context, new string[] { "名侦探柯南制作委员会", });
            moviegqzq.VideoPublishers = GetVideoPublishers(context, new string[] { "东宝株式会社", "小学馆", });
            moviegqzq.VideoGenres = GetVideoGenres(context, new string[] { "动画 ", "悬疑", });
            moviegqzq.VideoTags = GetVideoTags(context, new string[] { "飞机", "度假", "友情" });


            context.Movies.AddRange(movielldq, moviexc, moviejsc, moviegqzq);
            context.SaveChanges();
        }


        public static void AddLibrary(SwellowDbContext context)
        {
            // 添加LibraryPreviews
            List<Library> Librarys = new List<Library>
            {
                new Library
                {
                    Name = "科幻",
                    Type = "电影",
                    PathPicture = "/swellowdata/images/library/preview/1.jpg",
                    PathDirectorys = new List<PathDirectory>
                    {
                        new PathDirectory{ Path = "/testmovies/科幻1", },
                        new PathDirectory{ Path = "/testmovies/科幻2", },
                        new PathDirectory{ Path = "/testmovies/科幻3", },
                    }
                },
                new Library
                {
                    Name = "动漫",
                    Type = "电影",
                    PathPicture = "/swellowdata/images/library/preview/2.jpg",
                    PathDirectorys = new List<PathDirectory>
                    {
                        new PathDirectory{ Path = "/testmovies/喜剧1", },
                        new PathDirectory{ Path = "/testmovies/喜剧2", },
                    }
                },
            };

            foreach (Library library in Librarys)
            {
                context.Librarys.Add(library);
            }
            context.SaveChanges();
        }


        public static List<VideoDirector> GetVideoDirectors(SwellowDbContext context, Array array)
        {
            List<VideoDirector> videoDirectors = new List<VideoDirector>();
            // ==== 导演 ====
            foreach (string directorSearch in array)
            {
                Cast directorAlready = context.Casts.FirstOrDefault(cast => cast.Name == directorSearch);
                Cast director = new Cast();
                // 数据库还不存在该【特征】，添加它
                if (directorAlready == null)
                {
                    director.Name = directorSearch;
                }
                else
                {
                    director = directorAlready;
                }
                // 一个新的导航属性<影片，特征>
                VideoDirector videoDirector = new VideoDirector()
                {
                    Cast = director,
                };
                videoDirectors.Add(videoDirector);
            }
            return videoDirectors;
        }


        public static List<VideoActor> GetVideoActors(SwellowDbContext context, Array array)
        {
            List<VideoActor> videoActors = new List<VideoActor>();
            // ==== 演员 ====
            foreach (string actorSearch in array)
            {
                Cast actorAlready = context.Casts.FirstOrDefault(g => g.Name == actorSearch);
                Cast actor = new Cast();
                // 数据库还不存在该【特征】，添加它
                if (actorAlready == null)
                {
                    actor.Name = actorSearch;
                }
                else
                {
                    actor = actorAlready;
                }
                // 一个新的导航属性<影片，特征>
                VideoActor videoActor = new VideoActor()
                {
                    Cast = actor,
                };
                videoActors.Add(videoActor);
            }
            return videoActors;
        }


        public static List<VideoStudio> GetVideoStudios(SwellowDbContext context, Array array)
        {
            List<VideoStudio> videoStudios = new List<VideoStudio>();
            // ==== 制作公司 ====
            foreach (string studioSearch in array)
            {
                Studio studioAlready = context.Studios.FirstOrDefault(g => g.Name == studioSearch);
                Studio studio = new Studio();
                // 数据库还不存在该【特征】，添加它
                if (studioAlready == null)
                {
                    studio.Name = studioSearch;
                }
                else
                {
                    studio = studioAlready;
                }
                // 一个新的导航属性<影片，特征>
                VideoStudio videoStudio = new VideoStudio()
                {
                    Studio = studio,
                };
                videoStudios.Add(videoStudio);
            }
            return videoStudios;
        }


        public static List<VideoPublisher> GetVideoPublishers(SwellowDbContext context, Array array)
        {
            List<VideoPublisher> videoDirectors = new List<VideoPublisher>();
            // ==== 出品公司 ====
            foreach (string publisherSearch in array)
            {
                Publisher publisherAlready = context.Publishers.FirstOrDefault(g => g.Name == publisherSearch);
                Publisher publisher = new Publisher();
                // 数据库还不存在该【特征】，添加它
                if (publisherAlready == null)
                {
                    publisher.Name = publisherSearch;
                }
                else
                {
                    publisher = publisherAlready;
                }
                // 一个新的导航属性<影片，特征>
                VideoPublisher videoPublisher = new VideoPublisher()
                {
                    Publisher = publisher,
                };
                videoDirectors.Add(videoPublisher);
            }
            return videoDirectors;
        }


        public static List<VideoGenre> GetVideoGenres(SwellowDbContext context, Array array)
        {
            List<VideoGenre> videoGenres = new List<VideoGenre>();
            // ==== 特征 ====
            foreach (string genreSearch in array)
            {
                Genre genreAlready = context.Genres.FirstOrDefault(g => g.Name == genreSearch);
                Genre genre = new Genre();
                // 数据库还不存在该【特征】，添加它
                if (genreAlready == null)
                {
                    genre.Name = genreSearch;
                }
                else
                {
                    genre = genreAlready;
                }
                // 一个新的导航属性<影片，特征>
                VideoGenre videoGenre = new VideoGenre()
                {
                    Genre = genre,
                };
                videoGenres.Add(videoGenre);
            }
            return videoGenres;
        }


        public static List<VideoTag> GetVideoTags(SwellowDbContext context, Array array)
        {
            List<VideoTag> videoTags = new List<VideoTag>();
            // ==== 标签 ====
            foreach (string tagSearch in array)
            {
                Tag tagAlready = context.Tags.FirstOrDefault(g => g.Name == tagSearch);
                Tag tag = new Tag();
                // 数据库还不存在该【特征】，添加它
                if (tagAlready == null)
                {
                    tag.Name = tagSearch;
                }
                else
                {
                    tag = tagAlready;
                }
                // 一个新的导航属性<影片，特征>
                VideoTag videoTag = new VideoTag()
                {
                    Tag = tag,
                };
                videoTags.Add(videoTag);
            }
            return videoTags;
        }
    }
}
