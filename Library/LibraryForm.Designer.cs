namespace Library
{
    partial class LibraryForm
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
            this.homePanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mtxtbxSSNRadd = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbxInput4 = new System.Windows.Forms.TextBox();
            this.txtbxInput3 = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbxAction = new System.Windows.Forms.ComboBox();
            this.txtbxInput2 = new System.Windows.Forms.TextBox();
            this.txtbxInput1 = new System.Windows.Forms.TextBox();
            this.loanGrpbx = new System.Windows.Forms.GroupBox();
            this.mtxtbxSSNRloan = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.loanListView = new System.Windows.Forms.ListView();
            this.returnLoanButton = new System.Windows.Forms.Button();
            this.cmbxLoanDisplay = new System.Windows.Forms.ComboBox();
            this.displayLoansButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descriptionButton = new System.Windows.Forms.Button();
            this.txtbxDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mtxtbxSSNR1 = new System.Windows.Forms.MaskedTextBox();
            this.searchListView = new System.Windows.Forms.ListView();
            this.chbxInStock = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.loanAllButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxSearchInput = new System.Windows.Forms.TextBox();
            this.cmbxSearchBy = new System.Windows.Forms.ComboBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.ttSSID = new System.Windows.Forms.ToolTip(this.components);
            this.homePanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.loanGrpbx.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // homePanel
            // 
            this.homePanel.Controls.Add(this.groupBox2);
            this.homePanel.Controls.Add(this.loanGrpbx);
            this.homePanel.Controls.Add(this.groupBox1);
            this.homePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homePanel.Location = new System.Drawing.Point(0, 0);
            this.homePanel.Margin = new System.Windows.Forms.Padding(4);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(1984, 1031);
            this.homePanel.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mtxtbxSSNRadd);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtbxInput4);
            this.groupBox2.Controls.Add(this.txtbxInput3);
            this.groupBox2.Controls.Add(this.submitButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbbxAction);
            this.groupBox2.Controls.Add(this.txtbxInput2);
            this.groupBox2.Controls.Add(this.txtbxInput1);
            this.groupBox2.Location = new System.Drawing.Point(1308, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(576, 492);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add/Remove";
            // 
            // mtxtbxSSNRadd
            // 
            this.mtxtbxSSNRadd.Location = new System.Drawing.Point(18, 220);
            this.mtxtbxSSNRadd.Margin = new System.Windows.Forms.Padding(6);
            this.mtxtbxSSNRadd.Mask = "000000-0000";
            this.mtxtbxSSNRadd.Name = "mtxtbxSSNRadd";
            this.mtxtbxSSNRadd.Size = new System.Drawing.Size(196, 31);
            this.mtxtbxSSNRadd.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 248);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // txtbxInput4
            // 
            this.txtbxInput4.Location = new System.Drawing.Point(15, 277);
            this.txtbxInput4.Margin = new System.Windows.Forms.Padding(4);
            this.txtbxInput4.Multiline = true;
            this.txtbxInput4.Name = "txtbxInput4";
            this.txtbxInput4.Size = new System.Drawing.Size(354, 106);
            this.txtbxInput4.TabIndex = 14;
            this.txtbxInput4.Visible = false;
            // 
            // txtbxInput3
            // 
            this.txtbxInput3.Location = new System.Drawing.Point(205, 130);
            this.txtbxInput3.Margin = new System.Windows.Forms.Padding(4);
            this.txtbxInput3.Name = "txtbxInput3";
            this.txtbxInput3.Size = new System.Drawing.Size(180, 31);
            this.txtbxInput3.TabIndex = 11;
            this.txtbxInput3.Visible = false;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(375, 323);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(180, 60);
            this.submitButton.TabIndex = 15;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 174);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "label5";
            // 
            // cbbxAction
            // 
            this.cbbxAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxAction.FormattingEnabled = true;
            this.cbbxAction.Location = new System.Drawing.Point(17, 55);
            this.cbbxAction.Margin = new System.Windows.Forms.Padding(4);
            this.cbbxAction.Name = "cbbxAction";
            this.cbbxAction.Size = new System.Drawing.Size(180, 33);
            this.cbbxAction.TabIndex = 9;
            this.cbbxAction.SelectedIndexChanged += new System.EventHandler(this.cbbxAction_SelectedIndexChanged);
            // 
            // txtbxInput2
            // 
            this.txtbxInput2.Location = new System.Drawing.Point(17, 203);
            this.txtbxInput2.Margin = new System.Windows.Forms.Padding(4);
            this.txtbxInput2.Name = "txtbxInput2";
            this.txtbxInput2.Size = new System.Drawing.Size(180, 31);
            this.txtbxInput2.TabIndex = 12;
            // 
            // txtbxInput1
            // 
            this.txtbxInput1.Location = new System.Drawing.Point(17, 130);
            this.txtbxInput1.Margin = new System.Windows.Forms.Padding(4);
            this.txtbxInput1.Name = "txtbxInput1";
            this.txtbxInput1.Size = new System.Drawing.Size(180, 31);
            this.txtbxInput1.TabIndex = 10;
            // 
            // loanGrpbx
            // 
            this.loanGrpbx.Controls.Add(this.mtxtbxSSNRloan);
            this.loanGrpbx.Controls.Add(this.label9);
            this.loanGrpbx.Controls.Add(this.loanListView);
            this.loanGrpbx.Controls.Add(this.returnLoanButton);
            this.loanGrpbx.Controls.Add(this.cmbxLoanDisplay);
            this.loanGrpbx.Controls.Add(this.displayLoansButton);
            this.loanGrpbx.Location = new System.Drawing.Point(12, 515);
            this.loanGrpbx.Margin = new System.Windows.Forms.Padding(4);
            this.loanGrpbx.Name = "loanGrpbx";
            this.loanGrpbx.Padding = new System.Windows.Forms.Padding(4);
            this.loanGrpbx.Size = new System.Drawing.Size(1292, 496);
            this.loanGrpbx.TabIndex = 2;
            this.loanGrpbx.TabStop = false;
            this.loanGrpbx.Text = "Loaning";
            // 
            // mtxtbxSSNRloan
            // 
            this.mtxtbxSSNRloan.Location = new System.Drawing.Point(12, 275);
            this.mtxtbxSSNRloan.Margin = new System.Windows.Forms.Padding(6);
            this.mtxtbxSSNRloan.Mask = "000000-0000";
            this.mtxtbxSSNRloan.Name = "mtxtbxSSNRloan";
            this.mtxtbxSSNRloan.Size = new System.Drawing.Size(170, 31);
            this.mtxtbxSSNRloan.TabIndex = 16;
            this.mtxtbxSSNRloan.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 244);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "SSNR";
            this.label9.Visible = false;
            // 
            // loanListView
            // 
            this.loanListView.FullRowSelect = true;
            this.loanListView.Location = new System.Drawing.Point(200, 31);
            this.loanListView.Margin = new System.Windows.Forms.Padding(4);
            this.loanListView.MultiSelect = false;
            this.loanListView.Name = "loanListView";
            this.loanListView.Size = new System.Drawing.Size(822, 448);
            this.loanListView.TabIndex = 20;
            this.loanListView.UseCompatibleStateImageBehavior = false;
            this.loanListView.View = System.Windows.Forms.View.Details;
            // 
            // returnLoanButton
            // 
            this.returnLoanButton.Location = new System.Drawing.Point(1028, 419);
            this.returnLoanButton.Margin = new System.Windows.Forms.Padding(4);
            this.returnLoanButton.Name = "returnLoanButton";
            this.returnLoanButton.Size = new System.Drawing.Size(180, 60);
            this.returnLoanButton.TabIndex = 19;
            this.returnLoanButton.Text = "Return selected loan";
            this.returnLoanButton.UseVisualStyleBackColor = true;
            this.returnLoanButton.Click += new System.EventHandler(this.returnLoanButton_Click);
            // 
            // cmbxLoanDisplay
            // 
            this.cmbxLoanDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxLoanDisplay.FormattingEnabled = true;
            this.cmbxLoanDisplay.Location = new System.Drawing.Point(12, 316);
            this.cmbxLoanDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.cmbxLoanDisplay.Name = "cmbxLoanDisplay";
            this.cmbxLoanDisplay.Size = new System.Drawing.Size(180, 33);
            this.cmbxLoanDisplay.TabIndex = 17;
            this.cmbxLoanDisplay.SelectedIndexChanged += new System.EventHandler(this.cmbxLoanDisplay_SelectedIndexChanged);
            // 
            // displayLoansButton
            // 
            this.displayLoansButton.Location = new System.Drawing.Point(12, 362);
            this.displayLoansButton.Margin = new System.Windows.Forms.Padding(4);
            this.displayLoansButton.Name = "displayLoansButton";
            this.displayLoansButton.Size = new System.Drawing.Size(180, 60);
            this.displayLoansButton.TabIndex = 18;
            this.displayLoansButton.Text = "Display";
            this.displayLoansButton.UseVisualStyleBackColor = true;
            this.displayLoansButton.Click += new System.EventHandler(this.displayLoansButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descriptionButton);
            this.groupBox1.Controls.Add(this.txtbxDescription);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.mtxtbxSSNR1);
            this.groupBox1.Controls.Add(this.searchListView);
            this.groupBox1.Controls.Add(this.chbxInStock);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.loanAllButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbxSearchInput);
            this.groupBox1.Controls.Add(this.cmbxSearchBy);
            this.groupBox1.Controls.Add(this.filterButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1292, 496);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // descriptionButton
            // 
            this.descriptionButton.Location = new System.Drawing.Point(13, 415);
            this.descriptionButton.Name = "descriptionButton";
            this.descriptionButton.Size = new System.Drawing.Size(179, 60);
            this.descriptionButton.TabIndex = 5;
            this.descriptionButton.Text = "Description";
            this.descriptionButton.UseVisualStyleBackColor = true;
            this.descriptionButton.Click += new System.EventHandler(this.descriptionButton_Click);
            // 
            // txtbxDescription
            // 
            this.txtbxDescription.Location = new System.Drawing.Point(1028, 55);
            this.txtbxDescription.Multiline = true;
            this.txtbxDescription.Name = "txtbxDescription";
            this.txtbxDescription.ReadOnly = true;
            this.txtbxDescription.Size = new System.Drawing.Size(254, 280);
            this.txtbxDescription.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1023, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "Description";
            // 
            // mtxtbxSSNR1
            // 
            this.mtxtbxSSNR1.Location = new System.Drawing.Point(1042, 379);
            this.mtxtbxSSNR1.Margin = new System.Windows.Forms.Padding(6);
            this.mtxtbxSSNR1.Mask = "000000-0000";
            this.mtxtbxSSNR1.Name = "mtxtbxSSNR1";
            this.mtxtbxSSNR1.Size = new System.Drawing.Size(178, 31);
            this.mtxtbxSSNR1.TabIndex = 6;
            // 
            // searchListView
            // 
            this.searchListView.FullRowSelect = true;
            this.searchListView.Location = new System.Drawing.Point(200, 56);
            this.searchListView.Margin = new System.Windows.Forms.Padding(4);
            this.searchListView.MultiSelect = false;
            this.searchListView.Name = "searchListView";
            this.searchListView.Size = new System.Drawing.Size(824, 427);
            this.searchListView.TabIndex = 19;
            this.searchListView.UseCompatibleStateImageBehavior = false;
            this.searchListView.View = System.Windows.Forms.View.Details;
            // 
            // chbxInStock
            // 
            this.chbxInStock.AutoSize = true;
            this.chbxInStock.Location = new System.Drawing.Point(12, 248);
            this.chbxInStock.Margin = new System.Windows.Forms.Padding(4);
            this.chbxInStock.Name = "chbxInStock";
            this.chbxInStock.Size = new System.Drawing.Size(121, 29);
            this.chbxInStock.TabIndex = 2;
            this.chbxInStock.Text = "In Stock";
            this.chbxInStock.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1036, 348);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "SSNR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Searchresults:";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 348);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(180, 60);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear results";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // loanAllButton
            // 
            this.loanAllButton.Location = new System.Drawing.Point(1042, 420);
            this.loanAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.loanAllButton.Name = "loanAllButton";
            this.loanAllButton.Size = new System.Drawing.Size(180, 60);
            this.loanAllButton.TabIndex = 7;
            this.loanAllButton.Text = "Loan selected book";
            this.loanAllButton.UseVisualStyleBackColor = true;
            this.loanAllButton.Click += new System.EventHandler(this.loanSelectedButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Text to search for:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter by:";
            // 
            // txtbxSearchInput
            // 
            this.txtbxSearchInput.Location = new System.Drawing.Point(12, 90);
            this.txtbxSearchInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtbxSearchInput.Name = "txtbxSearchInput";
            this.txtbxSearchInput.Size = new System.Drawing.Size(180, 31);
            this.txtbxSearchInput.TabIndex = 0;
            // 
            // cmbxSearchBy
            // 
            this.cmbxSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxSearchBy.FormattingEnabled = true;
            this.cmbxSearchBy.Location = new System.Drawing.Point(12, 204);
            this.cmbxSearchBy.Margin = new System.Windows.Forms.Padding(4);
            this.cmbxSearchBy.Name = "cmbxSearchBy";
            this.cmbxSearchBy.Size = new System.Drawing.Size(180, 33);
            this.cmbxSearchBy.TabIndex = 1;
            this.cmbxSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbxSearchBy_SelectedIndexChanged);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(12, 285);
            this.filterButton.Margin = new System.Windows.Forms.Padding(4);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(180, 60);
            this.filterButton.TabIndex = 3;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1984, 1031);
            this.Controls.Add(this.homePanel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "LibraryForm";
            this.Text = "My Library App";
            this.homePanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.loanGrpbx.ResumeLayout(false);
            this.loanGrpbx.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel homePanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxSearchInput;
        private System.Windows.Forms.ComboBox cmbxSearchBy;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.CheckBox chbxInStock;
        private System.Windows.Forms.GroupBox loanGrpbx;
        private System.Windows.Forms.Button loanAllButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button displayLoansButton;
        private System.Windows.Forms.ComboBox cmbxLoanDisplay;
        private System.Windows.Forms.Button returnLoanButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbxAction;
        private System.Windows.Forms.TextBox txtbxInput2;
        private System.Windows.Forms.TextBox txtbxInput1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbxInput4;
        private System.Windows.Forms.TextBox txtbxInput3;
        private System.Windows.Forms.ListView searchListView;
        private System.Windows.Forms.ListView loanListView;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mtxtbxSSNR1;
        private System.Windows.Forms.ToolTip ttSSID;
        private System.Windows.Forms.MaskedTextBox mtxtbxSSNRadd;
        private System.Windows.Forms.MaskedTextBox mtxtbxSSNRloan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtbxDescription;
        private System.Windows.Forms.Button descriptionButton;



    }
}

