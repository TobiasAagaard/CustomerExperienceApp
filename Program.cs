bool restart = true;

do
{
    RunContactForm();
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Klik Enter for at sende, eller Esc for at afslutte.");
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
    string name = GetName();
    int rating = GetRating();
    string message = GetMessage();

    SaveFeedback(name, rating, message);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Tak for din tid, {name}! På gensyn.");
}

static string GetName()
{
    string name;
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Tast dit navn her: ");
        name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du skal skrive dit navn!");
        }
    } while (string.IsNullOrWhiteSpace(name));

    return name;
}

static int GetRating()
{
    int rating;
    string? ratingInput;
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Hvor god var din oplevelse hos Jagt & Vanvittigt (1 - 5): ");
        ratingInput = Console.ReadLine();

        if (!int.TryParse(ratingInput, out rating) || rating < 1 || rating > 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Din bedømmelse skal være fra 1 til 5.");
        }
    } while (rating < 1 || rating > 5);

    return rating;
}

static string GetMessage()
{
    string message;
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Hvordan var din oplevelse?");
        Console.Write("Skriv her: ");
        message = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(message))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du skal udfylde med tekst!");
        }
    } while (string.IsNullOrWhiteSpace(message));

    return message;
}

static void SaveFeedback(string name, int rating, string message)
{
    string fileName = DateTime.Now.ToString("MMMM-dd-yy_HH-mm-ss") + ".txt";
    string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

    if (!Directory.Exists(outputDirectory))
    {
        Directory.CreateDirectory(outputDirectory);
    }

    string filePath = Path.Combine(outputDirectory, fileName);
    string fileContent = $"Navn: {name}\nRating: {rating}\nAnmeldelse: {message}\nIndsendt dato: {DateTime.Now}\n";

    try
    {
        File.WriteAllText(filePath, fileContent);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Din anmeldelse er gemt som '{fileName}' i mappen Output.");
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Der opstod en fejl ved gemning af anmeldelsen.");
        Console.WriteLine($"Fejlbesked: {ex.Message}");
    }
}
