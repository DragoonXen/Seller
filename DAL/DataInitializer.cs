using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Security;
using Seller.Models;

namespace Seller.DAL
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var seedRandom = new Random();

            #region Shops

            var shops = new List<Shop>
                            {
                                new Shop
                                    {
                                        Name = "Sli.by",
                                        Phone = "+375 29 576 66 44",
                                        Email = "price@sli.by",
                                        Exchange = 8420,
                                        Site = "Sli.by",
                                        Image = "SLI.gif",
                                        Description = @"Есть возможность оплаты заказа по Webmoney!
Все продаваемые в нашем магазине мониторы до момента покупки не распаковываются, т.е. заклеены первым заводским скотчем.\ 
На жидкокристаллических мониторах допускается некоторое количество дефектных (""битых"") пикселей. Это количество устанавливается каждым производителем в соответствии с общепринятым стандартом ISO 13406-2. Если количество дефектных пикселей соответствует этим нормам, то монитор считается исправным и это не является дефектом. 

Московская, 6 (офис) Не магазин! ! ! Прийти, купить, послушать, посмотреть, выбрать, проверить - такого варианта нет.

Доставка ВСЕГО мелкогабаритного товара (винчестеры, видеокарты и т.д.)осуществляется ТОЛЬКО до вашего подъезда. На проверку данного товара дается неделя, чтобы вы неспеша проверили приобретенный товар. В случае бракованного изделия - меняется на следующий день.

Только крупногабаритные товары (мониторы, принтеры и т.д.)доставляются до квартиры.

Прием заказов:
Пн-Пт - с 9.00 до 17.00
Сб - c 9.00 до 13.00"
                                    },
                                new Shop
                                    {
                                        Name = "UNI",
                                        Phone = "+375 29 566 19 81",
                                        Adress = "г.Минск, ул.Сурганова, д.27 оф.5 (ст. метро \"Академия наук\")",
                                        Email = "uni-1@tut.by",
                                        Exchange = 8500,
                                        Image = "UNI.gif",
                                        Description =
                                            @"Продажа компьютеров, ноутбуков, комплектующих, периферии за наличный и безналичный рассчет.
Полный актуальный прайс лист на сайте www.uni.by (обновляется каждый час) 

Время работы:
в будние дни с 10.00 до 19.00
суббота и воскресенье - выходной"
                                    },
                                new Shop
                                    {
                                        Name = "StarSys",
                                        Phone = "+375 29 754 91 11",
                                        Email = "Star-sys@mail.ru",
                                        Exchange = 8400,
                                        Site = "www.star-sys.shop.by",
                                        Image = "StarSys.gif",
                                        Description =
                                            @"ВНИМАНИЕ! Курьер, доставляющий вам покупку, НЕ является техническим консультантом, мастером по установке и настройке. Он осуществляет доставку - облегчает процесс покупки. Поэтому, пожалуйста, все существенные моменты (свойства товара, его подключение и настройка) оговаривайте с менеджером заранее!"
                                    },
                                new Shop
                                    {
                                        Name = "e2.by",
                                        Phone = "+375 29 705 63 05",
                                        Adress = "г.Минск ул.Кульман 2 офис 422",
                                        Email = "def.wsm@gmail.com",
                                        Exchange = 8500,
                                        Site = "e2.by",
                                        Image = "e2.by.gif",
                                        Description = @"*понедельник - пятница с 12.00 до 19.00 . 
*суббота с 12.00 до 16.00.
*воскресенье - приём заказов.

*Уважаемые покупатели просьба учитывать то что, наша компания работает ПОД ЗАКАЗ, поэтому не нужно ехать к нам и требовать от нас наличия, ничего при этом предварительно не заказав.

Компьютеры, серверы, ноутбуки, комплектующие, мониторы, принтеры, факсы, периферия, CD, DVD. Консультация опытных и квалифицированных специалистов. Индивидуальный подход к каждому клиенту. Оптимальное соотношение цены и качества. 

Доставка по Минску и РБ.

ЛЮБАЯ ФОРМА ОПЛАТЫ.


Мониторы поставляем в заводской упаковке ""ПЕРВЫЙ СКОТЧ"". После оплаты - можем провести проверку *по желанию покупателя на исправность (включается - есть картинка). Претензии при наличии ""битых пикселей"" или любых других дефектов предъявляются сервис-центру производителя и после заключения сервис центра клиенту на выбор или возвращаются деньги или новое изделие.
В случае если клиент не желает иметь дело с сервис центром производителя, но на мониторе обнаружился дефект который по нормам допуска для данного класса изделия допустим мы согласны вернуть клиенту денежные средства за вычетом 10% от стоимости изделия."
                                    },
                                new Shop
                                    {
                                        Name = "ATOM+",
                                        Phone = "+375 33 665 05 19",
                                        Adress = "г. Минск, ул. Захарова 24, оф. 3п",
                                        Email = "shop@atom.by",
                                        Exchange = 8500,
                                        Site = "atom.by",
                                        Image = "Atom+.gif",
                                        Description =
                                            @"Мы находимся в центре города Минска (станция метро ""Площадь Победы""). 
В нашем магазине представлен широкий спектр моделей по лучшим ценам.
Мы квалифицированно консультируем покупателя и подключаем товар. 
У нас можно приобрести товар за наличный, безналичный расчет или в кредит. 
Мы доставляем товар по Минску и всей Беларуси.
Более полный ассортимент товара вы можете увидеть и заказать через наш интернет-магазин www.atom.by
Гарантия в официальных сервисных центрах до 36 месяцев. Товар, производители которого не имеют официального сервис-центра, обслуживается в нашем сервисном центре по адресу: г. Минск, ул. Захарова 24, оф. 3п
Приглашаем к сотрудничеству дилеров."
                                    }
                            };

            foreach (Shop shop in shops)
            {
                MembershipUser user;
                if ((user = Membership.GetUser(shop.Name)) == null)
                    user = Membership.CreateUser(shop.Name, "test`12" + shop.Name);

                if (!Roles.IsUserInRole(user.UserName, Helper.Roles.Shop))
                    Roles.AddUserToRole(user.UserName, Helper.Roles.Shop);

                shop.AccountGuid = (Guid) user.ProviderUserKey;
                context.Shops.Add(shop);
            }

            #endregion

            #region Category

            var CPU = new Category {Name = "CPU"};
            var GPU = new Category {Name = "GPU"};
            var Motherboard = new Category {Name = "Motherboard"};
            var categories = new List<Category>
                                 {
                                     CPU,
                                     GPU,
                                     Motherboard
                                 };
            categories.ForEach(category => context.Categories.Add(category));

            #endregion

            #region Producers

            var AMD = new Producer {Name = "AMD", Site = "www.amd.com", LogoPath = "amd_logo.png"};
            var Intel = new Producer {Name = "Intel", Site = "www.intel.com", LogoPath = "intel-logo.jpg"};
            var ASRock = new Producer {Name = "ASRock", Site = "www.asrock.com", LogoPath = "asrock-logo.png"};
            var Gigabyte = new Producer {Name = "Gigabyte", Site = "www.gigabyte.com", LogoPath = "gigabyte_logo.gif"};
            var BIOSTAR = new Producer {Name = "BIOSTAR", Site = "www.biostar.com.tw", LogoPath = "biostar_logo.png"};
            var ASUS = new Producer {Name = "ASUS", Site = "www.asus.com", LogoPath = "asus-logo.jpg"};
            var Palit = new Producer {Name = "Palit", Site = "www.palit.biz", LogoPath = "palit-logo.jpg"};
            var MSI = new Producer {Name = "MSI", Site = "www.msi.com", LogoPath = "msi-logo.jpg"};
            var producers = new List<Producer>
                                {
                                    AMD,
                                    Intel,
                                    ASRock,
                                    Gigabyte,
                                    BIOSTAR,
                                    ASUS,
                                    Palit,
                                    MSI
                                };
            producers.ForEach(producer => context.Producers.Add(producer));

            #endregion

            #region Products

            MembershipUserCollection usersCollection = Membership.GetAllUsers();
            var users = new MembershipUser[usersCollection.Count];
            usersCollection.CopyTo(users, 0);

            var products = new List<Product>
                               {
                                   #region CPU
                                   new Product
                                       {
                                           Category = CPU,
                                           Description = "4 ядра, тактовая частота 3.6 ГГц, кэш L2+L3 12 Мб, сокет AM3+",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "d604a8c103b45880c817493038a97a67.jpg"
                                                                }
                                                        },
                                           Name = "AMD FX-4100 (FD4100WMW4KGU)",
                                           Producer = AMD
                                       },
                                   new Product
                                       {
                                           Category = CPU,
                                           Description =
                                               "4 ядра, тактовая частота 3.3 ГГц, кэш L2+L3 7 Мб, сокет LGA1155",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "165464035d25197e96cb7711f52ce7e7.jpg"
                                                                }
                                                        },
                                           Name = "Intel Core i5-2500K",
                                           Producer = Intel
                                       },
                                   new Product
                                       {
                                           Category = CPU,
                                           Description = "4 ядра, тактовая частота 3.4 ГГц, кэш L2+L3 8 Мб, сокет AM3",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "0fbee68706a1c5aa346a01c133afa162.jpg"
                                                                }
                                                        },
                                           Name = "AMD Phenom II X4 965 (HDZ965FBK4DGI)",
                                           Producer = AMD
                                       },
                                   new Product
                                       {
                                           Category = CPU,
                                           Description = "6 ядeр, тактовая частота 3.3 ГГц, кэш L2+L3 14 Мб, сокет AM3+",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "d604a8c103b45880c817493038a97a67 (1).jpg"
                                                                }
                                                        },
                                           Name = "AMD FX-6100 (FD6100WMW6KGU)",
                                           Producer = AMD
                                       },
                                   new Product
                                       {
                                           Category = CPU,
                                           Description =
                                               "4 ядра, тактовая частота 3.4 ГГц, кэш L2+L3 7 Мб, сокет LGA1155",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "e8952867597b4bd4681a93cc9befc628.jpg"
                                                                }
                                                        },
                                           Name = "Core i5-3570K",
                                           Producer = Intel
                                       },

                                   #endregion
                                   #region GPU
                                   new Product
                                       {
                                           Category = GPU,
                                           Description =
                                               "PCI-Express x16 2.0, nVidia GeForce GTX 550 Ti 1024 Мб, частота процессора 900 МГц, частота памяти 1025 МГц, ширина шины 192 бит, поддержка DirectX 11",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "79c1ff0745e77b372dde54ca5e11cf0a.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "896d0160c27bc99532f5b2bc13828185.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "4a307d079cc122f9b73dacfcf5a4c3ff.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "eab80914b370224e408ffc8952b0f1a7.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "a84698535347a266e8105e645864d14a.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "87e172f20b9d3a01bd9a455e10c6e4dc.jpg"
                                                                }
                                                        },
                                           Name = "Palit GeForce GTX 550 (NE5X55T0HD09-1061F)",
                                           Producer = Palit
                                       },
                                   new Product
                                       {
                                           Category = GPU,
                                           Description =
                                               "PCI Express x16 3.0, nVidia GeForce GTX 670 2048 Мб, частота процессора 980 МГц, частота памяти 1502 МГц, ширина шины 256 бит, поддержка DirectX 11",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "3d9a744401c3118ae2f10ad45274a5b5.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "577d37213295311f8bd2148fa252614f.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "433aff0436b6c5c1bc20ea3a8bda5b55.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "1cc57c120934fa4cb2cb689c73e82d27.jpg"
                                                                }
                                                        },
                                           Name = "Gigabyte GeForce GTX 670 OC (GV-N670OC-2GD)",
                                           Producer = Gigabyte
                                       },
                                   new Product
                                       {
                                           Category = GPU,
                                           Description =
                                               "PCI-Express x16 2.0, nVidia GeForce GTS 450 1024 Мб, частота процессора 783 МГц, частота памяти 902 МГц, ширина шины 128 бит, поддержка DirectX 11",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "8d4b642dba741df6171fdf4e5ab94543.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "1d1931fc36af1a7a968c9610c92c2738.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "c60e6c70a06188456682a16937343c70.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "b1898eedfe8bf456178e65256c0746a8.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "06d5b405a761983b355a4a953f08724f.jpg"
                                                                }
                                                        },
                                           Name = "Palit GeForce GTS 450",
                                           Producer = Palit
                                       },
                                   new Product
                                       {
                                           Category = GPU,
                                           Description =
                                               "PCI-Express x16 2.0, nVidia GeForce GTX 550 Ti 1024 Мб, частота процессора 970 МГц, частота памяти 1050 МГц, ширина шины 192 бит, поддержка DirectX 11",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "34bd021961813d708ae17edf739b8e39.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "bc5282e5458ea44cdf2d77326f8a536a.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "ebb6f6f0dec35761cbced74c1001dd85.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "647e0bc6065f0b652c05b50a8770aa06.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "fa4ba57f9de757cc2ef54a4ac23afabf.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "8bc5d68774a6860617bcabfab29c738c.jpg"
                                                                }
                                                        },
                                           Name = "Gigabyte GeForce GTX 550 Ti (GV-N550WF2-1GI)",
                                           Producer = Gigabyte
                                       },
                                   new Product
                                       {
                                           Category = GPU,
                                           Description =
                                               "PCI-Express x16 2.0, nVidia GeForce GTX 560 Ti 1024 Мб, частота процессора 950 МГц, частота памяти 1050 МГц, ширина шины 256 бит, поддержка DirectX 11",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "d476a2ca3daabc2a72119de71ec21aec.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "87531f478bd81978c05aeb9b5c091384.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "70436b1e2df97b1e17ce1f10147659bd.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "6832bf2a685fe146f0683b282aa8a87f.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "a92d320503223d269eab6553348de4f1.jpg"
                                                                }
                                                        },
                                           Name = "MSI GeForce GTX 560 Ti (N560GTX-Ti Hawk)",
                                           Producer = MSI
                                       },

                                   #endregion
                                   #region Motherboard
                                   new Product
                                       {
                                           Category = Motherboard,
                                           Description =
                                               "AMD, сокет AM2/AM2+/AM3, чипсет GeForce 7025 + nForce 630a, DDR2, DDR3, встроенная видеокарта NVIDIA GeForce 7025, звук 5.1",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "3d29a93bd02ebc8c4731570261b7e7b3.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "2f52ca05f8e06ae0dba6abc4e9bd51c3.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "b429651c4a4bbed13878e534266ba3c4.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "a579d50aafc781f4adb39deb9234dbaf.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "93bdee7d645d4adb125a251e49c3d27e.jpg"
                                                                }
                                                        },
                                           Name = "ASRock N68C-S UCC",
                                           Producer = ASRock
                                       },
                                   new Product
                                       {
                                           Category = Motherboard,
                                           Description =
                                               "AMD, сокет AM3/AM3+, чипсет AMD 990X + SB950, DDR3, SLi/CrossFire, звук 7.1",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "cae335517b5cb448d3bd990c610c3c45.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "ff59d520029d3c552ccf779010c895df.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "b5c8d8f590a81ca7dc2bab0be0e648f6.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "30c767a1cd14af1c1f91b540ce239d78.jpg"
                                                                }
                                                        },
                                           Name = "Gigabyte GA-990XA-UD3 (rev. 1.0)",
                                           Producer = Gigabyte
                                       },
                                   new Product
                                       {
                                           Category = Motherboard,
                                           Description =
                                               "AMD, сокет AM3, чипсет GeForce 7025 + nForce 630a, DDR3, встроенная видеокарта NVIDIA GeForce 7025, звук 5.1",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "a3426b62af05d641e322a7abec89f901.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "4c2f61a0ef93dff9253ecaf246ab6a59.jpg"
                                                                }
                                                        },
                                           Name = "BIOSTAR N68S3B Ver. 6.x",
                                           Producer = BIOSTAR
                                       },
                                   new Product
                                       {
                                           Category = Motherboard,
                                           Description =
                                               "Intel, сокет LGA1155, чипсет Intel Z77, DDR3, встроенная видеокарта Intel HD Graphics 2500/4000, SLi/CrossFire, звук 7.1, Wi-Fi",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "120fb3a7699145ced7b62b1db1184a81.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "51f06177bb815d19882adb54aebea5b4.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "dd4798729292817c4662ac9038f89941.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "76b8fa84f292871bbfa32668fae56ef6.jpg"
                                                                }
                                                        },
                                           Name = "ASUS P8Z77-V",
                                           Producer = ASUS
                                       },
                                   new Product
                                       {
                                           Category = Motherboard,
                                           Description =
                                               "Intel, сокет LGA1155, чипсет Intel Z77, DDR3, встроенная видеокарта Intel HD Graphics 2500/4000, SLi/CrossFire, звук 7.1, eSATA",
                                           Images = new Collection<Image>
                                                        {
                                                            new Image
                                                                {
                                                                    Path = "8b88eeb62783a31593dc28d0f59c5dec.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "9f3fc55b36bc2749cb9ff175cba1360f.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "9f5b3b5fa16c2d71706c3c3656230676.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "f2da4e82ed719bcb0c2f27d353edd0e5.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "ea16e1e99a059d174f96fcbd347392a1.jpg"
                                                                },
                                                            new Image
                                                                {
                                                                    Path = "ed69d98703e72cbb9f2c9e71d0916767.jpg"
                                                                }
                                                        },
                                           Name = "ASUS SABERTOOTH Z77",
                                           Producer = ASUS
                                       }
                                   #endregion
                               };
            foreach (Product product in products)
            {
                product.CreatedBy = (Guid) users[seedRandom.Next(users.Length)].ProviderUserKey;
                context.Products.Add(product);
            }

            #endregion

            #region Offers

            var offers = new List<Offer>
                             {
                                 new Offer
                                     {
                                         Product = products[0],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 105
                                     },
                                 new Offer
                                     {
                                         Product = products[0],
                                         Shop = shops.Find(shop => shop.Name == "Sli.by"),
                                         Price = 104
                                     },
                                 new Offer
                                     {
                                         Product = products[0],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 111
                                     },
                                 new Offer
                                     {
                                         Product = products[1],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 216
                                     },
                                 new Offer
                                     {
                                         Product = products[1],
                                         Shop = shops.Find(shop => shop.Name == "ATOM+"),
                                         Price = 222
                                     },
                                 new Offer
                                     {
                                         Product = products[2],
                                         Shop = shops.Find(shop => shop.Name == "Sli.by"),
                                         Price = 90
                                     },
                                 new Offer
                                     {
                                         Product = products[2],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 90
                                     },
                                 new Offer
                                     {
                                         Product = products[3],
                                         Shop = shops.Find(shop => shop.Name == "UNI"),
                                         Price = 137
                                     },
                                 new Offer
                                     {
                                         Product = products[3],
                                         Shop = shops.Find(shop => shop.Name == "ATOM+"),
                                         Price = 135
                                     },
                                 new Offer
                                     {
                                         Product = products[3],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 130
                                     },
                                 new Offer
                                     {
                                         Product = products[4],
                                         Shop = shops.Find(shop => shop.Name == "ATOM+"),
                                         Price = 237
                                     },
                                 new Offer
                                     {
                                         Product = products[4],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 224
                                     },
                                 new Offer
                                     {
                                         Product = products[5],
                                         Shop = shops.Find(shop => shop.Name == "ATOM+"),
                                         Price = 114
                                     },
                                 new Offer
                                     {
                                         Product = products[5],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 114
                                     },
                                 new Offer
                                     {
                                         Product = products[5],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 109
                                     },
                                 new Offer
                                     {
                                         Product = products[6],
                                         Shop = shops.Find(shop => shop.Name == "Sli.by"),
                                         Price = 451
                                     },
                                 new Offer
                                     {
                                         Product = products[6],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 500
                                     },
                                 new Offer
                                     {
                                         Product = products[7],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 94
                                     },
                                 new Offer
                                     {
                                         Product = products[7],
                                         Shop = shops.Find(shop => shop.Name == "ATOM+"),
                                         Price = 84
                                     },
                                 new Offer
                                     {
                                         Product = products[7],
                                         Shop = shops.Find(shop => shop.Name == "UNI"),
                                         Price = 97
                                     },
                                 new Offer
                                     {
                                         Product = products[8],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 132
                                     },
                                 new Offer
                                     {
                                         Product = products[8],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 139
                                     },
                                 new Offer
                                     {
                                         Product = products[8],
                                         Shop = shops.Find(shop => shop.Name == "UNI"),
                                         Price = 134
                                     },
                                 new Offer
                                     {
                                         Product = products[8],
                                         Shop = shops.Find(shop => shop.Name == "Sli.by"),
                                         Price = 127
                                     },
                                 new Offer
                                     {
                                         Product = products[9],
                                         Shop = shops.Find(shop => shop.Name == "UNI"),
                                         Price = 255
                                     },
                                 new Offer
                                     {
                                         Product = products[9],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 262
                                     },
                                 new Offer
                                     {
                                         Product = products[9],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 245
                                     },
                                 new Offer
                                     {
                                         Product = products[10],
                                         Shop = shops.Find(shop => shop.Name == "UNI"),
                                         Price = 48
                                     },
                                 new Offer
                                     {
                                         Product = products[11],
                                         Shop = shops.Find(shop => shop.Name == "Sli.by"),
                                         Price = 107
                                     },
                                 new Offer
                                     {
                                         Product = products[11],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 108
                                     },
                                 new Offer
                                     {
                                         Product = products[11],
                                         Shop = shops.Find(shop => shop.Name == "ATOM+"),
                                         Price = 113
                                     },
                                 new Offer
                                     {
                                         Product = products[11],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 120
                                     },
                                 new Offer
                                     {
                                         Product = products[11],
                                         Shop = shops.Find(shop => shop.Name == "UNI"),
                                         Price = 113
                                     },
                                 new Offer
                                     {
                                         Product = products[12],
                                         Shop = shops.Find(shop => shop.Name == "ATOM+"),
                                         Price = 42
                                     },
                                 new Offer
                                     {
                                         Product = products[12],
                                         Shop = shops.Find(shop => shop.Name == "UNI"),
                                         Price = 43
                                     },
                                 new Offer
                                     {
                                         Product = products[12],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 42
                                     },
                                 new Offer
                                     {
                                         Product = products[12],
                                         Shop = shops.Find(shop => shop.Name == "StarSys"),
                                         Price = 42
                                     },
                                 new Offer
                                     {
                                         Product = products[12],
                                         Shop = shops.Find(shop => shop.Name == "Sli.by"),
                                         Price = 42
                                     },
                                 new Offer
                                     {
                                         Product = products[13],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 202
                                     },
                                 new Offer
                                     {
                                         Product = products[14],
                                         Shop = shops.Find(shop => shop.Name == "e2.by"),
                                         Price = 263
                                     }
                             };
            foreach (Offer offer in offers)
            {
                offer.LastUpdate = DateTime.Now;
                context.Offers.Add(offer);
            }

            #endregion

            context.SaveChanges();
        }
    }
}