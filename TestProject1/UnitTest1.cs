using FilmAndActorsClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    /// <summary>
    /// Comprehensive unit test class for Film and Actor classes.
    /// Tests all major functionality including validation, data manipulation, and business logic.
    /// Reference: https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit
    /// </summary>
    public class FilmAndActorTests
    {
        // Test data constants for consistent testing
        private const string TestActorName = "John Doe";
        private const int TestActorAge = 35;
        private const string TestFilmTitle = "Inception";
        private const string TestFilmGenre = "Science Fiction";
        private const int TestFilmYear = 2010;

        #region Actor Class Tests

        [Test]
        public void ActorConstructor_WithValidNameAndAge_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            // Create an instance of the Actor class with valid name and age
            Actor testActor = new Actor(TestActorName, TestActorAge);

            // Assert
            // Verify that the actor name is set correctly
            Assert.AreEqual(TestActorName, testActor.ActorName, "Actor name should match the provided value.");
            
            // Verify that the calculated age is approximately correct (within 1 year due to birth date calculation)
            int calculatedAge = testActor.CalculateCurrentAge();
            Assert.That(calculatedAge, Is.InRange(TestActorAge - 1, TestActorAge + 1), "Actor age should be within expected range.");
        }

        [Test]
        public void ActorConstructor_WithNullName_ThrowsArgumentException()
        {
            // Arrange, Act & Assert
            // Verify that creating an actor with null name throws ArgumentException
            Assert.Throws<ArgumentException>(() => new Actor(null, TestActorAge), 
                "Constructor should throw ArgumentException for null name.");
        }

        [Test]
        public void ActorConstructor_WithEmptyName_ThrowsArgumentException()
        {
            // Arrange, Act & Assert
            // Verify that creating an actor with empty name throws ArgumentException
            Assert.Throws<ArgumentException>(() => new Actor(string.Empty, TestActorAge), 
                "Constructor should throw ArgumentException for empty name.");
        }

        [Test]
        public void ActorConstructor_WithInvalidAge_ThrowsArgumentException()
        {
            // Arrange, Act & Assert
            // Verify that creating an actor with negative age throws ArgumentException
            Assert.Throws<ArgumentException>(() => new Actor(TestActorName, -1), 
                "Constructor should throw ArgumentException for negative age.");
            
            // Verify that creating an actor with age over 150 throws ArgumentException
            Assert.Throws<ArgumentException>(() => new Actor(TestActorName, 151), 
                "Constructor should throw ArgumentException for age over 150.");
        }

        [Test]
        public void AddFilmToFilmography_WithValidFilm_AddsFilmSuccessfully()
        {
            // Arrange
            // Create an actor instance and specify a film to be added
            Actor testActor = new Actor(TestActorName, TestActorAge);
            string testFilmTitle = "Example Film";

            // Act
            // Add the specified film to the actor's filmography
            testActor.AddFilmToFilmography(testFilmTitle);

            // Assert
            // Verify that the film was successfully added to the actor's filmography
            Assert.Contains(testFilmTitle, testActor.Films, "Film should be added to actor's filmography.");
            Assert.AreEqual(1, testActor.Films.Count, "Filmography should contain exactly one film.");
        }

        [Test]
        public void AddFilmToFilmography_WithDuplicateFilm_DoesNotAddDuplicate()
        {
            // Arrange
            // Create an actor instance and add a film twice
            Actor testActor = new Actor(TestActorName, TestActorAge);
            string testFilmTitle = "Example Film";

            // Act
            // Add the same film twice
            testActor.AddFilmToFilmography(testFilmTitle);
            testActor.AddFilmToFilmography(testFilmTitle);

            // Assert
            // Verify that only one instance of the film exists in filmography
            Assert.AreEqual(1, testActor.Films.Count, "Duplicate films should not be added to filmography.");
        }

        [Test]
        public void AddFilmToFilmography_WithNullFilm_ThrowsArgumentException()
        {
            // Arrange
            // Create an actor instance
            Actor testActor = new Actor(TestActorName, TestActorAge);

            // Act & Assert
            // Verify that adding null film throws ArgumentException
            Assert.Throws<ArgumentException>(() => testActor.AddFilmToFilmography(null), 
                "Adding null film should throw ArgumentException.");
        }

        [Test]
        public void CalculateCurrentAge_WithValidBirthDate_ReturnsCorrectAge()
        {
            // Arrange
            // Create an actor with a specific birth date
            DateTime birthDate = new DateTime(1990, 5, 15);
            Actor testActor = new Actor(TestActorName, birthDate);

            // Act
            // Calculate the current age
            int calculatedAge = testActor.CalculateCurrentAge();

            // Assert
            // Verify that the calculated age is reasonable (between 30-40 for someone born in 1990)
            Assert.That(calculatedAge, Is.InRange(30, 40), "Calculated age should be within expected range.");
        }

        [Test]
        public void ValidateActorData_WithValidData_ReturnsTrue()
        {
            // Arrange
            // Create an actor with valid data
            Actor testActor = new Actor(TestActorName, TestActorAge);

            // Act
            // Validate the actor data
            bool isValid = testActor.ValidateActorData();

            // Assert
            // Verify that validation passes for valid data
            Assert.IsTrue(isValid, "Validation should pass for actor with valid data.");
        }

        #endregion

        #region Film Class Tests

        [Test]
        public void FilmConstructor_WithValidParameters_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            // Create an instance of the Film class with valid parameters
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);

            // Assert
            // Verify that all properties are set correctly
            Assert.AreEqual(TestFilmTitle, testFilm.FilmTitle, "Film title should match the provided value.");
            Assert.AreEqual(TestFilmGenre, testFilm.FilmGenre, "Film genre should match the provided value.");
            Assert.AreEqual(TestFilmYear, testFilm.ReleaseYear, "Release year should match the provided value.");
        }

        [Test]
        public void FilmConstructor_WithNullTitle_ThrowsArgumentException()
        {
            // Arrange, Act & Assert
            // Verify that creating a film with null title throws ArgumentException
            Assert.Throws<ArgumentException>(() => new Film(null, TestFilmGenre, TestFilmYear), 
                "Constructor should throw ArgumentException for null title.");
        }

        [Test]
        public void FilmConstructor_WithInvalidYear_ThrowsArgumentException()
        {
            // Arrange, Act & Assert
            // Verify that creating a film with year before 1888 throws ArgumentException
            Assert.Throws<ArgumentException>(() => new Film(TestFilmTitle, TestFilmGenre, 1887), 
                "Constructor should throw ArgumentException for year before 1888.");
            
            // Verify that creating a film with year too far in future throws ArgumentException
            int futureYear = DateTime.Now.Year + 10;
            Assert.Throws<ArgumentException>(() => new Film(TestFilmTitle, TestFilmGenre, futureYear), 
                "Constructor should throw ArgumentException for year too far in future.");
        }

        [Test]
        public void AddActorToFilm_WithValidActor_AddsActorSuccessfully()
        {
            // Arrange
            // Create instances of Film and Actor classes
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);
            Actor testActor = new Actor("Leonardo DiCaprio", 46);

            // Act
            // Add the actor to the film's cast
            testFilm.AddActorToFilm(testActor);

            // Assert
            // Verify that the actor was successfully added to the film's cast
            Assert.AreEqual(1, testFilm.Actors.Count, "Film should contain exactly one actor.");
            Assert.AreEqual("Leonardo DiCaprio", testFilm.Actors[0].ActorName, "Actor name should match the added actor.");
        }

        [Test]
        public void AddActorToFilm_WithNullActor_ThrowsArgumentNullException()
        {
            // Arrange
            // Create a film instance
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);

            // Act & Assert
            // Verify that adding null actor throws ArgumentNullException
            Assert.Throws<ArgumentNullException>(() => testFilm.AddActorToFilm(null), 
                "Adding null actor should throw ArgumentNullException.");
        }

        [Test]
        public void AddAudienceRating_WithValidRating_AddsRatingSuccessfully()
        {
            // Arrange
            // Create a film instance
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);

            // Act
            // Add valid ratings to the film
            testFilm.AddAudienceRating(4);
            testFilm.AddAudienceRating(5);

            // Assert
            // Verify that ratings were added successfully
            Assert.AreEqual(2, testFilm.Ratings.Count, "Film should contain exactly two ratings.");
            Assert.Contains(4, testFilm.Ratings, "Film should contain the first rating.");
            Assert.Contains(5, testFilm.Ratings, "Film should contain the second rating.");
        }

        [Test]
        public void AddAudienceRating_WithInvalidRating_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Create a film instance
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);

            // Act & Assert
            // Verify that adding rating below 1 throws ArgumentOutOfRangeException
            Assert.Throws<ArgumentOutOfRangeException>(() => testFilm.AddAudienceRating(0), 
                "Adding rating below 1 should throw ArgumentOutOfRangeException.");
            
            // Verify that adding rating above 5 throws ArgumentOutOfRangeException
            Assert.Throws<ArgumentOutOfRangeException>(() => testFilm.AddAudienceRating(6), 
                "Adding rating above 5 should throw ArgumentOutOfRangeException.");
        }

        [Test]
        public void CalculateAverageRating_WithMultipleRatings_ReturnsCorrectAverage()
        {
            // Arrange
            // Create a film instance and add multiple ratings
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);
            testFilm.AddAudienceRating(4);
            testFilm.AddAudienceRating(5);
            testFilm.AddAudienceRating(3);

            // Act
            // Calculate the average rating
            double averageRating = testFilm.CalculateAverageRating();

            // Assert
            // Verify that the calculated average is correct (4+5+3)/3 = 4.0
            Assert.AreEqual(4.0, averageRating, 0.01, "Average rating should be calculated correctly.");
        }

        [Test]
        public void CalculateAverageRating_WithNoRatings_ReturnsZero()
        {
            // Arrange
            // Create a film instance with no ratings
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);

            // Act
            // Calculate the average rating
            double averageRating = testFilm.CalculateAverageRating();

            // Assert
            // Verify that average rating is zero when no ratings exist
            Assert.AreEqual(0.0, averageRating, "Average rating should be zero when no ratings exist.");
        }

        [Test]
        public void SearchForActorByName_WithExistingActor_ReturnsTrue()
        {
            // Arrange
            // Create a film and add an actor
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);
            Actor testActor = new Actor("Tom Hanks", 65);
            testFilm.AddActorToFilm(testActor);

            // Act
            // Search for the actor by name
            bool actorFound = testFilm.SearchForActorByName("Tom Hanks");

            // Assert
            // Verify that the search returns true for existing actor
            Assert.IsTrue(actorFound, "Search should return true for existing actor.");
        }

        [Test]
        public void SearchForActorByName_WithNonExistingActor_ReturnsFalse()
        {
            // Arrange
            // Create a film with no actors
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);

            // Act
            // Search for a non-existing actor
            bool actorFound = testFilm.SearchForActorByName("Non Existing Actor");

            // Assert
            // Verify that the search returns false for non-existing actor
            Assert.IsFalse(actorFound, "Search should return false for non-existing actor.");
        }

        [Test]
        public void ValidateFilmData_WithValidData_ReturnsTrue()
        {
            // Arrange
            // Create a film with valid data
            Film testFilm = new Film(TestFilmTitle, TestFilmGenre, TestFilmYear);

            // Act
            // Validate the film data
            bool isValid = testFilm.ValidateFilmData();

            // Assert
            // Verify that validation passes for valid data
            Assert.IsTrue(isValid, "Validation should pass for film with valid data.");
        }

        #endregion

        #region Data Manager Tests

        [Test]
        public void DataManager_Constructor_CreatesInstanceSuccessfully()
        {
            // Arrange & Act
            // Create a DataManager instance
            DataManager dataManager = new DataManager();

            // Assert
            // Verify that the instance is created successfully
            Assert.IsNotNull(dataManager, "DataManager instance should be created successfully.");
            Assert.IsNotNull(dataManager.GetDataDirectoryPath(), "Data directory path should be set.");
        }

        [Test]
        public void SaveAndLoadFilms_WithValidData_WorksCorrectly()
        {
            // Arrange
            // Create a DataManager and a list of films
            DataManager dataManager = new DataManager();
            List<Film> originalFilms = new List<Film>
            {
                new Film("Test Film 1", "Action", 2020),
                new Film("Test Film 2", "Drama", 2021)
            };

            // Act
            // Save films and then load them back
            bool saveResult = dataManager.SaveFilmsToFile(originalFilms);
            List<Film> loadedFilms = dataManager.LoadFilmsFromFile();

            // Assert
            // Verify that save operation succeeded
            Assert.IsTrue(saveResult, "Save operation should succeed.");
            
            // Verify that loaded films match original films
            Assert.AreEqual(originalFilms.Count, loadedFilms.Count, "Loaded films count should match original count.");
            
            // Verify specific film details
            Assert.AreEqual("Test Film 1", loadedFilms[0].FilmTitle, "First film title should match.");
            Assert.AreEqual("Test Film 2", loadedFilms[1].FilmTitle, "Second film title should match.");
        }

        [Test]
        public void SaveAndLoadActors_WithValidData_WorksCorrectly()
        {
            // Arrange
            // Create a DataManager and a list of actors
            DataManager dataManager = new DataManager();
            List<Actor> originalActors = new List<Actor>
            {
                new Actor("Test Actor 1", 30),
                new Actor("Test Actor 2", 40)
            };

            // Act
            // Save actors and then load them back
            bool saveResult = dataManager.SaveActorsToFile(originalActors);
            List<Actor> loadedActors = dataManager.LoadActorsFromFile();

            // Assert
            // Verify that save operation succeeded
            Assert.IsTrue(saveResult, "Save operation should succeed.");
            
            // Verify that loaded actors match original actors
            Assert.AreEqual(originalActors.Count, loadedActors.Count, "Loaded actors count should match original count.");
            
            // Verify specific actor details
            Assert.AreEqual("Test Actor 1", loadedActors[0].ActorName, "First actor name should match.");
            Assert.AreEqual("Test Actor 2", loadedActors[1].ActorName, "Second actor name should match.");
        }

        [Test]
        public void ValidateDataFiles_WithValidFiles_ReturnsTrue()
        {
            // Arrange
            // Create a DataManager and save some test data
            DataManager dataManager = new DataManager();
            List<Film> testFilms = new List<Film> { new Film("Test Film", "Action", 2020) };
            List<Actor> testActors = new List<Actor> { new Actor("Test Actor", 30) };
            
            dataManager.SaveFilmsToFile(testFilms);
            dataManager.SaveActorsToFile(testActors);

            // Act
            // Validate the data files
            bool validationResult = dataManager.ValidateDataFiles();

            // Assert
            // Verify that validation passes
            Assert.IsTrue(validationResult, "Data file validation should pass for valid files.");
        }

        #endregion

        #region Integration Tests

        [Test]
        public void CompleteWorkflow_CreateFilmWithActorsAndRatings_WorksCorrectly()
        {
            // Arrange
            // Create a comprehensive test scenario
            Film testFilm = new Film("Integration Test Film", "Adventure", 2022);
            Actor leadActor = new Actor("Lead Actor", 35);
            Actor supportingActor = new Actor("Supporting Actor", 28);

            // Act
            // Perform complete workflow operations
            testFilm.AddActorToFilm(leadActor);
            testFilm.AddActorToFilm(supportingActor);
            testFilm.AddAudienceRating(5);
            testFilm.AddAudienceRating(4);
            testFilm.AddAudienceRating(5);

            leadActor.AddFilmToFilmography("Integration Test Film");
            supportingActor.AddFilmToFilmography("Integration Test Film");

            // Assert
            // Verify that all operations completed successfully
            Assert.AreEqual(2, testFilm.Actors.Count, "Film should have two actors.");
            Assert.AreEqual(3, testFilm.Ratings.Count, "Film should have three ratings.");
            Assert.AreEqual(4.67, testFilm.CalculateAverageRating(), 0.01, "Average rating should be calculated correctly.");
            Assert.IsTrue(testFilm.SearchForActorByName("Lead Actor"), "Film should contain the lead actor.");
            Assert.IsTrue(leadActor.SearchForFilmByTitle("Integration Test Film"), "Actor should have the film in filmography.");
        }

        #endregion
    }
}
