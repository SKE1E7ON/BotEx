using BotEx_Api.Model;

namespace BotEx_Api.ModelDTO
{
    public class MenuGETRequest
    {
        public int MenuId { get; set; }
        public int IdResto { get; set; }
        public string Naming { get; set; } = null!;
        public string Cost { get; set; } = null!;
        public string Info { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Sale { get; set; } = null!;

        public static Menu ConvertGetToMenu(MenuGETRequest menus)
        {
            Menu menu = new Menu();
            menu.MenuId = menus.MenuId;
            menu.IdResto = menus.IdResto;
            menu.Naming = menus.Naming;
            menu.Cost = menus.Cost;
            menu.Info = menus.Info;
            menu.Image = menus.Image;
            menu.Sale = menus.Sale;
            return menu;
        }

        public static MenuGETRequest ConvertGetToMenus(Menu Menus)
        {
            MenuGETRequest Menu = new MenuGETRequest();
            Menu.MenuId = Menus.MenuId;
            Menu.IdResto = Menus.IdResto;
            Menu.Naming = Menus.Naming;
            Menu.Cost = Menus.Cost;
            Menu.Info = Menus.Info;
            Menu.Image = Menus.Image;
            Menu.Sale = Menus.Sale;
            return Menu;
        }

        public static List<MenuGETRequest> ConvertToGet(List<Menu> menu)
        {
            List<MenuGETRequest> menus = new List<MenuGETRequest>();
            foreach(Menu menu1 in menu)
            {
                menus.Add(new MenuGETRequest
                {
                    MenuId = menu1.MenuId,
                    IdResto = menu1.IdResto,
                    Naming = menu1.Naming,
                    Cost = menu1.Cost,
                    Info = menu1.Info,
                    Image = menu1.Image,
                    Sale = menu1.Sale,
                });
            }
            return menus;
        }

    }
}
