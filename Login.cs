using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using GrowSky.Properties;


namespace GrowSky
{
	// Token: 0x02000004 RID: 4
	public class Login : MetroForm
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000207B File Offset: 0x0000027B
		public Login()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002093 File Offset: 0x00000293
		private void Form1_Load(object sender, EventArgs e)
		{
			base.BringToFront();
			openanimation.AnimateWindow(base.Handle, 750, 16);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020B0 File Offset: 0x000002B0
		private void metroButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroTextBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020BA File Offset: 0x000002BA
		private void licensenumber_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020BA File Offset: 0x000002BA
		private void password_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020BD File Offset: 0x000002BD
		private void metroTextBox1_Click_1(object sender, EventArgs e)
		{
			this.username.Text = "";
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020D1 File Offset: 0x000002D1
		private void metroTextBox2_Click(object sender, EventArgs e)
		{
			this.password.Text = "";
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000020E5 File Offset: 0x000002E5
		private void metroTextBox3_Click(object sender, EventArgs e)
		{
			this.Token.Text = "";
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000247C File Offset: 0x0000067C
		private void metroButton3_Click(object sender, EventArgs e)
		{
			string text = new WebClient
			{
				Proxy = null
			}.DownloadString("https://pastebin.com/raw/gY0TTvUX");
			string text2 = new WebClient
			{
				Proxy = null
			}.DownloadString("https://pastebin.com/raw/gY0TTvUX");
			bool flag = text.Contains(this.Token.Text);
			if (flag)
			{
				Main main = new Main();
				main.Show();
				base.Hide();
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020BA File Offset: 0x000002BA
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020F9 File Offset: 0x000002F9
		private void metroButton2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020BA File Offset: 0x000002BA
		private void pictureBox2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000020BA File Offset: 0x000002BA
		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroButton6_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000024E8 File Offset: 0x000006E8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002520 File Offset: 0x00000720
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Login));
			this.metroButton1 = new MetroButton();
			this.metroButton2 = new MetroButton();
			this.metroButton3 = new MetroButton();
			this.username = new MetroTextBox();
			this.password = new MetroTextBox();
			this.Token = new MetroTextBox();
			this.label1 = new Label();
			this.pictureBox2 = new PictureBox();
			this.pictureBox1 = new PictureBox();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.metroButton1.Location = new Point(253, 6);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(42, 23);
			this.metroButton1.TabIndex = 0;
			this.metroButton1.Text = "X";
			this.metroButton1.Theme = 2;
			this.metroButton1.Click += this.metroButton1_Click;
			this.metroButton2.Location = new Point(211, 6);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new Size(42, 23);
			this.metroButton2.TabIndex = 2;
			this.metroButton2.Text = "_";
			this.metroButton2.Theme = 2;
			this.metroButton2.Click += this.metroButton2_Click;
			this.metroButton3.Location = new Point(28, 239);
			this.metroButton3.Name = "metroButton3";
			this.metroButton3.Size = new Size(239, 23);
			this.metroButton3.TabIndex = 5;
			this.metroButton3.Text = "Login";
			this.metroButton3.Theme = 2;
			this.metroButton3.Click += this.metroButton3_Click;
			this.username.Location = new Point(28, 89);
			this.username.Name = "username";
			this.username.PromptText = "Username";
			this.username.Size = new Size(239, 23);
			this.username.Style = 3;
			this.username.TabIndex = 6;
			this.username.Text = "Username";
			this.username.Theme = 2;
			this.username.Click += this.metroTextBox1_Click_1;
			this.password.Location = new Point(28, 137);
			this.password.Name = "password";
			this.password.PromptText = "Password";
			this.password.Size = new Size(239, 23);
			this.password.Style = 3;
			this.password.TabIndex = 7;
			this.password.Text = "Password";
			this.password.Theme = 2;
			this.password.Click += this.metroTextBox2_Click;
			this.Token.Location = new Point(28, 187);
			this.Token.Name = "Token";
			this.Token.PromptText = "Token";
			this.Token.Size = new Size(239, 23);
			this.Token.Style = 3;
			this.Token.TabIndex = 8;
			this.Token.Text = "Token";
			this.Token.Theme = 2;
			this.Token.Click += this.metroTextBox3_Click;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(22, 38);
			this.label1.Name = "label1";
			this.label1.Size = new Size(211, 31);
			this.label1.TabIndex = 9;
			this.label1.Text = "GrowSky Login";
			this.label1.Click += this.label1_Click;
			this.pictureBox2.Image = Resources.tenor;
			this.pictureBox2.Location = new Point(-8, 273);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(311, 10);
			this.pictureBox2.TabIndex = 11;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += this.pictureBox2_Click;
			this.pictureBox1.Image = Resources.tenor;
			this.pictureBox1.Location = new Point(-8, -4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(311, 10);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += this.pictureBox1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(295, 279);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.Token);
			base.Controls.Add(this.password);
			base.Controls.Add(this.username);
			base.Controls.Add(this.metroButton3);
			base.Controls.Add(this.metroButton2);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.label1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Login";
			base.Resizable = false;
			base.Theme = 2;
			base.Load += this.Form1_Load;
			((ISupportInitialize)this.pictureBox2).EndInit();
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000003 RID: 3
		private IContainer components = null;

		// Token: 0x04000004 RID: 4
		private MetroButton metroButton1;

		// Token: 0x04000005 RID: 5
		private MetroButton metroButton2;

		// Token: 0x04000006 RID: 6
		private MetroButton metroButton3;

		// Token: 0x04000007 RID: 7
		private MetroTextBox username;

		// Token: 0x04000008 RID: 8
		private MetroTextBox password;

		// Token: 0x04000009 RID: 9
		private MetroTextBox Token;

		// Token: 0x0400000A RID: 10
		private Label label1;

		// Token: 0x0400000B RID: 11
		private PictureBox pictureBox1;

		// Token: 0x0400000C RID: 12
		private PictureBox pictureBox2;
	}
}
