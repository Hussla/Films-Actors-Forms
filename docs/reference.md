# Reference Documentation - Films and Actors Application

## Overview

This document provides comprehensive references for all code used throughout the Films and Actors C# Windows Forms application project. It includes links to official Microsoft documentation for all technologies, frameworks, classes, and methods implemented in the codebase.

## Project Structure and Technologies

### Core Technologies Used
- **C# Programming Language**: [Microsoft C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- **.NET 8.0 Framework**: [.NET 8 Documentation](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- **Windows Forms**: [Windows Forms Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- **NUnit Testing Framework**: [NUnit Documentation](https://docs.nunit.org/)
- **JSON Serialisation**: [System.Text.Json Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.text.json)

## FilmAndActorsClasses Project References

### Film Class Implementation
**File**: `FilmAndActorsClasses/Film.cs`
**Purpose**: Core business entity representing film data

#### Properties and Related Documentation
- **Private Fields with Underscore Prefix**: [C# Naming Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- **Public Properties with Validation**: [C# Properties](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)
- **List<T> Collections**: [List<T> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)
- **String Validation**: [String Class](https://docs.microsoft.com/en-us/dotnet/api/system.string)

#### Methods and Related Documentation
- **Constructor Overloading**: [C# Constructors](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors)
- **Parameter Validation**: [ArgumentException Class](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)
- **Collection Operations**: [Collection Classes](https://docs.microsoft.com/en-us/dotnet/standard/collections/)
- **LINQ Operations**: [LINQ Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- **Mathematical Operations**: [Math Class](https://docs.microsoft.com/en-us/dotnet/api/system.math)
- **String Formatting**: [String Interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated)

#### Specific Method References
- `AddActorToFilm()`: [List<T>.Add Method](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add)
- `AddAudienceRating()`: [Input Validation Patterns](https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format)
- `CalculateAverageRating()`: [Enumerable.Average Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.average)
- `SearchForActorByName()`: [String.Equals Method](https://docs.microsoft.com/en-us/dotnet/api/system.string.equals)
- `DisplayFilmInformation()`: [Console.WriteLine Method](https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline)

### Actor Class Implementation
**File**: `FilmAndActorsClasses/Actor.cs`
**Purpose**: Core business entity representing actor data

#### Properties and Related Documentation
- **DateTime Handling**: [DateTime Structure](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)
- **Age Calculations**: [DateTime.Now Property](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.now)
- **Collection Initialisation**: [Collection Initializers](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers)

#### Methods and Related Documentation
- `CalculateCurrentAge()`: [DateTime Arithmetic](https://docs.microsoft.com/en-us/dotnet/standard/datetime/performing-arithmetic-operations)
- `CalculateBirthDateFromAge()`: [DateTime.AddYears Method](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addyears)
- `AddFilmToFilmography()`: [List<T>.Contains Method](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains)
- `SearchForFilmByTitle()`: [String Comparison](https://docs.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings)
- `ValidateActorData()`: [Data Validation Patterns](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions)

### DataManager Class Implementation
**File**: `FilmAndActorsClasses/DataManager.cs`
**Purpose**: Data persistence and file operations management

#### File I/O Operations
- **File Operations**: [File Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.file)
- **Directory Operations**: [Directory Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory)
- **Path Operations**: [Path Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.path)
- **Stream Operations**: [FileStream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream)

#### JSON Serialisation
- **JsonSerializer Class**: [JsonSerializer Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer)
- **JsonSerializerOptions**: [JsonSerializerOptions Class](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions)
- **JSON Naming Policies**: [JsonNamingPolicy Class](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonnamingnpolicy)

#### Error Handling
- **Exception Handling**: [Exception Handling](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)
- **Specific Exceptions**: 
  - [UnauthorizedAccessException](https://docs.microsoft.com/en-us/dotnet/api/system.unauthorizedaccessexception)
  - [DirectoryNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/system.io.directorynotfoundexception)
  - [JsonException](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonexception)
  - [FileNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/system.io.filenotfoundexception)

#### Environment and Path Management
- **Environment.GetFolderPath**: [Environment.SpecialFolder](https://docs.microsoft.com/en-us/dotnet/api/system.environment.specialfolder)
- **Path.Combine**: [Path.Combine Method](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.combine)

## FilmsAndActors-App Project References

### Form1 Class Implementation
**File**: `FilmsAndActors-App/Form1.cs`
**Purpose**: Main Windows Forms user interface

#### Windows Forms Controls
- **Form Class**: [Form Class Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form)
- **Button Control**: [Button Class](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.button)
- **TextBox Control**: [TextBox Class](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.textbox)
- **ListBox Control**: [ListBox Class](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listbox)
- **PictureBox Control**: [PictureBox Class](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.picturebox)
- **MessageBox Class**: [MessageBox Class](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox)

#### Event Handling
- **Event Handling**: [Events and Delegates](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/)
- **EventArgs Class**: [EventArgs Class](https://docs.microsoft.com/en-us/dotnet/api/system.eventargs)
- **FormClosingEventArgs**: [FormClosingEventArgs Class](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.formclosingeventargs)

#### User Interface Configuration
- **Form Properties**: [Form Properties](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/form-properties)
- **Control Layout**: [Control Layout](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/layout)
- **Tab Order**: [Tab Order](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-set-the-tab-order-on-windows-forms)
- **Access Keys**: [Access Keys](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-create-access-keys-for-windows-forms-controls)

#### Data Validation and Input Handling
- **Input Validation**: [Validating User Input](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/user-input/user-input-validation-in-windows-forms)
- **String Operations**: [String Methods](https://docs.microsoft.com/en-us/dotnet/api/system.string)
- **Int32.TryParse**: [Int32.TryParse Method](https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse)
- **StringComparison Enumeration**: [StringComparison Enum](https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison)

#### LINQ Operations
- **LINQ Any Method**: [Enumerable.Any Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any)
- **LINQ Select Method**: [Enumerable.Select Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select)
- **LINQ GroupBy Method**: [Enumerable.GroupBy Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby)
- **LINQ OrderBy Method**: [Enumerable.OrderByDescending Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderbydescending)

#### Image Handling (PictureBox Implementation)
- **Image Class**: [Image Class](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image)
- **Bitmap Class**: [Bitmap Class](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- **Graphics Class**: [Graphics Class](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- **Font Class**: [Font Class](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.font)
- **Color Structure**: [Color Structure](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color)
- **PictureBoxSizeMode**: [PictureBoxSizeMode Enum](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.pictureboxsizemode)

### Program Class Implementation
**File**: `FilmsAndActors-App/Program.cs`
**Purpose**: Application entry point

#### Application Configuration
- **STAThread Attribute**: [STAThreadAttribute Class](https://docs.microsoft.com/en-us/dotnet/api/system.stathreadattribute)
- **Application.EnableVisualStyles**: [Application.EnableVisualStyles Method](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application.enablevisualstyles)
- **Application.SetCompatibleTextRenderingDefault**: [Application.SetCompatibleTextRenderingDefault Method](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application.setcompatibletextrenderingdefault)
- **Application.Run**: [Application.Run Method](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application.run)

## TestProject1 Project References

### Unit Testing Implementation
**File**: `TestProject1/UnitTest1.cs`
**Purpose**: Comprehensive unit testing for all classes

#### NUnit Framework
- **NUnit Framework**: [NUnit Documentation](https://docs.nunit.org/)
- **Test Attribute**: [Test Attribute](https://docs.nunit.org/articles/nunit/writing-tests/attributes/test.html)
- **SetUp Attribute**: [SetUp Attribute](https://docs.nunit.org/articles/nunit/writing-tests/attributes/setup.html)
- **TearDown Attribute**: [TearDown Attribute](https://docs.nunit.org/articles/nunit/writing-tests/attributes/teardown.html)

#### Assertion Methods
- **Assert.AreEqual**: [Assert.AreEqual Method](https://docs.nunit.org/articles/nunit/writing-tests/assertions/classic-assertions/Assert.AreEqual.html)
- **Assert.IsTrue**: [Assert.IsTrue Method](https://docs.nunit.org/articles/nunit/writing-tests/assertions/classic-assertions/Assert.IsTrue.html)
- **Assert.IsFalse**: [Assert.IsFalse Method](https://docs.nunit.org/articles/nunit/writing-tests/assertions/classic-assertions/Assert.IsFalse.html)
- **Assert.IsNotNull**: [Assert.IsNotNull Method](https://docs.nunit.org/articles/nunit/writing-tests/assertions/classic-assertions/Assert.IsNotNull.html)
- **Assert.Throws**: [Assert.Throws Method](https://docs.nunit.org/articles/nunit/writing-tests/assertions/classic-assertions/Assert.Throws.html)
- **Assert.That**: [Assert.That Method](https://docs.nunit.org/articles/nunit/writing-tests/assertions/constraint-model/Assert.That.html)

#### Test Patterns
- **Arrange-Act-Assert Pattern**: [AAA Pattern](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#arranging-your-tests)
- **Test Naming Conventions**: [Test Naming](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#naming-your-tests)

## Project Configuration References

### MSBuild Project Files
- **MSBuild Documentation**: [MSBuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild)
- **Project File Schema**: [MSBuild Project File Schema](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-project-file-schema-reference)
- **Target Framework**: [Target Frameworks](https://docs.microsoft.com/en-us/dotnet/standard/frameworks)

### NuGet Package References
- **NUnit Package**: [NUnit NuGet Package](https://www.nuget.org/packages/NUnit/)
- **NUnit3TestAdapter**: [NUnit3TestAdapter Package](https://www.nuget.org/packages/NUnit3TestAdapter/)
- **Microsoft.NET.Test.Sdk**: [Microsoft.NET.Test.Sdk Package](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/)

## Design Patterns and Principles

### Object-Oriented Programming
- **Encapsulation**: [Encapsulation](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop)
- **Inheritance**: [Inheritance](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance)
- **Polymorphism**: [Polymorphism](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/polymorphism)

### SOLID Principles
- **Single Responsibility Principle**: [SOLID Principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#single-responsibility)
- **Dependency Inversion**: [Dependency Inversion](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)

### Design Patterns
- **Repository Pattern**: [Repository Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
- **Model-View Pattern**: [Separation of Concerns](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns)

## Error Handling and Validation

### Exception Handling Best Practices
- **Exception Handling**: [Exception Handling Best Practices](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions)
- **Custom Exceptions**: [Creating Custom Exceptions](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions)
- **Using Statement**: [Using Statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement)

### Input Validation
- **Data Validation**: [Validating Data](https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format)
- **Regular Expressions**: [Regular Expressions](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions)

## Performance and Memory Management

### Collection Performance
- **Collection Performance**: [Collections Performance](https://docs.microsoft.com/en-us/dotnet/standard/collections/when-to-use-generic-collections)
- **LINQ Performance**: [LINQ Performance](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/performance-linq-to-xml)

### Memory Management
- **Garbage Collection**: [Garbage Collection](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/)
- **IDisposable Pattern**: [IDisposable Pattern](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose)
- **Using Statements**: [Using Statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement)

## Accessibility and Usability

### Windows Forms Accessibility
- **Accessibility Guidelines**: [Accessibility in Windows Forms](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/advanced/windows-forms-accessibility)
- **AccessibleName Property**: [AccessibleName Property](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.accessiblename)
- **AccessibleDescription Property**: [AccessibleDescription Property](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.accessibledescription)

### Keyboard Navigation
- **Tab Order**: [Tab Order](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-set-the-tab-order-on-windows-forms)
- **Access Keys**: [Access Keys](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-create-access-keys-for-windows-forms-controls)

## Documentation Standards

### XML Documentation
- **XML Documentation Comments**: [XML Documentation Comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/)
- **Documentation Tags**: [Recommended Tags](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags)

### Code Comments
- **Code Comments Best Practices**: [Code Comments](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/lexical-structure#comments)

## Version Control and Project Management

### Git Integration
- **Git Documentation**: [Git Documentation](https://git-scm.com/doc)
- **GitHub Documentation**: [GitHub Docs](https://docs.github.com/)
- **.gitignore Best Practices**: [gitignore Documentation](https://git-scm.com/docs/gitignore)

### Project Structure
- **Solution and Project Files**: [Solutions and Projects](https://docs.microsoft.com/en-us/visualstudio/ide/solutions-and-projects-in-visual-studio)

## Development Tools and Environment

### Visual Studio
- **Visual Studio Documentation**: [Visual Studio Documentation](https://docs.microsoft.com/en-us/visualstudio/)
- **IntelliSense**: [IntelliSense](https://docs.microsoft.com/en-us/visualstudio/ide/using-intellisense)
- **Debugging**: [Debugging in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/debugger/)

### Build and Deployment
- **MSBuild**: [MSBuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild)
- **NuGet Package Manager**: [NuGet Documentation](https://docs.microsoft.com/en-us/nuget/)

## Coding Standards and Conventions

### C# Coding Conventions
- **C# Coding Conventions**: [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- **Naming Guidelines**: [Naming Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines)
- **Framework Design Guidelines**: [Framework Design Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/)

### Code Quality
- **Code Analysis**: [Code Analysis](https://docs.microsoft.com/en-us/visualstudio/code-quality/)
- **Code Metrics**: [Code Metrics](https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values)

## Security Considerations

### Input Validation Security
- **Input Validation**: [Input Validation](https://docs.microsoft.com/en-us/dotnet/standard/security/secure-coding-guidelines#input-validation)
- **SQL Injection Prevention**: [SQL Injection Prevention](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/overview-of-sql-server-security)
- **Cross-Site Scripting Prevention**: [XSS Prevention](https://docs.microsoft.com/en-us/aspnet/core/security/cross-site-scripting)

### File Security
- **File Access Security**: [File Security](https://docs.microsoft.com/en-us/dotnet/standard/security/secure-coding-guidelines#file-io-and-isolated-storage)
- **Path Traversal Prevention**: [Path Security](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath)

## Maintenance and Updates

### Documentation Maintenance
This reference document should be updated whenever:
- New classes, methods, or properties are added to the codebase
- External dependencies or frameworks are updated
- Microsoft documentation links change or become obsolete
- New design patterns or best practices are implemented

### Review Schedule
- **Weekly**: Verify accuracy of method and class references
- **Monthly**: Check validity of external documentation links
- **Quarterly**: Review and update framework version references
- **Annually**: Comprehensive audit of all documentation links and references

### Link Validation
All Microsoft documentation links should be validated regularly to ensure they remain active and point to current documentation versions. When links become obsolete, they should be updated to point to the current equivalent documentation.

## Additional Resources

### Learning Resources
- **Microsoft Learn**: [Microsoft Learn Platform](https://docs.microsoft.com/en-us/learn/)
- **C# Programming Guide**: [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/)
- **Windows Forms Tutorial**: [Windows Forms Tutorial](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/getting-started-with-windows-forms)
- **Unit Testing Tutorial**: [Unit Testing Tutorial](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit)

### Community Resources
- **Stack Overflow**: [Stack Overflow C# Tag](https://stackoverflow.com/questions/tagged/c%23)
- **GitHub**: [Microsoft .NET GitHub](https://github.com/dotnet)
- **NuGet Gallery**: [NuGet Package Repository](https://www.nuget.org/)

### Official Forums and Support
- **Microsoft Developer Community**: [Developer Community](https://developercommunity.visualstudio.com/)
- **Microsoft Q&A**: [Microsoft Q&A Platform](https://docs.microsoft.com/en-us/answers/)
- **Visual Studio Feedback**: [Visual Studio Feedback](https://developercommunity.visualstudio.com/spaces/8/index.html)

---


