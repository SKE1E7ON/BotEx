using BotEx_Api.Model;

namespace BotEx_Api.ModelDTO
{
    public class OrdersGETRequest
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


        public static Order ConvertGetToOrder(OrdersRequest orders)
        {
            Order order = new Order();
            order.IdOrders = orders.IdOrders;
            order.IdUsers = orders.IdUsers;
            order.IdResto = orders.IdResto;
            order.IdDelivery = orders.IdDelivery;
            order.IdMenu = orders.IdMenu;
            order.Status = orders.Status;
            order.Cost = orders.Cost;
            order.Photo = orders.Photo;
            order.Data = orders.Data;
            return order;
        }

        public static OrdersGETRequest ConvertGetToOrders(Order orders)
        {
            OrdersGETRequest orders1 = new OrdersGETRequest();
            orders1.IdOrders = orders.IdOrders;
            orders1.IdUsers = orders.IdUsers;
            orders1.IdResto = orders.IdResto;
            orders1.IdDelivery = orders.IdDelivery;
            orders1.IdMenu = orders.IdMenu;
            orders1.Status = orders.Status;
            orders1.Cost = orders.Cost;
            orders1.Photo = orders.Photo;
            orders1.Data = orders.Data;
            return orders1;
        }

        public static List<OrdersGETRequest> ConvertToGet(List<Order> order)
        {
            List<OrdersGETRequest> order1 = new List<OrdersGETRequest>();
            foreach (Order orders in order)
            {
                order1.Add(new OrdersGETRequest
                {
                    IdOrders = orders.IdOrders,
                    IdUsers = orders.IdUsers,
                    IdResto = orders.IdResto,
                    IdDelivery = orders.IdDelivery,
                    IdMenu = orders.IdMenu,
                    Status = orders.Status,
                    Cost = orders.Cost,
                    Photo = orders.Photo,
                    Data = orders.Data

                });
            }
            return order1;
        }
    }
}