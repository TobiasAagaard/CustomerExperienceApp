bool restart = true;

do
{
    RunContactForm();

    Console.WriteLine("Klik Enter for at sende!");
    string input = Console.ReadLine();
    Console.Clear();


} while (restart);

static void RunContactForm()
{

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


    Console.WriteLine("Hvad tænker du vi kunne gøre bedere for at vi kan give den bedste kunde oplevelse? ");
    Console.Write("Skriv din: anmeldelse her: ");
    message = Console.ReadLine();
    Console.WriteLine("");





    string fileName = DateTime.Now.ToString("MM-dd-yy_HH/mm/ss") + ".txt";
    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Output", fileName);

    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Output")))
    {

        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Output"));

    }


    string fileContent = $"Navn: {name}\n" +
                     $"Rating (et til fem): {rating}\n" +
                     $"Anmeldelse: {message}\n" +
                     $"indsendt dato: {DateTime.Now}\n";

    File.WriteAllText(filePath, fileContent);


    Console.WriteLine($"Tak for din tid, {name}! På gensyn.");




}



RunContactForm();




