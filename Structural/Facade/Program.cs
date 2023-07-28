
Facade facade = new Facade();
facade.Method01();

/// <summary>
/// The Facade design pattern provides a unified interface to a set of 
/// interfaces in a subsystem. This pattern defines a higher-level
/// interface that makes the subsystem easier to use.
/// </summary>
public class Facade
{
    private readonly SubClassOne subClassOne;
    private readonly SubClassTwo subClassTwo;
    private readonly SubClassTree subClassTree;
    public Facade()
    {
        subClassOne = new SubClassOne();
        subClassTwo = new SubClassTwo();
        subClassTree = new SubClassTree();
    }

    public void Method01()
    {
        subClassOne.SubClassOneMethod();
        subClassTwo.SubClassTwoMethod();
        subClassTree.SubClassThreeMethod();

        Console.ReadLine();
    }
}

public class SubClassOne
{
    public void SubClassOneMethod()
    {
        Console.WriteLine("I am SubClassOne's Method");
    }
}
class SubClassTwo
{
    public void SubClassTwoMethod()
    {
        Console.WriteLine("I am SubClassTwo's Method");
    }
}

class SubClassTree
{
    public void SubClassThreeMethod()
    {
        Console.WriteLine("I am SubClassTree's Method");
    }
}