using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image_pdf_Test
{
    public partial class Form1 : Form
    {
        SqlConnection sConn = new SqlConnection(@"Data Source=SATYAM; Initial Catalog=ImgTask; Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            BindGrid();


        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            this.openFileDialog1.Filter = "Pdf Files | *.Pdf|jpg  Files |.jpg";
            var result = openFileDialog1.ShowDialog();

           
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;

                string[] f = file.Split('\\');
                // to get the only file name
                string fn = f[(f.Length) - 1];
                string dest = @"C:\Users\satya\source\repos\image-pdf-Test\Files\" + fn;

                //to copy the file to the destination folder
                File.Copy(file, dest, true);

                //to save to the database
                if (sConn.State == ConnectionState.Open)
                {
                    sConn.Close();
                }
                sConn.Open();
                SqlCommand cmd = new SqlCommand("Sp_FileIns", sConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@filename", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar);
                cmd.Parameters["@filename"].Value = fn;
                cmd.Parameters["@Caption"].Value = txtfname.Text;
                cmd.ExecuteNonQuery();
                sConn.Close();
                BindGrid();
                txtfname.Text = "";
                MessageBox.Show("success");


            }
        }
     
        
        public void BindGrid()
        {
            DataTable objtable = new DataTable();
            try
            {
                if (sConn.State == ConnectionState.Open)
                {
                    sConn.Close();
                }
                sConn.Open();
                SqlCommand cmd = new SqlCommand("Sp_Filesget", sConn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        
                     
                        objtable.Load(reader);
                        grdFiles.DataSource = objtable;
                        gridedit();
                        DataGridViewButtonColumn btnUpd = new DataGridViewButtonColumn();
                        btnUpd.UseColumnTextForButtonValue = true;
                        btnUpd.Text = "Update";
                        
                        grdFiles.Columns.Add(btnUpd);
                        btnUpd.UseColumnTextForButtonValue = true;
                        grdFiles.DataSource = objtable;
                        DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn();
                        btnDel.Text = "Delete";
                    
                        btnDel.UseColumnTextForButtonValue = true;
                        grdFiles.Columns.Add(btnDel);
                        btnDel.UseColumnTextForButtonValue = true;

                    }
                    else
                    {
                        objtable = new DataTable();
                        objtable.Load(reader);
                        grdFiles.DataSource = objtable;
                    }
                    reader.Close();
                }
            }
            catch
            {


            }
            finally
            {

                sConn.Close();

            }
        }
        private void grdFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int currentRow = int.Parse(e.RowIndex.ToString());
            int currentColumnIndex = int.Parse(e.ColumnIndex.ToString());
            string command = grdFiles.CurrentCell.Value.ToString();
         
                int id = Convert.ToInt32(grdFiles.Rows[currentRow].Cells[2].Value.ToString());
            
            if (command == "Update")
            {
              
                string name = grdFiles.Rows[currentRow].Cells[4].Value.ToString();

                //to save to the database
                if (sConn.State == ConnectionState.Open)
                {
                    sConn.Close();
                }   
                sConn.Open();
                SqlCommand cmd = new SqlCommand("Sp_FileUpd", sConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar);
                cmd.Parameters["@id"].Value = id;
                cmd.Parameters["@Caption"].Value = name;
                cmd.ExecuteNonQuery();
                sConn.Close();
             
                MessageBox.Show("Update Successfully");
               BindGrid();
            }
            if (command == "Delete")
            {

            
                if (sConn.State == ConnectionState.Open)
                {
                    sConn.Close();
                }
                sConn.Open();
                SqlCommand cmd = new SqlCommand("Sp_FileDel", sConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                cmd.ExecuteNonQuery();
               
                sConn.Close();
                MessageBox.Show("Deleted Successfully");
                BindGrid();
            }
            
            }
        public void gridedit()
        {
            foreach (DataGridViewColumn dc in grdFiles.Columns)
            {
                if (dc.Index.Equals(2))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }
            }

        }

    }
}
