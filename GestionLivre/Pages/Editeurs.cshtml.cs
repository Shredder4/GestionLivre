using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace GestionLivre.Pages
{
    public class EditeursModel : PageModel
    {
		public List<EditeurInfo> listEditeurs = new List<EditeurInfo>();	
        public void OnGet()
        {
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "select * from Editeur";
				SqlCommand cmd = new SqlCommand(sql, con);
				SqlDataReader rd = cmd.ExecuteReader();


				while (rd.Read())
				{
					EditeurInfo editinf = new EditeurInfo();
					editinf.id = rd.GetInt32(0);
					editinf.nom = rd.GetString(1);
					editinf.description = rd.GetString(2);
					editinf.email = rd.GetString(3);
					editinf.tele=rd.GetString(4);
					editinf.adresse=rd.GetString(5);
					listEditeurs.Add(editinf);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception " + ex.ToString());
			}
		}
	}

	public class EditeurInfo
	{
		public int id;
		public string? nom;
		public string? description;
		public string? email;
		public string? tele;
		public string? adresse;
	}
}
