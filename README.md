# ASP Authentication API with JWT Tokens

## Overview
This project provides a set of APIs built using ASP.NET for handling authentication processes. These APIs are designed to incorporate JSON Web Tokens (JWT) for secure authentication and authorization within your application.

### Features
- User registration
- User login
- JWT token generation
- Token verification
- Password hashing for security

## Installation
1. Clone the repository: `git clone [repository_url]`
2. Navigate to the project directory: `cd project_directory`

## Dependencies
- ASP.NET Core
- Entity Framework Core
- JSON Web Tokens (JWT)
- Any additional packages as specified in the project's `packages.config` or `csproj` file

## Configuration
1. Set up your database connection string in `appsettings.json`.
2. Ensure that all necessary migrations are applied to your database schema.

## Usage
1. Run the ASP.NET application.
2. Access the APIs using appropriate endpoints for registration, login, token generation, etc.
3. Ensure proper authentication and authorization mechanisms within your application to utilize JWT tokens securely.

## Endpoints

### 1. User Registration
- Endpoint: `/api/register`
- Method: POST
- Parameters: 
  - Email
  - Password
  - First Name
  - Last Name

### 2. User Login
- Endpoint: `/api/login`
- Method: POST
- Parameters:
  - Email
  - Password
- Response: JWT token upon successful authentication


## Security
- Passwords are hashed before storing in the database using industry-standard hashing algorithms.
- JWT tokens are securely generated and verified to prevent tampering and unauthorized access.


## Acknowledgments
- ASP.NET Core community
- JSON Web Tokens (JWT) specification
- Entity Framework Core developers




