using Swellow.Model.Enum;
using Swellow.Model.SqlModel.LocalFile;
using Swellow.Model.SqlModel.Middle;
using Swellow.Model.SqlModel.People;
using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.View;
using Swellow.Model.SqlModel.Works.Film;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swellow.API.Sql.Init
{
    public class DbInitializer
    {
        public static void Initialize(SwellowDbContext context)
        {
            context.Database.EnsureCreated();

            // 如果有数据了，就不初始化数据库种子
            if (context.Librarys.Any())
            {
                return;
            }

            AddLibrary(context);
            // ==== Library ====
            Library librarySF = context.Librarys.FirstOrDefault(library => library.Name == "科幻");
            Library libraryComic = context.Librarys.FirstOrDefault(library => library.Name == "动漫");

            Movie movie1 = new ()
            {
                Type = MovieType.Common,
                Display = "流浪地球(2019)",
                Title = "流浪地球",
                Plot = "近未来，科学家们发现太阳急速衰老膨胀，短时间内包括地球在内的整个太阳系都将被太阳所吞没。为了自救，人类提出一个名为“流浪地球IdDouban”的大胆计划，即倾全球之力在地球表面建造上万座发动机和转向发动机，推动地球离开太阳系，用2500年的时间奔往另外一个栖息之地。中国航天员刘培强（吴京 饰）在儿子刘启四岁那年前往国际空间站，和国际同侪肩负起领航者的重任。转眼刘启（屈楚萧 饰）长大，他带着妹妹朵朵（赵今麦 饰）偷偷跑到地表，偷开外公韩子昂（吴孟达 饰）的运输车，结果不仅遭到逮捕，还遭遇了全球发动机停摆的事件。为了修好发动机，阻止地球坠入木星，全球开始展开饱和式营救，连刘启他们的车也被强征加入。在与时间赛跑的过程中，无数的人前仆后继，奋不顾身，只为延续百代子孙生存的希望……",
                Runtime = 150,
                Year = "2019",
                Date = "2019-01-01",
                Score = 79,
                Region = "中国大陆",
                Fanart = "TestVideos/流浪地球(2019)/fanart.jpg",
                Poster = "TestVideos/流浪地球(2019)/poster.jpg",
                DoubanId = "26266893",
                ImdbId = "tt7605074",
                TmdbId = "535167",
                Library = librarySF,
            };
            List<WorkCast> workCasts1 = new ();
            workCasts1.AddRange(GetWorkCasts(context, new string[] { "郭帆" }, CastType.Director));
            workCasts1.AddRange(GetWorkCasts(context, new string[] { "吴京", "屈楚萧", "赵今麦", "吴孟达" }, CastType.Actor));
            movie1.WorkCasts = workCasts1;

            List<WorkCompany> workCompanies1 = new ();
            workCompanies1.AddRange(GetWorkCompanys(context, new string[] { "郭帆文化传媒（北京）有限公司", "北京京西文化旅游股份有限公司" }, CompanyType.Producer));
            workCompanies1.AddRange(GetWorkCompanys(context, new string[] { "中国电影股份有限公司", "北京京西文化旅游股份有限公司", }, CompanyType.Publisher));
            workCompanies1.AddRange(GetWorkCompanys(context, new string[] { "北京登峰国际文化传播有限公司", "中青新影文化传媒（北京）有限公司", }, CompanyType.Investor));
            movie1.WorkCompanys = workCompanies1;

            movie1.WorkGenres = GetWorkGenres(context, new string[] { "科幻", "灾难" });
            movie1.WorkTags = GetWorkTags(context, new string[] { "冰原", "宇宙", "亲情" });

            Movie movie2 = new ()
            {
                Type = MovieType.Common,
                Display = "冰雪奇缘2(2019)",
                Title = "冰雪奇缘2",
                Plot = "在前作中，阿伦黛尔王国的公主艾莎因为拥有难以控制的强大魔力而选择封闭心扉，远离家园。在妹妹安娜等的帮助鼓舞下，艾莎终于鼓起勇气拥抱真我获得真正的力量。正当艾莎与安娜终于获得了曾经梦寐以求的生活，艾莎却听到了一个神秘声音的呼唤——这声音许诺将揭示她为何拥有冰雪魔法的真相，而这个神秘的真相也威胁着她的王国。艾莎与安娜不得不再次踏上非凡的旅程，前往未知的魔法森林和暗海。在艰险加倍的旅程中，艾莎和安娜的姐妹深情，也更加熠熠生辉，令人动容。",
                Runtime = 103,
                Year = "2019",
                Date = "2019-11-20",
                Score = 73,
                Region = "美国",
                Fanart = "TestVideos/冰雪奇缘2(2019)/fanart.jpg",
                Poster = "TestVideos/冰雪奇缘2(2019)/poster.jpg",
                DoubanId = "26266893",
                ImdbId = "tt7605074",
                TmdbId = "535167",
                Library = librarySF,
            };
            List<WorkCast> workCasts2 = new();
            workCasts2.AddRange(GetWorkCasts(context, new string[] { "托德·菲利普斯" }, CastType.Director));
            workCasts2.AddRange(GetWorkCasts(context, new string[] { "华金·菲尼克斯", "罗伯特·德尼罗", "马克·马龙", "莎姬·贝兹", "谢伊·惠格姆" }, CastType.Actor));
            movie2.WorkCasts = workCasts2;

            List<WorkCompany> workCompanies2 = new();
            workCompanies2.AddRange(GetWorkCompanys(context, new string[] { "华纳兄弟公司", "DC Comics", "美国威秀影片公司", "Bron Studios", "DC Comics", "22 & Indiana Pictures" }, CompanyType.Producer));
            workCompanies2.AddRange(GetWorkCompanys(context, new string[] { "华纳兄弟公司", "Karo Premiere", "Tanweer Alliances", "Bron Studios", "NOS Audiovisuais", }, CompanyType.Producer));
            movie2.WorkCompanys = workCompanies2;

            movie2.WorkGenres = GetWorkGenres(context, new string[] { "动漫", "喜剧", "冒险" });
            movie2.WorkTags = GetWorkTags(context, new string[] { "冰原", "歌舞", });

            Movie movie3 = new ()
            {
                Display = "头文字D(2005)",
                Title = "头文字D",
                Plot = "日本秋名山上的清晨，一辆丰田出产的她中古垢车AE86优美地在下坡道飞驰，车内神秘车手的飘烤移车速使人吃惊。AE86在滕原豆腐店旁停下，睡眼惺忪的少年滕原拓海（周杰伦）回到店里，只见老父滕原文太（黄秋生）醉倒厅中，拓海帮父亲收拾东西，忆起五年来每天清晨代父送豆腐到秋明山上的旅店，心情也沉重起来。&#13; 阿木父亲立花佑一（钟镇涛）开设油站，拓海下课后会来做兼职。中里毅来到油站，挑战阿木的车队，阿木硬着头皮接战。晚上，中里毅开着GTR来到秋名山起步点，凉介早在等候。阿木应战，结果在山路上被中里毅大败。当晚，中里毅在山路上练习时巧遇神秘的AE86，竟被对方轻易击败。中里毅和凉介遂向阿木打探AE86的消息，阿木两父子心知该车为文太所有。&#13; 阿木求文太出战中里毅，文太听到GTR的利害，有点心动。凉介和中里毅在豆腐店出现，原来两人查出文太是当年的传奇车神，并向文太下战书。挑战之夜，AE86上山。阿木见来者竟是拓海，吓了一跳！山路上，AE86再战GTR，拓海利用沟渠拐弯技术将之击败。凉介更诧异于拓海的赛车技术全凭感觉，根本毫无认识。阿木及拓海遇上岩城清次（刘宏）挑战，拓海虽险胜清次，岂料接着却被清次的好友须藤京一报仇（陈小春）。拓海力战下，AE86超越机件极限，引擎失灵。同时，阿木目睹拓海的女友夏树与一个男人步出酒店。拓海同时面对信心、友情及爱情的挑战，究竟如何面对？",
                Runtime = 107,
                Year = "2005",
                Date = "2005-05-12",
                Score = 87,
                Region = "香港",
                DoubanId = "27010768",
                ImdbId = "tt6751668",
                TmdbId = "535167",
                Library = librarySF,
            };
            List<WorkCast> workCasts3 = new ();
            workCasts3.AddRange(GetWorkCasts(context, new string[] { "刘伟强", "麦兆辉" }, CastType.Director));
            workCasts3.AddRange(GetWorkCasts(context, new string[] { "周杰伦", "陈冠希", "铃木杏", "余文乐", "钟镇涛" }, CastType.Actor));
            movie3.WorkCasts = workCasts3;

            List<WorkCompany> workCompanies3 = new();
            workCompanies3.AddRange(GetWorkCompanys(context, new string[] { "CJ Entertainment", "Barunson E&A", }, CompanyType.Producer));
            workCompanies3.AddRange(GetWorkCompanys(context, new string[] { "CJ Entertainment", }, CompanyType.Producer));
            movie3.WorkCompanys = workCompanies3;

            movie3.WorkGenres = GetWorkGenres(context, new string[] { "剧情", "动作",});
            movie3.WorkTags = GetWorkTags(context, new string[] { "赛车", "日本", "情爱" });

            Movie movieg4 = new ()
            {
                Display = "名侦探柯南剧场版20：绀青之拳(2019)",
                Title = "名探偵コナン 紺青の拳",
                PlotOrigin = "“名侦探柯南系列”第23部动画剧场版，票房和口碑也屡破纪录。作为平成年代最后一部柯南电影，首次将案件发生地设立在海外，基德时隔四年后再度回归，与柯南合体展开行动。故事围绕着19世纪末与海盗船一同沉入海底、世界上最大的蓝宝石“绀青之拳”展开。",
                Plot = "",
                Runtime = 110,
                Year = "2019",
                Date = "2019-04-12",
                Score = 59,
                Region = "日本",
                ImdbId = "tt9501310",
                TmdbId = "535167",
                DoubanId = "30208010",
                Series = new Series { NameZh = "未知系列" },
                Library = libraryComic,
            };
            movieg4.VideoDirectors = GetWorkCasts(context, new string[] { "永冈智佳" });
            movieg4.VideoActors = GetVideoActors(context, new string[] { "高山南", "山口胜平", "山崎和佳奈", "小山力也", "绪方贤一" });
            movieg4.VideoStudios = GetWorkCompanys(context, new string[] { "名侦探柯南制作委员会", });
            movieg4.VideoPublishers = GetVideoPublishers(context, new string[] { "东宝株式会社", "小学馆", });
            movieg4.WorkGenres = GetWorkGenres(context, new string[] { "动画 ", "悬疑", });
            movieg4.WorkTags = GetWorkTags(context, new string[] { "飞机", "度假", "友情" });


            context.Movies.AddRange(movie1, movie2, movie3, movieg4);
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
                    Type = LibraryType.Movie,
                    Fanart = "/SwellowData/Images/Library/Preview/1.jpg",
                    Directorys = new List<MeidaDirectory>
                    {
                        new MeidaDirectory{ Path = "/TestMovies/科幻1", },
                        new MeidaDirectory{ Path = "/TestMovies/科幻2", },
                        new MeidaDirectory{ Path = "/TestMovies/科幻3", },
                    }
                },
                new Library
                {
                    Name = "动漫",
                    Type = LibraryType.Movie,
                    Fanart = "/SwellowData/Images/Library/Preview/2.jpg",
                    Directorys = new List<MeidaDirectory>
                    {
                        new MeidaDirectory{ Path = "/TestMovies/喜剧1", },
                        new MeidaDirectory{ Path = "/TestMovies/喜剧2", },
                    }
                },
            };
            foreach (Library library in Librarys)
            {
                context.Librarys.Add(library);
            }
            context.SaveChanges();
        }


        public static List<WorkCast> GetWorkCasts(SwellowDbContext context, Array casts, CastType castType)
        {
            List<WorkCast> workCasts = new ();
            foreach (string castName in casts)
            {
                Cast castAlready = context.Casts.FirstOrDefault(cast => cast.Name == castName);
                Cast cast = new ();
                if (castAlready == null)
                {
                    cast.Name = castName;
                }
                else
                {
                    cast = castAlready;
                }
                WorkCast workCast = new ()
                {
                    Cast = cast,
                    Type = castType,
                };
                workCasts.Add(workCast);
            }
            return workCasts;
        }
        

        public static List<WorkCompany> GetWorkCompanys(SwellowDbContext context, Array companys, CompanyType companyType)
        {
            List<WorkCompany> workCompanies = new ();
            foreach (string companyName in companys)
            {
                Company companyAlready = context.Studios.FirstOrDefault(g => g.Name == companyName);
                Company company = new ();
                if (companyAlready == null)
                {
                    company.Name = companyName;
                }
                else
                {
                    company = companyAlready;
                }
                WorkCompany videoStudio = new ()
                {
                    Company = company,
                    Type = companyType,
                };
                workCompanies.Add(videoStudio);
            }
            return workCompanies;
        }


        public static List<WorkGenre> GetWorkGenres(SwellowDbContext context, Array genres)
        {
            List<WorkGenre> workGenres = new ();
            // ==== 特征 ====
            foreach (string genreName in genres)
            {
                Genre genreAlready = context.Genres.FirstOrDefault(g => g.Name == genreName);
                Genre genre = new ();
                if (genreAlready == null)
                {
                    genre.Name = genreName;
                }
                else
                {
                    genre = genreAlready;
                }
                WorkGenre workGenre = new ()
                {
                    Genre = genre,
                };
                workGenres.Add(workGenre);
            }
            return workGenres;
        }


        public static List<WorkTag> GetWorkTags(SwellowDbContext context, Array tags)
        {
            List<WorkTag> workTags = new ();
            foreach (string tagSearch in tags)
            {
                Tag tagAlready = context.Tags.FirstOrDefault(g => g.Name == tagSearch);
                Tag tag = new ();
                if (tagAlready == null)
                {
                    tag.Name = tagSearch;
                }
                else
                {
                    tag = tagAlready;
                }
                WorkTag workTag = new ()
                {
                    Tag = tag,
                };
                workTags.Add(workTag);
            }
            return workTags;
        }
    }
}
