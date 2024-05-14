@echo off

rem Inicia a API em uma nova janela de terminal
start cmd /k "echo Running API ... && cd WebApi/CodeGenerator.API && dotnet run"

rem Aguarda um pouco para garantir que o servidor da API tenha tempo para iniciar antes de iniciar o frontend
timeout /t 5

rem Inicia o frontend em uma nova janela de terminal
start cmd /k "cd UI/CodeGenerator && if not exist node_modules (echo node_modules not found. Installing... && npm install) else (echo node_modules found. Skipping installation.) && echo Starting frontend... && npm start"
