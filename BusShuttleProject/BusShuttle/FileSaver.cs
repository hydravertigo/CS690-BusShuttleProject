namespace BusShuttle;

using System.IO;

public class FileSaver
{
    string filename;

    public FileSaver(string filename)
    {
        this.filename = filename;

        if ( ! File.Exists(this.filename) ) {
            File.Create(this.filename).Close();
        }
        
    }

    public void AppendLine(string line)
    {
        File.AppendAllText(this.filename, line + Environment.NewLine);
    }

    public void AppendData(PassengerData data)
    {
        File.AppendAllText(this.filename, data.Driver + ":" + data.Loop + ":" + data.Stop + ":" + data.Boarded + Environment.NewLine);
    }
}
