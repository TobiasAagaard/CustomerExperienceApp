﻿
// Her har vi et While loop som først starter vores program så når det har kørt beder den dig om at restart Programmet


bool restart = true;

do 
{
    RunContactForm();
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Klik enter for at sende!");
    Console.ForegroundColor = ConsoleColor.White;

    ConsoleKeyInfo keyInfo = Console.ReadKey(); 
    Console.Clear();

    if (keyInfo.Key == ConsoleKey.Escape)
    {
        restart = false;
    }

} while (restart); 

static void RunContactForm()
{
    //Variabler
    string? name = "";
    string? message = "";
    int rating = 0;
    string? ratingInput;

    //Intro til Programmet
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Tak fordi du kom, vi vil virkelig gerne vide hvad din oplevelse var hos os i Jagt & Vanvittigt");
    Console.WriteLine("");

    // Tast dit navn i input
    while (string.IsNullOrWhiteSpace(name))
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Tast dit navn her: ");
        name = Console.ReadLine();
        Console.WriteLine("");

        //Error håndtering
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du skal skrive dit Navn!");
            Console.WriteLine("");
        } 
    } 

    // While Loop til vores rating 
    // Den checker hele tiden på om dens betingelser er opfyldt ellers køre den igen
    while (rating < 1 || rating > 5)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Hvor god var din oplevelse hos Jagt Vandvitigt mellem 1 - 5: ");
        ratingInput = Console.ReadLine();
        Console.WriteLine("");

        //Her siger vi at hvis ikke vi kan parse vores input ind som en Int eller hvis vores Int er mindre end 1 og Støre end 5 så skal vi give den her error
        if (!int.TryParse(ratingInput, out rating) || rating < 1 || rating > 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du tastede forkert! Din bedømmelse skal være fra 1 til 5.");
        }
    }

    //Her beder vi om at få en andmeldse
    while (string.IsNullOrWhiteSpace(message))
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Hvordan var din oplevelse med at handle hos os?");
        Console.Write("Skriv her: ");
        message = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(message))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du skal udfylde med tekst!");
            Console.WriteLine("");
        }
    }

    // Her sætter vi et variabel som sætter datoen som fillnavn
    string fileName = DateTime.Now.ToString("MMMM-dd-yy_HH-mm-ss") + ".txt";

    // Her bestemmer vi hvor vores filler skal gemmes.
    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Output", fileName);

    // Dette er en If statement som kigger efter om du har en folder som hedder Output der hvor den skal være for at vi kan komme af med vores filler.
    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Output")))
    {
        //Ellers vil den lave en selv
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Output"));

    }

    // Her er opsætningen på vores fill dokument 
    string fileContent = $"Navn: {name}\n" +
                     $"Rating (et til fem): {rating}\n" +
                     $"Anmeldelse: {message}\n" +
                     $"Indsendt dato: {DateTime.Now}\n";

    //Her er functionen som spytter fillen ud 
    File.WriteAllText(filePath, fileContent);

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Tak for din tid, {name}! På gensyn.");



}
