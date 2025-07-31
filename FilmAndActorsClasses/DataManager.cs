using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FilmAndActorsClasses
{
    /// <summary>
    /// Manages data persistence operations for films and actors using JSON serialisation.
    /// Implements file input/output operations with comprehensive error handling.
    /// Reference: https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview
    /// </summary>
    public class DataManager
    {
        // Private fields for file paths and configuration
        private readonly string _filmsDataFilePath;
        private readonly string _actorsDataFilePath;
        private readonly string _dataDirectoryPath;

        /// <summary>
        /// Initialises a new instance of the DataManager class with default file paths.
        /// Creates data directory if it does not exist.
        /// </summary>
        public DataManager()
        {
            // Set default data directory and file paths
            _dataDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FilmsAndActors");
            _filmsDataFilePath = Path.Combine(_dataDirectoryPath, "films.json");
            _actorsDataFilePath = Path.Combine(_dataDirectoryPath, "actors.json");

            // Ensure data directory exists
            CreateDataDirectoryIfNotExists();
        }

        /// <summary>
        /// Initialises a new instance of the DataManager class with custom file paths.
        /// Validates file paths and creates directories as needed.
        /// </summary>
        /// <param name="customDataDirectory">Custom directory path for data storage.</param>
        /// <exception cref="ArgumentException">Thrown when directory path is invalid.</exception>
        public DataManager(string customDataDirectory)
        {
            // Validate custom directory path
            if (string.IsNullOrWhiteSpace(customDataDirectory))
            {
                throw new ArgumentException("Data directory path cannot be null or empty.", nameof(customDataDirectory));
            }

            _dataDirectoryPath = customDataDirectory;
            _filmsDataFilePath = Path.Combine(_dataDirectoryPath, "films.json");
            _actorsDataFilePath = Path.Combine(_dataDirectoryPath, "actors.json");

            // Ensure data directory exists
            CreateDataDirectoryIfNotExists();
        }

        /// <summary>
        /// Creates the data directory if it does not already exist.
        /// Handles directory creation with appropriate error handling.
        /// </summary>
        private void CreateDataDirectoryIfNotExists()
        {
            try
            {
                // Check if directory exists before attempting to create
                if (!Directory.Exists(_dataDirectoryPath))
                {
                    Directory.CreateDirectory(_dataDirectoryPath);
                    Console.WriteLine($"Data directory created: {_dataDirectoryPath}");
                }
            }
            catch (UnauthorizedAccessException unauthorisedAccessException)
            {
                Console.WriteLine($"Access denied when creating directory: {unauthorisedAccessException.Message}");
                throw;
            }
            catch (IOException inputOutputException)
            {
                Console.WriteLine($"Input/Output error when creating directory: {inputOutputException.Message}");
                throw;
            }
            catch (Exception generalException)
            {
                Console.WriteLine($"Unexpected error when creating directory: {generalException.Message}");
                throw;
            }
        }

        /// <summary>
        /// Saves a collection of films to the JSON data file.
        /// Implements comprehensive error handling for file operations.
        /// </summary>
        /// <param name="filmsCollection">The collection of films to save.</param>
        /// <returns>True if save operation succeeded, false otherwise.</returns>
        public bool SaveFilmsToFile(List<Film> filmsCollection)
        {
            // Validate input parameter
            if (filmsCollection == null)
            {
                Console.WriteLine("Cannot save null films collection.");
                return false;
            }

            try
            {
                // Configure JSON serialisation options for readable output
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // Serialise films collection to JSON string
                string jsonContent = JsonSerializer.Serialize(filmsCollection, jsonOptions);

                // Write JSON content to file with proper encoding
                File.WriteAllText(_filmsDataFilePath, jsonContent, System.Text.Encoding.UTF8);

                Console.WriteLine($"Successfully saved {filmsCollection.Count} films to {_filmsDataFilePath}");
                return true;
            }
            catch (UnauthorizedAccessException unauthorisedAccessException)
            {
                Console.WriteLine($"Access denied when saving films: {unauthorisedAccessException.Message}");
                return false;
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                Console.WriteLine($"Directory not found when saving films: {directoryNotFoundException.Message}");
                return false;
            }
            catch (IOException inputOutputException)
            {
                Console.WriteLine($"Input/Output error when saving films: {inputOutputException.Message}");
                return false;
            }
            catch (JsonException jsonException)
            {
                Console.WriteLine($"JSON serialisation error when saving films: {jsonException.Message}");
                return false;
            }
            catch (Exception generalException)
            {
                Console.WriteLine($"Unexpected error when saving films: {generalException.Message}");
                return false;
            }
        }

        /// <summary>
        /// Loads a collection of films from the JSON data file.
        /// Returns empty collection if file does not exist or cannot be read.
        /// </summary>
        /// <returns>Collection of films loaded from file, or empty collection if error occurs.</returns>
        public List<Film> LoadFilmsFromFile()
        {
            try
            {
                // Check if films data file exists
                if (!File.Exists(_filmsDataFilePath))
                {
                    Console.WriteLine($"Films data file not found: {_filmsDataFilePath}");
                    return new List<Film>();
                }

                // Read JSON content from file
                string jsonContent = File.ReadAllText(_filmsDataFilePath, System.Text.Encoding.UTF8);

                // Check if file content is empty
                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    Console.WriteLine("Films data file is empty.");
                    return new List<Film>();
                }

                // Configure JSON deserialisation options
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // Deserialise JSON content to films collection
                List<Film> loadedFilms = JsonSerializer.Deserialize<List<Film>>(jsonContent, jsonOptions);

                // Handle null result from deserialisation
                if (loadedFilms == null)
                {
                    Console.WriteLine("Failed to deserialise films data.");
                    return new List<Film>();
                }

                Console.WriteLine($"Successfully loaded {loadedFilms.Count} films from {_filmsDataFilePath}");
                return loadedFilms;
            }
            catch (UnauthorizedAccessException unauthorisedAccessException)
            {
                Console.WriteLine($"Access denied when loading films: {unauthorisedAccessException.Message}");
                return new List<Film>();
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Console.WriteLine($"Films data file not found: {fileNotFoundException.Message}");
                return new List<Film>();
            }
            catch (IOException inputOutputException)
            {
                Console.WriteLine($"Input/Output error when loading films: {inputOutputException.Message}");
                return new List<Film>();
            }
            catch (JsonException jsonException)
            {
                Console.WriteLine($"JSON deserialisation error when loading films: {jsonException.Message}");
                return new List<Film>();
            }
            catch (Exception generalException)
            {
                Console.WriteLine($"Unexpected error when loading films: {generalException.Message}");
                return new List<Film>();
            }
        }

        /// <summary>
        /// Saves a collection of actors to the JSON data file.
        /// Implements comprehensive error handling for file operations.
        /// </summary>
        /// <param name="actorsCollection">The collection of actors to save.</param>
        /// <returns>True if save operation succeeded, false otherwise.</returns>
        public bool SaveActorsToFile(List<Actor> actorsCollection)
        {
            // Validate input parameter
            if (actorsCollection == null)
            {
                Console.WriteLine("Cannot save null actors collection.");
                return false;
            }

            try
            {
                // Configure JSON serialisation options for readable output
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // Serialise actors collection to JSON string
                string jsonContent = JsonSerializer.Serialize(actorsCollection, jsonOptions);

                // Write JSON content to file with proper encoding
                File.WriteAllText(_actorsDataFilePath, jsonContent, System.Text.Encoding.UTF8);

                Console.WriteLine($"Successfully saved {actorsCollection.Count} actors to {_actorsDataFilePath}");
                return true;
            }
            catch (UnauthorizedAccessException unauthorisedAccessException)
            {
                Console.WriteLine($"Access denied when saving actors: {unauthorisedAccessException.Message}");
                return false;
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                Console.WriteLine($"Directory not found when saving actors: {directoryNotFoundException.Message}");
                return false;
            }
            catch (IOException inputOutputException)
            {
                Console.WriteLine($"Input/Output error when saving actors: {inputOutputException.Message}");
                return false;
            }
            catch (JsonException jsonException)
            {
                Console.WriteLine($"JSON serialisation error when saving actors: {jsonException.Message}");
                return false;
            }
            catch (Exception generalException)
            {
                Console.WriteLine($"Unexpected error when saving actors: {generalException.Message}");
                return false;
            }
        }

        /// <summary>
        /// Loads a collection of actors from the JSON data file.
        /// Returns empty collection if file does not exist or cannot be read.
        /// </summary>
        /// <returns>Collection of actors loaded from file, or empty collection if error occurs.</returns>
        public List<Actor> LoadActorsFromFile()
        {
            try
            {
                // Check if actors data file exists
                if (!File.Exists(_actorsDataFilePath))
                {
                    Console.WriteLine($"Actors data file not found: {_actorsDataFilePath}");
                    return new List<Actor>();
                }

                // Read JSON content from file
                string jsonContent = File.ReadAllText(_actorsDataFilePath, System.Text.Encoding.UTF8);

                // Check if file content is empty
                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    Console.WriteLine("Actors data file is empty.");
                    return new List<Actor>();
                }

                // Configure JSON deserialisation options
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // Deserialise JSON content to actors collection
                List<Actor> loadedActors = JsonSerializer.Deserialize<List<Actor>>(jsonContent, jsonOptions);

                // Handle null result from deserialisation
                if (loadedActors == null)
                {
                    Console.WriteLine("Failed to deserialise actors data.");
                    return new List<Actor>();
                }

                Console.WriteLine($"Successfully loaded {loadedActors.Count} actors from {_actorsDataFilePath}");
                return loadedActors;
            }
            catch (UnauthorizedAccessException unauthorisedAccessException)
            {
                Console.WriteLine($"Access denied when loading actors: {unauthorisedAccessException.Message}");
                return new List<Actor>();
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Console.WriteLine($"Actors data file not found: {fileNotFoundException.Message}");
                return new List<Actor>();
            }
            catch (IOException inputOutputException)
            {
                Console.WriteLine($"Input/Output error when loading actors: {inputOutputException.Message}");
                return new List<Actor>();
            }
            catch (JsonException jsonException)
            {
                Console.WriteLine($"JSON deserialisation error when loading actors: {jsonException.Message}");
                return new List<Actor>();
            }
            catch (Exception generalException)
            {
                Console.WriteLine($"Unexpected error when loading actors: {generalException.Message}");
                return new List<Actor>();
            }
        }

        /// <summary>
        /// Creates a backup of the current data files with timestamp.
        /// Useful for data recovery and version management.
        /// </summary>
        /// <returns>True if backup operation succeeded, false otherwise.</returns>
        public bool CreateDataBackup()
        {
            try
            {
                // Generate timestamp for backup file names
                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupDirectory = Path.Combine(_dataDirectoryPath, "Backups");

                // Create backup directory if it doesn't exist
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }

                // Create backup file paths
                string filmsBackupPath = Path.Combine(backupDirectory, $"films_backup_{timeStamp}.json");
                string actorsBackupPath = Path.Combine(backupDirectory, $"actors_backup_{timeStamp}.json");

                // Copy films data file if it exists
                if (File.Exists(_filmsDataFilePath))
                {
                    File.Copy(_filmsDataFilePath, filmsBackupPath, true);
                    Console.WriteLine($"Films backup created: {filmsBackupPath}");
                }

                // Copy actors data file if it exists
                if (File.Exists(_actorsDataFilePath))
                {
                    File.Copy(_actorsDataFilePath, actorsBackupPath, true);
                    Console.WriteLine($"Actors backup created: {actorsBackupPath}");
                }

                Console.WriteLine("Data backup completed successfully.");
                return true;
            }
            catch (UnauthorizedAccessException unauthorisedAccessException)
            {
                Console.WriteLine($"Access denied when creating backup: {unauthorisedAccessException.Message}");
                return false;
            }
            catch (IOException inputOutputException)
            {
                Console.WriteLine($"Input/Output error when creating backup: {inputOutputException.Message}");
                return false;
            }
            catch (Exception generalException)
            {
                Console.WriteLine($"Unexpected error when creating backup: {generalException.Message}");
                return false;
            }
        }

        /// <summary>
        /// Validates the integrity of data files by attempting to load them.
        /// Useful for checking data consistency and file corruption.
        /// </summary>
        /// <returns>True if all data files are valid, false otherwise.</returns>
        public bool ValidateDataFiles()
        {
            bool filmsValid = true;
            bool actorsValid = true;

            Console.WriteLine("Validating data files...");

            // Validate films data file
            try
            {
                List<Film> testFilms = LoadFilmsFromFile();
                Console.WriteLine($"Films data file validation: {testFilms.Count} films loaded successfully.");
            }
            catch (Exception filmsException)
            {
                Console.WriteLine($"Films data file validation failed: {filmsException.Message}");
                filmsValid = false;
            }

            // Validate actors data file
            try
            {
                List<Actor> testActors = LoadActorsFromFile();
                Console.WriteLine($"Actors data file validation: {testActors.Count} actors loaded successfully.");
            }
            catch (Exception actorsException)
            {
                Console.WriteLine($"Actors data file validation failed: {actorsException.Message}");
                actorsValid = false;
            }

            bool overallValid = filmsValid && actorsValid;
            Console.WriteLine($"Data files validation result: {(overallValid ? "PASSED" : "FAILED")}");
            
            return overallValid;
        }

        /// <summary>
        /// Gets the full path to the films data file.
        /// Used for debugging and file management operations.
        /// </summary>
        /// <returns>The complete file path for films data storage.</returns>
        public string GetFilmsDataFilePath()
        {
            return _filmsDataFilePath;
        }

        /// <summary>
        /// Gets the full path to the actors data file.
        /// Used for debugging and file management operations.
        /// </summary>
        /// <returns>The complete file path for actors data storage.</returns>
        public string GetActorsDataFilePath()
        {
            return _actorsDataFilePath;
        }

        /// <summary>
        /// Gets the data directory path where all data files are stored.
        /// Used for file management and directory operations.
        /// </summary>
        /// <returns>The complete directory path for data storage.</returns>
        public string GetDataDirectoryPath()
        {
            return _dataDirectoryPath;
        }
    }
}
