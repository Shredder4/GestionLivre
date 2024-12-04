using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace GestionLivre.Pages
{
    public class CategorieModel : PageModel
    {
        public List<CategInfo> listCategories = new List<CategInfo>();
        public void OnGet()
        {
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "select * from Categorie";
				SqlCommand cmd = new SqlCommand(sql, con);
				SqlDataReader rd = cmd.ExecuteReader();


				while (rd.Read())
				{
					CategInfo catinf = new CategInfo();
					catinf.id = rd.GetInt32(0);
					catinf.nom = rd.GetString(1);
					catinf.description = rd.GetString(2);
					listCategories.Add(catinf);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception " + ex.ToString());
			}
		}
	}
    

	public class CategInfo
	{
		public int id;
		public string? nom;
		public string? description;
	}
}
