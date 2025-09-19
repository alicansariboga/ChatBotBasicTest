namespace WinFormsApp1
{
    partial class XtraMainForm
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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            rchChat = new RichTextBox();
            btnSendMsg = new DevExpress.XtraEditors.SimpleButton();
            txtUserMsg = new DevExpress.XtraEditors.MemoEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtUserMsg.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(rchChat);
            layoutControl1.Controls.Add(btnSendMsg);
            layoutControl1.Controls.Add(txtUserMsg);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(348, 330);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // rchChat
            // 
            rchChat.Location = new Point(12, 12);
            rchChat.Name = "rchChat";
            rchChat.Size = new Size(324, 250);
            rchChat.TabIndex = 6;
            rchChat.Text = "";
            // 
            // btnSendMsg
            // 
            btnSendMsg.Location = new Point(262, 266);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(74, 52);
            btnSendMsg.StyleController = layoutControl1;
            btnSendMsg.TabIndex = 5;
            btnSendMsg.Text = "Gönder";
            btnSendMsg.Click += btnSendMsg_Click;
            // 
            // txtUserMsg
            // 
            txtUserMsg.Location = new Point(59, 266);
            txtUserMsg.Name = "txtUserMsg";
            txtUserMsg.Size = new Size(199, 52);
            txtUserMsg.StyleController = layoutControl1;
            txtUserMsg.TabIndex = 4;
            txtUserMsg.KeyDown += txtUserMsg_KeyDown;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new Size(348, 330);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtUserMsg;
            layoutControlItem1.Location = new Point(0, 254);
            layoutControlItem1.MaxSize = new Size(0, 56);
            layoutControlItem1.MinSize = new Size(61, 56);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(250, 56);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.Text = "Mesaj :";
            layoutControlItem1.TextSize = new Size(35, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btnSendMsg;
            layoutControlItem2.Location = new Point(250, 254);
            layoutControlItem2.MaxSize = new Size(0, 56);
            layoutControlItem2.MinSize = new Size(46, 56);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(78, 56);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = rchChat;
            layoutControlItem3.Location = new Point(0, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(328, 254);
            layoutControlItem3.Text = "Text";
            layoutControlItem3.TextSize = new Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // XtraMainForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 330);
            Controls.Add(layoutControl1);
            Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "XtraMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatBot";
            Load += XtraMainForm_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtUserMsg.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private RichTextBox rchChat;
        private DevExpress.XtraEditors.SimpleButton btnSendMsg;
        private DevExpress.XtraEditors.MemoEdit txtUserMsg;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}