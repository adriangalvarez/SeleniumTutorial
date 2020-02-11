namespace SeleniumTutorial
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenBrowser = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.txtNavigate = new System.Windows.Forms.TextBox();
            this.btnNavigate = new System.Windows.Forms.Button();
            this.txtUsernameFB = new System.Windows.Forms.TextBox();
            this.txtPassFB = new System.Windows.Forms.TextBox();
            this.btnLoginFB = new System.Windows.Forms.Button();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtPost = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnFullscreen = new System.Windows.Forms.Button();
            this.btnGetUrl = new System.Windows.Forms.Button();
            this.btnGetTitle = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenBrowser
            // 
            this.btnOpenBrowser.Location = new System.Drawing.Point(12, 12);
            this.btnOpenBrowser.Name = "btnOpenBrowser";
            this.btnOpenBrowser.Size = new System.Drawing.Size(75, 43);
            this.btnOpenBrowser.TabIndex = 0;
            this.btnOpenBrowser.Text = "Open Browser";
            this.btnOpenBrowser.UseVisualStyleBackColor = true;
            this.btnOpenBrowser.Click += new System.EventHandler(this.btnOpenBrowser_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(93, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(75, 43);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "Minimize Browser";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Location = new System.Drawing.Point(174, 12);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(75, 43);
            this.btnMaximize.TabIndex = 2;
            this.btnMaximize.Text = "Maximize Browser";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // txtNavigate
            // 
            this.txtNavigate.Location = new System.Drawing.Point(12, 61);
            this.txtNavigate.Name = "txtNavigate";
            this.txtNavigate.Size = new System.Drawing.Size(156, 20);
            this.txtNavigate.TabIndex = 3;
            // 
            // btnNavigate
            // 
            this.btnNavigate.Location = new System.Drawing.Point(174, 61);
            this.btnNavigate.Name = "btnNavigate";
            this.btnNavigate.Size = new System.Drawing.Size(75, 23);
            this.btnNavigate.TabIndex = 4;
            this.btnNavigate.Text = "Navigate";
            this.btnNavigate.UseVisualStyleBackColor = true;
            this.btnNavigate.Click += new System.EventHandler(this.btnNavigate_Click_1);
            // 
            // txtUsernameFB
            // 
            this.txtUsernameFB.Location = new System.Drawing.Point(346, 11);
            this.txtUsernameFB.Name = "txtUsernameFB";
            this.txtUsernameFB.PasswordChar = '*';
            this.txtUsernameFB.Size = new System.Drawing.Size(155, 20);
            this.txtUsernameFB.TabIndex = 5;
            // 
            // txtPassFB
            // 
            this.txtPassFB.Location = new System.Drawing.Point(347, 38);
            this.txtPassFB.Name = "txtPassFB";
            this.txtPassFB.PasswordChar = '*';
            this.txtPassFB.Size = new System.Drawing.Size(154, 20);
            this.txtPassFB.TabIndex = 6;
            // 
            // btnLoginFB
            // 
            this.btnLoginFB.Location = new System.Drawing.Point(266, 258);
            this.btnLoginFB.Name = "btnLoginFB";
            this.btnLoginFB.Size = new System.Drawing.Size(236, 38);
            this.btnLoginFB.TabIndex = 7;
            this.btnLoginFB.Text = "Login to FB and Post";
            this.btnLoginFB.UseVisualStyleBackColor = true;
            this.btnLoginFB.Click += new System.EventHandler(this.btnLoginFB_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(347, 65);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(154, 20);
            this.txtGroupName.TabIndex = 8;
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(266, 94);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(236, 158);
            this.txtPost.TabIndex = 9;
            this.txtPost.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "E-mail";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Group";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 97);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 43);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh Browser";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(93, 97);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 42);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Go Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(174, 97);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 42);
            this.btnForward.TabIndex = 13;
            this.btnForward.Text = "Go Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.Location = new System.Drawing.Point(10, 144);
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(75, 39);
            this.btnFullscreen.TabIndex = 17;
            this.btnFullscreen.Text = "Go Fullscreen";
            this.btnFullscreen.UseVisualStyleBackColor = true;
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // btnGetUrl
            // 
            this.btnGetUrl.Location = new System.Drawing.Point(92, 145);
            this.btnGetUrl.Name = "btnGetUrl";
            this.btnGetUrl.Size = new System.Drawing.Size(75, 38);
            this.btnGetUrl.TabIndex = 18;
            this.btnGetUrl.Text = "Get URL";
            this.btnGetUrl.UseVisualStyleBackColor = true;
            this.btnGetUrl.Click += new System.EventHandler(this.btnGetUrl_Click);
            // 
            // btnGetTitle
            // 
            this.btnGetTitle.Location = new System.Drawing.Point(174, 145);
            this.btnGetTitle.Name = "btnGetTitle";
            this.btnGetTitle.Size = new System.Drawing.Size(75, 38);
            this.btnGetTitle.TabIndex = 19;
            this.btnGetTitle.Text = "Get Title";
            this.btnGetTitle.UseVisualStyleBackColor = true;
            this.btnGetTitle.Click += new System.EventHandler(this.btnGetTitle_Click);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(92, 190);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(40, 13);
            this.lblData.TabIndex = 20;
            this.lblData.Text = "lblData";
            this.lblData.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 306);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.btnGetTitle);
            this.Controls.Add(this.btnGetUrl);
            this.Controls.Add(this.btnFullscreen);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.btnLoginFB);
            this.Controls.Add(this.txtPassFB);
            this.Controls.Add(this.txtUsernameFB);
            this.Controls.Add(this.btnNavigate);
            this.Controls.Add(this.txtNavigate);
            this.Controls.Add(this.btnMaximize);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnOpenBrowser);
            this.Name = "Form1";
            this.Text = "SeleniumTutorial";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenBrowser;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.TextBox txtNavigate;
        private System.Windows.Forms.Button btnNavigate;
        private System.Windows.Forms.TextBox txtUsernameFB;
        private System.Windows.Forms.TextBox txtPassFB;
        private System.Windows.Forms.Button btnLoginFB;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.RichTextBox txtPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnFullscreen;
        private System.Windows.Forms.Button btnGetUrl;
        private System.Windows.Forms.Button btnGetTitle;
        private System.Windows.Forms.Label lblData;
    }
}

