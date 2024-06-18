@echo off

rem API Run (Você pode adicionar comandos para iniciar sua API aqui)
start cmd /k "echo Running API ... && cd WebApi/CodeGenerator.API && dotnet run"

rem FRONT Run
start cmd /k "
cd UI/CodeGenerator
if not exist node_modules (
    echo node_modules not found. Installing...
    npm install
) else (
    echo node_modules found. Skipping installation.
)

if not exist dist (
    echo dist not found. building...
    npm run build
) else (
    echo dist found. Skipping build.
)

echo Starting frontend...
echo Access here on the browser: http://127.0.0.1:8080
npm run serve
"