# UTS-SoftwareDesignStudio-Project
This is a University project completed by Group 6. 

## Database Setup Steps
**Prerequisites:** Install MSSQL 
1.	Right-click on the `UserDB` project
2.	Select Publish
3.	Edit Database Target location (Select MSSQL)
4.	Name the database [Optionally publish save profile]
5.	Publish database
6.	In Visual studio, Select View + SQL Server Object Explorer
7.	Navigate to your database (And click on it)
8.	While your database is selected, Click on “Properties” found on right side of screen
9.	Copy Full connection string
10. Right-Click on the 'GroupCreationProject' + Select 'Manage User Secrets'
10.	Paste the connection string into `secrets.json` like example below:
```
 {
  "ConnectionStrings": {
    "Default": "[YOUR CONNECTION STRING]"
  }
 }
```

