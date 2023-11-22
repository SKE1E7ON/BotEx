using BotEx_Api.Model;
using static BotEx_Api.ModelDTO.RestoransRequest;
namespace BotEx_Api.ModelDTO
{
    public class RestoransRequest
    {
        public int RestoransId { get; internal set; }
        public int Type { get; internal set; }
        public string Naming { get; internal set; } = null!;
        public string Adres { get; internal set; } = null!;
        public string Info { get; internal set; } = null!;
        public int UserRate { get; internal set; }
        public int CostRate { get; internal set; }
        public string Image { get; internal set; } = null!;

        public class RestoDTO
        {
            public int RestoransId { get; set; }
            public int Type { get; set; }
            public string Naming { get; set; } = null!;
            public string Adres { get; set; } = null!;
            public string Info { get; set; } = null!;
            public int UserRate { get; set; }
            public int CostRate { get; set; }
            public string Image { get; set; } = null!;
        }

        public static Restoran RestoConverter(RestoDTO restoDTO)
        {
            Restoran restoranDTO = new Restoran();

            restoranDTO.RestoransId = restoDTO.RestoransId;
            restoranDTO.Type = restoDTO.Type;
            restoranDTO.Naming = restoDTO.Naming;
            restoranDTO.Adres = restoDTO.Adres;
            restoranDTO.Info = restoDTO.Info;
            restoranDTO.UserRate = restoDTO.UserRate;
            restoranDTO.CostRate = restoDTO.CostRate;
            restoranDTO.Image = restoDTO.Image;
            return restoranDTO;
        }


        public static RestoDTO RestoConverter(Restoran resto) 
        {
            RestoDTO restoDTO = new RestoDTO();
            restoDTO.RestoransId = resto.RestoransId;
            restoDTO.Type = resto.Type;
            restoDTO.Naming = resto.Naming;
            restoDTO.Adres = resto.Adres;
            restoDTO.Info = resto.Info;
            restoDTO.UserRate = resto.UserRate;
            restoDTO.CostRate = resto.CostRate;
            restoDTO.Image = resto.Image;
            return restoDTO;

        
        }
    }
}
