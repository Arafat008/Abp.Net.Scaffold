# Abp.Net.Scaffold
Abp.Net.Scaffold is a powerful and flexible tool designed to streamline the creation of feature-related files in ABP (ASP.NET Boilerplate) projects. This CLI tool automates the generation of domain entities, DTOs, and services following ABP conventions, enhancing developer productivity and ensuring consistency across the project.

## Features
- **Automated File Generation**: Quickly generate domain entities, DTOs, services, and configurations with a single command.
- **Namespace Management**: Automatically detects and uses the correct project namespaces.
Customizable Interface Types: Choose between different interface types (e.g., ApplicationService or Blank) during the generation process.
- **User-Friendly Prompts**: Easy-to-use dropdown prompts for selecting options.

## Installation
To install the CLI tool globally:
```sh
dotnet tool install -g abp.net.scaffold
```
## Usage
After installation, you can use the CLI tool with the following command:
```sh
scaffold --f <feature-name> --e <entity-name>
```

## Contributions
Contributions are welcome! Please fork the repository, create a new branch, and submit a pull request. Ensure your code follows the project's coding standards and includes appropriate tests.
