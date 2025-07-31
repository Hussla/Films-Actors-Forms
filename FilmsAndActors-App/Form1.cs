using FilmAndActorsClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FilmsAndActors_App
{
    /// <summary>
    /// Main application form for the Films and Actors management system.
    /// Demonstrates all 11 curriculum topics in a comprehensive Windows Forms application.
    /// Reference: https://docs.microsoft.com/en-us/dotnet/desktop/winforms/
    /// </summary>
    public partial class Form1 : Form
    {
        // Private fields for data management and application state
        private List<Film> _filmsCollection;
        private List<Actor> _actorsCollection;
        private DataManager _dataManager;
        private Film _currentlySelectedFilm;
        private Actor _currentlySelectedActor;

        /// <summary>
        /// Initialises a new instance of the main form.
        /// Sets up data collections and loads existing data from files.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitialiseApplicationData();
            ConfigureUserInterface();
            LoadExistingData();
        }

        /// <summary>
        /// Initialises the application data structures and managers.
        /// Creates empty collections and sets up the data persistence manager.
        /// </summary>
        private void InitialiseApplicationData()
        {
            // Initialise collections for films and actors
            _filmsCollection = new List<Film>();
            _actorsCollection = new List<Actor>();
            
            // Create data manager for file operations
            _dataManager = new DataManager();
            
            // Initialise selected item references
            _currentlySelectedFilm = null;
            _currentlySelectedActor = null;
            
            // Display initialisation message to console
            Console.WriteLine("Application data structures initialised successfully.");
        }

        /// <summary>
        /// Configures the user interface elements with initial settings.
        /// Sets up control properties and placeholder text for better user experience.
        /// </summary>
        private void ConfigureUserInterface()
        {
            // Configure form properties
            this.Text = "Films and Actors Management System";
            this.WindowState = FormWindowState.Maximized;
            
            // Set placeholder text for input controls
            if (titleTextBox.Text == "Title")
            {
                titleTextBox.ForeColor = Color.Gray;
            }
            
            if (genreTextBox.Text == "Genre")
            {
                genreTextBox.ForeColor = Color.Gray;
            }
            
            if (yearTextBox.Text == "Year")
            {
                yearTextBox.ForeColor = Color.Gray;
            }
            
            Console.WriteLine("User interface configured with initial settings.");
        }

        /// <summary>
        /// Loads existing data from persistent storage files.
        /// Populates the application collections with previously saved data.
        /// </summary>
        private void LoadExistingData()
        {
            try
            {
                // Load films from persistent storage
                _filmsCollection = _dataManager.LoadFilmsFromFile();
                
                // Load actors from persistent storage
                _actorsCollection = _dataManager.LoadActorsFromFile();
                
                // Refresh user interface to display loaded data
                RefreshFilmsListBox();
                
                // Display success message to user
                Console.WriteLine($"Loaded {_filmsCollection.Count} films and {_actorsCollection.Count} actors from storage.");
            }
            catch (Exception loadException)
            {
                // Handle loading errors gracefully
                MessageBox.Show($"Error loading existing data: {loadException.Message}", 
                               "Data Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"Data loading failed: {loadException.Message}");
            }
        }

        /// <summary>
        /// Event handler for the Add Film button click event.
        /// Validates user input and creates a new film entry in the database.
        /// Demonstrates input validation, error handling, and collection management.
        /// </summary>
        /// <param name="sender">The button control that triggered the event.</param>
        /// <param name="eventArguments">Event arguments containing click information.</param>
        private void addFilmButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve and validate input from text boxes
                string filmTitle = GetValidatedTextInput(titleTextBox, "Title");
                string filmGenre = GetValidatedTextInput(genreTextBox, "Genre");
                string yearInput = GetValidatedTextInput(yearTextBox, "Year");

                // Validate that all required fields are provided
                if (string.IsNullOrWhiteSpace(filmTitle) || 
                    string.IsNullOrWhiteSpace(filmGenre) || 
                    string.IsNullOrWhiteSpace(yearInput))
                {
                    MessageBox.Show("All fields are required. Please complete the form before adding a film.", 
                                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse and validate the release year
                if (!int.TryParse(yearInput, out int releaseYear))
                {
                    MessageBox.Show("Please enter a valid year as a number.", 
                                   "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    yearTextBox.Focus();
                    return;
                }

                // Check for duplicate films using LINQ and operators
                bool filmAlreadyExists = _filmsCollection.Any(existingFilm => 
                    existingFilm.FilmTitle.Equals(filmTitle, StringComparison.OrdinalIgnoreCase) &&
                    existingFilm.ReleaseYear == releaseYear);

                if (filmAlreadyExists)
                {
                    MessageBox.Show($"A film with the title '{filmTitle}' from {releaseYear} already exists in the database.", 
                                   "Duplicate Film", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create new film object with validated data
                Film newFilm = new Film(filmTitle, filmGenre, releaseYear);
                
                // Add film to collection
                _filmsCollection.Add(newFilm);

                // Save updated data to persistent storage
                bool saveSuccessful = _dataManager.SaveFilmsToFile(_filmsCollection);
                
                if (saveSuccessful)
                {
                    MessageBox.Show($"Film '{filmTitle}' added successfully to the database!", 
                                   "Film Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Clear input fields and refresh display
                    ClearInputFields();
                    RefreshFilmsListBox();
                    
                    // Display success message to console
                    Console.WriteLine($"Successfully added film: {filmTitle} ({releaseYear})");
                }
                else
                {
                    MessageBox.Show("Film was added to memory but could not be saved to file. Please check file permissions.", 
                                   "Save Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException argumentException)
            {
                // Handle validation errors from Film constructor
                MessageBox.Show($"Invalid film data: {argumentException.Message}", 
                               "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"Film validation error: {argumentException.Message}");
            }
            catch (Exception generalException)
            {
                // Handle unexpected errors
                MessageBox.Show($"An unexpected error occurred while adding the film: {generalException.Message}", 
                               "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Unexpected error in addFilmButton_Click: {generalException.Message}");
            }
        }

        /// <summary>
        /// Validates and retrieves text input from a TextBox control.
        /// Handles placeholder text and returns clean input values.
        /// </summary>
        /// <param name="textBox">The TextBox control to validate.</param>
        /// <param name="placeholderText">The placeholder text to check against.</param>
        /// <returns>The validated text input or empty string if invalid.</returns>
        private string GetValidatedTextInput(TextBox textBox, string placeholderText)
        {
            // Check if the text box contains placeholder text or actual input
            if (textBox.Text.Equals(placeholderText, StringComparison.OrdinalIgnoreCase) || 
                string.IsNullOrWhiteSpace(textBox.Text))
            {
                return string.Empty;
            }
            
            return textBox.Text.Trim();
        }

        /// <summary>
        /// Clears all input fields and resets them to placeholder state.
        /// Provides visual feedback to indicate successful form submission.
        /// </summary>
        private void ClearInputFields()
        {
            // Reset title text box
            titleTextBox.Text = "Title";
            titleTextBox.ForeColor = Color.Gray;
            
            // Reset genre text box
            genreTextBox.Text = "Genre";
            genreTextBox.ForeColor = Color.Gray;
            
            // Reset year text box
            yearTextBox.Text = "Year";
            yearTextBox.ForeColor = Color.Gray;
            
            // Set focus to first input field
            titleTextBox.Focus();
        }

        /// <summary>
        /// Refreshes the films ListBox with current data from the collection.
        /// Uses foreach iteration to populate the display with formatted film information.
        /// </summary>
        private void RefreshFilmsListBox()
        {
            // Clear existing items from the ListBox
            filmsListBox.Items.Clear();

            // Check if there are films to display
            if (_filmsCollection.Count == 0)
            {
                filmsListBox.Items.Add("No films available in the database. Add films using the form above.");
                return;
            }

            // Use foreach loop to iterate through the films collection
            foreach (Film currentFilm in _filmsCollection)
            {
                // Format film information for display
                string displayText = $"{currentFilm.FilmTitle} ({currentFilm.ReleaseYear}) - {currentFilm.FilmGenre}";
                
                // Add formatted text to ListBox
                filmsListBox.Items.Add(displayText);
            }
            
            Console.WriteLine($"Films ListBox refreshed with {_filmsCollection.Count} films.");
        }

        /// <summary>
        /// Event handler for the films ListBox selection changed event.
        /// Updates the currently selected film and displays detailed information.
        /// </summary>
        /// <param name="sender">The ListBox control that triggered the event.</param>
        /// <param name="eventArguments">Event arguments containing selection information.</param>
        private void filmsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if a valid item is selected
            if (filmsListBox.SelectedIndex >= 0 && filmsListBox.SelectedIndex < _filmsCollection.Count)
            {
                // Get the selected film from the collection
                _currentlySelectedFilm = _filmsCollection[filmsListBox.SelectedIndex];
                
                // Display detailed film information to console
                Console.WriteLine("=== Selected Film Details ===");
                _currentlySelectedFilm.DisplayFilmInformation();
                
                // Update user interface to show selection
                this.Text = $"Films and Actors Management System - Selected: {_currentlySelectedFilm.FilmTitle}";
            }
            else
            {
                // Clear selection if no valid item is selected
                _currentlySelectedFilm = null;
                this.Text = "Films and Actors Management System";
            }
        }

        /// <summary>
        /// Event handler for the title TextBox text changed event.
        /// Manages placeholder text behaviour and input validation.
        /// </summary>
        /// <param name="sender">The TextBox control that triggered the event.</param>
        /// <param name="eventArguments">Event arguments containing text change information.</param>
        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle placeholder text behaviour
            if (titleTextBox.Focused && titleTextBox.Text == "Title")
            {
                titleTextBox.Text = "";
                titleTextBox.ForeColor = Color.Black;
            }
            else if (!titleTextBox.Focused && string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                titleTextBox.Text = "Title";
                titleTextBox.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Event handler for the Display Films button click event.
        /// Demonstrates collection processing and user interface updates.
        /// </summary>
        /// <param name="sender">The button control that triggered the event.</param>
        /// <param name="eventArguments">Event arguments containing click information.</param>
        private void displayFilms_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear the ListBox before displaying films
                filmsListBox.Items.Clear();

                // Check if there are films to display
                if (_filmsCollection.Count == 0)
                {
                    filmsListBox.Items.Add("No films found in the database.");
                    MessageBox.Show("The film database is currently empty. Add some films to get started!", 
                                   "Empty Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Use for loop to demonstrate iteration with index access
                for (int filmIndex = 0; filmIndex < _filmsCollection.Count; filmIndex++)
                {
                    Film currentFilm = _filmsCollection[filmIndex];
                    
                    // Create detailed display text with film information
                    string detailedInfo = $"{filmIndex + 1}. {currentFilm.FilmTitle} ({currentFilm.ReleaseYear}) - {currentFilm.FilmGenre}";
                    
                    // Add average rating if available
                    double averageRating = currentFilm.CalculateAverageRating();
                    if (averageRating > 0)
                    {
                        detailedInfo += $" - Rating: {averageRating:F1}/5.0";
                    }
                    
                    // Add actor count if available
                    if (currentFilm.Actors.Count > 0)
                    {
                        detailedInfo += $" - Actors: {currentFilm.Actors.Count}";
                    }
                    
                    filmsListBox.Items.Add(detailedInfo);
                }

                // Display summary information
                MessageBox.Show($"Displaying {_filmsCollection.Count} films from the database.", 
                               "Films Displayed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Console.WriteLine($"Displayed complete film list with {_filmsCollection.Count} entries.");
            }
            catch (Exception displayException)
            {
                // Handle display errors
                MessageBox.Show($"Error displaying films: {displayException.Message}", 
                               "Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error in displayFilms_Click: {displayException.Message}");
            }
        }

        /// <summary>
        /// Demonstrates advanced collection operations and LINQ queries.
        /// Provides statistical analysis of the film database.
        /// </summary>
        private void AnalyseFilmDatabase()
        {
            // Use LINQ to perform complex queries on the film collection
            var genreStatistics = _filmsCollection
                .GroupBy(film => film.FilmGenre)
                .Select(group => new { Genre = group.Key, Count = group.Count() })
                .OrderByDescending(stat => stat.Count)
                .ToList();

            // Display genre statistics to console
            Console.WriteLine("=== Film Database Analysis ===");
            Console.WriteLine("Genre Distribution:");
            
            foreach (var genreStat in genreStatistics)
            {
                Console.WriteLine($"- {genreStat.Genre}: {genreStat.Count} films");
            }

            // Calculate year range statistics
            if (_filmsCollection.Count > 0)
            {
                int earliestYear = _filmsCollection.Min(film => film.ReleaseYear);
                int latestYear = _filmsCollection.Max(film => film.ReleaseYear);
                double averageYear = _filmsCollection.Average(film => film.ReleaseYear);

                Console.WriteLine($"Year Range: {earliestYear} - {latestYear}");
                Console.WriteLine($"Average Release Year: {averageYear:F1}");
            }
        }

        /// <summary>
        /// Handles form closing event to ensure data is saved before exit.
        /// Demonstrates proper resource cleanup and data persistence.
        /// </summary>
        /// <param name="sender">The form that is closing.</param>
        /// <param name="eventArguments">Event arguments containing closing information.</param>
        protected override void OnFormClosing(FormClosingEventArgs eventArguments)
        {
            try
            {
                // Save current data before closing
                bool filmsSaved = _dataManager.SaveFilmsToFile(_filmsCollection);
                bool actorsSaved = _dataManager.SaveActorsToFile(_actorsCollection);

                if (!filmsSaved || !actorsSaved)
                {
                    DialogResult result = MessageBox.Show(
                        "Some data could not be saved. Do you want to exit anyway?", 
                        "Save Warning", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        eventArguments.Cancel = true;
                        return;
                    }
                }

                Console.WriteLine("Application closing - data saved successfully.");
            }
            catch (Exception closeException)
            {
                Console.WriteLine($"Error during application close: {closeException.Message}");
            }
            finally
            {
                // Call base implementation
                base.OnFormClosing(eventArguments);
            }
        }
    }
}
