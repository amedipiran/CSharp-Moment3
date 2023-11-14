using System;

class Program
{

    static void Main(string[] args)
    {
        GuestBook myGuestBook = new GuestBook();
        bool running = true;

//While loop för menyval och vilka metoder som ska startas med hjälp av switch-sats.
        while (running)
        {
            Console.WriteLine("Välkommen till gästboken!");
            Console.WriteLine("1. Lägg till inlägg");
            Console.WriteLine("2. Ta bort inlägg");
            Console.WriteLine("3. Visa inlägg");
            Console.WriteLine("4. Avsluta");

            Console.Write("Välj ett alternativ: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEntry(myGuestBook);
                    break;
                case "2":
                    RemoveEntry(myGuestBook);
                    break;
                case "3":
                    ShowAndSelectEntry(myGuestBook);
                    break;

                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

//Metod för att lägga till inlägg, man måste ha ägare titel och meddelande.
  static void AddEntry(GuestBook guestBook)
{
    Console.Write("Ange ägarens namn: ");
    string owner = Console.ReadLine();

    Console.Write("Ange titel: ");
    string title = Console.ReadLine();

    Console.Write("Ange meddelande: ");
    string message = Console.ReadLine();

    GuestBookEntry entry = new GuestBookEntry { Owner = owner, Title = title, Message = message };

    if (guestBook.AddEntry(entry))
    {
        Console.WriteLine("Inlägg tillagt!");
    }
    else
    {
        Console.WriteLine("Inlägget kunde inte läggas till. Kontrollera att alla fält är korrekt ifyllda.");
    }
}

//Raderar inlägg baserat på index vilket returnerar en boolean från guestbook.cs klassen som styr meddelanden.
static void RemoveEntry(GuestBook guestBook)
{
    // Visa alla inlägg med deras index
    guestBook.ShowEntriesWithIndex();

    Console.Write("Ange index för inlägget som ska tas bort: ");
    if (int.TryParse(Console.ReadLine(), out int index))
    {
        bool removedSuccessfully = guestBook.RemoveEntry(index);
        if (removedSuccessfully)
        {
            Console.WriteLine("Inlägg raderat!");
        }
        else
        {
            Console.WriteLine("Inget inlägg hittades med angivet index.");
        }
    }
    else
    {
        Console.WriteLine("Ogiltigt index.");
    }
}

//Metod för att visa inlägg i lista sedan hela inlägget man valt.
static void ShowAndSelectEntry(GuestBook guestBook)
{
    while (true)
    {
        // Visa alla inlägg med deras index
        guestBook.ShowEntriesWithIndex();

        Console.WriteLine("Välj ett inläggsindex för att läsa mer, eller skriv 'exit' för att återgå till huvudmenyn:");
        string input = Console.ReadLine();

        if (input.ToLower() == "exit")
        {
            break; // Återgå till huvudmenyn
        }

        if (int.TryParse(input, out int index))
        {
            GuestBookEntry entry = guestBook.GetEntry(index);
            if (entry != null)
            {
                Console.WriteLine($"\nÄgare: {entry.Owner}\nTitel: {entry.Title}\nMeddelande: {entry.Message}\n");
            }
            else
            {
                Console.WriteLine("Inget inlägg hittades med angivet index.");
            }
        }
        else
        {
            Console.WriteLine("Ogiltig inmatning, försök igen.");
        }

        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
        Console.Clear();
    }
}


}
