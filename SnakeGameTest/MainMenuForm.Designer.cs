namespace SnakeGameTest
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPlayerHighscore = new System.Windows.Forms.Label();
            this.btnScoreboard = new System.Windows.Forms.Button();
            this.btnLeaderboard = new System.Windows.Forms.Button();
            this.lblHighscoreLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Gold;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(213, 349);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(174, 40);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Quit Game";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Gold;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPlay.Location = new System.Drawing.Point(213, 184);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(174, 40);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Red;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogin.Location = new System.Drawing.Point(451, 39);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(136, 36);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login/Register";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.Color.Navy;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.Red;
            this.lblPlayerName.Location = new System.Drawing.Point(238, 85);
            this.lblPlayerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(132, 26);
            this.lblPlayerName.TabIndex = 3;
            this.lblPlayerName.Text = "Guest Player";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerHighscore
            // 
            this.lblPlayerHighscore.AutoSize = true;
            this.lblPlayerHighscore.Font = new System.Drawing.Font("Press Start 2P", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerHighscore.ForeColor = System.Drawing.Color.Yellow;
            this.lblPlayerHighscore.Location = new System.Drawing.Point(293, 153);
            this.lblPlayerHighscore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerHighscore.Name = "lblPlayerHighscore";
            this.lblPlayerHighscore.Size = new System.Drawing.Size(18, 12);
            this.lblPlayerHighscore.TabIndex = 4;
            this.lblPlayerHighscore.Text = "0";
            this.lblPlayerHighscore.Visible = false;
            // 
            // btnScoreboard
            // 
            this.btnScoreboard.BackColor = System.Drawing.Color.Gold;
            this.btnScoreboard.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnScoreboard.Location = new System.Drawing.Point(213, 241);
            this.btnScoreboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnScoreboard.Name = "btnScoreboard";
            this.btnScoreboard.Size = new System.Drawing.Size(174, 40);
            this.btnScoreboard.TabIndex = 5;
            this.btnScoreboard.Text = "Scoreboard";
            this.btnScoreboard.UseVisualStyleBackColor = false;
            this.btnScoreboard.Click += new System.EventHandler(this.btnScoreboard_Click);
            // 
            // btnLeaderboard
            // 
            this.btnLeaderboard.BackColor = System.Drawing.Color.Gold;
            this.btnLeaderboard.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLeaderboard.Location = new System.Drawing.Point(213, 296);
            this.btnLeaderboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeaderboard.Name = "btnLeaderboard";
            this.btnLeaderboard.Size = new System.Drawing.Size(174, 40);
            this.btnLeaderboard.TabIndex = 6;
            this.btnLeaderboard.Text = "Global Players";
            this.btnLeaderboard.UseVisualStyleBackColor = false;
            this.btnLeaderboard.Click += new System.EventHandler(this.btnLeaderboard_Click);
            // 
            // lblHighscoreLabel
            // 
            this.lblHighscoreLabel.AutoSize = true;
            this.lblHighscoreLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblHighscoreLabel.ForeColor = System.Drawing.Color.Yellow;
            this.lblHighscoreLabel.Location = new System.Drawing.Point(244, 118);
            this.lblHighscoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHighscoreLabel.Name = "lblHighscoreLabel";
            this.lblHighscoreLabel.Size = new System.Drawing.Size(117, 26);
            this.lblHighscoreLabel.TabIndex = 7;
            this.lblHighscoreLabel.Text = "High Score";
            this.lblHighscoreLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Press Start 2P", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "SNAKE GAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(572, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(600, 408);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHighscoreLabel);
            this.Controls.Add(this.btnLeaderboard);
            this.Controls.Add(this.btnScoreboard);
            this.Controls.Add(this.lblPlayerHighscore);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblPlayerHighscore;
        private System.Windows.Forms.Button btnScoreboard;
        private System.Windows.Forms.Button btnLeaderboard;
        private System.Windows.Forms.Label lblHighscoreLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}