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
        public static list<Etudiant> etudiants = new list<Etudiant>();
        int IdSelected ;


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInitial();
            
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            LoadInsert();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            etudiants.remove(etudiants.find(x => x.id == IdSelected));
            ModelDB.deleteEtudiant(IdSelected);
            LoadInitial();
            
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            LoadInitial();

        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "" || txtPrenom.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
            else
            {
                if (titleLabel.Text == "Insertion")
                {
                    Etudiant etudiant = new Etudiant(txtNom.Text, txtPrenom.Text);
                    etudiants.add(etudiant);
                    ModelDB.addEtudiant(txtNom.Text, txtPrenom.Text);
                    LoadInitial();
                }
                else if(titleLabel.Text == "Modification")
                {
                    etudiants.find(x => x.id == IdSelected).setnom(txtNom.Text);
                    etudiants.find(x => x.id == IdSelected).setprenom(txtPrenom.Text);
                    LoadInitial();
                }
                
                else{
                    MessageBox.Show("Erreur!! Unknown window");
                }
            }

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
            Fill();
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
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
     

        }
    }
}
