using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FilmAndActorsClasses
{
    /// <summary>
    /// Represents an actor entity with biographical and career information.
    /// Implements business logic for actor management including filmography and validation.
    /// Reference: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/
    /// </summary>
    public class Actor
    {
        // Private member variables following encapsulation principles
        private int _actorIdentification;
        private string _actorName;
        private DateTime _dateOfBirth;
        private string _nationality;
        private string _biography;
        private string _actorPhotoPath;
        private string _yearsActive;
        private List<string> _awardsList;
        private List<string> _filmography;

        /// <summary>
        /// Initialises a new instance of the Actor class with default values.
        /// Creates empty collections for awards and filmography.
        /// </summary>
        public Actor()
        {
            _awardsList = new List<string>();
            _filmography = new List<string>();
            _actorName = string.Empty;
            _nationality = string.Empty;
            _biography = string.Empty;
            _actorPhotoPath = string.Empty;
            _yearsActive = string.Empty;
            _dateOfBirth = DateTime.MinValue;
        }

        /// <summary>
        /// Initialises a new instance of the Actor class with specified parameters.
        /// Validates input parameters and creates collections for awards and filmography.
        /// </summary>
        /// <param name="actorName">The full name of the actor without abbreviations.</param>
        /// <param name="actorAge">The current age of the actor for birth date calculation.</param>
        /// <exception cref="ArgumentException">Thrown when parameters are invalid.</exception>
        public Actor(string actorName, int actorAge) : this()
        {
            // Validate input parameters before assignment
            if (string.IsNullOrWhiteSpace(actorName))
            {
                throw new ArgumentException("Actor name cannot be null or empty.", nameof(actorName));
            }

            if (actorAge < 0 || actorAge > 150)
            {
                throw new ArgumentException("Actor age must be between 0 and 150.", nameof(actorAge));
            }

            _actorName = actorName;
            // Calculate approximate birth date from age
            _dateOfBirth = DateTime.Now.AddYears(-actorAge);
        }

        /// <summary>
        /// Initialises a new instance of the Actor class with name and birth date.
        /// Provides more precise age calculation using actual birth date.
        /// </summary>
        /// <param name="actorName">The full name of the actor without abbreviations.</param>
        /// <param name="dateOfBirth">The actor's actual date of birth.</param>
        /// <exception cref="ArgumentException">Thrown when parameters are invalid.</exception>
        public Actor(string actorName, DateTime dateOfBirth) : this()
        {
            // Validate input parameters before assignment
            if (string.IsNullOrWhiteSpace(actorName))
            {
                throw new ArgumentException("Actor name cannot be null or empty.", nameof(actorName));
            }

            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.", nameof(dateOfBirth));
            }

            if (dateOfBirth < new DateTime(1850, 1, 1))
            {
                throw new ArgumentException("Date of birth cannot be before 1850.", nameof(dateOfBirth));
            }

            _actorName = actorName;
            _dateOfBirth = dateOfBirth;
        }

        // Public properties for controlled access to private fields
        /// <summary>
        /// Gets or sets the unique identification number for the actor.
        /// Used for database operations and actor management.
        /// </summary>
        public int ActorIdentification
        {
            get { return _actorIdentification; }
            set { _actorIdentification = value; }
        }

        /// <summary>
        /// Gets or sets the full name of the actor.
        /// Must not contain abbreviations and should be complete.
        /// </summary>
        public string ActorName
        {
            get { return _actorName; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Actor name cannot be null or empty.");
                }
                _actorName = value; 
            }
        }

        /// <summary>
        /// Gets or sets the actor's date of birth.
        /// Used for age calculations and biographical information.
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set 
            { 
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Date of birth cannot be in the future.");
                }
                if (value < new DateTime(1850, 1, 1))
                {
                    throw new ArgumentException("Date of birth cannot be before 1850.");
                }
                _dateOfBirth = value; 
            }
        }

        /// <summary>
        /// Gets or sets the actor's nationality or country of origin.
        /// Represents the actor's cultural background.
        /// </summary>
        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets the detailed biographical information about the actor.
        /// Should provide comprehensive background and career highlights.
        /// </summary>
        public string Biography
        {
            get { return _biography; }
            set { _biography = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets the file path to the actor's photograph.
        /// Used for displaying actor images in the user interface.
        /// </summary>
        public string ActorPhotoPath
        {
            get { return _actorPhotoPath; }
            set { _actorPhotoPath = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets the period of the actor's professional activity.
        /// Represents the span of their acting career.
        /// </summary>
        public string YearsActive
        {
            get { return _yearsActive; }
            set { _yearsActive = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets the collection of awards and recognitions received by the actor.
        /// Maintains a list of professional achievements.
        /// </summary>
        [JsonIgnore]
        public List<string> AwardsReceived
        {
            get { return _awardsList; }
        }

        /// <summary>
        /// Gets the collection of films in which the actor has appeared.
        /// Maintains the actor's complete filmography.
        /// </summary>
        [JsonIgnore]
        public List<string> ActorFilmography
        {
            get { return _filmography; }
        }

        // Serialisation properties for JSON persistence
        /// <summary>
        /// Gets or sets the awards list for JSON serialisation.
        /// Used internally for data persistence operations.
        /// </summary>
        public List<string> Awards
        {
            get { return _awardsList; }
            set { _awardsList = value ?? new List<string>(); }
        }

        /// <summary>
        /// Gets or sets the filmography for JSON serialisation.
        /// Used internally for data persistence operations.
        /// </summary>
        public List<string> Films
        {
            get { return _filmography; }
            set { _filmography = value ?? new List<string>(); }
        }

        /// <summary>
        /// Calculates and returns the current age of the actor.
        /// Uses the date of birth to determine precise age in years.
        /// </summary>
        /// <returns>The actor's current age in years.</returns>
        public int CalculateCurrentAge()
        {
            // Handle case where date of birth is not set
            if (_dateOfBirth == DateTime.MinValue)
            {
                return 0;
            }

            // Calculate age based on current date and birth date
            DateTime currentDate = DateTime.Now;
            int calculatedAge = currentDate.Year - _dateOfBirth.Year;

            // Adjust age if birthday hasn't occurred this year
            if (currentDate.Month < _dateOfBirth.Month || 
                (currentDate.Month == _dateOfBirth.Month && currentDate.Day < _dateOfBirth.Day))
            {
                calculatedAge--;
            }

            return calculatedAge;
        }

        /// <summary>
        /// Adds a film to the actor's filmography with validation.
        /// Prevents duplicate films from being added to the same actor.
        /// </summary>
        /// <param name="filmTitle">The title of the film to add to the filmography.</param>
        /// <exception cref="ArgumentException">Thrown when film title is invalid.</exception>
        public void AddFilmToFilmography(string filmTitle)
        {
            // Validate film title parameter
            if (string.IsNullOrWhiteSpace(filmTitle))
            {
                throw new ArgumentException("Film title cannot be null or empty.", nameof(filmTitle));
            }

            // Check if film is already in filmography to prevent duplicates
            bool filmAlreadyExists = false;
            foreach (string existingFilm in _filmography)
            {
                if (existingFilm.Equals(filmTitle, StringComparison.OrdinalIgnoreCase))
                {
                    filmAlreadyExists = true;
                    break;
                }
            }

            // Add film only if not already present
            if (!filmAlreadyExists)
            {
                _filmography.Add(filmTitle);
                Console.WriteLine($"Film '{filmTitle}' added to {_actorName}'s filmography.");
            }
            else
            {
                Console.WriteLine($"Film '{filmTitle}' is already in {_actorName}'s filmography.");
            }
        }

        /// <summary>
        /// Adds an award to the actor's awards collection with validation.
        /// Maintains a record of professional achievements and recognitions.
        /// </summary>
        /// <param name="awardName">The name of the award or recognition received.</param>
        /// <exception cref="ArgumentException">Thrown when award name is invalid.</exception>
        public void AddAwardToCollection(string awardName)
        {
            // Validate award name parameter
            if (string.IsNullOrWhiteSpace(awardName))
            {
                throw new ArgumentException("Award name cannot be null or empty.", nameof(awardName));
            }

            // Add award to collection (duplicates allowed for multiple wins)
            _awardsList.Add(awardName);
            Console.WriteLine($"Award '{awardName}' added to {_actorName}'s collection.");
        }

        /// <summary>
        /// Retrieves all films in the actor's filmography using foreach iteration.
        /// Demonstrates collection traversal and string manipulation.
        /// </summary>
        /// <returns>A formatted string containing all film titles.</returns>
        public string GetCompleteFilmography()
        {
            // Handle case where no films are present
            if (_filmography.Count == 0)
            {
                return $"{_actorName} has no films in their filmography.";
            }

            string filmographyList = $"{_actorName}'s Filmography: ";
            
            // Use foreach to iterate through film collection
            foreach (string currentFilm in _filmography)
            {
                filmographyList += currentFilm + ", ";
            }

            // Remove trailing comma and space
            if (filmographyList.EndsWith(", "))
            {
                filmographyList = filmographyList.Substring(0, filmographyList.Length - 2);
            }

            return filmographyList;
        }

        /// <summary>
        /// Searches for films by title using selection logic and operators.
        /// Demonstrates conditional statements and string comparison.
        /// </summary>
        /// <param name="searchTitle">The film title to search for in the filmography.</param>
        /// <returns>True if film is found, false otherwise.</returns>
        public bool SearchForFilmByTitle(string searchTitle)
        {
            // Validate search parameter
            if (string.IsNullOrWhiteSpace(searchTitle))
            {
                return false;
            }

            // Use selection logic to find matching film
            foreach (string currentFilm in _filmography)
            {
                // Use operators for string comparison (case-insensitive)
                if (currentFilm.ToLower().Contains(searchTitle.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates all actor data using comprehensive selection logic.
        /// Demonstrates multiple conditional statements and operators.
        /// </summary>
        /// <returns>True if all actor data is valid, false otherwise.</returns>
        public bool ValidateActorData()
        {
            // Check name validity
            if (string.IsNullOrWhiteSpace(_actorName))
            {
                Console.WriteLine("Validation failed: Actor name is required.");
                return false;
            }

            // Check date of birth validity using logical operators
            if (_dateOfBirth == DateTime.MinValue || _dateOfBirth > DateTime.Now)
            {
                Console.WriteLine("Validation failed: Valid date of birth is required.");
                return false;
            }

            // Check age validity
            int currentAge = CalculateCurrentAge();
            if (currentAge < 0 || currentAge > 150)
            {
                Console.WriteLine("Validation failed: Actor age is outside reasonable range.");
                return false;
            }

            // All validation checks passed
            Console.WriteLine($"Actor {_actorName} passed all validation checks.");
            return true;
        }

        /// <summary>
        /// Displays comprehensive actor information to console.
        /// Demonstrates console input/output and string formatting.
        /// </summary>
        public void DisplayActorInformation()
        {
            Console.WriteLine("=== Actor Information ===");
            Console.WriteLine($"Name: {_actorName}");
            Console.WriteLine($"Age: {CalculateCurrentAge()} years old");
            Console.WriteLine($"Date of Birth: {_dateOfBirth:dd/MM/yyyy}");
            Console.WriteLine($"Nationality: {_nationality}");
            Console.WriteLine($"Years Active: {_yearsActive}");
            Console.WriteLine($"Biography: {_biography}");
            Console.WriteLine($"Photo Path: {_actorPhotoPath}");
            Console.WriteLine($"Number of Films: {_filmography.Count}");
            Console.WriteLine($"Number of Awards: {_awardsList.Count}");
            Console.WriteLine(GetCompleteFilmography());
            Console.WriteLine("=========================");
        }

        /// <summary>
        /// Provides string representation of the actor for display purposes.
        /// Used in list controls and debugging output.
        /// </summary>
        /// <returns>Formatted string representation of the actor.</returns>
        public override string ToString()
        {
            return $"{_actorName} (Age: {CalculateCurrentAge()})";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current actor.
        /// Compares actors based on name and date of birth.
        /// </summary>
        /// <param name="objectToCompare">The object to compare with the current actor.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override bool Equals(object objectToCompare)
        {
            // Check if the object is an Actor instance
            if (objectToCompare is Actor otherActor)
            {
                // Compare based on name and date of birth
                return _actorName.Equals(otherActor._actorName, StringComparison.OrdinalIgnoreCase) &&
                       _dateOfBirth.Date == otherActor._dateOfBirth.Date;
            }
            return false;
        }

        /// <summary>
        /// Generates hash code for the actor based on name and date of birth.
        /// Used for efficient storage in hash-based collections.
        /// </summary>
        /// <returns>Hash code for the actor object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_actorName?.ToLower(), _dateOfBirth.Date);
        }
    }
}


/*
  Explanation of Actor.cs - A class representing an actor in a film.
 
  This class is used to manage information about an actor, including their name, age, and filmography.
  The main features of this class are:
 
 * 1. **Private Fields and Public Properties**:
      - The class contains private fields for `name`, `age`, and `films` to encapsulate the actor's data.
      - Public properties (`Name` and `Age`) are used to get and set the values of these private fields, allowing controlled access.
      - The `Films` property returns the list of films the actor has appeared in.
  
 * 2. **Constructors**:
      - The class provides a constructor for initializing an actor with a specific name and age.
      - The `Actor` constructor initializes the `films` list to store the actor's filmography.
   
   3. **Methods**:
      - `AddFilm(string film)`: Adds a film to the actor's filmography.
      - `DisplayInfo()`: Displays the actor's information, including their name, age, and list of films.
      - This class can be extended or inherited by other classes to introduce polymorphism if additional types of actors (such as `LeadActor` or `SupportingActor`) are needed.
  
 * 4. **Polymorphism**:
      - The `Actor` class serves as a base class, which allows for polymorphism.
      - For example, the `LeadActor` class inherits from `Actor` and adds a unique `LeadRole` property, demonstrating inheritance and adding specialised behavior.
      - In a polymorphic setting, different types of actors can be treated as `Actor` objects while still exhibiting their specialised behavior.
  
 * 5. **Encapsulation and Access Control**:
      - By using private fields and public properties, the class ensures that the data is properly encapsulated and access is controlled.
      - The use of protected constructors in the `FilmMember` class allows only derived classes to create instances of it, providing an extra layer of access control.
   
 * 6. **Inheritance from FilmPerson**:
      - The `Actor` class inherits from `FilmMember`, which serves as a general base class for people involved in films.
      - This allows code reuse and the addition of specialised behavior for other types of film-related people, such as `Director` or `Producer`.
 */


/*
Explanation of Changes:

1. Renamed the base class from `FilmPerson` to `FilmMember` to make it simpler and unique.
   - This name change makes it easier to understand that this class represents a member of the film industry without confusion.

2. `FilmMember` serves as a general representation of anyone involved in the film industry.
   - It has private fields `_name` and `_age`, along with associated getters and setters.
   - Contains an abstract method `DisplayInfo()`, which must be implemented by derived classes like `Actor`.

3. Updated `Actor` to inherit from `FilmMember`.
   - The `Actor` class now inherits the properties `Name` and `Age` from `FilmMember`.
   - This demonstrates **polymorphism**, as `Actor` provides a specific implementation of the abstract `DisplayInfo()` method.

4. Used encapsulation by keeping the fields `_name` and `_age` private and providing public properties to access them.
   - This approach ensures that the internal state of `FilmMember` cannot be modified directly from outside the class, thus preserving data integrity.

5. Added detailed inline comments to explain the purpose and functionality of classes, constructors, and methods.
   - This includes explanations for constructors, methods, and the use of inheritance and polymorphism with the `FilmMember` base class.
*/
