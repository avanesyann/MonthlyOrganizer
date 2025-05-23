﻿using System.IO;

namespace MonthlyOrganizer
{
    public class Organize
    {
        private DirectoryInfo UserDirectory { get; }

        public Organize()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string settingsFilePath = Path.Combine(exeDirectory, "settings.txt");

            string targetDirectory = File.ReadAllText(settingsFilePath);

            Console.WriteLine(settingsFilePath);
            Console.WriteLine(targetDirectory);

            if (File.Exists(settingsFilePath))
            {
                string path = File.ReadAllText(settingsFilePath).Trim();

                if (Directory.Exists(path))
                {
                    UserDirectory = new DirectoryInfo(path);
                    Console.WriteLine($"Directory set to: {path}");
                }
                else
                {
                    throw new DirectoryNotFoundException($"The directory from {settingsFilePath} does not exist.");
                }
            }
            else
            {
                throw new FileNotFoundException("Settings file not found.");
            }
        }

        public void StartWatching()
        {
            OrganizeByMonth();

            FileSystemWatcher watcher = new FileSystemWatcher(UserDirectory.FullName, "*.*");

            watcher.NotifyFilter = NotifyFilters.LastWrite;

            watcher.Created += new FileSystemEventHandler(BeginWatch);
            watcher.Changed += new FileSystemEventHandler(BeginWatch);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine($"Watching for new recordings in: {UserDirectory.FullName}");
            Console.WriteLine("Press 'q' to exit...");

            while (Console.ReadKey().Key != ConsoleKey.Q) { }
        }

        private void BeginWatch(object sender, FileSystemEventArgs e)
        {
            OrganizeByMonth();
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
                    Thread.Sleep(100);
                    file.MoveTo(newDirectory);
                    Console.WriteLine($"Moved {file.Name} to {folderName} folder.");
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
