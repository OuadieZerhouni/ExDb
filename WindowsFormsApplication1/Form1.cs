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
        public static List<Etudiant> etudiants = new List<Etudiant>();
        int IdSelected ;


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
            
            titleLabel.Text = "Initiale";

        }
        private void LoadInsert()
        {
            NomTxt.Enabled = true;
            PrenomTxt.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            Confirm.Enabled = true;
            Cancel.Enabled = true;
            btnInsert.Enabled = false;
            Fill();
            comboBox1.Enabled = false;
            titleLabel.Text = "Insertion";
        }
        private void LoadUpdate()
        {
            NomTxt.Enabled = true;
            PrenomTxt.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            Confirm.Enabled = true;
            Cancel.Enabled = true;
            btnInsert.Enabled = false;
            comboBox1.Enabled = false;
            titleLabel.Text = "Modification";
        }      
        private void Fill()
        {
            comboBox1.Items.Clear();
            foreach (Etudiant etudiant in etudiants)
            {
                comboBox1.Items.Add(etudiant.getnom() + " " + etudiant.getprenom());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NomTxt.Text = comboBox1.Text.Split(' ')[0];
            PrenomTxt.Text = comboBox1.Text.Split(' ')[1];
            IdSelected = Etudiant.getIdByName(NomTxt.Text, PrenomTxt.Text);
     

        }
    }
}
