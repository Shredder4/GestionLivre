using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class LivresModel : PageModel
    {
		public List<LivreInfo> listLivres = new List<LivreInfo>();
        public void OnGet()
        {
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "select * from Livre";
				SqlCommand cmd = new SqlCommand(sql, con);
				SqlDataReader rd = cmd.ExecuteReader();


				while (rd.Read())
				{
					LivreInfo livreinf = new LivreInfo();
					livreinf.id = rd.GetInt32(0);
					livreinf.titre = rd.GetString(1);
					livreinf.isbn = rd.GetString(2);

					livreinf.idediteur = rd.GetInt32(3);

					string connectionString2 = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
					SqlConnection con2 = new SqlConnection(connectionString2);
					con2.Open();
					int id2 = Convert.ToInt32(livreinf.idediteur);
					string sql2 = "select NomEditeur from Editeur where IDEditeur=@id2";
					SqlCommand cnd2 = new SqlCommand(sql2, con2);
					cnd2.Parameters.AddWithValue("@id2", id2);
					SqlDataReader rd2 = cnd2.ExecuteReader();
					if (rd2.Read())
					{
						string v1 = rd2.GetString(0);
						livreinf.Editeur = v1;
					}



					livreinf.idauteur = rd.GetInt32(4);

					string connectionString1 = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
					SqlConnection con1=new SqlConnection(connectionString1);
					con1.Open();
					int id = Convert.ToInt32(livreinf.idauteur);
					string sql1 = "select NomAuteur from Auteur where IDAuteur=@id";
					SqlCommand cnd1= new SqlCommand(sql1, con1);
					cnd1.Parameters.AddWithValue("@id", id);
					SqlDataReader rd1=cnd1.ExecuteReader();
					if(rd1.Read())
					{
						string v=rd1.GetString(0);
						livreinf.Auteur = v;
					}
					


					livreinf.idcat = rd.GetInt32(5);


					string connectionString3 = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
					SqlConnection con3 = new SqlConnection(connectionString3);
					con3.Open();
					int id3 = Convert.ToInt32(livreinf.idcat);
					string sql3 = "select NomCat from Categorie where IDCat=@id3";
					SqlCommand cnd3 = new SqlCommand(sql3, con3);
					cnd3.Parameters.AddWithValue("@id3", id3);
					SqlDataReader rd3 = cnd3.ExecuteReader();
					if (rd3.Read())
					{
						string v2 = rd3.GetString(0);
						livreinf.Categorie = v2;
					}


					livreinf.description=rd.GetString(6);
					livreinf.anneeedition = rd.GetInt32(7);
					listLivres.Add(livreinf);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception " + ex.ToString());
			}
		}
	}


	public class LivreInfo
	{
		public int id;
		public string? titre;
		public string? isbn;
		public int? idediteur;
		public int? idauteur;
		public int? idcat;
		public string? description;
		public int? anneeedition;
		public string? Auteur;
		public string? Editeur;
		public string? Categorie;
	}
}
