using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class editCategorieModel : PageModel
    {

		public CategInfo CategInfo = new CategInfo();
		public void OnGet()
		{
			string id = Request.Query["id"];
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "select * from Categorie where IDCat=@id";
				SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@id", id);
				SqlDataReader rd = cmd.ExecuteReader();


				if (rd.Read())
				{
					CategInfo.id = rd.GetInt32(0);
					CategInfo.nom = rd.GetString(1);
					CategInfo.description = rd.GetString(2);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception " + ex.ToString());
			}
		}
		public void OnPost()
		{
			CategInfo.id = Convert.ToInt32(Request.Form["id"]);
			CategInfo.nom = Request.Form["nom"];
			CategInfo.description = Request.Form["description"];
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();

				string sql = "update Categorie set NomCat = @nom,DescriptionCat = @description where IDCat = @id";
				SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@id", CategInfo.id);
				cmd.Parameters.AddWithValue("@nom", CategInfo.nom);
				cmd.Parameters.AddWithValue("@description", CategInfo.description);
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
