**Project Documentation for St10083869.prog7311.part2**       **Video link** :https://youtu.be/azgRy7AxMug?feature=shared  
**Table of Contents**
1.	Overview
2.	Prerequisites
3.	Setup Instructions
4.	Running the Application
5.	Operating the Application
6.	Project Structure
7.	Key Features
8.	Contributing
9.	Contact

    ___
Overview
This ASP.NET MVC application made on visual studio in the language C sharp efficiently manages farmer and product data, implementing CRUD (Create, Read, Update, Delete) operations through a SQL Server database. This README aims to provide comprehensive guidance on the setup, operation, and further development of this project.
Prerequisites
This project requires:
- Visual Studio 
- NET Core 3.1 SDK 
- SQL Server 
Setup Instructions
Clone the Repository
To get started, clone the project repository to your local machine: https://github.com/VCDN-2024/prog7311-part-2-Sherelda/tree/master 
____
 Open the Solution
Navigate to the directory where you cloned the repository and open the `.sln` file in Visual Studio.

**Restore Dependencies**
In Visual Studio, right-click on the solution in Solution Explorer and select "Restore NuGet Packages".

 Configure the Database
- Make sure your SQL Server instance is active.
- Run the SQL script from the `DatabaseScripts` folder to configure and populate the database.

**Update Connection Strings**
Modify the connection string in the `appsettings.json` file to match your SQL Server settings.
Running the Application
Build the Project
Select `Build > Build Solution` in Visual Studio to compile the project.

**Launch the Application**
Start the application by pressing `F5` or clicking the "Start" button in Visual Studio. Access it by visiting `https://localhost:{port}` in your web browser.
Operating the Application
 Logging In
Navigate to the application's root URL to access the login page and enter your credentials. If you do not have an account, proceed to register.

![image](https://github.com/VCDN-2024/prog7311-part-2-Sherelda/assets/103831256/87377a21-8823-436d-ba64-95d6725af0ed)

 
 **Registering a New User**
From the login page, move to the registration page to create a new account. Fill in details such as email, password, and user type (Farmer or Employee).
![image](https://github.com/VCDN-2024/prog7311-part-2-Sherelda/assets/103831256/2b0eb01c-4f6f-4547-a3eb-6f9e9c66da34)
 
 **Managing Farmers**
Logged in as an employee, use the Farmers section via the navigation menu to add, edit, or delete farmer entries.
Managing Products
If logged in as a farmer, access the Products section from the dashboard to add new products or update existing ones.
![image](https://github.com/VCDN-2024/prog7311-part-2-Sherelda/assets/103831256/4dc287ce-e84c-4e51-add7-8b9fa339d6e3)

**Managing Products**
If logged in as a farmer, access the Products section from the dashboard to add new products or update existing ones.
![image](https://github.com/VCDN-2024/prog7311-part-2-Sherelda/assets/103831256/ab62e25c-2b6d-4a8e-a25a-7ff0dec89831)


**Logging Out**
Securely log out of your session using the logout option in the navigation menu.
Project Structure
The project includes:
- **Controllers**: Handle requests and return responses.
- **Models**: Data structures for the project.
- **Views**: Files for rendering user interfaces.
- **DatabaseScripts**: Scripts for database management and initial setup.
Key Features
Secure user authentication system.
Full CRUD operations for managing both farmers and products.
Responsive interaction with the backend SQL Server database.
Contributing
We welcome contributions! Please adhere to the following steps for contributing:
1. Fork the repository.
2. Create your Feature branch                                                                                                                                   3. Commit your changes                                                                                                                                                                 4. Push to the branch 
5. Open a Pull Request.

