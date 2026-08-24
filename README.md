# Library Management System

A RESTful Library Management System built using ASP.NET Core Web API, Entity Framework Core, SQL Server, and ASP.NET Core Identity.

The system provides book and member management, borrowing and returning operations, authentication and role-based authorization, book cover image upload, and user activity logging.

---

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Swagger / OpenAPI
- C#
- LINQ
- RESTful APIs

---

**Main Layers**

- **Controllers:** Handle HTTP requests and responses.
- **Services:** Contain business logic and database operations.
- **DTOs:** Define request and response models.
- **Models:** Contain database entities and enums.
- **Data:** Contains `ApplicationDbContext` and Entity Framework Core configuration.

---

## Main Features

### 1. Authentication

The system uses ASP.NET Core Identity with JWT authentication.

Users can log in and receive a JWT token that is used to access protected API endpoints. Passwords are securely stored using ASP.NET Core Identity password hashing.

### 2. Role-Based Authorization

The system supports three roles:

- Administrator
- Librarian
- Staff

Different operations are restricted according to the user's role.

| Operation                | Administrator | Librarian | Staff |
|---------------------------|:--------------:|:----------:|:------:|
| View Books                | Yes            | Yes        | Yes    |
| Create / Update Books     | Yes            | Yes        | No     |
| Delete Books               | Yes            | Yes        | No     |
| View Members               | Yes            | Yes        | Yes    |
| Create / Update Members    | Yes            | Yes        | Yes    |
| Borrow Books                | Yes            | Yes        | Yes    |
| Return Books                | Yes            | Yes        | Yes    |
| Manage Users                | Yes            | No         | No     |
| View Activity Logs          | Yes            | No         | No     |

### 3. Book Management

The system supports:

- Create book
- Get all books
- Get book by ID
- Update book
- Delete book
- Search books
- Filter books by status

Each book contains extended metadata including:

- Title
- ISBN
- Edition
- Summary
- Language
- Publication Year
- Category
- Publisher
- Authors
- Status
- Cover Image

### 4. Multiple Authors

A book can have multiple authors. This is implemented using a many-to-many relationship through the `BookAuthors` junction table:

```
Book ── BookAuthor ── Author
```

### 5. Book Cover Image Upload

Book cover images can be uploaded through the API. Uploaded images are:

- Validated by file type and size.
- Stored in `wwwroot/uploads/books`.
- Saved using a unique file name.
- Stored as a file name in the database.
- Returned to the client as a full URL.

### 6. Members

The system supports member management including:

- Create member
- Get all members
- Get member by ID
- Update member
- Deactivate / Delete member

### 7. Borrowing and Returning

The system supports book borrowing and returning.

**When a book is borrowed:**
- A borrowing transaction is created.
- The book status changes to `Borrowed`.
- The borrowing user is recorded.
- The due date is stored.

**When a book is returned:**
- The return date is recorded.
- The user who returned the book is recorded.
- The borrowing status changes to `Returned`.
- The book becomes `Available`.

The system prevents invalid operations such as borrowing a book that is already borrowed.

### 8. Book Search

The API supports searching books using:

- Book name
- Author
- Category

```http
GET /api/Books/search?name=Clean
GET /api/Books/search?authorId=1
GET /api/Books/search?categoryId=1
```

Multiple filters can also be used together:

```http
GET /api/Books/search?name=Clean&authorId=1&categoryId=1
```

### 9. Books by Status

Books can be retrieved based on their current status.

Available statuses:

- Available
- Borrowed

```http
GET /api/Books/status/1   # Get available books
GET /api/Books/status/2   # Get borrowed books
```

### 10. User Activity Logging

Important user actions are recorded in the `UserActivityLogs` table.

Logged information includes:

- User
- Action
- Entity Name
- Entity ID
- Timestamp
- IP Address

Examples of logged actions: `Login`, `Logout`, `Borrow Book`, `Return Book`.

Activity logs can be viewed by Administrators.

---

## Database Design

The database is implemented using SQL Server and Entity Framework Core Code First.

Main application entities include:

- Books
- Authors
- BookAuthors
- Categories
- Publishers
- Members
- Borrowings
- UserActivityLogs
- Application Users and Identity tables

---

### Sample API Endpoints

**Authentication**
```
POST /api/Auth/login
POST /api/Auth/logout
```

**Books**
```
GET    /api/Books
GET    /api/Books/{id}
POST   /api/Books
PUT    /api/Books/{id}
DELETE /api/Books/{id}
GET    /api/Books/search
GET    /api/Books/status/{status}
```

**Members**
```
GET    /api/Members
GET    /api/Members/{id}
POST   /api/Members
PUT    /api/Members/{id}
DELETE /api/Members/{id}
```

**Borrowing**
```
POST /api/Borrowings/borrow
POST /api/Borrowings/{id}/return
```

**Activity Logs**
```
GET /api/UserActivityLogs
```

---

## Roles

The application supports the following roles:

- Administrator
- Librarian
- Staff

Users must be assigned the appropriate role before accessing protected endpoints.

---

## Design Decisions

**Entity Framework Core**
Used for database access and entity relationship management.

**DTOs**
Used to separate API request and response models from database entities and to control the data exposed through the API.

**Service Layer**
Business logic is kept inside services instead of placing it directly inside controllers. This keeps controllers focused on handling HTTP requests and responses.

**ASP.NET Core Identity**
Used for user management, password hashing, and role management.

**JWT Authentication**
Used to secure RESTful API endpoints.

**Activity Logging**
Important user actions are recorded for auditing purposes and can be reviewed by Administrators.

**File Storage**
Book cover images are stored in the application's `wwwroot/uploads/books` directory, while only the generated file name is stored in the database.

---

## Security

The application includes:

- JWT-based authentication.
- Role-based authorization.
- Secure password hashing using ASP.NET Core Identity.
- Unique email validation for system users.
- Protected API endpoints.
- File type and size validation for book cover images.
- User activity logging.

---

**Marwa Ahmed**
Full Stack Developer
