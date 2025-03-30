namespace MonthlyOrganizer
{
    public class Organize
    {
        private DirectoryInfo UserDirectory { get; }

        public Organize(string path)
        {
            if (Directory.Exists(path))
                UserDirectory = new DirectoryInfo(path);
            else
                throw new DirectoryNotFoundException("The directory does not exist.");
        }

        public void OrganizeByMonth()
        {
            var files = UserDirectory.GetFiles();

            foreach (var file in files)
            {
                string folderName = $"{file.LastWriteTime:MM.yyyy}";
                string directory = CreateDirectory(folderName);
                string newDirectory = Path.Combine(directory, file.Name);

                if (File.Exists(newDirectory))
                    continue;

                try
                {
                    file.MoveTo(newDirectory);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error moving file {file.Name}: {ex.Message}");
                }
            }
        }


        public string CreateDirectory(string folderName)
        {
            string newDirectory = Path.Combine(UserDirectory.FullName, folderName);

            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);

                Console.WriteLine($"Directory \"{newDirectory}\" created.");
            }

            return newDirectory;
        }
    }
}
