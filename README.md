# SampleDataBase
# Description
The program was written based on the Windows forms framework.
The database was created using a table designer.
To make the program work on another computer, you need to install Microsoft Sql Server.
Then simply change the hostname in the program code to the one you specified during installation.
string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databaseFilePath};Integrated Security=True;Connect Timeout=30";
# Features 
1. Enrollment of an individual person in the database.
2. Edit an individual record in the database.
3. Deleting individual records from the database.
4. Summary of payments during the period.
5. Making a copy of the entire database.
6. After entering the appropriate password, delete all records from the database. 
