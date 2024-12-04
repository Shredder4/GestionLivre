using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class createCategorieModel : PageModel
    {
		public CategInfo CategInfo = new CategInfo();
		public string errormessage = "";
		public string SuccessMessage = "";
		public void OnGet()
		{
		}
		public void OnPost()
		{
			CategInfo.nom = Request.Form["nom"];
			CategInfo.description = Request.Form["description"];

			if (CategInfo.nom.Length == 0 || CategInfo.description.Length==0)
			{
				errormessage = "Tous les champs sont obligatoires";
				return;
			}

			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "insert into Categorie(NomCat,DescriptionCat) values(@nom, @description)";
				SqlCommand cmd = new SqlCommand(sql, con);
				// cmd.Parameters.AddWithValue("@id",clientInfo.id);
				cmd.Parameters.AddWithValue("@nom", CategInfo.nom);
				cmd.Parameters.AddWithValue("@description", CategInfo.description);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception" + ex.ToString());
			}




		}
	}
}
