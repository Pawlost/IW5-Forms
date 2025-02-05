# IW5 Project

## Overview
This project is a web-based application designed to create and manage online forms. The application includes functionality for creating forms, submitting responses, and managing users. It is built using Blazor WebAssembly for the front-end and Web API for the back-end. This application was created in a course during my university study. 

## Goal
The goal of this project was to create a usable and easily extensible web application for **online form management**.

## Features
- **Form Creation**: Users can create, edit, and delete forms.
- **Question Types**: The application supports multiple question types, including multiple choice, text input, and numeric input.
- **User Roles**: There are two main roles: Users (who can manage their own forms) and Administrators (who can manage all forms and users).
- **Search Functionality**: Users can search through questions, descriptions, and user names across the application.
- **Data Management**: Real-time data updates, with the ability to view, create, edit, and delete records.

## Technologies Used
- **Blazor WebAssembly**: For building the client front-end application.
- **.NET Core**: For building the Web API.
- **Azure**: For deployment and hosting.
- **Swagger and OpenApi**: For API documentation and testing.
- **EntityFramework Core**: For SQL server database connection.
- **Three-tiered architecture**: For project structure.
- **Duende identity server**: For user authentication and authorization.

## Setup

### Requirements
- .NET 8.0 or higher
- Visual Studio or Visual Studio Code
- Visual Studio environment for Web development
- Azure account for deployment
- Git

### Running the Application Locally

1. Clone the repository:
    ```bash
    git clone <repository-url>
    ```

2. Open the project in Visual Studio or your preferred IDE.

3. Run the application:
    - Build and run the Web API project.
    - Build and run Identity Server.
    - Run the Blazor WebAssembly project.

4. Access the application at `https://localhost:<port-number>`.

### Database
The application data are stored in persistent storage on SQL server and entities are managed using EntityFramework.

Database diagram:
***TO BE ADDED***

---

## Architecture
- **Web API**: Implements CRUD functionality and exposes an OpenAPI specification for integration with the front-end.
- **Blazor WebAssembly Front-End**: Displays data from the API and allows users to interact with the application.
- **Identity server**: Stores users data and issues JWT tokens.

The structure is organized as follows:
- `FormsIW5.Api.App`: Contains all API-related logic and endpoints.
- `FormsIW5.IdentityProvider.App`: Contains duende identity server and user management logic.
- `FormsIW5.Web.App`: Contains the Blazor WebAssembly application and user interface components.

---

## Deployment

The project is deployed to **Azure** for hosting the web application. Azure CI/CD pipelines were set up for automated deployment.

- The Blazor WebAssembly front-end is hosted on an Azure Web App.
- The Web API is deployed as an Azure Function.

CI/CD pipelines are written in yaml and stored in `/pipelines` folder.

Pipelines:
- Web CD: `web-release-pipelines.yml`
- API CD: `api-release-pipelines.yml`
- Identity server CD: `identity-pipeline.yml`
- CI: `test-pipelines.yml`

### Continuous Integration & Continuous Deployment (CI/CD)
The project uses Azure DevOps for continuous integration and deployment. Each commit triggers automated tests, builds, and deployments to the Azure environment.

---

## API Endpoints

The application exposes the following API endpoints:
***TO BE MODIFIED***

### Form Management

- `GET /forms`: Get a list of all forms.
- `GET /forms/{id}`: Get details of a specific form.
- `POST /forms`: Create a new form.
- `PUT /forms/{id}`: Edit an existing form.
- `DELETE /forms/{id}`: Delete a form.

### Question Management

- `GET /questions`: Get a list of all questions.
- `GET /questions/{id}`: Get details of a specific question.
- `POST /questions`: Create a new question.
- `PUT /questions/{id}`: Edit an existing question.
- `DELETE /questions/{id}`: Delete a question.

### Search

- `GET /search`: Perform a search across forms, questions, and users.

---

## User Roles

The application supports two main roles:

### User
- Can create, edit, and delete forms that they have created.
- Can fill out forms created by themselves or others.

### Administrator
- Can create, edit, and delete any form.
- Can manage users, including creating and deleting accounts.

---

## Testing

The project includes end-to-end tests for the Web API. The tests ensure that all API endpoints work as expected and that data is correctly processed.

### Running Tests
To run tests, use the following command in the root of the API project:
```bash
dotnet test
```