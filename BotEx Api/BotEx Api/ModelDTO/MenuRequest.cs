using BotEx_Api.Model;

namespace BotEx_Api.ModelDTO
{
    public class MenuRequest
    {
        public int MenuId { get; set; }
        public int IdResto { get; set; }
        public string Naming { get; set; } = null!;
        public string Cost { get; set; } = null!;
        public string Info { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Sale { get; set; } = null!;
    
        public class MenuDTO
        {
            public int MenuId { get; set; }
            public int IdResto { get; set; }
            public string Naming { get; set; } = null!;
            public string Cost { get; set; } = null!;
            public string Info { get; set; } = null!;
            public string Image { get; set; } = null!;
            public string Sale { get; set; } = null!;

        }
        
        public static Menu MenuConverter(MenuDTO menuDTO)
        {
            Menu menudto = new Menu();

            menudto.MenuId = menuDTO.MenuId;
            menudto.IdResto = menuDTO.IdResto;
            menudto.Naming = menuDTO.Naming;
            menudto.Cost = menuDTO.Cost;
            menudto.Info = menuDTO.Info;
            menudto.Image = menuDTO.Image;
            menudto.Sale = menuDTO.Sale;
            return menudto;
        }

        public static MenuDTO MenuConvert(Menu Menu)
        {
            MenuDTO menu = new MenuDTO();
            menu.MenuId = Menu.MenuId;
            menu.IdResto = Menu.IdResto;
            menu.Naming = Menu.Naming;
            menu.Cost = Menu.Cost;
            menu.Info = Menu.Info;  
            menu.Image = Menu.Image;
            menu.Sale = Menu.Sale;
            return menu;
        }
    
    
    
    }
}
