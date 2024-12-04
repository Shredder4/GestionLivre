using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class createLivreModel : PageModel
    {
        public LivreInfo livreInfo = new LivreInfo();
        public string errorMessage = "";
        public string SuccessMessage = "";
        public List<AuteurInfo> listauteur = new List<AuteurInfo>();
        public List<EditeurInfo> listediteur = new List<EditeurInfo>();
        public List<CategInfo> listcategorie = new List<CategInfo>();
        public void OnGet()
        {

            try
            {
                string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sql = "select NomAuteur,IDAuteur from Auteur";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    AuteurInfo aut = new AuteurInfo();
                    aut.nom = rd.GetString(0);
                    aut.id = rd.GetInt32(1);
                    listauteur.Add(aut);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + ex.ToString());
            }
            try
            {
                string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sql = "select NomEditeur,IDEditeur from Editeur";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    EditeurInfo ed = new EditeurInfo();
                    ed.nom = rd.GetString(0);
                    ed.id = rd.GetInt32(1);
                    listediteur.Add(ed);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + ex.ToString());
            }
            try
            {
                string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sql = "select NomCat,IDCat from Categorie";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    CategInfo c = new CategInfo();
                    c.nom = rd.GetString(0);
                    c.id = rd.GetInt32(1);
                    listcategorie.Add(c);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + ex.ToString());
            }

        }
        public void OnPost()
        {
            livreInfo.titre = Request.Form["titre"];
            livreInfo.isbn = Request.Form["isbn"];
            livreInfo.idauteur = Convert.ToInt32(Request.Form["ida"]);
            livreInfo.idediteur = Convert.ToInt32(Request.Form["edi"]);
            livreInfo.idcat = Convert.ToInt32(Request.Form["cat"]);
            livreInfo.description = Request.Form["descrip"];
            livreInfo.anneeedition = Convert.ToInt32(Request.Form["annee"]);
            if (livreInfo.titre.Length == 0 || livreInfo.isbn.Length == 0 || livreInfo.description.Length == 0)
            {
                errorMessage = "tous les champs sont obligatoires";
                return;
            }
            //enregistrer le nouveau client dans la base de données
            try
            {
                string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sql = "insert into Livre values(@titre,@isbn,@edi,@ida,@cat, @descrip, @annee)";
                SqlCommand cmd = new SqlCommand(sql, con);
                // cmd.Parameters.AddWithValue("@id",clientInfo.id);
                cmd.Parameters.AddWithValue("@titre", livreInfo.titre);
                cmd.Parameters.AddWithValue("@isbn", livreInfo.isbn);
                cmd.Parameters.AddWithValue("@edi", livreInfo.idediteur);
                cmd.Parameters.AddWithValue("@ida", livreInfo.idauteur);
                cmd.Parameters.AddWithValue("@cat", livreInfo.idcat);
                cmd.Parameters.AddWithValue("@descrip", livreInfo.description);
                cmd.Parameters.AddWithValue("@annee", livreInfo.anneeedition);




                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + ex.ToString());
            }
        }
    }
}
