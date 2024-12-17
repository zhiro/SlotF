using NUnit.Framework;
using SlotF;

namespace SlotF_Tests;

public class RunSlotsTests
{
    private RunSlots _runSlots;
    [SetUp]
    public void Setup()
    {
        _runSlots = new RunSlots();
    }

    [TestCase("Bar", "Bar", "Bar", "Bar")]
    [TestCase("Bar", "Bar", "Wild", "Bar")]
    [TestCase("Wild", "Cherry", "Wild", "Cherry")]
    [TestCase("Wild", "Wild", "Wild", "Wild")]
    [TestCase("Cherry", "Bar", "Wild", "")]
    [TestCase("Cherry", "Bar", "777", "")]
    public void CheckWins(string col1, string col2, string col3, string expected)
    {
        
        string[] columns = { col1, col2, col3 };
        string match = RunSlots.GetValueIfMatchingColumns(columns);
        
        
        Assert.That(match, Is.EqualTo(expected));
    }
}