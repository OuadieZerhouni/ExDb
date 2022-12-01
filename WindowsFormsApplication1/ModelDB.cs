//imprt db connection sql server
using System.Data.SqlClient;





namespace WindowsFormsApplication1

{
    public class newclass
    {
        //sql server
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\user\Documents\Visual Studio 2010\Projects\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        //Etudiant(id )
        
        
    }
}