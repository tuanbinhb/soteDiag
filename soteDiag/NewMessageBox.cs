// Decompiled with JetBrains decompiler
// Type: soteDiag.NewMessageBox
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace soteDiag
{
  public class NewMessageBox : Form
  {
    private static string _Message = "";
    private IContainer components = (IContainer) null;
    private Button btnOK;
    private TextBox textMessage;

    public NewMessageBox()
    {
      this.InitializeComponent();
    }

    public string Message
    {
      set
      {
        NewMessageBox._Message = value;
      }
    }

    private void form_Load(object sender, EventArgs e)
    {
      this.textMessage.Text = NewMessageBox._Message;
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
      this.btnOK = new Button();
      this.textMessage = new TextBox();
      this.SuspendLayout();
      this.btnOK.BackColor = Color.Transparent;
      this.btnOK.DialogResult = DialogResult.Cancel;
      this.btnOK.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnOK.ForeColor = Color.Green;
      this.btnOK.Location = new Point(217, 131);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(84, 56);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = false;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.textMessage.BackColor = SystemColors.ControlLightLight;
      this.textMessage.BorderStyle = BorderStyle.None;
      this.textMessage.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textMessage.Location = new Point(22, 21);
      this.textMessage.Multiline = true;
      this.textMessage.Name = "textMessage";
      this.textMessage.ReadOnly = true;
      this.textMessage.Size = new Size(445, 84);
      this.textMessage.TabIndex = 3;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.btnOK;
      this.ClientSize = new Size(489, 199);
      this.Controls.Add((Control) this.textMessage);
      this.Controls.Add((Control) this.btnOK);
      this.Name = nameof (NewMessageBox);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Message";
      this.Load += new EventHandler(this.form_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
