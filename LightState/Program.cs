namespace LightState;

public static class Program
{
    public static void Main()
    {
        TrafficLight trafficLight = new();

        trafficLight.Request();
        trafficLight.Request();
        trafficLight.Request();
    }
}
public class TrafficLight
{
    private ITrafficLightState currentState;

    public TrafficLight()
    {
        currentState = new GreenState();
    }

    public void ChangeState(ITrafficLightState newState)
    {
        currentState = newState;
    }

    public void Request()
    {
        currentState.HandleRequest(this);
    }
}

public interface ITrafficLightState
{
    void HandleRequest(TrafficLight trafficLight);
}

public class GreenState : ITrafficLightState
{
    public void HandleRequest(TrafficLight trafficLight)
    {
        Console.WriteLine("Turning from green to yellow.");
        trafficLight.ChangeState(new YellowState());
    }
}

public class YellowState : ITrafficLightState
{
    public void HandleRequest(TrafficLight trafficLight)
    {
        Console.WriteLine("Turning from yellow to red.");
        trafficLight.ChangeState(new RedState());
    }
}

public class RedState : ITrafficLightState
{
    public void HandleRequest(TrafficLight trafficLight)
    {
        Console.WriteLine("Turning from red to green.");
        trafficLight.ChangeState(new GreenState());
    }
}