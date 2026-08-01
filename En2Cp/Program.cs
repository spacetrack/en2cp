using System.Runtime.Serialization;

if (args.Length < 1)
{
    Console.WriteLine("Please provide the path to the Evernote export file (.enex) as first argument.");
    return;
}

Console.WriteLine("reading enex file ...");
var result = En2Cp.Services.EvernoteService.ParseEnexFile(args[0]);
var count = result?.Notes.Count ?? 0;

result?.Notes.Sort((a, b) => a.Created?.CompareTo(b.Created) ?? 0);

var action = args.Length > 1 ? args[1] : "list";

switch (action)
{
    case "count":
        Console.WriteLine($"... found {count} notes");
        break;

    case "list":
        var index = 1;
        var size = count.ToString().Length;
        foreach (var note in result?.Notes ?? [])
        {
            Console.WriteLine($"{index++.ToString().PadLeft(size)} | {note.Created} | {note.Title}");
        }

        break;

    default:
        Console.WriteLine($"Unknown action: {action}");
        break;
}
