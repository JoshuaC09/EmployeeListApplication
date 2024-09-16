****
Employee List Application Setup Guide****

This guide will walk you through the process of setting up and running the Employee List Application. 
Follow these steps carefully to ensure proper setup of both the backend and frontend components.

**Backend Setup:**
1. Clone the repository to your local machine.
2. Navigate to the "Employee.List.App.Client" folder.
3. Open the "EmployeeListApp.Client.sln" solution in Visual Studio.
4. Set up the database:
    a. In Visual Studio, go to Tools > NuGet Package Manager > Package Manager Console.
    b. Change the default project to "EmployeeListApp.DataAccess".
    c. Run the following commands:
    "Add-Migration InitialMigration"
    "Update-Database"
   
    Note: If you encounter issues, try this alternative command:
    "Add-Migration InitialMigration -Project EmployeeListApp.DataAccess"

5. Set up the stored procedure:
    a. Open SQL Server Management Studio.
    b. Connect to your database.
    c. Execute the following SQL script to create the stored procedure:
    
    USE EmployeeDb;
    GO
    
    CREATE PROCEDURE dbo.sp_SearchEmployees
        @searchPattern NVARCHAR(100)
    AS
    BEGIN
        SET NOCOUNT ON;
        SELECT EmployeeId, FirstName, LastName, MiddleName, Email, Address, PhoneNumber, Salary, Status, Gender
        FROM dbo.Employees
        WHERE LOWER(CONCAT(
            COALESCE(FirstName, ''),
            COALESCE(LastName, ''),
            COALESCE(MiddleName, ''),
            COALESCE(Email, ''),
            COALESCE(Address, ''),
            COALESCE(PhoneNumber, '')
        )) LIKE '%' + LOWER(@searchPattern) + '%'
        ORDER BY LastName, FirstName;
    END

6. Run the "EmployeeListApp.Client" project in Visual Studio.

**Frontend Setup**

7. Navigate to the "employee-list-app.UI" folder.
8. Open a terminal in this folder.
9. Run the following command to start the Angular development server: "ng serve"

Access the application by opening a web browser and navigating to http://localhost:4200 (or the URL provided in the terminal).

**Important Notes**
1. Ensure that the backend API (EmployeeListApp.Client) is running before starting the frontend.
2. If you encounter any issues, double-check that all steps have been followed correctly and that all necessary dependencies are installed.
