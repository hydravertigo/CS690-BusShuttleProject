namespace BusShuttle;

using System.IO;

public class FileSaver
{
    string filename;

    public FileSaver(string filename)
    {

        this.filename = filename;

        File.Create(this.filename).Close();
    }

    public void AppendLine(string line)
    {
        File.AppendAllText(this.filename, line + Environment.NewLine);
    }
}
