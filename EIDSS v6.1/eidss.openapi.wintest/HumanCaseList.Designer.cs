namespace eidss.openapi.wintest
{
    partial class HumanCaseList
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSourceHumanCaseList = new System.Windows.Forms.BindingSource(this.components);
            this.RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEntered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfCompletionOfPaperForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialCaseClassificationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalCaseClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentResidenceCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentResidenceRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentResidenceRayon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentResidenceSettlement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHumanCaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 406);
            this.panel1.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRefresh.Location = new System.Drawing.Point(13, 371);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(30, 69);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(141, 20);
            this.dateTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date to";
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(30, 30);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(141, 20);
            this.dateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date from";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordID,
            this.CaseID,
            this.LocalID,
            this.PatientLastName,
            this.PatientFirstName,
            this.DateEntered,
            this.DateOfBirth,
            this.DateOfCompletionOfPaperForm,
            this.FinalDiagnosis,
            this.initialCaseClassificationDataGridViewTextBoxColumn,
            this.FinalCaseClassification,
            this.CaseStatus,
            this.Age,
            this.AgeType,
            this.CurrentResidenceCountry,
            this.CurrentResidenceRegion,
            this.CurrentResidenceRayon,
            this.CurrentResidenceSettlement});
            this.dataGridView1.DataSource = this.bindingSourceHumanCaseList;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(177, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(760, 406);
            this.dataGridView1.TabIndex = 1;
            // 
            // bindingSourceHumanCaseList
            // 
            this.bindingSourceHumanCaseList.DataSource = typeof(eidss.openapi.contract.HumanCaseListItem);
            // 
            // RecordID
            // 
            this.RecordID.DataPropertyName = "RecordID";
            this.RecordID.HeaderText = "RecordID";
            this.RecordID.Name = "RecordID";
            this.RecordID.ReadOnly = true;
            // 
            // CaseID
            // 
            this.CaseID.DataPropertyName = "CaseID";
            this.CaseID.HeaderText = "CaseID";
            this.CaseID.Name = "CaseID";
            this.CaseID.ReadOnly = true;
            // 
            // LocalID
            // 
            this.LocalID.DataPropertyName = "LocalID";
            this.LocalID.HeaderText = "LocalID";
            this.LocalID.Name = "LocalID";
            this.LocalID.ReadOnly = true;
            // 
            // PatientLastName
            // 
            this.PatientLastName.DataPropertyName = "PatientLastName";
            this.PatientLastName.HeaderText = "PatientLastName";
            this.PatientLastName.Name = "PatientLastName";
            this.PatientLastName.ReadOnly = true;
            // 
            // PatientFirstName
            // 
            this.PatientFirstName.DataPropertyName = "PatientFirstName";
            this.PatientFirstName.HeaderText = "PatientFirstName";
            this.PatientFirstName.Name = "PatientFirstName";
            this.PatientFirstName.ReadOnly = true;
            // 
            // DateEntered
            // 
            this.DateEntered.DataPropertyName = "DateEntered";
            this.DateEntered.HeaderText = "DateEntered";
            this.DateEntered.Name = "DateEntered";
            this.DateEntered.ReadOnly = true;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            this.DateOfBirth.HeaderText = "DateOfBirth";
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            // 
            // DateOfCompletionOfPaperForm
            // 
            this.DateOfCompletionOfPaperForm.DataPropertyName = "DateOfCompletionOfPaperForm";
            this.DateOfCompletionOfPaperForm.HeaderText = "DateOfCompletionOfPaperForm";
            this.DateOfCompletionOfPaperForm.Name = "DateOfCompletionOfPaperForm";
            this.DateOfCompletionOfPaperForm.ReadOnly = true;
            // 
            // FinalDiagnosis
            // 
            this.FinalDiagnosis.DataPropertyName = "FinalDiagnosis";
            this.FinalDiagnosis.HeaderText = "FinalDiagnosis";
            this.FinalDiagnosis.Name = "FinalDiagnosis";
            this.FinalDiagnosis.ReadOnly = true;
            // 
            // initialCaseClassificationDataGridViewTextBoxColumn
            // 
            this.initialCaseClassificationDataGridViewTextBoxColumn.DataPropertyName = "InitialCaseClassification";
            this.initialCaseClassificationDataGridViewTextBoxColumn.HeaderText = "InitialCaseClassification";
            this.initialCaseClassificationDataGridViewTextBoxColumn.Name = "initialCaseClassificationDataGridViewTextBoxColumn";
            this.initialCaseClassificationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FinalCaseClassification
            // 
            this.FinalCaseClassification.DataPropertyName = "FinalCaseClassification";
            this.FinalCaseClassification.HeaderText = "FinalCaseClassification";
            this.FinalCaseClassification.Name = "FinalCaseClassification";
            this.FinalCaseClassification.ReadOnly = true;
            // 
            // CaseStatus
            // 
            this.CaseStatus.DataPropertyName = "CaseStatus";
            this.CaseStatus.HeaderText = "CaseStatus";
            this.CaseStatus.Name = "CaseStatus";
            this.CaseStatus.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // AgeType
            // 
            this.AgeType.DataPropertyName = "AgeType";
            this.AgeType.HeaderText = "AgeType";
            this.AgeType.Name = "AgeType";
            this.AgeType.ReadOnly = true;
            // 
            // CurrentResidenceCountry
            // 
            this.CurrentResidenceCountry.DataPropertyName = "CurrentResidenceCountry";
            this.CurrentResidenceCountry.HeaderText = "CurrentResidenceCountry";
            this.CurrentResidenceCountry.Name = "CurrentResidenceCountry";
            this.CurrentResidenceCountry.ReadOnly = true;
            // 
            // CurrentResidenceRegion
            // 
            this.CurrentResidenceRegion.DataPropertyName = "CurrentResidenceRegion";
            this.CurrentResidenceRegion.HeaderText = "CurrentResidenceRegion";
            this.CurrentResidenceRegion.Name = "CurrentResidenceRegion";
            this.CurrentResidenceRegion.ReadOnly = true;
            // 
            // CurrentResidenceRayon
            // 
            this.CurrentResidenceRayon.DataPropertyName = "CurrentResidenceRayon";
            this.CurrentResidenceRayon.HeaderText = "CurrentResidenceRayon";
            this.CurrentResidenceRayon.Name = "CurrentResidenceRayon";
            this.CurrentResidenceRayon.ReadOnly = true;
            // 
            // CurrentResidenceSettlement
            // 
            this.CurrentResidenceSettlement.DataPropertyName = "CurrentResidenceSettlement";
            this.CurrentResidenceSettlement.HeaderText = "CurrentResidenceSettlement";
            this.CurrentResidenceSettlement.Name = "CurrentResidenceSettlement";
            this.CurrentResidenceSettlement.ReadOnly = true;
            // 
            // HumanCaseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 406);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "HumanCaseList";
            this.Text = "HumanCaseList";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceHumanCaseList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSourceHumanCaseList;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateEntered;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfCompletionOfPaperForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialCaseClassificationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalCaseClassification;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentResidenceCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentResidenceRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentResidenceRayon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentResidenceSettlement;
    }
}