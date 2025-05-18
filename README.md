School Management System
Overview
This project is an ASP.NET Core Web API application for managing school data, including students, teachers, subjects, classes, schedules, and grades. The system uses JWT authentication for access control and manages different roles such as administrators and teachers.

Architecture
The project follows Clean Architecture principles and consists of the following layers:

SchoolManagementSystem.Domain: Contains core entities and domain models

SchoolManagementSystem.Application: Contains business logic and repository interfaces

SchoolManagementSystem.Infrastructure: Contains actual repository implementations and infrastructure services

SchoolManagementSystem: The presentation layer containing controllers and documentation

Requirements
.NET 9.0 or later

SQL Server (LocalDB can be used for development)

Visual Studio 2022

How to Run the Project
Clone the repository:

git clone https://github.com/BasheerMohammed5/SchoolManagementSystem.git  
cd SchoolManagementSystem  
Run migrations:

cd SchoolManagementSystem  
dotnet ef database update  
Run the application:

dotnet run  
Access Swagger UI:
Open your browser and navigate to: https://localhost:7097/swagger

Testing API Endpoints
You can test the API endpoints using:

The built-in Swagger UI

The Postman collection (included in the /docs/postman folder)

Key Endpoints
Authentication
POST /api/auth/register - Register a new user

POST /api/auth/login - Login and obtain a JWT token

GET /api/auth/profile - View current user information

Students
GET /api/students - Get a list of students

POST /api/students - Add a new student

PUT /api/students/{id} - Update a student's data

DELETE /api/students/{id} - Delete a student

Teachers
GET /api/teachers - Get a list of teachers

POST /api/teachers - Add a new teacher

PUT /api/teachers/{id} - Update a teacher's data

DELETE /api/teachers/{id} - Delete a teacher

Subjects
GET /api/subjects - Get a list of subjects

POST /api/subjects - Add a new subject

PUT /api/subjects/{id} - Update a subject's data

DELETE /api/subjects/{id} - Delete a subject

Classes
GET /api/classes - Get a list of classes

POST /api/classes - Add a new class

PUT /api/classes/{id} - Update a class's data

DELETE /api/classes/{id} - Delete a class

Schedules
GET /api/schedules - Get a list of schedules

POST /api/schedules - Add a new schedule

PUT /api/schedules/{id} - Update a schedule's data

DELETE /api/schedules/{id} - Delete a schedule

Grades
GET /api/grades - Get a list of grades

POST /api/grades - Add a new grade

PUT /api/grades/{id} - Update a grade's data

DELETE /api/grades/{id} - Delete a grade

Additional Features
JWT authentication with support for different roles (admin, teacher)

Comprehensive API documentation using Swagger

Implementation of SOLID principles and design patterns

Clean and maintainable code organization
