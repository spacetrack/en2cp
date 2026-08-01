using System.Globalization;
using System.Xml.Serialization;

namespace En2Cp.DTOs;

[XmlRoot("en-export")]
public class EnExportDto
{
    [XmlElement("note")]
    public List<EnNoteDto> Notes { get; set; } = [];
}

[XmlRoot("note")]
public record EnNoteDto
{
    [XmlElement("title")]
    public string? Title { get; set; }

    [XmlElement("content")]
    public string? Content { get; set; }

    [XmlIgnore]
    public DateTime? Created { get; set; }
    [XmlElement("created")]
    public string? CreatedString
    {
        get => Created?.ToString("yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture);
        set => Created  = value is null ? null : DateTime.ParseExact(value, "yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
    }

    [XmlIgnore]
    public DateTime? Updated { get; set; }
    [XmlElement("updated")]
    public string? UpdatedString
    {
        get => Updated?.ToString("yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture);
        set => Updated = value is null ? null : DateTime.ParseExact(value, "yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
    }

    [XmlElement("note-attributes")]
    public EnNoteAttributesDto? Attributes { get; set; }
}

[XmlRoot("note-attributes")]
public record EnNoteAttributesDto
{
    [XmlElement("source")]
    public string? Source { get; set; }

    [XmlElement("source-url")]
    public string? SourceUrl { get; set; }
}

public record EnNoteContentDto
{
    [XmlElement("content")]
    public string? Content { get; set; }
}
