# :file_folder: MonthlyOrganizer 
A simple C# console application to organize files by their date of creation.

## :wrench: Changelog

### :arrows_counterclockwise: Version 0.1
- Initial Working Implementation.

### :arrows_counterclockwise: Version 0.2
- Fixed the code to avoid redundant operations.
- Fixed the folder date formatting for better readability.

### :arrows_counterclockwise: Version 0.3
- Implemented a FileSystemWatcher.
- Now everty time a new recording is created, it is moved instantly to its corresponding folder.

### :new: Version 0.4
- Implemented a configuration file settings.txt to store the user directory externally.

## :bulb: Future Plans
- ~~Implement a FileSystemWatcher to move newly created files instantly.~~
- Implement a logging system to track errors long-term.


## :book: How to Use

### 1. **Download the Program**

### 2. **Prepare the `settings.txt` File**
- Locate the `settings.txt` file in the same folder as the program's executable.
- Open the `settings.txt` file with a text editor.
- Enter the path to the folder you want to monitor.

### 3. **Run the Program**