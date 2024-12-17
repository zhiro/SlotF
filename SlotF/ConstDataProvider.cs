namespace SlotF;

public class ConstDataProvider
{
    public string[] GetColumnOneValues()
    {
        return new[]
        {
            "Bar",
            "Cherry",
            "Bar",
            "Bar",
            "Bar",
            "Bar",
            "Bar",
            "Cherry",
            "Bar",
            "Bar",
            "777",
            "Cherry",
            "Cherry",
            "Cherry",
            "Bar",
            "Bar",
            "Cherry",
            "Bar",
            "Cherry",
            "Bar",
            "Wild"
        };
    }
    public string[] GetColumnTwoValues()
    {
        return new[]
        {
            "Bar",
            "Bar",
            "Bar",
            "Bar",
            "Cherry",
            "Bar",
            "Bar",
            "777",
            "Bar",
            "Bar",
            "Cherry",
            "Cherry",
            "Cherry",
            "777",
            "Bar",
            "Bar",
            "Bar",
            "Cherry",
            "Bar",
            "Cherry",
            "Wild"
        };
    }
    public string[] GetColumnThreeValues()
    {
        return new[]
        {
            "777",
            "Cherry",
            "Bar",
            "Cherry",
            "Bar",
            "Bar",
            "Cherry",
            "Cherry",
            "Bar",
            "Bar",
            "Bar",
            "Cherry",
            "Bar",
            "Cherry",
            "Cherry",
            "Bar",
            "Bar",
            "Bar",
            "Cherry",
            "Bar",
            "Wild"
        };
    }

    public Dictionary<string, int> GetPaytable()
    {
        return new Dictionary<string, int>
        {
            { "777", 50 },
            { "Cherry", 18 },
            { "Bar", 1 },
            { "Wild", 100 }    
        };
    }

    public static Dictionary<string, (int, long)> EmptyLogResult()
    {
        return new Dictionary<string, (int, long)>
        {
            { "777", (0, 0) },
            { "Cherry", (0, 0) },
            { "Bar", (0, 0) },
            { "Wild", (0, 0) }
        };
    }


}