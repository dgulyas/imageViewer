using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		private int m_currentIndex = 0;
		private ArrayList m_pics = new ArrayList();

		public Form1()
		{
			InitializeComponent();
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			DialogResult result = folderBrowserDialog.ShowDialog();

			string folder = "";
			if (result == DialogResult.OK) // Test result.
			{
				folder = folderBrowserDialog.SelectedPath;
			}
			else
			{
				return;
			}

			var files = Directory.GetFiles(folder);

			var ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
			foreach (var file in files)
			{
				if (ImageExtensions.Contains(Path.GetExtension(file).ToUpperInvariant()))
				{
					m_pics.Add(file);
				}
			}

			if (m_pics.Count < 1)
			{
				return;
			}

			SetPicture();

		}

		private void SetPicture()
		{
			pictureBox1.Image = Image.FromFile((string)m_pics[m_currentIndex]);

			pictureBox1.Height = pictureBox1.Image.Height;
			pictureBox1.Width = pictureBox1.Image.Width;

			//Form1. make is scroll to the top
		}

		private void previousButton_Click(object sender, EventArgs e)
		{
			if (m_currentIndex > 0)
			{
				m_currentIndex--;
				SetPicture();
			}
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			if (m_currentIndex < m_pics.Count - 1)
			{
				m_currentIndex++;
				SetPicture();
			}
		}

	}
}
