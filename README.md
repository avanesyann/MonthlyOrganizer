# :file_folder: MonthlyOrganizer 
A simple C# console application to organize files by their date of creation.

## :wrench: Changelog

### :arrows_counterclockwise: Version 0.1
- Initial Working Implementation.

### :arrows_counterclockwise: Version 0.2
- Fixed the code to avoid redundant operations.
- Fixed the folder date formatting for better readability.

### :new: Version 0.3
- Implemented a FileSystemWatcher.
- Now everty time a new recording is created, it is moved instantly to its corresponding folder.

## :bulb: Future Plans
- Implement a FileSystemWatcher to move newly created files instantly.
- Implement a logging system to track errors long-term.


## :book: How to Use
1. Run the program and specify the target folder path.
2. Create a Organizer class instance.
3. Use Organizer's methods to manipulate the directory.