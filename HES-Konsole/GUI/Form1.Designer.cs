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
            this.TextBoxKlasse = new System.Windows.Forms.TextBox();
            this.TextBoxMethode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Senden = new System.Windows.Forms.Button();
            this.TextBoxAufrufe = new System.Windows.Forms.TextBox();
            this.Empfangen = new System.Windows.Forms.Button();
            this.clientTextBox = new System.Windows.Forms.TextBox();
            this.clientname = new System.Windows.Forms.Label();
            this.parameter_label = new System.Windows.Forms.Label();
            this.TextBoxParameter = new System.Windows.Forms.TextBox();
            this.labeldll = new System.Windows.Forms.Label();
            this.TextBoxdll = new System.Windows.Forms.TextBox();
            this.labelnamespace = new System.Windows.Forms.Label();
            this.TextBoxNameSpace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLieferungNummer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAuftragnummer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerAusgang = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerLieferdatum = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonErstelleTransportauftrag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klassenname der Fassade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Methode";
            // 
            // TextBoxKlasse
            // 
            this.TextBoxKlasse.Location = new System.Drawing.Point(16, 102);
            this.TextBoxKlasse.Name = "TextBoxKlasse";
            this.TextBoxKlasse.Size = new System.Drawing.Size(289, 20);
            this.TextBoxKlasse.TabIndex = 2;
            this.TextBoxKlasse.Text = "TransportdienleisterVerwaltungFassade";
            // 
            // TextBoxMethode
            // 
            this.TextBoxMethode.Location = new System.Drawing.Point(16, 141);
            this.TextBoxMethode.Name = "TextBoxMethode";
            this.TextBoxMethode.Size = new System.Drawing.Size(212, 20);
            this.TextBoxMethode.TabIndex = 3;
            this.TextBoxMethode.Text = "HoleLieferungUeberLieferNummerRemote";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Anzahl der Aufrufe";
            // 
            // Senden
            // 
            this.Senden.Location = new System.Drawing.Point(19, 253);
            this.Senden.Name = "Senden";
            this.Senden.Size = new System.Drawing.Size(75, 23);
            this.Senden.TabIndex = 5;
            this.Senden.Text = "Senden";
            this.Senden.UseVisualStyleBackColor = true;
            this.Senden.Click += new System.EventHandler(this.Senden_Click);
            // 
            // TextBoxAufrufe
            // 
            this.TextBoxAufrufe.Location = new System.Drawing.Point(19, 227);
            this.TextBoxAufrufe.Name = "TextBoxAufrufe";
            this.TextBoxAufrufe.Size = new System.Drawing.Size(212, 20);
            this.TextBoxAufrufe.TabIndex = 6;
            this.TextBoxAufrufe.Text = "1";
            // 
            // Empfangen
            // 
            this.Empfangen.Location = new System.Drawing.Point(852, 52);
            this.Empfangen.Name = "Empfangen";
            this.Empfangen.Size = new System.Drawing.Size(75, 23);
            this.Empfangen.TabIndex = 7;
            this.Empfangen.Text = "Empfangen";
            this.Empfangen.UseVisualStyleBackColor = true;
            this.Empfangen.Click += new System.EventHandler(this.Empfangen_Click);
            // 
            // clientTextBox
            // 
            this.clientTextBox.Location = new System.Drawing.Point(852, 26);
            this.clientTextBox.Name = "clientTextBox";
            this.clientTextBox.Size = new System.Drawing.Size(100, 20);
            this.clientTextBox.TabIndex = 8;
            this.clientTextBox.Text = "Client1";
            // 
            // clientname
            // 
            this.clientname.AutoSize = true;
            this.clientname.Location = new System.Drawing.Point(849, 9);
            this.clientname.Name = "clientname";
            this.clientname.Size = new System.Drawing.Size(64, 13);
            this.clientname.TabIndex = 9;
            this.clientname.Text = "Client Name";
            // 
            // parameter_label
            // 
            this.parameter_label.AutoSize = true;
            this.parameter_label.Location = new System.Drawing.Point(16, 166);
            this.parameter_label.Name = "parameter_label";
            this.parameter_label.Size = new System.Drawing.Size(55, 13);
            this.parameter_label.TabIndex = 10;
            this.parameter_label.Text = "Parameter";
            // 
            // TextBoxParameter
            // 
            this.TextBoxParameter.Location = new System.Drawing.Point(19, 182);
            this.TextBoxParameter.Name = "TextBoxParameter";
            this.TextBoxParameter.Size = new System.Drawing.Size(209, 20);
            this.TextBoxParameter.TabIndex = 11;
            this.TextBoxParameter.Text = "1";
            // 
            // labeldll
            // 
            this.labeldll.AutoSize = true;
            this.labeldll.Location = new System.Drawing.Point(12, 9);
            this.labeldll.Name = "labeldll";
            this.labeldll.Size = new System.Drawing.Size(65, 13);
            this.labeldll.TabIndex = 12;
            this.labeldll.Text = "DLL (mit .dll)";
            // 
            // TextBoxdll
            // 
            this.TextBoxdll.Location = new System.Drawing.Point(15, 24);
            this.TextBoxdll.Name = "TextBoxdll";
            this.TextBoxdll.Size = new System.Drawing.Size(290, 20);
            this.TextBoxdll.TabIndex = 13;
            this.TextBoxdll.Text = "TransportdienstleisterVerwaltungKomponente.dll";
            // 
            // labelnamespace
            // 
            this.labelnamespace.AutoSize = true;
            this.labelnamespace.Location = new System.Drawing.Point(13, 47);
            this.labelnamespace.Name = "labelnamespace";
            this.labelnamespace.Size = new System.Drawing.Size(64, 13);
            this.labelnamespace.TabIndex = 14;
            this.labelnamespace.Text = "Namespace";
            // 
            // TextBoxNameSpace
            // 
            this.TextBoxNameSpace.Location = new System.Drawing.Point(16, 63);
            this.TextBoxNameSpace.Name = "TextBoxNameSpace";
            this.TextBoxNameSpace.Size = new System.Drawing.Size(289, 20);
            this.TextBoxNameSpace.TabIndex = 15;
            this.TextBoxNameSpace.Text = "TransportdienstleisterVerwaltungKomponente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Erstelle Transportauftrag";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Lieferung Nummer";
            // 
            // textBoxLieferungNummer
            // 
            this.textBoxLieferungNummer.Location = new System.Drawing.Point(399, 54);
            this.textBoxLieferungNummer.Name = "textBoxLieferungNummer";
            this.textBoxLieferungNummer.Size = new System.Drawing.Size(100, 20);
            this.textBoxLieferungNummer.TabIndex = 18;
            this.textBoxLieferungNummer.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Auftragnummer";
            // 
            // textBoxAuftragnummer
            // 
            this.textBoxAuftragnummer.Location = new System.Drawing.Point(399, 102);
            this.textBoxAuftragnummer.Name = "textBoxAuftragnummer";
            this.textBoxAuftragnummer.Size = new System.Drawing.Size(100, 20);
            this.textBoxAuftragnummer.TabIndex = 20;
            this.textBoxAuftragnummer.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(399, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ausgangsdatum";
            // 
            // dateTimePickerAusgang
            // 
            this.dateTimePickerAusgang.Location = new System.Drawing.Point(399, 140);
            this.dateTimePickerAusgang.Name = "dateTimePickerAusgang";
            this.dateTimePickerAusgang.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerAusgang.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(396, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Lieferung Erfolgt ?";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(399, 183);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(396, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Lieferdatum";
            // 
            // dateTimePickerLieferdatum
            // 
            this.dateTimePickerLieferdatum.Location = new System.Drawing.Point(399, 227);
            this.dateTimePickerLieferdatum.Name = "dateTimePickerLieferdatum";
            this.dateTimePickerLieferdatum.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerLieferdatum.TabIndex = 26;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(397, 269);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.Text = "DHL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(396, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Transportdienstleister";
            // 
            // buttonErstelleTransportauftrag
            // 
            this.buttonErstelleTransportauftrag.Location = new System.Drawing.Point(399, 296);
            this.buttonErstelleTransportauftrag.Name = "buttonErstelleTransportauftrag";
            this.buttonErstelleTransportauftrag.Size = new System.Drawing.Size(75, 23);
            this.buttonErstelleTransportauftrag.TabIndex = 29;
            this.buttonErstelleTransportauftrag.Text = "Erstellen";
            this.buttonErstelleTransportauftrag.UseVisualStyleBackColor = true;
            this.buttonErstelleTransportauftrag.Click += new System.EventHandler(this.buttonErstelleTransportauftrag_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 357);
            this.Controls.Add(this.buttonErstelleTransportauftrag);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePickerLieferdatum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePickerAusgang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAuftragnummer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLieferungNummer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxNameSpace);
            this.Controls.Add(this.labelnamespace);
            this.Controls.Add(this.TextBoxdll);
            this.Controls.Add(this.labeldll);
            this.Controls.Add(this.TextBoxParameter);
            this.Controls.Add(this.parameter_label);
            this.Controls.Add(this.clientname);
            this.Controls.Add(this.clientTextBox);
            this.Controls.Add(this.Empfangen);
            this.Controls.Add(this.TextBoxAufrufe);
            this.Controls.Add(this.Senden);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxMethode);
            this.Controls.Add(this.TextBoxKlasse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "HES Remote Call App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxKlasse;
        private System.Windows.Forms.TextBox TextBoxMethode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Senden;
        private System.Windows.Forms.TextBox TextBoxAufrufe;
        private System.Windows.Forms.Button Empfangen;
        private System.Windows.Forms.TextBox clientTextBox;
        private System.Windows.Forms.Label clientname;
        private System.Windows.Forms.Label parameter_label;
        private System.Windows.Forms.TextBox TextBoxParameter;
        private System.Windows.Forms.Label labeldll;
        private System.Windows.Forms.TextBox TextBoxdll;
        private System.Windows.Forms.Label labelnamespace;
        private System.Windows.Forms.TextBox TextBoxNameSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLieferungNummer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAuftragnummer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerAusgang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePickerLieferdatum;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonErstelleTransportauftrag;
    }
}

