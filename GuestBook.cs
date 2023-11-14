using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;

public class GuestBook
{
    private List<GuestBookEntry> entries = new List<GuestBookEntry>();
    private readonly string filePath = "GuestBook.json";

    public GuestBook()
    {
        LoadEntries();
    }
//Lägger till inlägg
    public bool AddEntry(GuestBookEntry entry)
    {
        if (entry.IsValid())
        {
            entries.Add(entry);
            SaveEntries();
            return true;
        }
        return false;
    }
//Tar bort inlägg baserat på index
public bool RemoveEntry(int index)
{
    if (index >= 0 && index < entries.Count)
    {
        entries.RemoveAt(index);
        SaveEntries();
        return true;
    }
    return false;
}

//Visar alla inlägg
    public void ShowEntries()
    {

        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine(); // Lägger till en tom rad mellan inlägg
        }
    }

//Hämtar data ifrån GuestBook.json
    private void LoadEntries()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            entries = JsonSerializer.Deserialize<List<GuestBookEntry>>(json) ?? new List<GuestBookEntry>();
        }
    }

//Sparar Json-data i GuestBook.json
    private void SaveEntries()
    {
        string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
//Hämtar index till inlägg som man kan välja
    public GuestBookEntry GetEntry(int index)
{
    if (index >= 0 && index < entries.Count)
    {
        return entries[index];
    }
    return null;
}


    //Används för att skriva ut ägare, titel samt index så man vet vad man tar bort
    public void ShowEntriesWithIndex()
{
    for (int i = 0; i < entries.Count; i++)
    {
        Console.WriteLine($"Index: {i} - Ägare: {entries[i].Owner}, Titel: {entries[i].Title}");
    }
}

}
