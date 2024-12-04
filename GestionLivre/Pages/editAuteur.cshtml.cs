using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class editAuteurModel : PageModel
    {
        public AuteurInfo AuteurInfo = new AuteurInfo(); 
        public void OnGet()
        {
            string id= Request.Query["id"];
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "select * from Auteur where IDAuteur=@id";
				SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@id", id);
				SqlDataReader rd = cmd.ExecuteReader();
				

				if (rd.Read())
				{
					AuteurInfo.id = rd.GetInt32(0);
					AuteurInfo.nom = rd.GetString(1);
					AuteurInfo.email = rd.GetString(2);
					AuteurInfo.telephone = rd.GetString(3);
					AuteurInfo.adresse = rd.GetString(4);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception " + ex.ToString());
			}	
		}
		public void OnPost()
		{
			AuteurInfo.id = Convert.ToInt32(Request.Form["id"]);
			AuteurInfo.nom = Request.Form["nom"];
			AuteurInfo.email = Request.Form["email"];
			AuteurInfo.telephone = Request.Form["telephone"];
			AuteurInfo.adresse = Request.Form["adresse"];
			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();

				string sql = "update Auteur set NomAuteur = @nom,EmailAuteur = @email,telephoneAut = @telephone,AdresseAut = @adresse where IDAuteur = @id";
		    SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("@id", AuteurInfo.id);
				cmd.Parameters.AddWithValue("@nom", AuteurInfo.nom);
				cmd.Parameters.AddWithValue("@email", AuteurInfo.email);
				cmd.Parameters.AddWithValue("@telephone", AuteurInfo.telephone);
				cmd.Parameters.AddWithValue("@adresse", AuteurInfo.adresse);
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
    

