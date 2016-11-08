using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace FileOps
{
    public partial class frmMain : Form
    {
        string strPath = "";

        public frmMain()
        {
            InitializeComponent();

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            strPath = folderBrowserDialog1.SelectedPath.ToString();
            Debug.Print(strPath);

            listView1.Clear();
            fsw1.Path = strPath;
            fsw1.IncludeSubdirectories = true;
            fsw1.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            fsw1.Filter = "*.*";
            fsw1.Changed += new FileSystemEventHandler(OnChanged);
           
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            //Add to listView1
            
            Debug.Print("");
        }

        private static bool CheckFile(String strFile)
        {
            try
            {
                using (FileStream StreamIn = File.Open(strFile, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    if (StreamIn.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
    }
}
