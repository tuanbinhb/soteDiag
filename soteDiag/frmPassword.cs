// Decompiled with JetBrains decompiler
// Type: soteDiag.frmPassword
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace soteDiag
{
  public class frmPassword : Form
  {
    public bool cancel = true;
    private string _Password = (string) null;
    private IContainer components = (IContainer) null;
    private TextBox textPassword;
    private Label label1;
    private Button frmOK;

    public string txtPassword
    {
      get
      {
        return this._Password;
      }
    }

    public frmPassword()
    {
      this.InitializeComponent();
      this.textPassword.Text = "";
      this.textPassword.PasswordChar = '*';
      this.textPassword.MaxLength = 15;
    }

    private void frmOK_Click(object sender, EventArgs e)
    {
      this._Password = this.textPassword.Text;
      this.cancel = false;
      this.Visible = false;
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
      this.textPassword = new TextBox();
      this.label1 = new Label();
      this.frmOK = new Button();
      this.SuspendLayout();
      this.textPassword.Location = new Point(27, 67);
      this.textPassword.Name = "textPassword";
      this.textPassword.Size = new Size(148, 20);
      this.textPassword.TabIndex = 0;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(27, 32);
      this.label1.Name = "label1";
      this.label1.Size = new Size(152, 15);
      this.label1.TabIndex = 3;
      this.label1.Text = "Please enter the password";
      this.frmOK.Location = new Point(190, 65);
      this.frmOK.Name = "frmOK";
      this.frmOK.Size = new Size(75, 23);
      this.frmOK.TabIndex = 5;
      this.frmOK.Text = "OK";
      this.frmOK.UseVisualStyleBackColor = true;
      this.frmOK.Click += new EventHandler(this.frmOK_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(312, (int) sbyte.MaxValue);
      this.Controls.Add((Control) this.frmOK);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textPassword);
      this.Name = "frmPasswordBox";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Password";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
