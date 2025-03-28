namespace MonthlyOrganizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Change this to your folder's path
            string path = @"C:\Users\Me\Desktop\recordings";

            Organize organize = new Organize(path);

            organize.OrganizeByMonth();
        }
    }
}
