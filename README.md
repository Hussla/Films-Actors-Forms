# Films and Actors Application

A comprehensive C# Windows Forms application for managing film and actor data with advanced features for data persistence, search functionality, and user-friendly interface design.


Author: Haleem Hussaim
GitHub - [Hussla](https://github.com/Hussla/FilmsAndActors-App)

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Project Structure](#project-structure)
- [System Requirements](#system-requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Architecture](#architecture)
- [Data Management](#data-management)
- [Testing](#testing)
- [Development](#development)
- [Documentation](#documentation)
- [Contributing](#contributing)
- [Version History](#version-history)
- [Support](#support)

## Overview

The Films and Actors Application is a desktop application built using C# and Windows Forms that provides comprehensive management capabilities for film and actor databases. The application features a clean, intuitive interface for adding, editing, searching, and managing film and actor information with robust data persistence and validation.

### Key Capabilities

- **Film Management**: Complete film database with metadata including title, year, duration, genre, rating, and cast information
- **Actor Management**: Comprehensive actor profiles with biographical information, filmography, and career details
- **Data Persistence**: JSON-based data storage with automatic backup and recovery capabilities
- **Search Functionality**: Advanced search and filtering options across all data fields
- **User Interface**: Modern Windows Forms interface with accessibility features and keyboard navigation
- **Data Validation**: Comprehensive input validation and error handling throughout the application
- **Testing Suite**: Complete unit testing coverage using NUnit framework

## Features

### Core Functionality

- **Film Database Management**
  - Add, edit, and delete film records
  - Comprehensive film metadata storage
  - Cast and crew information management
  - Genre categorisation and rating systems
  - Release year and duration tracking

- **Actor Database Management**
  - Complete actor profile management
  - Biographical information storage
  - Filmography tracking and management
  - Career timeline and awards information
  - Age calculation and birth date management

- **Data Operations**
  - JSON-based data persistence
  - Automatic data backup and recovery
  - Import and export capabilities
  - Data integrity validation
  - Error handling and recovery

- **User Interface Features**
  - Intuitive Windows Forms interface
  - Keyboard navigation support
  - Accessibility compliance
  - Responsive layout design
  - Context-sensitive help and tooltips

- **Search and Filtering**
  - Advanced search across all data fields
  - Multiple filter criteria support
  - Real-time search results
  - Sorting and ordering options
  - Search history and saved searches

## Project Structure

```
FilmsAndActors-App/
├── FilmsAndActors-App.sln              # Visual Studio solution file
├── README.md                           # Project documentation
├── .gitignore                          # Git version control exclusions
├── .gitattributes                      # Git configuration settings
│
├── FilmAndActorsClasses/               # Business logic and data models
│   ├── FilmAndActorsClasses.csproj     # Class library project file
│   ├── Film.cs                         # Film entity class
│   ├── Actor.cs                        # Actor entity class
│   ├── DataManager.cs                  # Data persistence management
│   ├── bin/                            # Compiled binary output
│   └── obj/                            # Build intermediate files
│
├── FilmsAndActors-App/                 # Windows Forms application
│   ├── FilmsAndActors-App.csproj       # Application project file
│   ├── Program.cs                      # Application entry point
│   ├── Form1.cs                        # Main application form
│   ├── Form1.Designer.cs               # Form designer code
│   ├── Form1.resx                      # Form resources
│   ├── bin/                            # Application binary output
│   └── obj/                            # Build intermediate files
│
├── TestProject1/                       # Unit testing project
│   ├── TestProject1.csproj             # Test project file
│   ├── UnitTest1.cs                    # Unit test implementations
│   ├── bin/                            # Test binary output
│   └── obj/                            # Test build files
│
└── docs/                               # Project documentation
    ├── reference.md                    # Code reference documentation
    └── walkthrough.md                  # Application walkthrough guide
```

### Project Components

#### FilmAndActorsClasses Library
**Purpose**: Core business logic and data model implementation
- **Film.cs**: Complete film entity with properties, validation, and business methods
- **Actor.cs**: Comprehensive actor entity with biographical and career information
- **DataManager.cs**: Data persistence, file operations, and JSON serialisation management

#### FilmsAndActors-App Application
**Purpose**: Windows Forms user interface and application logic
- **Program.cs**: Application entry point and configuration
- **Form1.cs**: Main application form with user interface logic and event handling
- **Form1.Designer.cs**: Auto-generated form layout and control configuration
- **Form1.resx**: Form resources including images and localisation data

#### TestProject1 Testing Suite
**Purpose**: Comprehensive unit testing for all application components
- **UnitTest1.cs**: Complete test coverage for Film, Actor, and DataManager classes
- **Test Configuration**: NUnit framework with assertion methods and test patterns

#### Documentation
**Purpose**: Comprehensive project documentation and reference materials
- **reference.md**: Complete code reference with Microsoft documentation links
- **walkthrough.md**: Step-by-step application usage guide

## System Requirements

### Minimum Requirements
- **Operating System**: Windows 10 or later
- **Framework**: .NET 8.0 or later
- **Memory**: 512 MB RAM minimum
- **Storage**: 100 MB available disk space
- **Display**: 1024x768 resolution minimum

### Recommended Requirements
- **Operating System**: Windows 11
- **Framework**: .NET 8.0 latest version
- **Memory**: 2 GB RAM or more
- **Storage**: 500 MB available disk space
- **Display**: 1920x1080 resolution or higher

### Development Requirements
- **Visual Studio**: Visual Studio 2022 or later
- **SDK**: .NET 8.0 SDK
- **Testing**: NUnit framework support
- **Version Control**: Git for source control

## Installation

### Prerequisites
1. Install .NET 8.0 Runtime or SDK from [Microsoft .NET Downloads](https://dotnet.microsoft.com/download)
2. Ensure Windows Forms support is installed with .NET

### Installation Steps

#### Option 1: Download Release
1. Download the latest release from the [Releases](https://github.com/Hussla/FilmsAndActors-App/releases) page
2. Extract the archive to your desired location
3. Run `FilmsAndActors-App.exe` to start the application

#### Option 2: Build from Source
1. Clone the repository:
   ```bash
   git clone https://github.com/Hussla/FilmsAndActors-App.git
   ```
2. Navigate to the project directory:
   ```bash
   cd FilmsAndActors-App
   ```
3. Build the solution:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run --project FilmsAndActors-App
   ```

### Development Setup
1. Clone the repository as above
2. Open `FilmsAndActors-App.sln` in Visual Studio
3. Restore NuGet packages if prompted
4. Build the solution (Ctrl+Shift+B)
5. Run the application (F5) or run tests (Ctrl+R, A)

## Usage

### Getting Started
1. Launch the application by running `FilmsAndActors-App.exe`
2. The main interface will display with options for managing films and actors
3. Use the navigation buttons to switch between film and actor management modes
4. Data is automatically saved to JSON files in the application directory

### Managing Films
1. **Adding Films**: Click "Add Film" and complete all required fields
2. **Editing Films**: Select a film from the list and click "Edit"
3. **Deleting Films**: Select a film and click "Delete" (confirmation required)
4. **Searching Films**: Use the search box to filter films by title, genre, or year

### Managing Actors
1. **Adding Actors**: Click "Add Actor" and provide biographical information
2. **Editing Actors**: Select an actor and click "Edit" to modify details
3. **Deleting Actors**: Select an actor and click "Delete" (confirmation required)
4. **Searching Actors**: Filter actors by name, nationality, or birth year

### Data Operations
- **Automatic Saving**: All changes are automatically saved to JSON files
- **Data Backup**: The application creates backup files before major operations
- **Data Recovery**: Automatic recovery from backup files if corruption is detected
- **Export Data**: Export film and actor data to JSON format for external use

## Architecture

### Design Patterns
- **Model-View Pattern**: Clear separation between data models and user interface
- **Repository Pattern**: Centralised data access through DataManager class
- **Single Responsibility Principle**: Each class has a focused, single purpose
- **Dependency Inversion**: Interface-based design for testability and maintainability

### Class Structure
- **Film Class**: Encapsulates all film-related data and business logic
- **Actor Class**: Manages actor information and career-related functionality
- **DataManager Class**: Handles all data persistence and file operations
- **Form1 Class**: Manages user interface interactions and event handling

### Data Flow
1. User interactions trigger events in Form1
2. Form1 validates input and calls appropriate business logic methods
3. Business logic classes (Film/Actor) process the data
4. DataManager handles persistence operations
5. Results are returned to Form1 for user feedback

## Data Management

### Data Storage
- **Format**: JSON serialisation for human-readable data files
- **Location**: Application directory with automatic directory creation
- **Backup**: Automatic backup creation before data modifications
- **Validation**: Comprehensive data integrity checking on load and save

### File Structure
```
Application Directory/
├── films.json          # Film database
├── actors.json         # Actor database
├── films.backup.json   # Film backup
└── actors.backup.json  # Actor backup
```

### Data Validation
- **Input Validation**: Real-time validation during data entry
- **Business Rules**: Enforcement of business logic constraints
- **Data Integrity**: Automatic checking for data consistency
- **Error Recovery**: Graceful handling of data corruption scenarios

## Testing

### Test Coverage
The application includes comprehensive unit testing covering:
- **Film Class**: All properties, methods, and validation logic
- **Actor Class**: Complete functionality including age calculations
- **DataManager Class**: File operations, serialisation, and error handling
- **Integration Tests**: End-to-end testing of complete workflows

### Running Tests
```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal

# Run specific test class
dotnet test --filter "TestClass=UnitTest1"
```

### Test Framework
- **Framework**: NUnit 3.x
- **Assertions**: Comprehensive assertion methods for all test scenarios
- **Test Patterns**: Arrange-Act-Assert pattern for clear test structure
- **Coverage**: Aim for 90%+ code coverage across all business logic

## Development

### Coding Standards
- **Language**: C# following Microsoft coding conventions
- **Naming**: PascalCase for public members, camelCase for private fields
- **Documentation**: XML documentation comments for all public APIs
- **Validation**: Comprehensive input validation and error handling
- **Comments**: Clear, descriptive comments explaining business logic

### Build Process
1. **Compilation**: MSBuild compilation with error checking
2. **Testing**: Automated test execution during build
3. **Packaging**: Automatic creation of deployment packages
4. **Documentation**: Generation of API documentation from XML comments

### Version Control
- **Repository**: Git with GitHub hosting
- **Branching**: Feature branches with pull request workflow
- **Commits**: Descriptive commit messages following conventional format
- **Releases**: Tagged releases with semantic versioning

## Documentation

### Available Documentation
- **README.md**: This comprehensive project overview
- **reference.md**: Complete code reference with Microsoft documentation links
- **walkthrough.md**: Step-by-step user guide and tutorials

### Documentation Standards
- **Format**: Markdown for all documentation files
- **Structure**: Clear headings and table of contents
- **Links**: References to official Microsoft documentation
- **Updates**: Regular updates to maintain accuracy and relevance

## Contributing

### Development Process
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/new-feature`)
3. Make changes following coding standards
4. Add or update tests for new functionality
5. Update documentation as needed
6. Commit changes with descriptive messages
7. Push to your fork and create a pull request

### Code Review Process
- All changes require code review before merging
- Tests must pass and coverage must be maintained
- Documentation must be updated for new features
- Code must follow established coding standards

### Issue Reporting
- Use GitHub Issues for bug reports and feature requests
- Provide detailed reproduction steps for bugs
- Include system information and error messages
- Follow the issue template for consistency

## Version History

### Version 1.0.0 (Current)
- Initial release with core functionality
- Film and actor management capabilities
- JSON data persistence
- Windows Forms user interface
- Comprehensive unit testing
- Complete documentation suite

### Planned Features
- Database integration options
- Advanced reporting capabilities
- Image management for actors and films
- Export to multiple formats
- Enhanced search and filtering
- User preferences and customisation

## Support

### Getting Help
- **Documentation**: Check the docs/ directory for comprehensive guides
- **Issues**: Report bugs or request features via GitHub Issues
- **Discussions**: Use GitHub Discussions for questions and community support

### Contact Information
- **Repository**: [https://github.com/Hussla/FilmsAndActors-App](https://github.com/Hussla/FilmsAndActors-App)
- **Issues**: [https://github.com/Hussla/FilmsAndActors-App/issues](https://github.com/Hussla/FilmsAndActors-App/issues)
- **Discussions**: [https://github.com/Hussla/FilmsAndActors-App/discussions](https://github.com/Hussla/FilmsAndActors-App/discussions)

### Troubleshooting
- **Application Won't Start**: Ensure .NET 8.0 runtime is installed
- **Data Not Saving**: Check file permissions in application directory
- **Performance Issues**: Verify system meets minimum requirements
- **Test Failures**: Ensure NUnit packages are properly restored

---

