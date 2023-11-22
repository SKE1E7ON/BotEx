using BotEx_Api.Model;

namespace BotEx_Api.ModelDTO
{
    public class RestoGETRequest
    {
        public int RestoransId { get; set; }
        public int Type { get; set; }
        public string Naming { get; set; } = null!;
        public string Adres { get; set; } = null!;
        public string Info { get; set; } = null!;
        public int UserRate { get; set; }
        public int CostRate { get; set; }
        public string Image { get; set; } = null!;


        public static Restoran ConvertGetToResto(RestoransRequest restoran)
        {
            Restoran resto = new Restoran();
            resto.RestoransId = restoran.RestoransId;
            resto.Type = restoran.Type;
            resto.Naming = restoran.Naming;
            resto.Adres = restoran.Adres;
            resto.Info = restoran.Info;
            resto.UserRate = restoran.UserRate;
            resto.CostRate = restoran.CostRate;
            resto.Image = restoran.Image;
            return resto;
        }
        
        public static RestoGETRequest ConvertToGetResto(Restoran restorans)
        {
            RestoGETRequest restos = new RestoGETRequest();
            restos.RestoransId = restorans.RestoransId;
            restos.Type = restorans.Type;
            restos.Naming = restorans.Naming;
            restos.Adres = restorans.Adres;
            restos.Info = restorans.Info;
            restos.UserRate = restorans.UserRate;
            restos.CostRate = restorans.CostRate;
            restos.Image = restorans.Image;
            return restos;
        }

        public static List<RestoGETRequest> ConvertToGetRestos(List<Restoran> restos)
        {
            List<RestoGETRequest> resto1 = new List<RestoGETRequest>();
            foreach(Restoran restorans in restos)
            {
                resto1.Add(new RestoGETRequest
                {
                    RestoransId = restorans.RestoransId,
                    Type = restorans.Type,
                    Naming = restorans.Naming,
                    Adres = restorans.Adres,
                    Info = restorans.Info,
                    UserRate = restorans.UserRate,
                    CostRate = restorans.CostRate,
                    Image = restorans.Image,
                });
            }
            return resto1;
        }
    }
}
