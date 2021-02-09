namespace tic_tac_toe
{
    partial class SettingsView
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
            MainMenuView.Show();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DifficultyBox;
        private System.Windows.Forms.ComboBox ThemeBox;
        private System.Windows.Forms.TextBox PSymbolBox;
        private System.Windows.Forms.TextBox CSymbolBox;
        private System.Windows.Forms.Button CancelButton;
    }
}

