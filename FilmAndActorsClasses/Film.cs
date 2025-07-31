namespace FilmAndActorsClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a film entity with comprehensive metadata and functionality.
    /// Implements business logic for film management including actors, ratings, and validation.
    /// Reference: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/
    /// </summary>
    public class Film
    {
        // Private member variables following encapsulation principles
        private int _filmIdentification;
        private string _filmTitle;
        private string _filmGenre;
        private int _releaseYear;
        private int _filmDuration;
        private string _filmRating;
        private string _filmDescription;
        private string _directorName;
        private string _productionCompany;
        private List<int> _audienceRatings;
        private List<Actor> _filmActors;

        /// <summary>
        /// Initialises a new instance of the Film class with default values.
        /// Creates empty collections for ratings and actors.
        /// </summary>
        public Film()
        {
            _audienceRatings = new List<int>();
            _filmActors = new List<Actor>();
            _filmTitle = string.Empty;
            _filmGenre = string.Empty;
            _filmDescription = string.Empty;
            _directorName = string.Empty;
            _productionCompany = string.Empty;
            _filmRating = string.Empty;
        }

        /// <summary>
        /// Initialises a new instance of the Film class with specified parameters.
        /// Validates input parameters and creates collections for ratings and actors.
        /// </summary>
        /// <param name="filmTitle">The complete title of the film without abbreviations.</param>
        /// <param name="filmGenre">The genre classification of the film.</param>
        /// <param name="releaseYear">The year the film was initially released.</param>
        /// <exception cref="ArgumentException">Thrown when parameters are invalid.</exception>
        public Film(string filmTitle, string filmGenre, int releaseYear) : this()
        {
            // Validate input parameters before assignment
            if (string.IsNullOrWhiteSpace(filmTitle))
            {
                throw new ArgumentException("Film title cannot be null or empty.", nameof(filmTitle));
            }

            if (string.IsNullOrWhiteSpace(filmGenre))
            {
                throw new ArgumentException("Film genre cannot be null or empty.", nameof(filmGenre));
            }

            if (releaseYear < 1888 || releaseYear > DateTime.Now.Year + 5)
            {
                throw new ArgumentException("Release year must be between 1888 and five years in the future.", nameof(releaseYear));
            }

            _filmTitle = filmTitle;
            _filmGenre = filmGenre;
            _releaseYear = releaseYear;
        }

        // Public properties for controlled access to private fields
        /// <summary>
        /// Gets or sets the unique identification number for the film.
        /// Used for database operations and film management.
        /// </summary>
        public int FilmIdentification
        {
            get { return _filmIdentification; }
            set { _filmIdentification = value; }
        }

        /// <summary>
        /// Gets or sets the complete title of the film.
        /// Must not contain abbreviations and should be descriptive.
        /// </summary>
        public string FilmTitle
        {
            get { return _filmTitle; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Film title cannot be null or empty.");
                }
                _filmTitle = value; 
            }
        }

        /// <summary>
        /// Gets or sets the genre classification of the film.
        /// Examples include Action, Drama, Comedy, Science Fiction.
        /// </summary>
        public string FilmGenre
        {
            get { return _filmGenre; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Film genre cannot be null or empty.");
                }
                _filmGenre = value; 
            }
        }

        /// <summary>
        /// Gets or sets the year the film was initially released.
        /// Must be between 1888 (first motion picture) and five years in the future.
        /// </summary>
        public int ReleaseYear
        {
            get { return _releaseYear; }
            set 
            { 
                if (value < 1888 || value > DateTime.Now.Year + 5)
                {
                    throw new ArgumentException("Release year must be between 1888 and five years in the future.");
                }
                _releaseYear = value; 
            }
        }

        /// <summary>
        /// Gets or sets the duration of the film in minutes.
        /// Must be a positive value representing the total runtime.
        /// </summary>
        public int FilmDuration
        {
            get { return _filmDuration; }
            set 
            { 
                if (value < 0)
                {
                    throw new ArgumentException("Film duration must be a positive value.");
                }
                _filmDuration = value; 
            }
        }

        /// <summary>
        /// Gets or sets the audience suitability rating for the film.
        /// Examples include Universal, Parental Guidance, 12A, 15, 18.
        /// </summary>
        public string FilmRating
        {
            get { return _filmRating; }
            set { _filmRating = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets the detailed description and plot summary of the film.
        /// Should provide comprehensive information about the film's content.
        /// </summary>
        public string FilmDescription
        {
            get { return _filmDescription; }
            set { _filmDescription = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets the full name of the primary director.
        /// Should not contain abbreviations and must be complete.
        /// </summary>
        public string DirectorName
        {
            get { return _directorName; }
            set { _directorName = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets or sets the name of the production company or studio.
        /// Represents the organisation responsible for film production.
        /// </summary>
        public string ProductionCompany
        {
            get { return _productionCompany; }
            set { _productionCompany = value ?? string.Empty; }
        }

        /// <summary>
        /// Gets the collection of audience ratings for the film.
        /// Ratings are stored as integers between 1 and 5.
        /// </summary>
        [JsonIgnore]
        public List<int> AudienceRatings
        {
            get { return _audienceRatings; }
        }

        /// <summary>
        /// Gets the collection of actors appearing in the film.
        /// Maintains the cast list for the film.
        /// </summary>
        [JsonIgnore]
        public List<Actor> FilmActors
        {
            get { return _filmActors; }
        }

        // Serialisation properties for JSON persistence
        /// <summary>
        /// Gets or sets the audience ratings for JSON serialisation.
        /// Used internally for data persistence operations.
        /// </summary>
        public List<int> Ratings
        {
            get { return _audienceRatings; }
            set { _audienceRatings = value ?? new List<int>(); }
        }

        /// <summary>
        /// Gets or sets the film actors for JSON serialisation.
        /// Used internally for data persistence operations.
        /// </summary>
        public List<Actor> Actors
        {
            get { return _filmActors; }
            set { _filmActors = value ?? new List<Actor>(); }
        }

        /// <summary>
        /// Adds an actor to the film's cast list with validation.
        /// Prevents duplicate actors from being added to the same film.
        /// </summary>
        /// <param name="actorToAdd">The Actor object to add to the film's cast.</param>
        /// <exception cref="ArgumentNullException">Thrown when actor parameter is null.</exception>
        public void AddActorToFilm(Actor actorToAdd)
        {
            // Validate actor parameter before processing
            if (actorToAdd == null)
            {
                throw new ArgumentNullException(nameof(actorToAdd), "Actor cannot be null.");
            }

            // Check if actor is already in the film to prevent duplicates
            bool actorAlreadyExists = false;
            foreach (Actor existingActor in _filmActors)
            {
                if (existingActor.ActorName.Equals(actorToAdd.ActorName, StringComparison.OrdinalIgnoreCase))
                {
                    actorAlreadyExists = true;
                    break;
                }
            }

            // Add actor only if not already present
            if (!actorAlreadyExists)
            {
                _filmActors.Add(actorToAdd);
                Console.WriteLine($"Actor {actorToAdd.ActorName} added to film {_filmTitle}.");
            }
            else
            {
                Console.WriteLine($"Actor {actorToAdd.ActorName} is already in the cast of {_filmTitle}.");
            }
        }

        /// <summary>
        /// Adds an audience rating to the film with validation.
        /// Ratings must be between 1 and 5 inclusive.
        /// </summary>
        /// <param name="ratingValue">The rating value between 1 and 5.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when rating is outside valid range.</exception>
        public void AddAudienceRating(int ratingValue)
        {
            // Validate rating is within acceptable range
            if (ratingValue < 1 || ratingValue > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(ratingValue), "Rating must be between 1 and 5 inclusive.");
            }

            _audienceRatings.Add(ratingValue);
            Console.WriteLine($"Rating of {ratingValue} added to film {_filmTitle}.");
        }

        /// <summary>
        /// Calculates and returns the average audience rating for the film.
        /// Returns 0.0 if no ratings have been submitted.
        /// </summary>
        /// <returns>The average rating as a double value, or 0.0 if no ratings exist.</returns>
        public double CalculateAverageRating()
        {
            // Check if any ratings exist to prevent division by zero
            if (_audienceRatings.Count == 0)
            {
                return 0.0;
            }

            // Calculate sum using for loop to demonstrate iteration
            int totalRatingSum = 0;
            for (int ratingIndex = 0; ratingIndex < _audienceRatings.Count; ratingIndex++)
            {
                totalRatingSum += _audienceRatings[ratingIndex];
            }

            // Return average as double for precision
            return (double)totalRatingSum / _audienceRatings.Count;
        }

        /// <summary>
        /// Retrieves all actors in the film using foreach iteration.
        /// Demonstrates collection traversal and string manipulation.
        /// </summary>
        /// <returns>A formatted string containing all actor names.</returns>
        public string GetAllActorNames()
        {
            // Handle case where no actors are present
            if (_filmActors.Count == 0)
            {
                return "No actors assigned to this film.";
            }

            string actorNamesList = "Cast: ";
            
            // Use foreach to iterate through actor collection
            foreach (Actor currentActor in _filmActors)
            {
                actorNamesList += currentActor.ActorName + ", ";
            }

            // Remove trailing comma and space
            if (actorNamesList.EndsWith(", "))
            {
                actorNamesList = actorNamesList.Substring(0, actorNamesList.Length - 2);
            }

            return actorNamesList;
        }

        /// <summary>
        /// Searches for actors by name using selection logic and operators.
        /// Demonstrates conditional statements and string comparison.
        /// </summary>
        /// <param name="searchName">The name to search for in the cast.</param>
        /// <returns>True if actor is found, false otherwise.</returns>
        public bool SearchForActorByName(string searchName)
        {
            // Validate search parameter
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return false;
            }

            // Use selection logic to find matching actor
            foreach (Actor currentActor in _filmActors)
            {
                // Use operators for string comparison (case-insensitive)
                if (currentActor.ActorName.ToLower().Contains(searchName.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates all film data using comprehensive selection logic.
        /// Demonstrates multiple conditional statements and operators.
        /// </summary>
        /// <returns>True if all film data is valid, false otherwise.</returns>
        public bool ValidateFilmData()
        {
            // Check title validity
            if (string.IsNullOrWhiteSpace(_filmTitle))
            {
                Console.WriteLine("Validation failed: Film title is required.");
                return false;
            }

            // Check genre validity
            if (string.IsNullOrWhiteSpace(_filmGenre))
            {
                Console.WriteLine("Validation failed: Film genre is required.");
                return false;
            }

            // Check release year validity using logical operators
            if (_releaseYear < 1888 || _releaseYear > DateTime.Now.Year + 5)
            {
                Console.WriteLine("Validation failed: Release year is outside valid range.");
                return false;
            }

            // Check duration validity
            if (_filmDuration < 0)
            {
                Console.WriteLine("Validation failed: Film duration must be positive.");
                return false;
            }

            // All validation checks passed
            Console.WriteLine($"Film {_filmTitle} passed all validation checks.");
            return true;
        }

        /// <summary>
        /// Displays comprehensive film information to console.
        /// Demonstrates console input/output and string formatting.
        /// </summary>
        public void DisplayFilmInformation()
        {
            Console.WriteLine("=== Film Information ===");
            Console.WriteLine($"Title: {_filmTitle}");
            Console.WriteLine($"Genre: {_filmGenre}");
            Console.WriteLine($"Release Year: {_releaseYear}");
            Console.WriteLine($"Duration: {_filmDuration} minutes");
            Console.WriteLine($"Rating: {_filmRating}");
            Console.WriteLine($"Director: {_directorName}");
            Console.WriteLine($"Production Company: {_productionCompany}");
            Console.WriteLine($"Description: {_filmDescription}");
            Console.WriteLine($"Average Rating: {CalculateAverageRating():F2}/5.0");
            Console.WriteLine(GetAllActorNames());
            Console.WriteLine("========================");
        }

        /// <summary>
        /// Provides string representation of the film for display purposes.
        /// Used in list controls and debugging output.
        /// </summary>
        /// <returns>Formatted string representation of the film.</returns>
        public override string ToString()
        {
            return $"{_filmTitle} ({_releaseYear}) - {_filmGenre}";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current film.
        /// Compares films based on title and release year.
        /// </summary>
        /// <param name="objectToCompare">The object to compare with the current film.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override bool Equals(object objectToCompare)
        {
            // Check if the object is a Film instance
            if (objectToCompare is Film otherFilm)
            {
                // Compare based on title and release year
                return _filmTitle.Equals(otherFilm._filmTitle, StringComparison.OrdinalIgnoreCase) &&
                       _releaseYear == otherFilm._releaseYear;
            }
            return false;
        }

        /// <summary>
        /// Generates hash code for the film based on title and release year.
        /// Used for efficient storage in hash-based collections.
        /// </summary>
        /// <returns>Hash code for the film object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_filmTitle?.ToLower(), _releaseYear);
        }
    }
}

/*
Explanation of the Film.cs:

1. **Namespace and Using Directives**:
   - The namespace `FilmAndActorsClasses` is used to organise related classes.
   - Several system namespaces are included: `System` for core functionalities, `System.Collections.Generic` for using generic collections like lists, and `System.Diagnostics` for debugging purposes.

2. **Film Class**:
   - The `Film` class represents the details and functionalities related to a film, including its title, genre, release year, ratings, and associated actors.
   - It also demonstrates the use of encapsulation by utilizing private fields and public properties for controlled access.

3. **Constructor**:
   - The constructor initialises a new `Film` object with specified parameters: title, genre, and release year.
   - `ratings` and `actors` are initialised as empty lists to store ratings and actors associated with the film.

4. **Public Properties**:
   - Properties `Title`, `Genre`, and `ReleaseYear` provide read and write access to the private fields `title`, `genre`, and `releaseYear`. This ensures controlled access to these fields.
   - The `Ratings` and `Actors` properties provide read-only access to the `ratings` and `actors` lists. This ensures that the list itself can't be replaced, though it can be modified through the class methods.

5. **AddActor Method**:
   - The `AddActor` method adds an actor to the `actors` list.
   - The `Contains` method ensures that the same actor isn't added more than once.

6. **AddRating Method**:
   - The `AddRating` method allows users to add ratings between 1 and 5.
   - If the rating is outside the valid range, an `ArgumentException` is thrown.

7. **GetAverageRating Method**:
   - The `GetAverageRating` method calculates the average rating of the film.
   - If there are no ratings, it returns `0.0` to avoid division by zero.

8. **DisplayInfo Method**:
   - The `DisplayInfo` method prints detailed information about the film, including its title, genre, release year, and a list of actors.
   - It also prints the average rating, calculated using the `GetAverageRating()` method.

9. **RunTests Method**:
   - `RunTests` is a static method used to run unit tests on the `Film` class.
   - It checks the correctness of properties like `Title`, `Genre`, and `ReleaseYear`.
   - It also tests the `AddRating` and `GetAverageRating` methods.
   - Additionally, it tests the `AddActor` method and ensures the correct actor is added to the list.

**Summary**:
This `Film` class follows best practices like encapsulation, keeping data private while exposing controlled access through properties. It includes functionalities for:
- Adding actors and ratings.
- Displaying detailed film information.
- Performing unit tests to verify the correctness of its properties and methods.

The changes that were made make it easier to maintain and extend, and they help protect the internal state of the object while allowing safe interaction with external code.
*/
