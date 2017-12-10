namespace UpdateNTAG
{
    partial class UpdateNTAG
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelConnect = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxCardDetails = new System.Windows.Forms.TextBox();
            this.labelPack = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonGetCard = new System.Windows.Forms.Button();
            this.textBoxUID = new System.Windows.Forms.TextBox();
            this.labelGetCard = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSetCardDetails = new System.Windows.Forms.TabPage();
            this.textBoxSetData = new System.Windows.Forms.TextBox();
            this.groupBoxPage9Data = new System.Windows.Forms.GroupBox();
            this.textBoxPage9Byte0 = new System.Windows.Forms.TextBox();
            this.textBoxPage9Byte1 = new System.Windows.Forms.TextBox();
            this.textBoxPage9Byte2 = new System.Windows.Forms.TextBox();
            this.textBoxPage9Byte3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxLength = new System.Windows.Forms.GroupBox();
            this.radioButton300m = new System.Windows.Forms.RadioButton();
            this.radioButton200m = new System.Windows.Forms.RadioButton();
            this.buttonSetData = new System.Windows.Forms.Button();
            this.groupBoxTemp = new System.Windows.Forms.GroupBox();
            this.radioButton200deg = new System.Windows.Forms.RadioButton();
            this.radioButton210deg = new System.Windows.Forms.RadioButton();
            this.radioButton190deg = new System.Windows.Forms.RadioButton();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSetCardDetails.SuspendLayout();
            this.groupBoxPage9Data.SuspendLayout();
            this.groupBoxLength.SuspendLayout();
            this.groupBoxTemp.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(27, 15);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(91, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelConnect
            // 
            this.labelConnect.AutoSize = true;
            this.labelConnect.Location = new System.Drawing.Point(126, 20);
            this.labelConnect.Name = "labelConnect";
            this.labelConnect.Size = new System.Drawing.Size(0, 13);
            this.labelConnect.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.textBoxCardDetails);
            this.tabPage1.Controls.Add(this.labelPack);
            this.tabPage1.Controls.Add(this.labelPassword);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.buttonGetCard);
            this.tabPage1.Controls.Add(this.textBoxUID);
            this.tabPage1.Controls.Add(this.labelGetCard);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(297, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Get Card Details";
            // 
            // textBoxCardDetails
            // 
            this.textBoxCardDetails.Location = new System.Drawing.Point(22, 156);
            this.textBoxCardDetails.Multiline = true;
            this.textBoxCardDetails.Name = "textBoxCardDetails";
            this.textBoxCardDetails.ReadOnly = true;
            this.textBoxCardDetails.Size = new System.Drawing.Size(254, 249);
            this.textBoxCardDetails.TabIndex = 34;
            // 
            // labelPack
            // 
            this.labelPack.AutoSize = true;
            this.labelPack.Location = new System.Drawing.Point(135, 115);
            this.labelPack.Name = "labelPack";
            this.labelPack.Size = new System.Drawing.Size(0, 13);
            this.labelPack.TabIndex = 33;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(135, 86);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(0, 13);
            this.labelPassword.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Calculated Pack:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Calculated Password:";
            // 
            // buttonGetCard
            // 
            this.buttonGetCard.Enabled = false;
            this.buttonGetCard.Location = new System.Drawing.Point(6, 6);
            this.buttonGetCard.Name = "buttonGetCard";
            this.buttonGetCard.Size = new System.Drawing.Size(122, 23);
            this.buttonGetCard.TabIndex = 2;
            this.buttonGetCard.Text = "Get Card Details";
            this.buttonGetCard.UseVisualStyleBackColor = true;
            this.buttonGetCard.Click += new System.EventHandler(this.buttonGetCard_Click);
            // 
            // textBoxUID
            // 
            this.textBoxUID.Location = new System.Drawing.Point(78, 42);
            this.textBoxUID.MaxLength = 20;
            this.textBoxUID.Name = "textBoxUID";
            this.textBoxUID.ReadOnly = true;
            this.textBoxUID.Size = new System.Drawing.Size(140, 20);
            this.textBoxUID.TabIndex = 3;
            // 
            // labelGetCard
            // 
            this.labelGetCard.AutoSize = true;
            this.labelGetCard.Location = new System.Drawing.Point(154, 11);
            this.labelGetCard.Name = "labelGetCard";
            this.labelGetCard.Size = new System.Drawing.Size(0, 13);
            this.labelGetCard.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "UID :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPageSetCardDetails);
            this.tabControl1.Location = new System.Drawing.Point(27, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(305, 449);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPageSetCardDetails
            // 
            this.tabPageSetCardDetails.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSetCardDetails.Controls.Add(this.textBoxSetData);
            this.tabPageSetCardDetails.Controls.Add(this.groupBoxPage9Data);
            this.tabPageSetCardDetails.Controls.Add(this.label4);
            this.tabPageSetCardDetails.Controls.Add(this.groupBoxLength);
            this.tabPageSetCardDetails.Controls.Add(this.buttonSetData);
            this.tabPageSetCardDetails.Controls.Add(this.groupBoxTemp);
            this.tabPageSetCardDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetCardDetails.Name = "tabPageSetCardDetails";
            this.tabPageSetCardDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetCardDetails.Size = new System.Drawing.Size(297, 423);
            this.tabPageSetCardDetails.TabIndex = 1;
            this.tabPageSetCardDetails.Text = "Set Card Details";
            // 
            // textBoxSetData
            // 
            this.textBoxSetData.Location = new System.Drawing.Point(12, 260);
            this.textBoxSetData.Multiline = true;
            this.textBoxSetData.Name = "textBoxSetData";
            this.textBoxSetData.ReadOnly = true;
            this.textBoxSetData.Size = new System.Drawing.Size(272, 148);
            this.textBoxSetData.TabIndex = 37;
            // 
            // groupBoxPage9Data
            // 
            this.groupBoxPage9Data.Controls.Add(this.textBoxPage9Byte0);
            this.groupBoxPage9Data.Controls.Add(this.textBoxPage9Byte1);
            this.groupBoxPage9Data.Controls.Add(this.textBoxPage9Byte2);
            this.groupBoxPage9Data.Controls.Add(this.textBoxPage9Byte3);
            this.groupBoxPage9Data.Location = new System.Drawing.Point(18, 170);
            this.groupBoxPage9Data.Name = "groupBoxPage9Data";
            this.groupBoxPage9Data.Size = new System.Drawing.Size(260, 46);
            this.groupBoxPage9Data.TabIndex = 36;
            this.groupBoxPage9Data.TabStop = false;
            this.groupBoxPage9Data.Text = "Page 9 data";
            // 
            // textBoxPage9Byte0
            // 
            this.textBoxPage9Byte0.Location = new System.Drawing.Point(76, 15);
            this.textBoxPage9Byte0.MaxLength = 2;
            this.textBoxPage9Byte0.Name = "textBoxPage9Byte0";
            this.textBoxPage9Byte0.Size = new System.Drawing.Size(32, 20);
            this.textBoxPage9Byte0.TabIndex = 28;
            this.textBoxPage9Byte0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPage9Byte1
            // 
            this.textBoxPage9Byte1.Location = new System.Drawing.Point(117, 15);
            this.textBoxPage9Byte1.MaxLength = 2;
            this.textBoxPage9Byte1.Name = "textBoxPage9Byte1";
            this.textBoxPage9Byte1.Size = new System.Drawing.Size(32, 20);
            this.textBoxPage9Byte1.TabIndex = 29;
            this.textBoxPage9Byte1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPage9Byte2
            // 
            this.textBoxPage9Byte2.Location = new System.Drawing.Point(158, 15);
            this.textBoxPage9Byte2.MaxLength = 2;
            this.textBoxPage9Byte2.Name = "textBoxPage9Byte2";
            this.textBoxPage9Byte2.Size = new System.Drawing.Size(32, 20);
            this.textBoxPage9Byte2.TabIndex = 30;
            this.textBoxPage9Byte2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPage9Byte3
            // 
            this.textBoxPage9Byte3.Location = new System.Drawing.Point(199, 15);
            this.textBoxPage9Byte3.MaxLength = 2;
            this.textBoxPage9Byte3.Name = "textBoxPage9Byte3";
            this.textBoxPage9Byte3.Size = new System.Drawing.Size(32, 20);
            this.textBoxPage9Byte3.TabIndex = 31;
            this.textBoxPage9Byte3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Set the required details";
            // 
            // groupBoxLength
            // 
            this.groupBoxLength.Controls.Add(this.radioButton300m);
            this.groupBoxLength.Controls.Add(this.radioButton200m);
            this.groupBoxLength.Location = new System.Drawing.Point(18, 58);
            this.groupBoxLength.Name = "groupBoxLength";
            this.groupBoxLength.Size = new System.Drawing.Size(260, 43);
            this.groupBoxLength.TabIndex = 26;
            this.groupBoxLength.TabStop = false;
            this.groupBoxLength.Text = "Length";
            // 
            // radioButton300m
            // 
            this.radioButton300m.AutoSize = true;
            this.radioButton300m.Checked = true;
            this.radioButton300m.Location = new System.Drawing.Point(180, 19);
            this.radioButton300m.Name = "radioButton300m";
            this.radioButton300m.Size = new System.Drawing.Size(51, 17);
            this.radioButton300m.TabIndex = 11;
            this.radioButton300m.TabStop = true;
            this.radioButton300m.Text = "300m";
            this.radioButton300m.UseVisualStyleBackColor = true;
            // 
            // radioButton200m
            // 
            this.radioButton200m.AutoSize = true;
            this.radioButton200m.Location = new System.Drawing.Point(13, 19);
            this.radioButton200m.Name = "radioButton200m";
            this.radioButton200m.Size = new System.Drawing.Size(51, 17);
            this.radioButton200m.TabIndex = 10;
            this.radioButton200m.Text = "200m";
            this.radioButton200m.UseVisualStyleBackColor = true;
            // 
            // buttonSetData
            // 
            this.buttonSetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSetData.Enabled = false;
            this.buttonSetData.Location = new System.Drawing.Point(12, 231);
            this.buttonSetData.Name = "buttonSetData";
            this.buttonSetData.Size = new System.Drawing.Size(272, 23);
            this.buttonSetData.TabIndex = 32;
            this.buttonSetData.Text = "Set Data";
            this.buttonSetData.UseVisualStyleBackColor = true;
            this.buttonSetData.Click += new System.EventHandler(this.buttonSetData_Click);
            // 
            // groupBoxTemp
            // 
            this.groupBoxTemp.Controls.Add(this.radioButton200deg);
            this.groupBoxTemp.Controls.Add(this.radioButton210deg);
            this.groupBoxTemp.Controls.Add(this.radioButton190deg);
            this.groupBoxTemp.Location = new System.Drawing.Point(18, 110);
            this.groupBoxTemp.Name = "groupBoxTemp";
            this.groupBoxTemp.Size = new System.Drawing.Size(260, 43);
            this.groupBoxTemp.TabIndex = 27;
            this.groupBoxTemp.TabStop = false;
            this.groupBoxTemp.Text = "Temp";
            // 
            // radioButton200deg
            // 
            this.radioButton200deg.AutoSize = true;
            this.radioButton200deg.Location = new System.Drawing.Point(98, 19);
            this.radioButton200deg.Name = "radioButton200deg";
            this.radioButton200deg.Size = new System.Drawing.Size(54, 17);
            this.radioButton200deg.TabIndex = 15;
            this.radioButton200deg.Text = "200°C";
            this.radioButton200deg.UseVisualStyleBackColor = true;
            // 
            // radioButton210deg
            // 
            this.radioButton210deg.AutoSize = true;
            this.radioButton210deg.Checked = true;
            this.radioButton210deg.Location = new System.Drawing.Point(180, 20);
            this.radioButton210deg.Name = "radioButton210deg";
            this.radioButton210deg.Size = new System.Drawing.Size(54, 17);
            this.radioButton210deg.TabIndex = 14;
            this.radioButton210deg.TabStop = true;
            this.radioButton210deg.Text = "210°C";
            this.radioButton210deg.UseVisualStyleBackColor = true;
            // 
            // radioButton190deg
            // 
            this.radioButton190deg.AutoSize = true;
            this.radioButton190deg.Location = new System.Drawing.Point(7, 20);
            this.radioButton190deg.Name = "radioButton190deg";
            this.radioButton190deg.Size = new System.Drawing.Size(54, 17);
            this.radioButton190deg.TabIndex = 13;
            this.radioButton190deg.Text = "190°C";
            this.radioButton190deg.UseVisualStyleBackColor = true;
            // 
            // UpdateNTAG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(352, 511);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelConnect);
            this.Controls.Add(this.buttonConnect);
            this.MinimizeBox = false;
            this.Name = "UpdateNTAG";
            this.Text = "Update NTAG213";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSetCardDetails.ResumeLayout(false);
            this.tabPageSetCardDetails.PerformLayout();
            this.groupBoxPage9Data.ResumeLayout(false);
            this.groupBoxPage9Data.PerformLayout();
            this.groupBoxLength.ResumeLayout(false);
            this.groupBoxLength.PerformLayout();
            this.groupBoxTemp.ResumeLayout(false);
            this.groupBoxTemp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelConnect;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonGetCard;
        private System.Windows.Forms.TextBox textBoxUID;
        private System.Windows.Forms.Label labelGetCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSetCardDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPage9Byte3;
        private System.Windows.Forms.TextBox textBoxPage9Byte2;
        private System.Windows.Forms.TextBox textBoxPage9Byte1;
        private System.Windows.Forms.TextBox textBoxPage9Byte0;
        private System.Windows.Forms.GroupBox groupBoxLength;
        private System.Windows.Forms.RadioButton radioButton300m;
        private System.Windows.Forms.RadioButton radioButton200m;
        private System.Windows.Forms.Button buttonSetData;
        private System.Windows.Forms.GroupBox groupBoxTemp;
        private System.Windows.Forms.RadioButton radioButton200deg;
        private System.Windows.Forms.RadioButton radioButton210deg;
        private System.Windows.Forms.RadioButton radioButton190deg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPack;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxCardDetails;
        private System.Windows.Forms.GroupBox groupBoxPage9Data;
        private System.Windows.Forms.TextBox textBoxSetData;
    }
}

