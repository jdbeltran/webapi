public class HelloService: IHello
{
    public string GetHello()
    {
        return "Hello Word!";
    }
}

public interface IHello
{
    string GetHello();
}