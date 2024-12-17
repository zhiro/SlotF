namespace SlotF;

public class SlotRow
{
    private static readonly Random Random = new Random();
    static readonly ConstDataProvider DataProvider = new ConstDataProvider();

    public static string[] GetRandomColumnValues()
    {
        string colOneValue = GetRandomColumnValue(DataProvider.GetColumnOneValues());
        string colTwoValue = GetRandomColumnValue(DataProvider.GetColumnTwoValues());  
        string colThreeValue = GetRandomColumnValue(DataProvider.GetColumnThreeValues());
                
        string[] columns = { colOneValue, colTwoValue, colThreeValue };
 
        return columns;
    }
        
    static string GetRandomColumnValue(string[] columnValues)
    {
        int randomIndex = Random.Next(columnValues.Length);
        return columnValues[randomIndex];
    }

}