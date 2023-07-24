namespace CompositeRoute
{
    public static class Program
    {
        static void Main()
        {
            var client = new ClientComposite();
            var currentLocation = new Route("Aimores", 0);
            client.Location(currentLocation);

            var tree = new CompositeRoute();

            var firstComposite = new CompositeRoute();
            firstComposite.AddRoute(new Route("Tancredo", 1));
            firstComposite.AddRoute(new Route("Nereu", 6));

            var secondComposite = new CompositeRoute();
            secondComposite.AddRoute(new Route("Xavantes", 1));
            secondComposite.AddRoute(new Route("Brasil", 3));
            secondComposite.AddRoute(new Route("Nereu", 7));

            tree.AddRoute(firstComposite);
            tree.AddRoute(secondComposite);
            client.Location(tree);

            client.Destination(tree, currentLocation);
        }
    }

    abstract public class RouteAbstract
    {
        protected RouteAbstract() { }

        public virtual void AddRoute(RouteAbstract route)
        {
        }

        public virtual int CountRoutes()
        {
            return 0;
        }

        public virtual string CurrentLocation()
        {
            return "Error get route!";
        }
    }

    public sealed class Route : RouteAbstract
    {
        public string StreetName { get; init; }
        public int Distance { get; init; }

        public Route(string streetName, int distance)
        {
            StreetName = streetName;
            Distance = distance;
        }

        public override string CurrentLocation()
        {
            return $"Street is {StreetName} and Distance is {Distance}";
        }
    }

    public sealed class CompositeRoute : RouteAbstract
    {
        private readonly List<RouteAbstract> _routes = new List<RouteAbstract>();

        public override void AddRoute(RouteAbstract route)
        {
            _routes.Add(route);
        }

        public override int CountRoutes()
        {
            return _routes.Count;
        }

        public override string CurrentLocation()
        {
            int i = 0;
            string result = "Route: (";

            foreach (var route in _routes)
            {
                result += route.CurrentLocation();
                if (i != CountRoutes() - 1)
                {
                    result += " follow ";
                }
                i++;
            }

            return result + ")";
        }
    }

    public sealed class ClientComposite
    {
        public void Location(RouteAbstract route)
        {
            Console.WriteLine($"{route.CurrentLocation()} \n");
        }

        public void Destination(RouteAbstract firstRoute, RouteAbstract secondRoute)
        {
            if (firstRoute.CountRoutes() > 0)
            {
                firstRoute.AddRoute(secondRoute);
            }

            Console.WriteLine($"{firstRoute.CurrentLocation()}");
        }
    }
}