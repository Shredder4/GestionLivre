using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class editEditeurModel : PageModel
	{
		public EditeurInfo EditeurInfo = new EditeurInfo();
		public void OnGet()
		{
			string id = Request.Query["id"];
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "select * from Editeur where IDEditeur=@id";
				SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@id", id);
				SqlDataReader rd = cmd.ExecuteReader();


				if (rd.Read())
				{
					EditeurInfo.id = rd.GetInt32(0);
					EditeurInfo.nom = rd.GetString(1);
					EditeurInfo.description = rd.GetString(2);
					EditeurInfo.email = rd.GetString(3);
					EditeurInfo.tele = rd.GetString(4);
					EditeurInfo.adresse=rd.GetString(5);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception " + ex.ToString());
			}
		}
		public void OnPost()
		{
			EditeurInfo.id = Convert.ToInt32(Request.Form["id"]);
			EditeurInfo.nom = Request.Form["nom"];
			EditeurInfo.description = Request.Form["description"];
			EditeurInfo.email = Request.Form["email"];
			EditeurInfo.tele = Request.Form["tele"];
			EditeurInfo.adresse = Request.Form["adresse"];
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();

				string sql = "update Editeur set NomEditeur = @nom,DescripEditeur = @description,EmailEdit = @email,telephoneEdi = @tele,AddressEdit = @adresse where IDEditeur = @id";
				SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@id", EditeurInfo.id);
				cmd.Parameters.AddWithValue("@nom", EditeurInfo.nom);
				cmd.Parameters.AddWithValue("@description", EditeurInfo.description);
				cmd.Parameters.AddWithValue("@email", EditeurInfo.email);
				cmd.Parameters.AddWithValue("@tele", EditeurInfo.tele);
				cmd.Parameters.AddWithValue("@adresse", EditeurInfo.adresse);
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
