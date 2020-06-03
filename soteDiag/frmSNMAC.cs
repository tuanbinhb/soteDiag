// Decompiled with JetBrains decompiler
// Type: soteDiag.frmSNMAC
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace soteDiag
{
  public class frmSNMAC : Form
  {
    public bool cancel = true;
    private string _SerialNumber = (string) null;
    private string _MACAddress = (string) null;
    private IContainer components = (IContainer) null;
    private const string PN_Boerne = "PBQSA";
    private const string PN_Putnam = "PBYWT";
    private const string PN_BUBBLES = "PWVQV";
    private const string PN_CASPIAN = "SN37A28236";
    private const string PN_ARAL = "SN37A28240";
    private const string PN_Woodville = "PBKRQ";
    private const string PN_BOAR = "PFDMD";
    private const string PN_BANDICOOT = "PFDMB";
    private const string PN_BOBCAT = "PFCJK";
    private const string PN_BOBOLINK = "PFDME";
    private const int ESR = 90;
    private const int ESR_GENERIC = 10;
    public int sfistype;
    public int testMode;
    private Label label1;
    private Label label2;
    private TextBox frmSN;
    private TextBox frmMAC;
    private Button frmOK;
    private Label label3;

    public string SerialNumber
    {
      get
      {
        return this._SerialNumber;
      }
    }

    public string MACAddress
    {
      get
      {
        return this._MACAddress;
      }
    }

    public frmSNMAC(int sfistype, int testMode)
    {
      this.InitializeComponent();
      this.sfistype = sfistype;
      this.testMode = testMode;
    }

    private void frmSN_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.frmMAC.Focus();
    }

    private void frmSN_Leave(object sender, EventArgs e)
    {
      if (this.sfistype == 90 && this.testMode != 10)
      {
        if (this.frmSN.Text.Length == 7)
          this.frmSN.Focus();
        else if (this.frmSN.Text.Substring(0, 1).Contains("C") && this.frmSN.Text.Length == 8)
        {
          this.frmSN.Focus();
        }
        else
        {
          if (!this.frmSN.Text.Substring(0, 6).Contains("000AF7") && !this.frmSN.Text.Substring(0, 6).Contains("001018") || this.frmSN.Text.Length != 12)
            return;
          this.frmSN.Focus();
        }
      }
      else if (this.sfistype == 90 && this.testMode == 10 && (this.frmSN.Text.Substring(0, 6).Contains("000AF7") || this.frmSN.Text.Substring(0, 6).Contains("001018")))
        this.frmSN.Text = this.frmSN.Text.Substring(4, this.frmSN.Text.Length - 4);
      else if (this.frmSN.Text.StartsWith("PBQSA"))
      {
        if (this.frmSN.Text.Length != 14)
          return;
        this.frmSN.Focus();
      }
      else if (this.frmSN.Text.StartsWith("PBYWT"))
      {
        if (this.frmSN.Text.Length != 14)
          return;
        this.frmSN.Focus();
      }
      else if (this.frmSN.Text.StartsWith("PWVQV"))
      {
        if (this.frmSN.Text.Length != 14)
          return;
        this.frmSN.Focus();
      }
      else if (this.frmSN.Text.StartsWith("PBKRQ"))
      {
        if (this.frmSN.Text.Length != 14)
          return;
        this.frmSN.Focus();
      }
      else if (this.frmSN.Text.StartsWith("PFDMD"))
      {
        if (this.frmSN.Text.Length != 14)
          return;
        this.frmSN.Focus();
      }
      else if (this.frmSN.Text.StartsWith("PFDMB"))
      {
        if (this.frmSN.Text.Length != 14)
          return;
        this.frmSN.Focus();
      }
      else if (this.frmSN.Text.StartsWith("PFCJK"))
      {
        if (this.frmSN.Text.Length != 14)
          return;
        this.frmSN.Focus();
      }
      else
      {
        if (!this.frmSN.Text.StartsWith("PFDME") || this.frmSN.Text.Length != 14)
          return;
        this.frmSN.Focus();
      }
    }

    private void frmMAC_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.frmOK_Click(sender, (EventArgs) e);
    }

    private void frmOK_Click(object sender, EventArgs e)
    {
      this._SerialNumber = this.frmSN.Text;
      this._MACAddress = this.frmMAC.Text;
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
      this.label1 = new Label();
      this.label2 = new Label();
      this.frmSN = new TextBox();
      this.frmMAC = new TextBox();
      this.frmOK = new Button();
      this.label3 = new Label();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(41, 90);
      this.label1.Name = "label1";
      this.label1.Size = new Size(40, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "LABEL";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(41, 135);
      this.label2.Name = "label2";
      this.label2.Size = new Size(30, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "MAC";
      this.frmSN.Location = new Point(92, 83);
      this.frmSN.Name = "frmSN";
      this.frmSN.Size = new Size(200, 20);
      this.frmSN.TabIndex = 2;
      this.frmSN.KeyPress += new KeyPressEventHandler(this.frmSN_KeyPress);
      this.frmSN.Leave += new EventHandler(this.frmSN_Leave);
      this.frmMAC.Location = new Point(92, 128);
      this.frmMAC.Name = "frmMAC";
      this.frmMAC.Size = new Size(114, 20);
      this.frmMAC.TabIndex = 3;
      this.frmMAC.KeyPress += new KeyPressEventHandler(this.frmMAC_KeyPress);
      this.frmOK.BackColor = Color.Transparent;
      this.frmOK.Font = new Font("Microsoft Sans Serif", 27.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.frmOK.ForeColor = Color.Green;
      this.frmOK.Location = new Point(333, 80);
      this.frmOK.Name = "frmOK";
      this.frmOK.Size = new Size(93, 51);
      this.frmOK.TabIndex = 4;
      this.frmOK.Text = "OK";
      this.frmOK.UseVisualStyleBackColor = false;
      this.frmOK.Click += new EventHandler(this.frmOK_Click);
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(41, 40);
      this.label3.Name = "label3";
      this.label3.Size = new Size(465, 16);
      this.label3.TabIndex = 5;
      this.label3.Text = "Please remove the DUT and scan the SN and MAC labels of the current DUT!";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(533, 176);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.frmOK);
      this.Controls.Add((Control) this.frmMAC);
      this.Controls.Add((Control) this.frmSN);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Name = nameof (frmSNMAC);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "verify SN/MAC";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
