using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PdfiumViewer;

namespace PdfReader
{
    public partial class Form1 : Form
    {
        private PdfViewer pdfViewer;

        public Form1()
        {
            InitializeComponent();
            //InitUI();
        }

        private void InitUI()
        {
            // Tạo control PdfViewer
            pdfViewer = new PdfViewer
            {
                Dock = DockStyle.Fill,
                ZoomMode = PdfViewerZoomMode.FitBest
            };

            // Tạo nút Import
            Button btnImport = new Button
            {
                Text = "Import",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnImport.Click += BtnImport_Click;

            // Tạo nút Clear
            Button btnClear = new Button
            {
                Text = "Clear",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnClear.Click += BtnClear_Click;

            // Thêm control vào form
            this.Controls.Add(pdfViewer);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnImport);
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF files (*.pdf)|*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var doc = PdfDocument.Load(ofd.FileName);
                        pdfViewer1.Document = doc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi đọc file: " + ex.Message);
                    }
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            pdfViewer1.Document = null;
        }
    }
}