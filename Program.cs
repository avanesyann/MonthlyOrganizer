
namespace MonthlyOrganizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Change this to your folder's path
            string path = @"C:\Users\You\Desktop\recordings";

            Organize organizer = new Organize(path);
            organizer.StartWatching();
        }
    }
}
