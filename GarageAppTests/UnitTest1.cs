using GarageApp;

namespace GarageAppTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void ParkVehicleTest()
    {
        // using MSTest and this guide from microsoft:
        // https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022

        // Arrange
        GarageHandler handler = new GarageHandler();
        MockConsole.InputString = "MOT111";


        // Act
        // handler.ParkVehicle();
        handler.UnParkVehicle();



        // Assert
        Assert.AreEqual("Successfully removed vehicle with registration MOT111.", MockConsole.InputString);

    }



    public static class MockConsole
    {
        public static string InputString { get; set; }
        public static List<string> OutputLines { get; private set; }
    
        static MockConsole()
        {
            OutputLines = new List<string>();
            Console.SetOut(TextWriter.Synchronized(new StringWriter()));
        }
    
        public static void ClearOutput()
        {
            OutputLines.Clear();
        }
    
        public static string GetLastLine()
        {
            if (OutputLines.Count > 0)
                return OutputLines[OutputLines.Count - 1];
            else
                return null;
        }
    
        public static void WriteLine(string line)
        {
            OutputLines.Add(line);
            Console.WriteLine(line);
        }
    }

}