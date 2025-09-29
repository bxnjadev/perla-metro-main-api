namespace perla_metro_main_api.Util;

public class Routes
{


    public static readonly string UserRoute = Environment.GetEnvironmentVariable("USER_ROUTE")
                                                   ?? "https://perla-metro-users-service.onrender.com:8080/api/users";


   
    public static readonly string AuthRoute = Environment.GetEnvironmentVariable("AUTH_ROUTE")
                                              ?? "https://perla-metro-users-service.onrender.com:8080/api/auth";



    public static readonly string RoutesRoute = Environment.GetEnvironmentVariable("ROUTES_ROUTE")
                                                   ?? "https://perla-metro-routes-service-ksk5.onrender.com/api/routes";

    public static readonly string StationsRoute = Environment.GetEnvironmentVariable("STATIONS_ROUTE")
                                                   ?? "https://perla-metro-stations-service.onrender.com/api/stations";
    
    public static readonly string TicketsRoute = Environment.GetEnvironmentVariable("TICKETS_ROUTE")
                                                   ?? "https://perla-metro-tickets.onrender.com/api/tickets";
    
    private Routes() {}
    
}