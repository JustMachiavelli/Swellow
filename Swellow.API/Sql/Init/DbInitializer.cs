using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.LocalData;
using Swellow.Shared.SqlModel.MetaData.Media;
using Swellow.Shared.SqlModel.MetaData.Media.Television;
using Swellow.Shared.SqlModel.MetaData.Middle;
using Swellow.Shared.SqlModel.MetaData.Organization;
using Swellow.Shared.SqlModel.MetaData.Person;
using Swellow.Shared.SqlModel.MetaData.Property;
using Swellow.Shared.SqlModel.View;
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
            Library library1 = context.Librarys.FirstOrDefault(library => library.Name == "科幻");
            Library library2 = context.Librarys.FirstOrDefault(library => library.Name == "动漫");

            // =================电影1：流浪地球=====================
            Work movie1 = new ()
            {
                Type = WorkType.SingleMovie,
                Display = "流浪地球(2019)",
                Name = "流浪地球",
                Outline = "近未来，科学家们发现太阳急速衰老膨胀，短时间内包括地球在内的整个太阳系都将被太阳所吞没。为了自救，人类提出一个名为“流浪地球IdDouban”的大胆计划，即倾全球之力在地球表面建造上万座发动机和转向发动机，推动地球离开太阳系，用2500年的时间奔往另外一个栖息之地。中国航天员刘培强（吴京 饰）在儿子刘启四岁那年前往国际空间站，和国际同侪肩负起领航者的重任。转眼刘启（屈楚萧 饰）长大，他带着妹妹朵朵（赵今麦 饰）偷偷跑到地表，偷开外公韩子昂（吴孟达 饰）的运输车，结果不仅遭到逮捕，还遭遇了全球发动机停摆的事件。为了修好发动机，阻止地球坠入木星，全球开始展开饱和式营救，连刘启他们的车也被强征加入。在与时间赛跑的过程中，无数的人前仆后继，奋不顾身，只为延续百代子孙生存的希望……",
                Runtime = 150,
                Year = "2019",
                Date = "2019-01-01",
                Score = 79,
                Region = "中国大陆",
                Fanart = $"TestVideos/流浪地球(2019)/fanart.jpg",
                Poster = "TestVideos/流浪地球(2019)/poster.jpg",
                DoubanId = "26266893",
                ImdbId = "tt7605074",
                TmdbId = "535167",
                Library = library1,
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

            // =================电影2：冰雪奇缘2=====================
            Work movie2 = new ()
            {
                Type = WorkType.SingleMovie,
                Display = "冰雪奇缘2(2019)",
                Name = "冰雪奇缘2",
                Outline = "在前作中，阿伦黛尔王国的公主艾莎因为拥有难以控制的强大魔力而选择封闭心扉，远离家园。在妹妹安娜等的帮助鼓舞下，艾莎终于鼓起勇气拥抱真我获得真正的力量。正当艾莎与安娜终于获得了曾经梦寐以求的生活，艾莎却听到了一个神秘声音的呼唤——这声音许诺将揭示她为何拥有冰雪魔法的真相，而这个神秘的真相也威胁着她的王国。艾莎与安娜不得不再次踏上非凡的旅程，前往未知的魔法森林和暗海。在艰险加倍的旅程中，艾莎和安娜的姐妹深情，也更加熠熠生辉，令人动容。",
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
                Library = library1,
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

            // =================电影3：头文字D=====================
            Work movie3 = new ()
            {
                Type = WorkType.SingleMovie,
                Display = "头文字D(2005)",
                Name = "头文字D",
                Outline = "日本秋名山上的清晨，一辆丰田出产的她中古垢车AE86优美地在下坡道飞驰，车内神秘车手的飘烤移车速使人吃惊。AE86在滕原豆腐店旁停下，睡眼惺忪的少年滕原拓海（周杰伦）回到店里，只见老父滕原文太（黄秋生）醉倒厅中，拓海帮父亲收拾东西，忆起五年来每天清晨代父送豆腐到秋明山上的旅店，心情也沉重起来。&#13; 阿木父亲立花佑一（钟镇涛）开设油站，拓海下课后会来做兼职。中里毅来到油站，挑战阿木的车队，阿木硬着头皮接战。晚上，中里毅开着GTR来到秋名山起步点，凉介早在等候。阿木应战，结果在山路上被中里毅大败。当晚，中里毅在山路上练习时巧遇神秘的AE86，竟被对方轻易击败。中里毅和凉介遂向阿木打探AE86的消息，阿木两父子心知该车为文太所有。&#13; 阿木求文太出战中里毅，文太听到GTR的利害，有点心动。凉介和中里毅在豆腐店出现，原来两人查出文太是当年的传奇车神，并向文太下战书。挑战之夜，AE86上山。阿木见来者竟是拓海，吓了一跳！山路上，AE86再战GTR，拓海利用沟渠拐弯技术将之击败。凉介更诧异于拓海的赛车技术全凭感觉，根本毫无认识。阿木及拓海遇上岩城清次（刘宏）挑战，拓海虽险胜清次，岂料接着却被清次的好友须藤京一报仇（陈小春）。拓海力战下，AE86超越机件极限，引擎失灵。同时，阿木目睹拓海的女友夏树与一个男人步出酒店。拓海同时面对信心、友情及爱情的挑战，究竟如何面对？",
                Runtime = 107,
                Year = "2005",
                Date = "2005-05-12",
                Score = 87,
                Region = "香港",
                DoubanId = "27010768",
                ImdbId = "tt6751668",
                TmdbId = "535167",
                Library = library1,
            };
            List<WorkCast> workCasts3 = new ();
            workCasts3.AddRange(GetWorkCasts(context, new string[] { "刘伟强", "麦兆辉" }, CastType.Director));
            workCasts3.AddRange(GetWorkCasts(context, new string[] { "周杰伦", "陈冠希", "铃木杏", "余文乐", "钟镇涛" }, CastType.Actor));
            movie3.WorkCasts = workCasts3;

            List<WorkCompany> workCompanies3 = new();
            workCompanies3.AddRange(GetWorkCompanys(context, new string[] { "CJ Entertainment", "Barunson E&A", }, CompanyType.Producer));
            movie3.WorkCompanys = workCompanies3;

            movie3.WorkGenres = GetWorkGenres(context, new string[] { "剧情", "动作",});
            movie3.WorkTags = GetWorkTags(context, new string[] { "赛车", "日本", "情爱" });

            // =================电影4：绀青之拳=====================
            Work movie4 = new ()
            {
                Type = WorkType.SingleMovie,
                Display = "名侦探柯南剧场版20：绀青之拳(2019)",
                Name = "名侦探柯南剧场版20：绀青之拳",
                Outline = "“名侦探柯南系列”第23部动画剧场版，票房和口碑也屡破纪录。作为平成年代最后一部柯南电影，首次将案件发生地设立在海外，基德时隔四年后再度回归，与柯南合体展开行动。故事围绕着19世纪末与海盗船一同沉入海底、世界上最大的蓝宝石“绀青之拳”展开。",
                Runtime = 110,
                Year = "2019",
                Date = "2019-04-12",
                Score = 59,
                Region = "日本",
                ImdbId = "tt9501310",
                TmdbId = "535167",
                DoubanId = "30208010",
                Library = library1,
            };
            List<WorkCast> workCasts4 = new();
            workCasts4.AddRange(GetWorkCasts(context, new string[] { "永冈智佳" }, CastType.Director));
            workCasts4.AddRange(GetWorkCasts(context, new string[] { "高山南", "山口胜平", "山崎和佳奈", "小山力也", "绪方贤一" }, CastType.Actor));
            movie4.WorkCasts = workCasts4;

            List<WorkCompany> workCompanies4 = new();
            workCompanies4.AddRange(GetWorkCompanys(context, new string[] { "东宝株式会社", "小学馆", }, CompanyType.Publisher));
            movie4.WorkCompanys = workCompanies4;

            movie4.WorkGenres = GetWorkGenres(context, new string[] { "动画 ", "悬疑", });
            movie4.WorkTags = GetWorkTags(context, new string[] { "飞机", "度假", "友情" });

            // =================混合：名侦探柯南=====================
            Work mix5 = new()
            {
                Type = WorkType.Mix,
                Display = "名侦探柯南(1996-)",
                Name = "名侦探柯南",
                Outline = "工藤新一是全国著名的高中生侦探，在一次追查黑衣人犯罪团伙时不幸被团伙成员发现，击晕后喂了神奇的药水，工藤新一变回了小孩！新一找到了经常帮助他的阿笠博士，博士为他度身打造不少间谍武器。为了防止犯罪团伙对他进行报复，新一决定隐姓埋名，暗中追查他们，希望能得到解药。一日，新一的女友毛利兰来到了阿笠博士的家寻找男友的下落，被小兰撞见的新一情急之下编造了自己名叫江户川柯南，随后柯南寄居在了小兰家。小兰的父亲毛利小五郎是一名私家侦探，新一可以籍着和他一起四出办案一起追查黑夜人的下落。柯南在小学认识步美等小学生，他们一起组织了一个少年侦探对，向罪犯宣战！",
                Runtime = 25,
                Year = "1996",
                Date = "1996-01-08",
                Score = 92,
                Region = "日本",
                Fanart = "TestVideos/科幻/名侦探柯南(1996-)/fanart.jpg",
                Poster = "TestVideos/科幻/名侦探柯南(1996-)/poster.jpg",
                DoubanId = "1463371",
                ImdbId = "tt0131179",
                TmdbId = "30983-case-closed",
                Library = library1,
            };
            List<WorkCast> workCasts5 = new();
            workCasts5.AddRange(GetWorkCasts(context, new string[] { "山本泰一郎" }, CastType.Director));
            workCasts5.AddRange(GetWorkCasts(context, new string[] { "高山南", "山崎和佳奈", "神谷明", "小山力也" }, CastType.Actor));
            mix5.WorkCasts = workCasts5;

            List<WorkCompany> workCompanies5 = new();
            workCompanies5.AddRange(GetWorkCompanys(context, new string[] { "TMS Entertainment", }, CompanyType.Producer));
            workCompanies5.AddRange(GetWorkCompanys(context, new string[] { "上海新创华文化发展有限公司", "曼迪传播有限公司", "小学馆", "B-VISION", }, CompanyType.Publisher));
            workCompanies5.AddRange(GetWorkCompanys(context, new string[] { "TMS Entertainment", "读卖电视台", }, CompanyType.Investor));
            mix5.WorkCompanys = workCompanies5;

            mix5.WorkGenres = GetWorkGenres(context, new string[] { "动作", "动画", "悬疑", "惊悚", "犯罪", "喜剧" });
            mix5.WorkTags = GetWorkTags(context, new string[] { "少年", "单元剧", "超长篇" });


            CD cd1 = new()
            {
                No = 1,
                Property = ".720p.修复版",

            };


            mix5.Seasons = GetSeasons();




            context.Works.AddRange(movie1, movie2, movie3, movie4);
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
                    Type = LibraryType.Mix,
                    Fanart = "/SwellowData/Images/Library/Preview/1.jpg",
                    VideoFolders = new List<VideoFolder>
                    {
                        new VideoFolder{ Path = "/TestMovies/科幻", },
                        new VideoFolder{ Path = "/TestMovies/空的", },
                    }
                },
                new Library
                {
                    Name = "动漫",
                    Type = LibraryType.Mix,
                    Fanart = "/SwellowData/Images/Library/Preview/2.jpg",
                    VideoFolders = new List<VideoFolder>
                    {
                        new VideoFolder{ Path = "/TestMovies/动漫", },
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
                Company companyAlready = context.Companys.FirstOrDefault(g => g.Name == companyName);
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


        public static List<Season> GetSeasons(SwellowDbContext context, Array Seasons)
        {
            return new List<Season>()
            {
                new Season()
                {
                    No = 1,
                    Plot = "名侦探柯南的第一季在1996年，永不完结的第一季",
                    Year = "1996",
                    Episodes = new List<Episode>()
                    {
                        // 第一集
                         new Episode()
                         {
                            No = 1,
                            Title = "云霄飞车杀人事件",
                            Display = "名侦探柯南 - Y1996S01E01 - 云霄飞车杀人事件",
                            Plot = "【主线剧情】高中生侦探工藤新一被称为“日本警察界的救世主”而响誉全国，他帮助警方解决了很多棘手案件。某日，他和青梅竹马小兰一起去坐云霄飞车时遇到了一起因情生恨凶杀事件，其中，有两名黑衣人引起了工藤的注意，工藤暗中跟踪却被发现，黑衣给他灌下毒药后离开，当被警察发现时，工藤已变成了小孩儿的模样。",
                            CDs = new List<CD>()
                            {
                                new CD () { Property = ".720p.修复版", },
                                new CD () { Property = ".1080p BD", },
                            }
                         },
                         new Episode()
                         {
                            No = 2,
                            Title = "董事长千金绑架事件",
                            Display = "名侦探柯南 - Y1996S01E02 - 董事长千金绑架事件",
                            Plot = "【主线剧情】趁警察不注意工藤逃到阿笠博士那里寻求帮助，这时担心工藤的小兰找也找到这里，为保护小兰安全，工藤隐瞒身份并在情急之下取名江户川柯南，阿笠博士将柯南托付给小兰照顾，回家后他们碰到了急匆匆出门办案的毛利小五郎，听说有黑衣人，柯南也跟着一起去。原来是董事长女儿谷晶子被绑架，在管家承认了自己是犯人且没有同伙后，却再次有人打来威胁电话……",
                            CDs = new List<CD>()
                            {
                                new CD () { Property = ".1080p BD", },
                            }
                         },
                         new Episode()
                         {
                            No = 3,
                            Title = "偶像密室杀人事件",
                            Display = "名侦探柯南 - Y1996S01E03 - 偶像密室杀人事件",
                            Plot = "【含主线信息】身体变小后柯南转入帝丹小学，并结识了步美、光彦和元太。某日，明星洋子来到毛利侦探事务所，说总感觉有人暗中监视她，为了更进一步了解真相，毛利一行人来到洋子住处，可开门后居然有具死尸横在门口，期间柯南发现了另一名演员优子的耳环并且还注意到洋子的经纪人山岸神态怪异，洋子、山岸、优子到底谁才是真正的凶手。",
                            CDs = new List<CD>()
                            {
                                new CD () { Property = ".1080p BD", },
                            }
                         },
                    },
                },
                new Season()
                {
                    No = 2,
                    Plot = "名侦探柯南的第一季在1997年，永不完结的第一季",
                    Year = "1997",
                    Episodes = new List<Episode>()
                    {
                        // 第一集
                         new Episode()
                         {
                            No = 43,
                            Title = "江户川柯南诱拐事件",
                            Display = "名侦探柯南 - Y1996S01E01 - 江户川柯南诱拐事件",
                            Plot = "【主线剧情】高中生侦探工藤新一被称为“日本警察界的救世主”而响誉全国，他帮助警方解决了很多棘手案件。某日，他和青梅竹马小兰一起去坐云霄飞车时遇到了一起因情生恨凶杀事件，其中，有两名黑衣人引起了工藤的注意，工藤暗中跟踪却被发现，黑衣给他灌下毒药后离开，当被警察发现时，工藤已变成了小孩儿的模样。",
                            CDs = new List<CD>()
                            {
                                new CD () { Property = ".720p.修复版", },
                                new CD () { Property = ".1080p BD", },
                            }
                         },
                         new Episode()
                         {
                            No = 44,
                            Title = "董事长千金绑架事件",
                            Display = "名侦探柯南 - Y1996S01E02 - 董事长千金绑架事件",
                            Plot = "【主线剧情】趁警察不注意工藤逃到阿笠博士那里寻求帮助，这时担心工藤的小兰找也找到这里，为保护小兰安全，工藤隐瞒身份并在情急之下取名江户川柯南，阿笠博士将柯南托付给小兰照顾，回家后他们碰到了急匆匆出门办案的毛利小五郎，听说有黑衣人，柯南也跟着一起去。原来是董事长女儿谷晶子被绑架，在管家承认了自己是犯人且没有同伙后，却再次有人打来威胁电话……",
                            CDs = new List<CD>()
                            {
                                new CD () { Property = ".1080p BD", },
                            }
                         },
                         new Episode()
                         {
                            No = 45,
                            Title = "偶像密室杀人事件",
                            Display = "名侦探柯南 - Y1996S01E03 - 偶像密室杀人事件",
                            Plot = "【含主线信息】身体变小后柯南转入帝丹小学，并结识了步美、光彦和元太。某日，明星洋子来到毛利侦探事务所，说总感觉有人暗中监视她，为了更进一步了解真相，毛利一行人来到洋子住处，可开门后居然有具死尸横在门口，期间柯南发现了另一名演员优子的耳环并且还注意到洋子的经纪人山岸神态怪异，洋子、山岸、优子到底谁才是真正的凶手。",
                            CDs = new List<CD>()
                            {
                                new CD () { Property = ".1080p BD", },
                            }
                         },
                    },
                },




            };






        }


        
    }
}
