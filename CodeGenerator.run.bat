@echo off

rem API Run
start cmd /k "echo Running API ... && cd WebApi/CodeGenerator.API && dotnet run"

rem FRONT Run
start cmd /k "cd UI/CodeGenerator && if not exist node_modules (echo node_modules not found. Installing... && npm install) else (echo node_modules found. Skipping installation.) && echo Starting frontend... && npm start"
