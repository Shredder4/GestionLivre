using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class editLivreModel : PageModel
    {
        public LivreInfo livreInfo = new LivreInfo();
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
            string id = Request.Query["id"];
            try
            {
                string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sql = "select * from Livre where IdLivre=@id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    livreInfo.id = rd.GetInt32(0);
                    livreInfo.titre = rd.GetString(1);
                    livreInfo.isbn = rd.GetString(2);
                    livreInfo.idediteur = rd.GetInt32(3);
                    livreInfo.idauteur = rd.GetInt32(4);
                    livreInfo.idcat = rd.GetInt32(5);
                    livreInfo.description = rd.GetString(6);
                    livreInfo.anneeedition = rd.GetInt32(7);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.ToString());
            }
        }
        public void OnPost()
        {
            livreInfo.id = Convert.ToInt32(Request.Form["id"]);
            livreInfo.titre = Request.Form["titre"];
            livreInfo.isbn = Request.Form["isbn"];
            livreInfo.idediteur = Convert.ToInt32(Request.Form["editeur"]);
            livreInfo.idauteur = Convert.ToInt32(Request.Form["auteur"]);
            livreInfo.idcat = Convert.ToInt32(Request.Form["cat"]);
            livreInfo.description = Request.Form["descrip"];
            livreInfo.anneeedition = Convert.ToInt32(Request.Form["annee"]);
            try
            {
                string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                string sql = "update Livre set Titre = @titre,ISBN = @isbn,IDEditeur= @editeur,IDAuteur = @auteur,IDCat=@cat,DescripLivre=@descrip,AnneeEdition=@annee where IdLivre = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", livreInfo.id);
                cmd.Parameters.AddWithValue("@titre", livreInfo.titre);
                cmd.Parameters.AddWithValue("@isbn", livreInfo.isbn);
                cmd.Parameters.AddWithValue("@editeur", livreInfo.idediteur);
                cmd.Parameters.AddWithValue("@auteur", livreInfo.idauteur);
                cmd.Parameters.AddWithValue("@cat", livreInfo.idcat);
                cmd.Parameters.AddWithValue("@descrip", livreInfo.description);
                cmd.Parameters.AddWithValue("@annee", livreInfo.anneeedition);

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.ToString());
            }
            Response.Redirect("/Index");
        }
    }
}
