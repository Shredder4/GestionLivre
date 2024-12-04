using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class createAuteurModel : PageModel
    {
        public AuteurInfo auteurInfo = new AuteurInfo();
        public string errormessage = "";
        public string SuccessMessage = "";
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            auteurInfo.nom = Request.Form["Nom"];
            auteurInfo.email = Request.Form["Email"];
            auteurInfo.telephone = Request.Form["Telephone"];
            auteurInfo.adresse = Request.Form["Adresse"];
            if(auteurInfo.nom.Length==0 || auteurInfo.email.Length == 0 || auteurInfo.telephone.Length==0 || auteurInfo.adresse.Length==0)
            {
                errormessage = "Tous les champs sont obligatoires";
                return;
            }

			try
			{
				string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
				SqlConnection con = new SqlConnection(connectionString);
				con.Open();
				string sql = "insert into Auteur(NomAuteur,EmailAuteur,telephoneAut,AdresseAut) values(@nom, @email, @telephone, @adresse)";
 SqlCommand cmd = new SqlCommand(sql, con);
				// cmd.Parameters.AddWithValue("@id",clientInfo.id);
				cmd.Parameters.AddWithValue("@nom", auteurInfo.nom);
				cmd.Parameters.AddWithValue("@email", auteurInfo.email);
				cmd.Parameters.AddWithValue("@telephone", auteurInfo.telephone);
				cmd.Parameters.AddWithValue("@adresse", auteurInfo.adresse);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception" + ex.ToString());
			}
		}
	}
}
