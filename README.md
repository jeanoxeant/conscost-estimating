# conscost-estimating

# Favorite Quote

"The Lord loves effort." — Russell M. Nelson (Gabriel Enrique)

“If we don’t try, then we don’t do; and if we don’t do, then why are we here?” -- President Monson (Jean Oxeant)

"When the focus of our lives is on Jesus Christ and His gospel, we can feel joy regardless of what is happening - or not happening - in our lives" -- Russell M. Nelson (Kevin Espinoza)

"It is not possible for you to sink lower than the infinite light of Christ's Atonement shines" -Jeffrey R.Holland (Joshua Mostert)

# Construction Cost Estimator

A web-based construction cost estimating application built using **Blazor Web App**, **ASP.NET Core**, **Entity Framework Core**, **SQLite**, and **ASP.NET Core Identity**.

---

# Prerequisites

Before running this project, make sure you have the following installed:

- .NET SDK 8.0 or later
- Visual Studio 2022 (recommended) or Visual Studio Code
- Git

Check your .NET version:

```bash
dotnet --version
```

---

# Getting Started

## 1. Clone the Repository

Clone the repository from GitHub:

```bash
git clone <repository-url>
```

Navigate into the project directory:

```bash
cd ConstructionCostEstimator
```

---

## 2. Restore Project Dependencies

Restore all required NuGet packages:

```bash
dotnet restore
```

---

## 3. Install Entity Framework Core Tools

Install the EF Core command-line tools if you do not already have them:

```bash
dotnet tool install --global dotnet-ef
```

If they are already installed, update them:

```bash
dotnet tool update --global dotnet-ef
```

Check that EF Core tools are installed:

```bash
dotnet ef --version
```

---

# Database Setup

This project uses **Entity Framework Core with SQLite** as the database provider.

## Apply Database Migrations

After cloning the project, create/update the database by running:

```bash
dotnet ef database update
```

This will automatically create the SQLite database and apply all existing migrations.

The database file will be created as:

```
app.db
```

The database connection can be found in:

```
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}
```

---

# Running the Application

Start the application using:

```bash
dotnet run
```

The terminal will display a local URL:

Example:

```
https://localhost:xxxx
```

Open the URL in your browser.

---

# User Authentication

This application uses **ASP.NET Core Identity** for authentication.

Included features:

- User registration
- User login
- User logout
- Secure password storage
- Authentication management

New users can register directly through the application.

---

# Creating Database Migrations

Whenever database models are changed, a new migration must be created.

## Step 1: Make changes to your models

Example:

```
Models/ConstructionProject.cs
```

## Step 2: Create a migration

Run:

```bash
dotnet ef migrations add MigrationName
```

Example:

```bash
dotnet ef migrations add AddProjectTable
```

## Step 3: Apply the migration

Run:

```bash
dotnet ef database update
```

---

# Project Structure

```
ConstructionCostEstimator
│
├── Components
│   ├── Pages
│   ├── Layout
│   └── Shared
│
├── Data
│   ├── ApplicationDbContext.cs
│   └── Migrations
│
├── Models
│   ├── UserProfile.cs
│   ├── Project.cs
│   ├── Material.cs
│   ├── Labor.cs
│   ├── Equipment.cs
│   └── Estimate.cs
│
├── Services
│
├── wwwroot
│
├── appsettings.json
├── Program.cs
└── README.md
```

---

# Git Workflow

Before starting work, always pull the latest changes:

```bash
git pull
```

Create a new branch for your feature:

```bash
git checkout -b feature-name
```

Example:

```bash
git checkout -b add-project-management
```

After completing your work:

```bash
git add .
git commit -m "Describe your changes"
git push origin feature-name
```

Create a Pull Request on GitHub for review before merging.

---

# Troubleshooting

## Database Issues

If the database becomes corrupted or migrations fail:

Delete:

```
app.db
```

Then recreate the database:

```bash
dotnet ef database update
```

---

## Package Errors

Restore packages:

```bash
dotnet restore
```

Rebuild the project:

```bash
dotnet build
```

---

## HTTPS Certificate Problems

If you receive HTTPS certificate errors, run:

```bash
dotnet dev-certs https --trust
```

---

# Technologies Used

- Blazor Web App
- ASP.NET Core
- Entity Framework Core
- SQLite Database
- ASP.NET Core Identity
- C#
- .NET 8