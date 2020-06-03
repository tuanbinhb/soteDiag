// Decompiled with JetBrains decompiler
// Type: soteDiag.frmUploadTestLog
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace soteDiag
{
  public class frmUploadTestLog : Form
  {
    public bool cancel = true;
    private string _PID = (string) null;
    private string _DUTType = (string) null;
    private string _Tester = (string) null;
    private IContainer components = (IContainer) null;
    private TextBox textPID;
    private TextBox textDUTType;
    private Button frmOK;
    private Label label1;
    private Label label2;
    private TextBox textTester;
    private Label label3;

    public string txtPID
    {
      get
      {
        return this._PID;
      }
    }

    public string txtDUTType
    {
      get
      {
        return this._DUTType;
      }
    }

    public string txtTester
    {
      get
      {
        return this._Tester;
      }
    }

    public frmUploadTestLog(string PID, string DUTType, string Tester)
    {
      this.InitializeComponent();
      this.textPID.Text = PID;
      this.textDUTType.Text = DUTType;
      this.textTester.Text = Tester;
    }

    private void frmOK_Click(object sender, EventArgs e)
    {
      this._PID = this.textPID.Text;
      this._DUTType = this.textDUTType.Text;
      this._Tester = this.textTester.Text;
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
      this.textPID = new TextBox();
      this.textDUTType = new TextBox();
      this.frmOK = new Button();
      this.label1 = new Label();
      this.label2 = new Label();
      this.textTester = new TextBox();
      this.label3 = new Label();
      this.SuspendLayout();
      this.textPID.Location = new Point(83, 37);
      this.textPID.Name = "textPID";
      this.textPID.Size = new Size(100, 20);
      this.textPID.TabIndex = 1;
      this.textDUTType.Location = new Point(83, 84);
      this.textDUTType.Name = "textDUTType";
      this.textDUTType.Size = new Size(100, 20);
      this.textDUTType.TabIndex = 2;
      this.frmOK.Location = new Point(217, 37);
      this.frmOK.Name = "frmOK";
      this.frmOK.Size = new Size(62, 23);
      this.frmOK.TabIndex = 4;
      this.frmOK.Text = "OK";
      this.frmOK.UseVisualStyleBackColor = true;
      this.frmOK.Click += new EventHandler(this.frmOK_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 44);
      this.label1.Name = "label1";
      this.label1.Size = new Size(25, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "PID";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(12, 91);
      this.label2.Name = "label2";
      this.label2.Size = new Size(61, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "DUT TYPE";
      this.textTester.Location = new Point(83, 135);
      this.textTester.Name = "textTester";
      this.textTester.Size = new Size(100, 20);
      this.textTester.TabIndex = 3;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(12, 142);
      this.label3.Name = "label3";
      this.label3.Size = new Size(50, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "TESTER";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(309, 196);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.textTester);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.frmOK);
      this.Controls.Add((Control) this.textDUTType);
      this.Controls.Add((Control) this.textPID);
      this.Name = nameof (frmUploadTestLog);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Upload Test Log";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
