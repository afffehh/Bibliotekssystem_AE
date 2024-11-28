using System;
using System.Threading.Tasks;
using Bibliotekssystem.Models;

class Program
{
    static async Task Main(string[] args)
    {
        // Skapa en instans av din DbContext
        var context = new AppDbContext();

        // Skapa instanser av CRUD-klasser
        var addData = new AddData(context);
        var updateData = new UpdateData(context);
        var deleteData = new DeleteData(context);
        var readData = new ReadData(context);

        bool running = true;

        while (running)
        {
            // Huvudmeny
            Console.Clear();
            Console.WriteLine("Välj en åtgärd:");
            Console.WriteLine("1. Skapa data");
            Console.WriteLine("2. Uppdatera data");
            Console.WriteLine("3. Ta bort data");
            Console.WriteLine("4. Läs data");
            Console.WriteLine("5. Lista SeedData");
            Console.WriteLine("6. Avsluta");
            Console.Write("Välj alternativ: ");

            var mainChoice = Console.ReadLine();

            switch (mainChoice)
            {
                case "1":
                    await AddDataMenu(addData);
                    break;
                case "2":
                    await UpdateDataMenu(updateData);
                    break;
                case "3":
                    await DeleteDataMenu(deleteData);
                    break;
                case "4":
                    await ReadDataMenu(readData);
                    break;
                case "5":
                    await ListSeedDataAsync(readData);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }

        Console.WriteLine("Programmet avslutas.");
    }

    // Meny för att lägga till data
    static async Task AddDataMenu(AddData addData)
    {
        Console.Clear();
        Console.WriteLine("Välj åtgärd för att skapa data:");
        Console.WriteLine("1. Lägg till författare");
        Console.WriteLine("2. Lägg till bok");
        Console.WriteLine("3. Lägg till lån");
        Console.WriteLine("4. Koppla författare till bok");
        Console.WriteLine("5. Tillbaka");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Ange författarens namn: ");
                string authorName = Console.ReadLine();
                Console.Write("Ange författarens nationalitet: ");
                string nationality = Console.ReadLine();
                await addData.AddAuthorAsync(authorName, nationality);
                Console.WriteLine("Författare tillagd.");
                break;
            case "2":
                Console.Write("Ange boktitel: ");
                string bookTitle = Console.ReadLine();
                Console.Write("Ange bokutgivningsdatum (yyyy-MM-dd): ");
                DateTime releaseDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Ange författarens ID: ");
                int authorIdForBook = int.Parse(Console.ReadLine());
                await addData.AddBookAsync(bookTitle, releaseDate, authorIdForBook);
                Console.WriteLine("Bok tillagd och kopplad till författare.");
                break;
            case "3":
                Console.Write("Ange bok-ID: ");
                int bookId = int.Parse(Console.ReadLine());
                Console.Write("Ange lånedatum (yyyy-MM-dd): ");
                DateTime loanDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Ange återlämningsdatum (yyyy-MM-dd, eller lämna tomt om ej återlämnad): ");
                DateTime? returnDate = string.IsNullOrEmpty(Console.ReadLine()) ? (DateTime?)null : DateTime.Parse(Console.ReadLine());
                await addData.AddLoanAsync(bookId, loanDate, returnDate);
                Console.WriteLine("Lån tillagt.");
                break;
            case "4": // Ny funktionalitet
                Console.Write("Ange bok-ID: ");
                int bookIdForAuthor = int.Parse(Console.ReadLine());
                Console.Write("Ange författarens ID: ");
                int authorIdToLink = int.Parse(Console.ReadLine());
                await addData.AddAuthorToBookAsync(bookIdForAuthor, authorIdToLink);
                break;
            case "5":
                break;
            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn: ");
        Console.ReadKey();
    }

    // Meny för att uppdatera data
    static async Task UpdateDataMenu(UpdateData updateData)
    {
        Console.Clear();
        Console.WriteLine("Välj åtgärd för att uppdatera data:");
        Console.WriteLine("1. Uppdatera författare");
        Console.WriteLine("2. Uppdatera bok");
        Console.WriteLine("3. Uppdatera lån");
        Console.WriteLine("4. Tillbaka");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Ange författarens ID att uppdatera: ");
                int authorId = int.Parse(Console.ReadLine());
                Console.Write("Ange nytt namn för författaren: ");
                string newName = Console.ReadLine();
                await updateData.UpdateAuthorAsync(authorId, newName);
                Console.WriteLine("Författare uppdaterad.");
                break;
            case "2":
                Console.Write("Ange bok-ID att uppdatera: ");
                int bookId = int.Parse(Console.ReadLine());
                Console.Write("Ange ny titel för boken: ");
                string newTitle = Console.ReadLine();
                await updateData.UpdateBookAsync(bookId, newTitle);
                Console.WriteLine("Bok uppdaterad.");
                break;
            case "3":
                Console.Write("Ange lån-ID att uppdatera: ");
                int loanId = int.Parse(Console.ReadLine());
                Console.Write("Ange återlämningsdatum (yyyy-MM-dd): ");
                DateTime returnDate = DateTime.Parse(Console.ReadLine());
                await updateData.UpdateLoanAsync(loanId, returnDate);
                Console.WriteLine("Lån uppdaterat.");
                break;
            case "4":
                break;
            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn: ");
        Console.ReadKey();
    }

    // Meny för att ta bort data
    static async Task DeleteDataMenu(DeleteData deleteData)
    {
        Console.Clear();
        Console.WriteLine("Välj åtgärd för att ta bort data:");
        Console.WriteLine("1. Ta bort författare");
        Console.WriteLine("2. Ta bort bok");
        Console.WriteLine("3. Ta bort lån");
        Console.WriteLine("4. Tillbaka");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Ange författarens ID att ta bort: ");
                int authorId = int.Parse(Console.ReadLine());
                await deleteData.DeleteAuthorAsync(authorId);
                Console.WriteLine("Författare borttagen.");
                break;
            case "2":
                Console.Write("Ange bok-ID att ta bort: ");
                int bookId = int.Parse(Console.ReadLine());
                await deleteData.DeleteBookAsync(bookId);
                Console.WriteLine("Bok borttagen.");
                break;
            case "3":
                Console.Write("Ange lån-ID att ta bort: ");
                int loanId = int.Parse(Console.ReadLine());
                await deleteData.DeleteLoanAsync(loanId);
                Console.WriteLine("Lån borttaget.");
                break;
            case "4":
                break;
            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn: ");
        Console.ReadKey();
    }

    // Meny för att läsa data
    static async Task ReadDataMenu(ReadData readData)
    {
        Console.Clear();
        Console.WriteLine("Välj åtgärd för att läsa data:");
        Console.WriteLine("1. Läs alla författare");
        Console.WriteLine("2. Läs alla böcker");
        Console.WriteLine("3. Läs alla lån");
        Console.WriteLine("4. Lista alla böcker med författare");
        Console.WriteLine("5. Lista alla lånade böcker");
        Console.WriteLine("6. Tillbaka");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                await readData.ReadAllAuthorsAsync();
                break;
            case "2":
                await readData.ReadAllBooksAsync();
                break;
            case "3":
                await readData.ReadAllLoansAsync();
                break;
            case "4":
                await readData.ListBooksWithAuthorsAsync();
                break;
            case "5":
                await readData.ListLoanedBooksAsync();
                break;
            case "6":
                break;
            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn: ");
        Console.ReadKey();
    }

    // Metod för att lista SeedData
    static async Task ListSeedDataAsync(ReadData readData)
    {
        Console.Clear();
        Console.WriteLine("--- SeedData ---");

        Console.WriteLine("\nFörfattare:");
        await readData.ReadAllAuthorsAsync();

        Console.WriteLine("\nBöcker:");
        await readData.ReadAllBooksAsync();

        Console.WriteLine("\nLån:");
        await readData.ReadAllLoansAsync();

        Console.WriteLine("\nTryck på valfri tangent för att återgå till huvudmenyn: ");
        Console.ReadKey();
    }
}
