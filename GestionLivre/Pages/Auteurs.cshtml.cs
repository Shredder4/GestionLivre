using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivre.Pages
{
    public class AuteursModel : PageModel
    {
        public List<AuteurInfo> listAuteurs= new List<AuteurInfo>();
        public void OnGet()
        { 
    try
{
    string connectionString = "Data Source=DESKTOP-K19V05R\\SQLEXPRESS02;Initial Catalog=GestionLivre;Integrated Security=True";
    SqlConnection con = new SqlConnection(connectionString);
    con.Open();
    string sql = "select * from Auteur";
    SqlCommand cmd = new SqlCommand(sql, con);
    SqlDataReader rd = cmd.ExecuteReader();


    while (rd.Read()) 
    {
        AuteurInfo autinf = new AuteurInfo();
        autinf.id = rd.GetInt32(0);
        autinf.nom = rd.GetString(1);
        autinf.email = rd.GetString(2);
        autinf.telephone = rd.GetString(3);
        autinf.adresse = rd.GetString(4);
        listAuteurs.Add(autinf);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Exception " + ex.ToString());
}
}
}

public class AuteurInfo
{
    public int id;
    public string? nom;
    public string? email;
    public string? telephone;
    public string? adresse;
}

}
