// Decompiled with JetBrains decompiler
// Type: soteLib.frmPass
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace soteLib
{
  public class frmPass : Form
  {
    private static string _Message = "";
    private IContainer components = (IContainer) null;
    private Label lblStatus;
    private Label lblMessage;
    private PictureBox pictureBox1;
    private Button btnOK;

    public frmPass()
    {
      this.InitializeComponent();
    }

    public string Message
    {
      set
      {
        frmPass._Message = value;
      }
    }

    private void frmStatus_Load(object sender, EventArgs e)
    {
      this.lblMessage.Text = frmPass._Message;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPass));
      this.lblStatus = new Label();
      this.lblMessage = new Label();
      this.pictureBox1 = new PictureBox();
      this.btnOK = new Button();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.lblStatus.AutoSize = true;
      this.lblStatus.Font = new Font("Microsoft Sans Serif", 50.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblStatus.ForeColor = Color.FromArgb(0, 192, 0);
      this.lblStatus.Location = new Point(39, 20);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new Size(217, 76);
      this.lblStatus.TabIndex = 0;
      this.lblStatus.Text = "PASS";
      this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
      this.lblMessage.AutoSize = true;
      this.lblMessage.Font = new Font("Courier New", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessage.Location = new Point(49, 135);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(64, 16);
      this.lblMessage.TabIndex = 1;
      this.lblMessage.Text = "Message";
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(250, 20);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(72, 64);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      this.btnOK.BackColor = Color.Transparent;
      this.btnOK.DialogResult = DialogResult.Cancel;
      this.btnOK.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnOK.ForeColor = Color.Green;
      this.btnOK.Location = new Point(365, 285);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(88, 53);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = false;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.AcceptButton = (IButtonControl) this.btnOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.CancelButton = (IButtonControl) this.btnOK;
      this.ClientSize = new Size(494, 376);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.lblMessage);
      this.Controls.Add((Control) this.lblStatus);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmPass);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "STATUS";
      this.Load += new EventHandler(this.frmStatus_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
