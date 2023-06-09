namespace MyReference.Services;

public class JoueurService : ContentPage
{
	public JoueurService()
	{
	
	}

	public async Task<List<Joueur>> GetJoueurs()
    {
        List<Joueur> joueurs;

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerDonnees", "Joueurs.json");

       
        using var reader = new StreamReader(filePath);
        var contents = await reader.ReadToEndAsync();
        joueurs = JsonSerializer.Deserialize<List<Joueur>>(contents);

        return joueurs;
    }
}