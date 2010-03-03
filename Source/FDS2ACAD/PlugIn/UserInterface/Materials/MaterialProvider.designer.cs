﻿namespace Fds2AcadPlugin.UserInterface.Materials
{
    partial class MaterialProvider
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.lbMaterials = new System.Windows.Forms.ListBox();
            this.cbMaterialTypes = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 61);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.On_btnEdit_Click);
            // 
            // lbMaterials
            // 
            this.lbMaterials.FormattingEnabled = true;
            this.lbMaterials.Location = new System.Drawing.Point(166, 12);
            this.lbMaterials.Name = "lbMaterials";
            this.lbMaterials.Size = new System.Drawing.Size(209, 225);
            this.lbMaterials.TabIndex = 1;
            // 
            // cbMaterialTypes
            // 
            this.cbMaterialTypes.FormattingEnabled = true;
            this.cbMaterialTypes.Items.AddRange(new object[] {
            "Лесной",
            "Нефтехимический"});
            this.cbMaterialTypes.Location = new System.Drawing.Point(12, 12);
            this.cbMaterialTypes.Name = "cbMaterialTypes";
            this.cbMaterialTypes.Size = new System.Drawing.Size(121, 21);
            this.cbMaterialTypes.TabIndex = 2;
            this.cbMaterialTypes.SelectedIndexChanged += new System.EventHandler(this.On_cbMaterialType_SelectedIndexChanged);
            this.cbMaterialTypes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.On_cbMaterialTypes_KeyPressed);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.On_btnAdd_Click);
            // 
            // MaterialProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 292);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbMaterialTypes);
            this.Controls.Add(this.lbMaterials);
            this.Controls.Add(this.btnEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(395, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(395, 320);
            this.Name = "MaterialProvider";
            this.Text = "Materials Provider";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.On_MaterialProvider_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListBox lbMaterials;
        private System.Windows.Forms.ComboBox cbMaterialTypes;
        private System.Windows.Forms.Button btnAdd;
    }
}