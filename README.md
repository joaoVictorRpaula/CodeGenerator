# CodeGenerator

## Description
**Code Generator** is a project developed for the quick and easy creation of software templates from reading a SQL Server database.

## Project Structure
- **WebApi**: Contains the API developed in .NET.
- **UI/CodeGenerator**: Contains the frontend developed using the Angular framework - HTML, TypeScript, and SCSS.

## Technologies Used
- **Backend**: .NET
- **Frontend**: TypeScript, HTML, SCSS, Angular
- **Build Tools**: npm, dotnet CLI

## How to Run the Project

### Prerequisites
- Node.js and npm installed
- .NET SDK installed

### Execution Steps
1. Clone the repository:
    ```bash
    git clone https://github.com/joaoVictorRpaula/CodeGenerator
    cd CodeGenerator
    ```

2. Run the script to start the API and frontend:
    ```bash
    .\CodeGenerator.run.bat
    ```
3. Open http://127.0.0.1:8080/ on browser

### Manual Execution

#### Starting the API
1. Navigate to the API folder:
    ```bash
    cd WebApi/CodeGenerator.API
    ```
2. Run the API:
    ```bash
    dotnet run
    ```

#### Starting the Frontend
1. Navigate to the frontend folder:
    ```bash
    cd UI/CodeGenerator
    ```
2. Install the dependencies:
    ```bash
    npm install
    ```
3. Build the project:
    ```bash
    npm run build
    ```
4. Start the frontend:
    ```bash
    npm run serve
    ```

---

## Creating a New Template

To create a new template in **Code Generator**, follow the steps below:

### Locating the Templates Folder

Within the project structure, navigate to `C:\Projects\CodeGenerator\WebApi\CodeGenerator.INFRA\Templates`.

### Ready-to-Use Design Pattern

Currently, there exists an API pattern called `controller-service-repository` ready for use. This pattern serves as an example and base for new templates.

### Template Structure

1. **Main File Implementing IFolderService**:
   - Each template must have a main file that implements the `IFolderService` interface. This file defines the entire folder and file structure of the template based on the `Folder` object. Refer to the existing example for guidance.

2. **"Templates" Folder with BLAZOR .cshtml Files**:
   - Every project pattern includes a "Templates" folder containing BLAZOR `.cshtml` files. These files act as templates that generate the final files based on the database tables and columns.

---

## Contribution

Feel free to contribute to this project. To do so:

1. Fork the project.
2. Create a new branch (`git checkout -b feature/new-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature/new-feature`).
5. Open a Pull Request.

---

## Contact

João Victor Ribeiro de Paula 
- [LinkedIn](www.linkedin.com/in/joão-victor-ribeiro-de-paula-2a495a217)
- [GitHub](https://github.com/joaoVictorRpaula)
