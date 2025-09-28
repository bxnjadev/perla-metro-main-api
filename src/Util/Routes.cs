namespace perla_metro_main_api.Util;

public class Routes
{

    public static readonly string? UserRoute = Environment.GetEnvironmentVariable("USER_ROUTE");

    public const string RoutesRoute = "http://localhost:4000/api/routes";

    public static readonly string? StationsRoute = Environment.GetEnvironmentVariable("STATIONS_ROUTE");
    
    public static readonly string? TicketsRoute = Environment.GetEnvironmentVariable("TICKETS_ROUTE");
    
    private Routes() {}
    
}