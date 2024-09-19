
//Variabel til at definer vores Restart variabel
bool restart = true;

// Her har vi et Do While loop som først starter vores program så når det har kørt beder den dig om at restart Programmet
do
{
    RunContactForm();

    Console.WriteLine();
    Console.WriteLine("Klik Enter for at sende!");
    string? input = Console.ReadLine();
    Console.Clear();


} while (restart);

static void RunContactForm()
{
    //Variabler
    string? name;
    string? message;
    int rating = 0;
    string? ratingInput;


    //Intro til Programmet

    Console.WriteLine("Tak for du kom, vi vil virkelig gerne vide hvad din oplevelse var hos os i Jagt & Vanvittigt");
    Console.WriteLine("");

    // Tast dit navn i input
    Console.Write("Tast dit navn: her: ");
    name = Console.ReadLine();
    Console.WriteLine("");


    // While Loop til vores rating 
    // Den checker hele tiden på om dens betingelser er opfyldt ellers køre den igen
    while (rating < 1 || rating > 5)
    {
        Console.Write("Hvor god var din oplevelse hos Jagt Vandvitigt mellem 1 - 5: ");
        ratingInput = Console.ReadLine();
        Console.WriteLine("");

        //Her siger vi at hvis ikke vi kan parse vores input ind som en Int eller hvis vores Int er mindre end 1 og Støre end 5 så skal vi give den her error
        if (!int.TryParse(ratingInput, out rating) || rating < 1 || rating > 5)
        {
            Console.WriteLine("Du tastede forkert! Du skal taste et tal mellem 1 og 5.");
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    //Her beder vi om at få en andmeldse

    Console.WriteLine("Hvad tænker du vi kunne gøre bedere for at vi kan give den bedste kunde oplevelse? ");
    Console.Write("Skriv din: anmeldelse her: ");
    message = Console.ReadLine();
    Console.WriteLine("");




    // Her sætter vi et variabel som sætter datoen som fillnavn
    string fileName = DateTime.Now.ToString("MM-dd-yy_HH-mm-ss") + ".txt";
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


    Console.WriteLine($"Tak for din tid, {name}! På gensyn.");




}
