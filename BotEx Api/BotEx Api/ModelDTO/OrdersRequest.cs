using BotEx_Api.Model;
using static BotEx_Api.ModelDTO.UserRequest;

namespace BotEx_Api.ModelDTO
{
    public class OrdersRequest
    {
        public int IdOrders { get; internal set; }
        public int IdUsers { get; internal set; }
        public int IdResto { get; internal set; }
        public int IdDelivery { get; internal set; }
        public int IdMenu { get; internal set; }
        public int Status { get; internal set; }
        public string Cost { get; internal set; } = null!;
        public string Photo { get; internal set; } = null!;
        public string Data { get; internal set; } = null!;
        

        public class OrdersDTO
        {
            public int IdOrders { get; set; }
            public int IdUsers { get; set; }
            public int IdResto { get; set; }
            public int IdDelivery { get; set; }
            public int IdMenu { get; set; }
            public int Status { get; set; }
            public string Cost { get; set; } = null!;
            public string Photo { get; set; } = null!;
            public string Data { get; set; } = null!;
        }

        public static Order OrderConverter(OrdersDTO orderDTO)
        {
            Order orderdto = new Order();

            orderdto.IdOrders = orderDTO.IdOrders;
            orderdto.IdUsers = orderDTO.IdUsers;
            orderdto.IdResto = orderDTO.IdResto;
            orderdto.IdDelivery = orderDTO.IdDelivery;
            orderdto.IdMenu = orderDTO.IdMenu;
            orderdto.Status = orderDTO.Status;  
            orderdto.Cost = orderDTO.Cost;
            orderdto.Photo = orderDTO.Photo;
            orderdto.Data = orderDTO.Data;
            return orderdto;
        }

        public static OrdersDTO OrderConvert(Order orderdto)
        {
            OrdersDTO ordersDTO = new OrdersDTO();

            ordersDTO.IdOrders = orderdto.IdOrders;
            ordersDTO.IdUsers = orderdto.IdUsers;
            ordersDTO.IdResto = ordersDTO.IdResto;
            ordersDTO.IdDelivery = ordersDTO.IdDelivery;
            ordersDTO.IdMenu = ordersDTO.IdMenu;
            ordersDTO.Status = ordersDTO.Status;
            ordersDTO.Cost = ordersDTO.Cost;
            ordersDTO.Photo = ordersDTO.Photo;
            ordersDTO.Data = ordersDTO.Data;
            return ordersDTO;
        }
    }
}
