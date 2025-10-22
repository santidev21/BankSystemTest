# BankSystem - Fullstack App (.NET 8 + Angular 12 + Docker)

A simple fullstack banking app with **.NET 8 backend** and **Angular 12 frontend**, fully containerized with **Docker Compose**.

---

## Requirements

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/downloads)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) running on Windows
  - Make sure TCP/IP protocol is enabled in SQL Server Configuration Manager

> No need to install .NET SDK or Node.js locally.

---

## Database Setup

Before running the app, you must create the database and seed initial data:

1. Open SQL Server Management Studio (SSMS)
2. Connect to your local SQL Server instance
3. Open the file `Database/BaseDatos.sql`
4. Execute the script to create the database, tables, and seed data

> This step ensures the backend can connect to a ready-to-use database.

---

## Getting Started

1. **Clone the repo**
```bash
git clone https://github.com/yourusername/BankSystem.git
cd BankSystem
Build and run containers
```

2. **Build and run containers**
```bash
Copiar código
docker compose up --build
Open the apps
```

3. **Open the apps**
- Frontend: http://localhost:4200
- Backend Swagger: http://localhost:7114/swagger