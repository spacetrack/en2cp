using System.Xml.Serialization;
using En2Cp.DTOs;

namespace En2Cp.Services;

public class EvernoteService
{
    public static EnExportDto? ParseEnexFile(string filePath)
    {
        var serializer = new XmlSerializer(typeof(EnExportDto));
        using var reader = new StreamReader(filePath);
        return (EnExportDto?)serializer.Deserialize(reader);
    }
}