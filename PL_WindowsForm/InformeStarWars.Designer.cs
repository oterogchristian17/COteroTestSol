namespace PL_WindowsForm
{
    partial class InformeStarWars
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.starWarsDataSet = new PL_WindowsForm.StarWarsDataSet();
            this.starWarsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.informeTableAdapter1 = new PL_WindowsForm.StarWarsDataSetTableAdapters.InformeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starWarsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starWarsDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.starWarsDataSet;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(501, 304);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // starWarsDataSet
            // 
            this.starWarsDataSet.DataSetName = "StarWarsDataSet";
            this.starWarsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // starWarsDataSetBindingSource
            // 
            this.starWarsDataSetBindingSource.DataSource = this.starWarsDataSet;
            this.starWarsDataSetBindingSource.Position = 0;
            // 
            // informeTableAdapter1
            // 
            this.informeTableAdapter1.ClearBeforeFill = true;
            // 
            // InformeStarWars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 326);
            this.Controls.Add(this.dataGridView1);
            this.Name = "InformeStarWars";
            this.Text = "InformeStarWars";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starWarsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starWarsDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private StarWarsDataSet starWarsDataSet;
        private System.Windows.Forms.BindingSource starWarsDataSetBindingSource;
        private StarWarsDataSetTableAdapters.InformeTableAdapter informeTableAdapter1;
    }
}