# Abp.Net.Scaffold
Abp.Net.Scaffold is a powerful and flexible tool designed to streamline the creation of feature-related files in ABP (ASP.NET Boilerplate) projects. This CLI tool automates the generation of domain entities, DTOs, and services following ABP conventions, enhancing developer productivity and ensuring consistency across the project.

## Features
- **Automated File Generation**: Quickly generate domain entities, DTOs, services, and configurations with a single command.
- **Namespace Management**: Automatically detects and uses the correct project namespaces.
Customizable Interface Types: Choose between different interface types (e.g., ApplicationService or Blank) during the generation process.
- **User-Friendly Prompts**: Easy-to-use dropdown prompts for selecting options.

## Installation
- **Add GitHub Package Source**: You can use your existing personal access token (with read-only permissions for packages) to add package source. Or you can create an access token (with read-only permissions for packages). Once you have setup your access token, open a terminal and execute the following command
```sh
dotnet nuget add source "https://nuget.pkg.github.com/arafat008/index.json" --name "githubabpnetscaffold" --username "<your github username>" --password "<your generatedaccesstoken >" --store-password-in-clear-text
```
This command will add the package source to your local machine.

- **Add GitHub Package Source**
To install the CLI tool globally, execute the following command
```sh
dotnet tool install -g Abp.Net.Scaffold
```
## Usage
After installation, you can use the CLI tool with the following command:
- Navigate to the backend project's root folder (in most cases, it will be aspnet-core).
- Run the following command:
```sh
scaffold --f <feature-name> --e <entity-name>
```

## Contributions
Contributions are welcome! Please fork the repository, create a new branch, and submit a pull request. Ensure your code follows the project's coding standards and includes appropriate tests.
