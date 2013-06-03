namespace HES_Monitor_GUI
{
    partial class MonitorGUI
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
            this.components = new System.ComponentModel.Container();
            this.runningInstances = new System.Windows.Forms.ListBox();
            this.newLocalInstance = new System.Windows.Forms.Button();
            this.refreshGUI = new System.Windows.Forms.Timer(this.components);
            this.autoRefresh = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // runningInstances
            // 
            this.runningInstances.FormattingEnabled = true;
            this.runningInstances.Location = new System.Drawing.Point(12, 13);
            this.runningInstances.Name = "runningInstances";
            this.runningInstances.Size = new System.Drawing.Size(520, 108);
            this.runningInstances.TabIndex = 0;
            // 
            // newLocalInstance
            // 
            this.newLocalInstance.Location = new System.Drawing.Point(12, 127);
            this.newLocalInstance.Name = "newLocalInstance";
            this.newLocalInstance.Size = new System.Drawing.Size(131, 23);
            this.newLocalInstance.TabIndex = 2;
            this.newLocalInstance.Text = "Neue Instanz (lokal)";
            this.newLocalInstance.UseVisualStyleBackColor = true;
            this.newLocalInstance.Click += new System.EventHandler(this.newLocalInstance_Click);
            // 
            // refreshGUI
            // 
            this.refreshGUI.Interval = 500;
            this.refreshGUI.Tick += new System.EventHandler(this.refreshGUI_Tick);
            // 
            // autoRefresh
            // 
            this.autoRefresh.AutoSize = true;
            this.autoRefresh.Checked = true;
            this.autoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRefresh.Location = new System.Drawing.Point(12, 156);
            this.autoRefresh.Name = "autoRefresh";
            this.autoRefresh.Size = new System.Drawing.Size(145, 17);
            this.autoRefresh.TabIndex = 3;
            this.autoRefresh.Text = "automatisch aktualisieren";
            this.autoRefresh.UseVisualStyleBackColor = true;
            this.autoRefresh.CheckedChanged += new System.EventHandler(this.autoRefresh_CheckedChanged);
            // 
            // MonitorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 401);
            this.Controls.Add(this.autoRefresh);
            this.Controls.Add(this.newLocalInstance);
            this.Controls.Add(this.runningInstances);
            this.Name = "MonitorGUI";
            this.Text = "Monitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MonitorGUI_FormClosed);
            this.Load += new System.EventHandler(this.MonitorGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox runningInstances;
        private System.Windows.Forms.Button newLocalInstance;
        private System.Windows.Forms.Timer refreshGUI;
        private System.Windows.Forms.CheckBox autoRefresh;
    }
}

