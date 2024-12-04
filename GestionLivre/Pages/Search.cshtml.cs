using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class SearchModel : PageModel
    {
        
        public List<LivreInfo> livreInfo = new List<LivreInfo>();
        public bool isposted = false;
        public bool isempty = true;

        
        public void OnPost()
        {
            isposted = true;
            string searchterm = Request.Form["searchterm"];
            string option = Request.Form["option"];
            try
            {
                string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                string sqlt = "select l.*,a.NomAuteur,c.NomCat,e.NomEditeur from Livre l inner join Auteur a on l.IDAuteur=a.IDAuteur inner join Editeur e on l.IDEditeur=e.IDEditeur inner join Categorie c on l.IDCat=c.IDCat where l.Titre in(@searchterm)";
                string sqla = "select l.*,a.NomAuteur,c.NomCat,e.NomEditeur from Livre l inner join Auteur a on l.IDAuteur=a.IDAuteur inner join Editeur e on l.IDEditeur=e.IDEditeur inner join Categorie c on l.IDCat=c.IDCat where a.NomAuteur in(@searchterm)";
                string sqle = "select l.*,a.NomAuteur,c.NomCat,e.NomEditeur from Livre l inner join Auteur a on l.IDAuteur=a.IDAuteur inner join Editeur e on l.IDEditeur=e.IDEditeur inner join Categorie c on l.IDCat=c.IDCat where e.NomEditeur in(@searchterm)";
                string sqlc = "select l.*,a.NomAuteur,c.NomCat,e.NomEditeur from Livre l inner join Auteur a on l.IDAuteur=a.IDAuteur inner join Editeur e on l.IDEditeur=e.IDEditeur inner join Categorie c on l.IDCat=c.IDCat where c.NomCat in(@searchterm)";
                con.Open();
                if (option.Equals("titre"))
                {
                    SqlCommand cmd = new SqlCommand(sqlt, con);
                    cmd.Parameters.AddWithValue("@searchterm", searchterm);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        LivreInfo livredets = new LivreInfo();
                        livredets.id = rd.GetInt32(0);
                        livredets.titre = rd.GetString(1);
                        livredets.isbn = rd.GetString(2);
                        livredets.idediteur = rd.GetInt32(3);
                        livredets.idauteur = rd.GetInt32(4);
                        livredets.idcat = rd.GetInt32(5);
                        livredets.description = rd.GetString(6);
                        livredets.anneeedition = rd.GetInt32(7);
                        livredets.Auteur = rd.GetString(8);
                        livredets.Categorie = rd.GetString(9);
                        livredets.Editeur = rd.GetString(10);
                        livreInfo.Add(livredets);
                    }
                    if (livreInfo.Count > 0) { isempty = false; }

                }
                else if (option.Equals("category"))
                {
                    SqlCommand cmd = new SqlCommand(sqlc, con);
                    cmd.Parameters.AddWithValue("@searchterm", searchterm);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        LivreInfo livredets = new LivreInfo();
                        livredets.id = rd.GetInt32(0);
                        livredets.titre = rd.GetString(1);
                        livredets.isbn = rd.GetString(2);
                        livredets.idediteur = rd.GetInt32(3);
                        livredets.idauteur = rd.GetInt32(4);
                        livredets.idcat = rd.GetInt32(5);
                        livredets.description = rd.GetString(6);
                        livredets.anneeedition = rd.GetInt32(7);
                        livredets.Auteur = rd.GetString(8);
                        livredets.Categorie = rd.GetString(9);
                        livredets.Editeur = rd.GetString(10);
                        livreInfo.Add(livredets);
                    }
                    if (livreInfo.Count > 0) { isempty = false; }
                }
                else if (option.Equals("auteur"))
                {
                    SqlCommand cmd = new SqlCommand(sqla, con);
                    cmd.Parameters.AddWithValue("@searchterm", searchterm);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        LivreInfo livredets = new LivreInfo();
                        livredets.id = rd.GetInt32(0);
                        livredets.titre = rd.GetString(1);
                        livredets.isbn = rd.GetString(2);
                        livredets.idediteur = rd.GetInt32(3);
                        livredets.idauteur = rd.GetInt32(4);
                        livredets.idcat = rd.GetInt32(5);
                        livredets.description = rd.GetString(6);
                        livredets.anneeedition = rd.GetInt32(7);
                        livredets.Auteur = rd.GetString(8);
                        livredets.Categorie = rd.GetString(9);
                        livredets.Editeur = rd.GetString(10);
                        livreInfo.Add(livredets);
                    }
                    if (livreInfo.Count > 0) { isempty = false; }
                }
                else if (option.Equals("editeur"))
                {
                    SqlCommand cmd = new SqlCommand(sqle, con);
                    cmd.Parameters.AddWithValue("@searchterm", searchterm);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        LivreInfo livredets = new LivreInfo();
                        livredets.id = rd.GetInt32(0);
                        livredets.titre = rd.GetString(1);
                        livredets.isbn = rd.GetString(2);
                        livredets.idediteur = rd.GetInt32(3);
                        livredets.idauteur = rd.GetInt32(4);
                        livredets.idcat = rd.GetInt32(5);
                        livredets.description = rd.GetString(6);
                        livredets.anneeedition = rd.GetInt32(7);
                        livredets.Auteur = rd.GetString(8);
                        livredets.Categorie = rd.GetString(9);
                        livredets.Editeur = rd.GetString(10);
                        livreInfo.Add(livredets);
                    }
                    if (livreInfo.Count > 0) { isempty = false; }
                }


                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.ToString());
            }

        }
    }
}
