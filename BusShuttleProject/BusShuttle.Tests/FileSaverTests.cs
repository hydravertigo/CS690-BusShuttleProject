namespace BusShuttle.Tests;

using BusShuttle;

public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;


    public FileSaverTests()
    {
        testFileName = "test-doc.txt";

        if ( File.Exists(testFileName) ) {
            File.Delete(testFileName);
        }

        fileSaver = new FileSaver(testFileName);
    }

    [Fact]
    public void Test_FileSaver_Append()
    {
        fileSaver.AppendLine("Hello, world");

        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Hello, world" + Environment.NewLine, contentFromFile);


    }

    [Fact]
    public void Test_FileSaver_AppendData()
    {
        Stop sampleStop = new Stop("MyStop");
        Loop sampleLoop = new Loop("MyLoop");
        Driver sampleDriver = new Driver("Sample");
        PassengerData sampleData = new PassengerData(5, sampleStop, sampleLoop, sampleDriver);

        fileSaver.AppendData(sampleData);
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Sample:MyLoop:MyStop:5" + Environment.NewLine, contentFromFile);


    }
}