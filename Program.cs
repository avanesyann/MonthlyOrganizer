
namespace MonthlyOrganizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Organize organizer = new Organize();
            organizer.StartWatching();
        }
    }
}
