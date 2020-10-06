namespace WindowsFormsApp2
{
    partial class MainFrm
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
            ActiveQueryBuilder.Core.MetadataStructure metadataStructure1 = new ActiveQueryBuilder.Core.MetadataStructure();
            ActiveQueryBuilder.Core.MetadataFilter metadataFilter1 = new ActiveQueryBuilder.Core.MetadataFilter();
            ActiveQueryBuilder.Core.MetadataStructureOptions metadataStructureOptions1 = new ActiveQueryBuilder.Core.MetadataStructureOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.button1 = new System.Windows.Forms.Button();
            this.sqlQuery1 = new ActiveQueryBuilder.Core.SQLQuery(this.components);
            this.sqlContext1 = new ActiveQueryBuilder.Core.SQLContext(this.components);
            this.queryTransformer1 = new ActiveQueryBuilder.Core.QueryTransformer.QueryTransformer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Design Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SQLContext = null;
            // 
            // sqlContext1
            // 
            this.sqlContext1.LoadingOptions.ExcludeFilter.Types = ActiveQueryBuilder.Core.MetadataType.None;
            this.sqlContext1.MetadataProvider = null;
            // 
            // 
            // 
            this.sqlContext1.SQLGenerationOptionsForServer.ExpandVirtualFields = true;
            this.sqlContext1.SQLGenerationOptionsForServer.ExpandVirtualObjects = true;
            this.sqlContext1.SQLGenerationOptionsForServer.UseAltNames = false;
            this.sqlContext1.SyntaxProvider = null;
            metadataStructure1.AllowChildAutoItems = false;
            metadataStructure1.Caption = null;
            metadataStructure1.ImageIndex = -1;
            metadataStructure1.IsDynamic = false;
            metadataFilter1.OwnObjects = true;
            metadataStructure1.MetadataFilter = metadataFilter1;
            metadataStructure1.MetadataName = null;
            metadataStructureOptions1.ProceduresFolderText = "Procedures";
            metadataStructureOptions1.SynonymsFolderText = "Synonyms";
            metadataStructureOptions1.TablesFolderText = "Tables";
            metadataStructureOptions1.ViewsFolderText = "Views";
            metadataStructure1.Options = metadataStructureOptions1;
            metadataStructure1.XML = resources.GetString("metadataStructure1.XML");
            this.sqlContext1.UserQueriesStructure = metadataStructure1;
            // 
            // queryTransformer1
            // 
            this.queryTransformer1.AlwaysExpandColumnsInQuery = false;
            this.queryTransformer1.AlwaysWrapInSubQuery = false;
            this.queryTransformer1.Query = null;
            this.queryTransformer1.QueryProvider = null;
            this.queryTransformer1.RenameDuplicatedColumns = false;
            this.queryTransformer1.SQLGenerationOptions = null;
            this.queryTransformer1.Tag = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 86);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "ActiveQueryBuilder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ActiveQueryBuilder.Core.SQLQuery sqlQuery1;
        private ActiveQueryBuilder.Core.SQLContext sqlContext1;
        private ActiveQueryBuilder.Core.QueryTransformer.QueryTransformer queryTransformer1;
    }
}

