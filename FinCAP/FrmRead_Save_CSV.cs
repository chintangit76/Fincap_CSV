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
    public partial class FrmRead_Save_CSV : Form
    {
        DataTable dtCSV = new DataTable();
        DataTable dtGrp = new DataTable();
        public FrmRead_Save_CSV()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //To CLose Application
            Application.Exit();
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {

            TxtMsg.AppendText("PROCESS START..." + Environment.NewLine) ;
            TxtMsg.ScrollToCaret();
            string strName = "";
            try
            {
                string ReadFolder = Application.StartupPath + "\\InputFile";
                //string[] subDirectories = Directory.GetDirectories(folderPath);
                string[] files = Directory.GetFiles(ReadFolder, "*.csv");

                string FileToRead_Grp = Application.StartupPath + "\\InputFile\\GROUP MASTER.csv";
                dtGrp = GetDataTabletFromCSVFile(FileToRead_Grp);

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

                        dtCSV.Rows.Clear();
                        dtCSV.Columns.Clear();

                        dtCSV = GetDataTabletFromCSVFile(FileToRead);

                        // Iterate through each row in table1
                        foreach (DataRow row1 in dtCSV.Rows)
                        {
                            //string id1 = (string)row1["group_name"];
                            //string value1 = (string)row1["group_name"];
                            string id1 = (string)row1[1];
                            string value1 = (string)row1[1];
                            bool foundMatch = false; // Flag to track if a match is found

                            // Iterate through each row in table2
                            foreach (DataRow row2 in dtGrp.Rows)
                            {
                                //string id2 = (string)row2["group_name"];
                                //string newValue = row2["Tally_Name"].ToString();
                                string id2 = (string)row2[0];
                                string newValue = row2[1].ToString();

                                // Check if IDs match
                                if (id1 == id2)
                                {
                                    // Update value in table1 from table2
                                    row1["group_name"] = newValue;
                                    foundMatch = true;
                                    break; // Exit inner loop since match is found
                                }
                            }

                            if (!foundMatch)
                                row1["group_name"] = value1;
                        }

                        TxtMsg.AppendText("SAVING PROCESS START FOR FILE :: " + strName.ToString() + Environment.NewLine);
                        TxtMsg.ScrollToCaret();

                        // Save DataTable to CSV file
                        SaveDataTableToCsv(dtCSV, FileNmToSave);

                        TxtMsg.AppendText("SAVING PROCESS COMPLETED SUCCESFULLY FOR FILE :: " + strName.ToString() + Environment.NewLine);
                        TxtMsg.ScrollToCaret();
                        TxtMsg.AppendText("========================================================================" + Environment.NewLine);
                        TxtMsg.ScrollToCaret();

                    }   //  if (strName != "")
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "File Process", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TxtMsg.AppendText("SAVING PROCESS COMPLETED SUCCESFULLY..." + Environment.NewLine);
            TxtMsg.ScrollToCaret();
            MessageBox.Show("Process Completed Successfully...", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //-------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------

            ////int iRow = 0;
            ////DataTable dtNew = new DataTable();
            //dtCSV = GetDataTabletFromCSVFile(FileToRead);

            //FileToRead = Application.StartupPath + "\\InputFile\\GROUP_NA.csv";
            //dtGrp = GetDataTabletFromCSVFile(FileToRead);

            ////// LINQ to update DataTable1 IDs based on DataTable2
            ////var updatedTable1 = from row1 in table1.AsEnumerable()
            ////                    join row2 in table2.AsEnumerable()
            ////                    on row1.Field<int>("ID") equals row2.Field<int>("ID") into gj
            ////                    from subRow in gj.DefaultIfEmpty()
            ////                    select new
            ////                    {
            ////                        ID = (subRow == null) ? row1.Field<int>("ID") : subRow.Field<int>("NewID"), // Update ID if found in table2
            ////                        Value = row1.Field<string>("Value")
            ////                    };


            //// Iterate through each row in table1
            //foreach (DataRow row1 in dtCSV.Rows)
            //{
            //    string id1 = (string)row1["group_name"];
            //    string value1 = (string)row1["group_name"];
            //    bool foundMatch = false; // Flag to track if a match is found

            //    // Iterate through each row in table2
            //    foreach (DataRow row2 in dtGrp.Rows)
            //    {
            //        string id2 = (string)row2["group_name"];
            //        string newValue = row2["Tally_Name"].ToString();

            //        // Check if IDs match
            //        if (id1 == id2)
            //        {
            //            // Update value in table1 from table2
            //            row1["group_name"] = newValue;
            //            foundMatch = true;
            //            break; // Exit inner loop since match is found
            //        }
            //    }

            //    if (!foundMatch)
            //        row1["group_name"] = value1;

            //}


            //////*********************************************************************
            //////*********************************************************************
            //////*********************************************************************
            ////// Create a new DataTable with the same schema (columns) as table1
            ////DataTable resultTable = dtCSV.Clone();

            ////// LINQ to update DataTable1 IDs based on DataTable2
            ////var updatedTable1 = from row1 in dtCSV.AsEnumerable()
            ////                    join row2 in dtGrp.AsEnumerable()
            ////                    on row1.Field<string>("group_name") equals row2.Field<string>("group_name") into gj
            ////                    from subRow in gj.DefaultIfEmpty()
            ////                    select new
            ////                    {
            ////                        ledger_nam = row1.Field<string>("ledger_nam"),
            ////                        group_name = (subRow == null) ? row1.Field<string>("group_name") : subRow.Field<string>("Tally_Name"), // Update ID if found in table2
            ////                        op_bal = row1.Field<string>("op_bal"),
            ////                        dr_cr = row1.Field<string>("dr_cr")
            ////                    };


            ////// Add the updated rows to the new DataTable
            ////foreach (var row in updatedTable1)
            ////{
            ////    resultTable.Rows.Add(row.ledger_nam, row.group_name, row.op_bal, row.dr_cr);
            ////}
            //////*********************************************************************
            //////*********************************************************************
            //////*********************************************************************

            //TxtMsg.AppendText("SAVING PROCESS START..." + Environment.NewLine);
            //TxtMsg.ScrollToCaret();

            //// Save DataTable to CSV file
            ////SaveDataTableToCsv(resultTable, FileNmToSave);
            //SaveDataTableToCsv(dtCSV, FileNmToSave);

            //TxtMsg.AppendText("SAVING PROCESS COMPLETED SUCCESFULLY..." + Environment.NewLine);
            //TxtMsg.ScrollToCaret();

            //MessageBox.Show("Process Completed Successfully...", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            //DataTable csvData = new DataTable();
            DataTable dt = new DataTable();
            try
            {
                // your code here 
                string CSVFilePathName = csv_file_path;
                string[] Lines = File.ReadAllLines(CSVFilePathName);
                string[] Fields;
                Fields = Lines[0].Split(new char[] { ',' });
                int Cols = Fields.GetLength(0);
                //1st row must be column names; force lower case to ensure matching later on.
                for (int i = 0; i < Cols; i++)
                    dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                DataRow Row;
                for (int i = 1; i < Lines.GetLength(0); i++)
                {
                    Fields = Lines[i].Split(new char[] { ',' });
                    Row = dt.NewRow();

                    //  Date : 16-Mar-2024
                    //for (int f = 0; f < Cols; f++)
                    //    Row[f] = Fields[f];
                    //dt.Rows.Add(Row);

                    for (int f = 0; f < Cols; f++)
                    {
                        if (Fields.Count() > 4)
                        {
                            if (f == 0)
                            {
                                Row[f] = Fields[f] + "," + Fields[f + 1];
                                f++;
                            }
                            else
                            {
                                if (f == 3)
                                {
                                    Row[f - 1] = Fields[f];
                                    Row[f] = Fields[f + 1];
                                }
                                else
                                    Row[f - 1] = Fields[f];
                            }
                        }
                        else
                        {
                            Row[f] = Fields[f];
                        }
                    }
                    dt.Rows.Add(Row);

                }
                //dataGridClients.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
                throw;
            }

            return dt;
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
