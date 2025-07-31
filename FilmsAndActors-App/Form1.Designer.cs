namespace FilmsAndActors_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddFilm = new Button();
            titleTextBox = new TextBox();
            genreTextBox = new TextBox();
            yearTextBox = new TextBox();
            filmsListBox = new ListBox();
            displayFilms = new Button();
            SuspendLayout();
            // 
            // AddFilm
            // 
            AddFilm.Location = new Point(213, 288);
            AddFilm.Name = "AddFilm";
            AddFilm.Size = new Size(75, 23);
            AddFilm.TabIndex = 0;
            AddFilm.Text = "Add Film";
            AddFilm.UseVisualStyleBackColor = true;
            AddFilm.Click += addFilmButton_Click;
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(55, 12);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(120, 23);
            titleTextBox.TabIndex = 1;
            titleTextBox.Text = "Title";
            titleTextBox.TextAlign = HorizontalAlignment.Center;
            titleTextBox.TextChanged += titleTextBox_TextChanged;
            // 
            // genreTextBox
            // 
            genreTextBox.Location = new Point(181, 12);
            genreTextBox.Name = "genreTextBox";
            genreTextBox.Size = new Size(129, 23);
            genreTextBox.TabIndex = 2;
            genreTextBox.Text = "Genre";
            genreTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // yearTextBox
            // 
            yearTextBox.Location = new Point(316, 12);
            yearTextBox.Name = "yearTextBox";
            yearTextBox.Size = new Size(100, 23);
            yearTextBox.TabIndex = 3;
            yearTextBox.Text = "Year";
            yearTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // filmsListBox
            // 
            filmsListBox.FormattingEnabled = true;
            filmsListBox.ItemHeight = 15;
            filmsListBox.Location = new Point(33, 53);
            filmsListBox.Name = "filmsListBox";
            filmsListBox.Size = new Size(434, 229);
            filmsListBox.TabIndex = 4;
            filmsListBox.SelectedIndexChanged += filmsListBox_SelectedIndexChanged;
            // 
            // displayFilms
            // 
            displayFilms.Location = new Point(194, 317);
            displayFilms.Name = "displayFilms";
            displayFilms.Size = new Size(107, 23);
            displayFilms.TabIndex = 5;
            displayFilms.Text = "Display Films";
            displayFilms.UseVisualStyleBackColor = true;
            displayFilms.Click += displayFilms_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(displayFilms);
            Controls.Add(filmsListBox);
            Controls.Add(yearTextBox);
            Controls.Add(genreTextBox);
            Controls.Add(titleTextBox);
            Controls.Add(AddFilm);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddFilm;
        private TextBox titleTextBox;
        private TextBox genreTextBox;
        private TextBox yearTextBox;
        private ListBox filmsListBox;
        private Button displayFilms;
    }
}
