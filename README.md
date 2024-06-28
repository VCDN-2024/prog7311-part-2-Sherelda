**Project Documentation for St10083869.prog7311.part2**       **Video link** :https://youtu.be/azgRy7AxMug?feature=shared  

## Table of Contents
1. [Overview](#overview)
2. [Prerequisites](#prerequisites)
3. [Setup Instructions](#setup-instructions)
4. [Running the Application](#running-the-application)
5. [Operating the Application](#operating-the-application)
6. [Project Structure](#project-structure)
7. [Key Features](#key-features)
8. [Contributing](#contributing)
9. [Contact](#contact)

---

## Overview
This ASP.NET MVC application, developed using Visual Studio and C#, efficiently manages farmer and product data by implementing CRUD (Create, Read, Update, Delete) operations through a SQL Server database. This README provides comprehensive guidance on setting up, operating, and further developing this project.

## Prerequisites
Ensure you have the following installed:
- Visual Studio
- .NET Core
- SQL Server

## Setup Instructions

### Clone the Repository
Clone the project repository to your local machine:
```bash
git clone https://github.com/VCDN-2024/prog7311-part-2-Sherelda/tree/master
```

### Open the Solution
Navigate to the directory where you cloned the repository and open the `.sln` file in Visual Studio.

### Restore Dependencies
In Visual Studio, right-click on the solution in Solution Explorer and select "Restore NuGet Packages".

### Configure the Database
- Ensure your SQL Server instance is active.
- Run the SQL script from the `DatabaseScripts` folder to configure and populate the database.

### Update Connection Strings
Modify the connection string in the `appsettings.json` file to match your SQL Server settings.

## Running the Application

### Build the Project
Select `Build > Build Solution` in Visual Studio to compile the project.

### Launch the Application
Start the application by pressing `F5` or clicking the "Start" button in Visual Studio. Access it by visiting `https://localhost:{port}` in your web browser.

## Operating the Application

### Logging In
Navigate to the application's root URL to access the login page and enter your credentials. If you do not have an account, proceed to register.

![Login Page](https://github.com/VCDN-2024/prog7311-part-2-Sherelda/assets/103831256/87377a21-8823-436d-ba64-95d6725af0ed)

### Registering a New User
From the login page, navigate to the registration page to create a new account. Fill in details such as email, password, and user type (Farmer or Employee).

![Registration Page](https://github.com/VCDN-2024/prog7311-part-2-Sherelda/assets/103831256/2b0eb01c-4f6f-4547-a3eb-6f9e9c66da34)

### Managing Farmers
As an employee, use the Farmers section via the navigation menu to add, edit, or delete farmer entries.

### Managing Products
As a farmer, access the Products section from the dashboard to add new products or update existing ones.

![Product Management](https://github.com/VCDN-2024/prog7311-part-2-Sherelda/assets/103831256/4dc287ce-e84c-4e51-add7-8b9fa339d6e3)

### Logging Out
Securely log out of your session using the logout option in the navigation menu.

## Project Structure
The project includes:
- **Controllers**: Handle requests and return responses.
- **Models**: Data structures for the project.
- **Views**: Files for rendering user interfaces.
- **DatabaseScripts**: Scripts for database management and initial setup.

## Key Features
- Secure user authentication system.
- Full CRUD operations for managing both farmers and products.
- Responsive interaction with the backend SQL Server database.

## Contributing
We welcome contributions! Please adhere to the following steps:
1. Fork the repository.
2. Create your feature branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a Pull Request.

## Contact
For any queries or further information, please reach out through the project's GitHub repository.

---

This document aims to provide all necessary information to efficiently set up, run, and contribute to the project. We appreciate your interest and contributions to improving this application.
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

