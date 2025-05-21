using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ClosedXML.Excel;
using System.IO;

namespace FinCAP_CSV
{
    public partial class FrmGetGrp_Name : Form
    {
        DataTable dtCSV = new DataTable();
        DataTable dtGrp = new DataTable();
        public FrmGetGrp_Name()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {

            TxtMsg.AppendText("PROCESS START..." + Environment.NewLine) ;
            TxtMsg.ScrollToCaret();

            dtGrp.Rows.Clear();
            dtGrp.Columns.Clear();

            dtGrp.Columns.Add("Group_Name", typeof(string));
            dtGrp.Columns.Add("Tally_Name", typeof(string));


            string strName = "";
            try
            {
                string ReadFolder = Application.StartupPath + "\\InputFile";
                //string[] subDirectories = Directory.GetDirectories(folderPath);
                string[] files = Directory.GetFiles(ReadFolder, "*.csv");

                //string FileToRead_Grp = Application.StartupPath + "\\InputFile\\GROUP_NA.csv";
                //dtGrp = GetDataTabletFromCSVFile(FileToRead_Grp);

                foreach (string s in files)
                {
                    //string FileToRead = Application.StartupPath + "\\InputFile\\" + s.ToString();
                    string FileToRead = s.ToString();
                    string FileNmToSave = Application.StartupPath + "\\OutputFile\\" + Path.GetFileName(s.ToString());

                    strName = Path.GetFileName(s.ToString());

                    if (strName.ToString().ToUpper() != "GROUP MASTER.CSV")
                    {
                        TxtMsg.AppendText("PROCESS START FOR FILE :: " + strName.ToString() + Environment.NewLine);
                        TxtMsg.ScrollToCaret();

                        //dtCSV.Rows.Clear();
                        //dtCSV.Columns.Clear();

                        //dtCSV = GetDataTabletFromCSVFile(FileToRead);
                        GetDataTabletFromCSVFile(FileToRead);

                        //TxtMsg.AppendText("SAVING PROCESS START FOR FILE :: " + strName.ToString() + Environment.NewLine);
                        //TxtMsg.ScrollToCaret();

                        //// Save DataTable to CSV file
                        //SaveDataTableToCsv(dtCSV, FileNmToSave);

                        TxtMsg.AppendText("SAVING PROCESS COMPLETED SUCCESFULLY FOR FILE :: " + strName.ToString() + Environment.NewLine);
                        TxtMsg.ScrollToCaret();
                        TxtMsg.AppendText("========================================================================" + Environment.NewLine);
                        TxtMsg.ScrollToCaret();

                    }   //  if (strName != "")
                }

                var distinctValues = dtGrp.AsEnumerable()
                        .Select(row => new
                        {
                            Group_Name = row.Field<string>("Group_name"),
                            Tally_Name = row.Field<string>("Tally_name")
                        })
                        .Distinct().OrderBy(row => row.Group_Name);

                
                DataTable dt = dtGrp.Clone();
                // Add the updated rows to the new DataTable
                foreach (var row in distinctValues)
                {
                    dt.Rows.Add(row.Group_Name, row.Tally_Name);
                }


                TxtMsg.AppendText("SAVING PROCESS START FOR FILE :: " + strName.ToString() + Environment.NewLine);
                TxtMsg.ScrollToCaret();

                string strSaveFile = Application.StartupPath + "\\OutputFile\\GROUP MASTER.csv";
                //// Save DataTable to CSV file
                SaveDataTableToCsv(dt, strSaveFile);

                TxtMsg.AppendText("SAVING PROCESS COMPLETED SUCCESFULLY :: " + strName.ToString() + Environment.NewLine);
                TxtMsg.ScrollToCaret();
                MessageBox.Show("Process Completed Successfully...", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "File Process", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //TxtMsg.AppendText("SAVING PROCESS COMPLETED SUCCESFULLY..." + Environment.NewLine);
            //TxtMsg.ScrollToCaret();
            //MessageBox.Show("Process Completed Successfully...", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //-------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------

        }

        private void GetDataTabletFromCSVFile(string csv_file_path)
        {
            //DataTable csvData = new DataTable();
            //DataTable dt = new DataTable();
            try
            {
                // your code here 
                string CSVFilePathName = csv_file_path;
                string[] Lines = File.ReadAllLines(CSVFilePathName);
                string[] Fields;
                Fields = Lines[0].Split(new char[] { ',' });
                int Cols = Fields.GetLength(0);
                //1st row must be column names; force lower case to ensure matching later on.
                //for (int i = 0; i < Cols; i++)
                //    dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                DataRow Row;
                for (int i = 1; i < Lines.GetLength(0); i++)
                {
                    Fields = Lines[i].Split(new char[] { ',' });

                    //  Date : 16-Mar-2024
                    //Row = dtGrp.NewRow();
                    //Row[0] = Fields[1];
                    //Row[1] = "";
                    //dtGrp.Rows.Add(Row);

                    Row = dtGrp.NewRow();
                    if (Fields.Count() > 4)
                    {
                        Row[0] = Fields[2];
                    }
                    else
                    {
                        Row[0] = Fields[1];
                    }
                    Row[1] = "";
                    dtGrp.Rows.Add(Row);

                }
                //dataGridClients.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
                throw;
            }

            return;// dt;
        }


        static void SaveDataTableToCsv(DataTable dataTable, string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
                        
            // Create a StringBuilder to hold the CSV data
            var sb = new System.Text.StringBuilder();

            // Write column headers
            foreach (DataColumn col in dataTable.Columns)
            {
                sb.Append(col.ColumnName);
                sb.Append(",");
            }
            sb.AppendLine();

            // Write row data
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    sb.Append(item.ToString());
                    sb.Append(",");
                }
                sb.AppendLine();
            }

            // Write the CSV data to the file
            File.WriteAllText(filePath, sb.ToString());
        }


    }
}
