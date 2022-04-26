using EntityLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public static class MenuManager
    {
        public static readonly List<MenuItem> Menu = new List<MenuItem> {
            new MenuItem {
                Text = "İhracat İşlemleri",
                Icon = "globe",
                Items = new List<MenuItem>() {
                    new MenuItem {
                        Text = "Nakliye işlemleri",
                        Icon = "export",
                        Items = new List<MenuItem>() {
                            new MenuItem {
                                Text = "Nakliye Yükleme Bilgileri",
                                Action = "/Export",
                                Icon = "chevronright"
                            }
                        }
                    },
                    new MenuItem {
                        Text = "Raporlar",
                        Icon = "file",
                        Items = new List<MenuItem>() {
                            new MenuItem {
                                Text = "Lojistik Bilgileri Listeleme",
                                Action = "",
                                Icon = "alignjustify",
                            },

                        }
                    },
                    new MenuItem {
                        Text = "Sabit Bilgiler",
                        Icon = "mergecells",
                        Items = new List<MenuItem>(){
                            new MenuItem {
                                Text = "Nakliyeci Bilgileri Tanımlama",
                                Action = "",
                                Icon = "edit"
                            }
                        }
                    },
                    new MenuItem {
                        Text = "Ayarlar",
                        Icon = "preferences",
                        Items = new List<MenuItem>() {
                            new MenuItem {
                                Text = "Şifre Değiştir",
                                Action = "/User/ChangePassword",
                                Icon = "key"
                            }
                        }
                    }
                }
            },
            new MenuItem {
                Text = "Ayarlar",
                Icon = "preferences",
                Items = new List<MenuItem>() {
                    new MenuItem {
                        Text = "Genel Ayarlar",
                        Action = "",
                        Icon = "/img/sub_menu_icon_1.png"
                    }
                }
            },
            new MenuItem {
                Text = "Çıkış",
                Action = "/Auth/Logout",
                Icon = "close"
            }
        };
        public static IEnumerable<MenuItem> GetMenu(bool isAdmin)
        {
            var result = Menu;
            var temp = Menu.Where(t => t.Text == "Ayarlar").First();
            var index = Menu.FindIndex(t => t.Text == "Ayarlar");
            if (isAdmin)
            {
                if (Menu[index].Items.Find(t => t.Text == "Kullanıcı Ayarları") == null)
                    Menu[index].Items.Add(new MenuItem
                    {
                        Text = "Kullanıcı Ayarları",
                        Action = "/Users",
                        Icon = "group"
                    });
            }
            else
            {
                if (Menu[index].Items.Find(t => t.Text == "Kullanıcı Ayarları") != null)
                    Menu[index].Items.RemoveAt(1);
            }
            return result;
        }
    }
}
