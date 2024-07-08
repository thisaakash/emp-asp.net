
# Employee Management System

This is a web-based Employee Management System built using ASP.NET Web Forms and C#. The application allows users to perform CRUD (Create, Read, Update, Delete) operations on employee data. The data is stored in a local SQL Server database.

## Features

- Add new employees to the database
- View the list of all employees
- Update existing employee information
- Delete employees from the database

## Prerequisites

- .NET Framework
- Visual Studio
- SQL Server or SQL Server Express

## Getting Started

### Setting Up the Project

1. **Clone the repository:**
   ```sh
   git clone https://github.com/thisaakash/emp-asp.net.git
   ```

2. **Open the project in Visual Studio:**
   - Open Visual Studio.
   - Click on `File > Open > Project/Solution`.
   - Navigate to the cloned repository and select `EmployeeManagementSystem.sln`.

3. **Configure the database:**
   - Open `Web.config`.
   - Update the connection string to match your SQL Server configuration:
     ```xml
     <connectionStrings>
       <add name="ConnectionString" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True" providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

4. **Run the project:**
   - Press `F5` to build and run the project.

## Usage

### Adding an Employee

1. Enter the employee details in the form fields.
2. Click the `Insert` button to add the employee to the database.
3. A message will be displayed confirming the insertion.

### Viewing Employees

- The list of employees is displayed in a `GridView` on the main page.
- Click the `Refresh` button to reload the list of employees.

### Updating an Employee

1. Click the `Update` button next to the employee's details in the `GridView`.
2. The employee's details will be loaded into the form fields.
3. Modify the details and click the `Save` button to update the employee's information.
4. A message will be displayed confirming the update.

### Deleting an Employee

1. Click the `Delete` button next to the employee's details in the `GridView`.
2. A message will be displayed confirming the deletion.

## Project Structure

- `WebForm1.aspx`: The main page of the application containing the form and `GridView`.
- `WebForm1.aspx.cs`: The code-behind file containing the event handlers and database logic.
- `App_Data`: Contains the local SQL Server database file (`Database1.mdf`).

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Thanks to all the developers who contributed to the ASP.NET and SQL Server communities.
