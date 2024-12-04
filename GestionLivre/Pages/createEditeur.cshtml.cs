using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class createEditeurModel : PageModel
	{
		public EditeurInfo EditeurInfo = new EditeurInfo();
		public string errormessage = "";
		public string SuccessMessage = "";
		public void OnGet()
		{
		}
		public void OnPost()
		{
			EditeurInfo.nom = Request.Form["nom"];
			EditeurInfo.description = Request.Form["description"];
			EditeurInfo.email = Request.Form["email"];
			EditeurInfo.tele = Request.Form["tele"];
			EditeurInfo.adresse = Request.Form["adresse"];

			if (EditeurInfo.nom.Length == 0 || EditeurInfo.description.Length == 0 || EditeurInfo.email.Length == 0 || EditeurInfo.tele.Length == 0 || EditeurInfo.adresse.Length == 0)
			{
				errormessage = "Tous les champs sont obligatoires";
				return;
			}

			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "insert into Editeur(NomEditeur,DescripEditeur,EmailEdit,telephoneEdi,AddressEdit) values(@nom, @description, @email, @tele, @adresse)";
				SqlCommand cmd = new SqlCommand(sql, con);
				// cmd.Parameters.AddWithValue("@id",clientInfo.id);
				cmd.Parameters.AddWithValue("@nom", EditeurInfo.nom);
				cmd.Parameters.AddWithValue("@description", EditeurInfo.description);
				cmd.Parameters.AddWithValue("@email", EditeurInfo.email);
				cmd.Parameters.AddWithValue("@tele", EditeurInfo.tele);
				cmd.Parameters.AddWithValue("@adresse", EditeurInfo.adresse);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception" + ex.ToString());
			}
		}
	}
}
