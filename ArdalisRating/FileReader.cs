using System.IO;

namespace ArdalisRating;

public class FileReader
{
    public string GetStringFromFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}