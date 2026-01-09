# TaskManagement # Task Management System

## 2.1.3.1 Overview of what is being built

This project is a **Task Management System** built using **ASP.NET Core MVC**.
The application allows users to create, update, delete, search, and paginate tasks.
It demonstrates clean architecture, database design, and proper documentation practices.

The goal of this project is to showcase:
- Backend development skills
- Database design understanding
- MVC architecture
- Search, pagination, and CRUD operations
- Production-ready code structure

---

## 2.1.3.2 Explanation of DB Design

The database is designed to store task-related information efficiently.
Each task represents a unit of work with metadata such as status, due date, and audit fields.

### 2.1.3.2.1 ER Diagram

**Entities:**
- Task

**Relationships:**
- Single table design (Task entity)

- Task

TaskId (PK)
TaskTitle
TaskDescription
TaskStatus
TaskDueDate
TaskRemarks
CreatedOn
LastUpdatedOn
CreatedById
CreatedByName
UpdatedById
UpdatedByName


---

### 2.1.3.2.2 Data Dictionary

| Column Name       | Data Type        | Description |
|------------------|------------------|-------------|
| TaskId           | INT (PK)         | Unique identifier of task |
| TaskTitle        | VARCHAR(200)     | Title of the task |
| TaskDescription  | VARCHAR(MAX)     | Detailed description |
| TaskStatus       | VARCHAR(50)      | Status (Open, InProgress, Closed) |
| TaskDueDate      | DATETIME         | Due date of task |
| TaskRemarks      | VARCHAR(500)     | Additional remarks |
| CreatedOn        | DATETIME         | Task creation timestamp |
| LastUpdatedOn    | DATETIME         | Last update timestamp |
| CreatedById      | INT              | Creator user ID |
| CreatedByName    | VARCHAR(100)     | Creator name |
| UpdatedById      | INT              | Last updater ID |
| UpdatedByName    | VARCHAR(100)     | Last updater name |

---

### 2.1.3.2.3 Documentation of Indexes Used

Indexes have been created to improve query performance:

- **Primary Key Index** on `TaskId`
- **Non-Clustered Index** on:
  - `TaskTitle`
  - `TaskStatus`
  - `CreatedOn`

These indexes improve search and pagination performance.

---

### 2.1.3.2.4 Code First or DB First Approach

**Approach Used:**  
✅ **DB First Approach**

**Reason:**
- Better control over database schema
- Suitable for enterprise-level applications
- Easy integration with stored procedures
- Clear separation between DB and application logic

---

## 2.1.3.3 Structure of the Application

The project follows a **layered architecture**.

### 2.1.3.3.1 Backend Structure



Solution
│
├── ModelLayer
│ └── TaskModel.cs
│
├── Repository
│ └── TaskRepository.cs
│
├── DataLayer
│ └── Dapper / SQL Access
│
├── Web (ASP.NET Core MVC)
│ ├── Controllers
│ ├── Views
│ └── wwwroot

### 2.1.3.3.2 MVC / SPA Approach

✅ **Standard MVC (Server Side Rendering)** is used.

**Reason:**
- Simple and maintainable
- Faster development
- SEO-friendly
- No additional frontend framework dependency

---

## 2.1.3.4 Frontend Structure

### 2.1.3.4.1 Frontend Technology Used

- Razor Views (ASP.NET Core MVC)
- Bootstrap 5
- HTML5 / CSS3

### 2.1.3.4.2 Why this Frontend?

- Clean UI
- Responsive design
- Easy integration with MVC
- No learning curve for reviewers

---

## 2.1.3.5 Build and Install

### 2.1.3.5.1 Environment Details

- .NET SDK: **.NET 9**
- Database: **SQL Server**
- ORM: **Dapper**
- IDE: **Visual Studio 2022**
- OS: Windows
