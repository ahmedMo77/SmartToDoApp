# 🧠 Smart To-Do Console App

A powerful and lightweight console-based To-Do List application built with **.NET Core** and **Entity Framework Core**. Manage your tasks, assign tags and habits, track completion, and build better routines — all from the command line.

---

## 🚀 Features

- Create tasks with a title, description, due date, and priority (Low, Medium, High)
- Mark tasks as completed
- Assign tags to tasks (many-to-many)
- Link habits to tasks (many-to-many)
- View all tasks with related tags and habits
- Automatic tracking of task creation using shadow properties
- Smart EF Core integrations:
  - Fluent API configurations
  - Enum conversion for priorities
  - Shadow properties like `CreatedAt`
  - Change tracking & soft deletion (`IsDeleted`)
  - Seeding sample data (Tags, Habits, Users)
  - Strong input validation

---

## Tech Stack
- **.NET Core 8.0**
- **Entity Framework Core**
- **C#**
- **SQL Server**
