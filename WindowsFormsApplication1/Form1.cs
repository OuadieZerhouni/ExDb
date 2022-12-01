using System;
using System.Data;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //list of etudiants
        public static List<Etudiant> etudiants = new List<Etudiant>();


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "insert into Dossier(ID_DOSSIER, NOM_DOSSIER) values('" + NomTxt.Text + "','" + PrenomTxt.Text + "') ";
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "update Dossier set NOM_DOSSIER='" + PrenomTxt.Text + "' where ID_DOSSIER='" + NomTxt.Text + "' ";
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "delete from DOSSIER where ID_DOSSIER='" + NomTxt.Text + "' ";
            cmd.ExecuteNonQuery();
            cnx.Close();
        }


        private void Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Confirm_Click(object sender, EventArgs e)
        {

        }
        //LoadInitial disable all exept combobox1 and insert button
        private void LoadInitial()
        {
            NomTxt.Enabled = false;
            PrenomTxt.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            Confirm.Enabled = false;
            Cancel.Enabled = false;
            btnInsert.Enabled = true;
            comboBox1.Enabled = true;
        }
    }
}
