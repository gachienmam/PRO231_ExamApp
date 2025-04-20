<img src="resources/Images/PolyTest Logo Full Horizontal 500x192.png"/>

[Bấm vào đây để xem bản Tiếng Việt](README_VN.md)

PolyTest Examination Management System
=====================================================
***by Group 2 - Project for PRO231 (C#, WinForms) at FPT PolySchool***
## Technologies
- Server powered by **ASP.NET Core** (.NET 8)
- Uses **gRPC** for client and server communication
- Authorization with **JWT (Json Web Tokens)** and password encryption using **BCrypt**
- Uses **SQL Server** as the database
- Uses **WinForms** for the user interface

## Usage

### Management Software (ManagementApp)
1. Install the application using the file ```Setup.exe``` or ```SetupManagementApp.msi```
2. After installing, click “PolyTest Manager” on the desktop, and login using the default account:
	- Username: vanthanh3045@gmail.com
	- Password: fptgg

<b>If you are deploying the server on another machine, please change the server address on the Login Form.</b>

---

### Examination Software (StudentApp)
1. Install the application using the file ```Setup.exe``` or ```SetupStudentApp.msi```
2. After installing, click “PolyTest Student” on the desktop, and take a test with an account you've created inside the management application.

<b>If you are deploying the server on another machine, please change the server address on the Settings Form.</b>

---

### Exam Server (ExamServer)
1. Set up an external SQL Server with the included database (created by running [this sql file](resources/PolyTest_Database_8-4-2025.sql))
2. Extract the ExamServer from the archive
3. In the "appsettings.json" file, change these settings:
	- ```Jwt:Key``` -> Change this key for better security (must be at least 256 characters in length)
	- ```ConnectionStrings:ExamDatabase``` -> Put the connection string that points to the SQL Server with the database that you've set up before*.
4. Run "ExamServer.exe"
5. (Optional) Ensure port ```50051``` is forwarded (if you're hosting the server on another network)

<b>* Note: Both the Management and Exam server use the same database. Please ensure that the connection string is pointed to the same SQL Server and database.</b>

---

### Management Server (ManagementServer)
1. Set up an external SQL Server with the included database (created by running [this sql file](resources/PolyTest_Database_8-4-2025.sql))
2. Extract the ExamServer from the archive
3. In the ```appsettings.json``` file, change these settings:
	- ```Directory:ExamPapers``` -> Change this directory to point to the "ExamPapers" directory (inside the base directory of the Exam Server)
	- ```Jwt:Key``` -> Change this key for better security (must be at least 256 characters in length)
	- ```ConnectionStrings:ExamDatabase``` -> Put the connection string that points to the SQL Server with the database that you've set up before*.
4. Run "ManagementServer.exe"
5. (Optional) Ensure port ```50052``` is forwarded (if you're hosting the server on another network)

<b>* Note: Both the Management and Exam server use the same database. Please ensure that the connection string is pointed to the same SQL Server and database.</b>

---
