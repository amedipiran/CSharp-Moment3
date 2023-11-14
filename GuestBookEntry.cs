public class GuestBookEntry
{
public string? Owner { get; set; }
public string? Title { get; set; }
public string? Message { get; set; }


    // En standardkonstruktor
    public GuestBookEntry()
    {
    }

    // En konstruktor som tar emot ägare, titel och meddelande
    public GuestBookEntry(string owner, string title, string message)
    {
        Owner = owner;
        Title = title;
        Message = message;
    }

    // Metod för att kontrollera om något av fälten är tomt
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Owner) && 
               !string.IsNullOrWhiteSpace(Title) && 
               !string.IsNullOrWhiteSpace(Message);
    }

    // Överskrida ToString för enklare utskrift
    public override string ToString()
    {
        return $"Ägare: {Owner}\nTitel: {Title}\nMeddelande: {Message}";
    }
}
