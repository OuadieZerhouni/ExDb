using System.Data.SqlClient;





namespace WindowsFormsApplication1

{
    public class newclass
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\user\Documents\Visual Studio 2010\Projects\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public void addEtudiant(string nom, string prenom)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Etudiant(nom,prenom) values('" + nom + "','" + prenom + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteEtudiant(int id)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from Etudiant where id=" + id;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateEtudiant(int id, string nom, string prenom)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update Etudiant set nom='" + nom + "',prenom='" + prenom + "' where id=" + id;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int getid_byname(string nom, string prenom)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select id from Etudiant where nom='" + nom + "' and prenom='" + prenom + "'";
            int id = (int)cmd.ExecuteScalar();
            con.Close();
            return id;
        }

        public DataTable getEtudiants()
        {
            DataTable dt = new DataTable();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Etudiant";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        
    }
}