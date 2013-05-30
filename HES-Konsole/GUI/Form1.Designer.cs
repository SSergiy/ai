namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InterfaceName = new System.Windows.Forms.TextBox();
            this.MethodenName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Senden = new System.Windows.Forms.Button();
            this.AnzahlAufrufe = new System.Windows.Forms.TextBox();
            this.Empfangen = new System.Windows.Forms.Button();
            this.client = new System.Windows.Forms.TextBox();
            this.clientname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interface";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Methode";
            // 
            // InterfaceName
            // 
            this.InterfaceName.Location = new System.Drawing.Point(15, 25);
            this.InterfaceName.Name = "InterfaceName";
            this.InterfaceName.Size = new System.Drawing.Size(100, 20);
            this.InterfaceName.TabIndex = 2;
            // 
            // MethodenName
            // 
            this.MethodenName.Location = new System.Drawing.Point(15, 65);
            this.MethodenName.Name = "MethodenName";
            this.MethodenName.Size = new System.Drawing.Size(100, 20);
            this.MethodenName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Anzahl";
            // 
            // Senden
            // 
            this.Senden.Location = new System.Drawing.Point(18, 135);
            this.Senden.Name = "Senden";
            this.Senden.Size = new System.Drawing.Size(75, 23);
            this.Senden.TabIndex = 5;
            this.Senden.Text = "Senden";
            this.Senden.UseVisualStyleBackColor = true;
            this.Senden.Click += new System.EventHandler(this.Senden_Click);
            // 
            // AnzahlAufrufe
            // 
            this.AnzahlAufrufe.Location = new System.Drawing.Point(15, 109);
            this.AnzahlAufrufe.Name = "AnzahlAufrufe";
            this.AnzahlAufrufe.Size = new System.Drawing.Size(100, 20);
            this.AnzahlAufrufe.TabIndex = 6;
            // 
            // Empfangen
            // 
            this.Empfangen.Location = new System.Drawing.Point(150, 135);
            this.Empfangen.Name = "Empfangen";
            this.Empfangen.Size = new System.Drawing.Size(75, 23);
            this.Empfangen.TabIndex = 7;
            this.Empfangen.Text = "Empfangen";
            this.Empfangen.UseVisualStyleBackColor = true;
            this.Empfangen.Click += new System.EventHandler(this.Empfangen_Click);
            // 
            // client
            // 
            this.client.Location = new System.Drawing.Point(150, 65);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(100, 20);
            this.client.TabIndex = 8;
            this.client.Text = "Client1";
            // 
            // clientname
            // 
            this.clientname.AutoSize = true;
            this.clientname.Location = new System.Drawing.Point(147, 48);
            this.clientname.Name = "clientname";
            this.clientname.Size = new System.Drawing.Size(64, 13);
            this.clientname.TabIndex = 9;
            this.clientname.Text = "Client Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 208);
            this.Controls.Add(this.clientname);
            this.Controls.Add(this.client);
            this.Controls.Add(this.Empfangen);
            this.Controls.Add(this.AnzahlAufrufe);
            this.Controls.Add(this.Senden);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MethodenName);
            this.Controls.Add(this.InterfaceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InterfaceName;
        private System.Windows.Forms.TextBox MethodenName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Senden;
        private System.Windows.Forms.TextBox AnzahlAufrufe;
        private System.Windows.Forms.Button Empfangen;
        private System.Windows.Forms.TextBox client;
        private System.Windows.Forms.Label clientname;
    }
}

