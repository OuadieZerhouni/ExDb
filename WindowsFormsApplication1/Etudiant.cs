using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    

namespace WindowsFormsApplication1

{
    //Etudiant
    public class Etudiant
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }

        public Etudiant( string nom, string prenom)
        {
            modelDB.addEtudiant(nom, prenom);
            this.id = modelDB.getid_byname(nom, prenom);
            this.nom = nom;
            this.prenom = prenom;
        }
        //getters
        public int getid()
        {
            return this.id;
        }
        public string getnom()
        {
            return this.nom;
        }
        public string getprenom()
        {
            return this.prenom;
        }
        //setters
        public void setnom(string nom)
        {
            modelDB.updateEtudiant(this.id, nom, this.prenom);
            this.nom = nom;
        }
        public void setprenom(string prenom)
        {
            modelDB.updateEtudiant(this.id, this.nom, prenom);
            this.prenom = prenom;
        }
        public void delete()
        {
            modelDB.deleteEtudiant(this.id);
        }
    }}

}
