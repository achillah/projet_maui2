﻿using System.IO;
using Newtonsoft.Json;
namespace MyReference.ViewModel;

public partial class AjouterJoueurViewModel : BaseViewModel
{
    [ObservableProperty]
    Joueur joueurNvx;
    public AjouterJoueurViewModel()
    {
        this.joueurNvx = new Joueur();
    }


    [RelayCommand]
    async void AjouterJoueur()
{
    if ((string.IsNullOrEmpty(JoueurNvx.ID)) || (string.IsNullOrWhiteSpace(JoueurNvx.ID))
                || (string.IsNullOrEmpty(JoueurNvx.Nom)) || (string.IsNullOrWhiteSpace(JoueurNvx.Nom))
                || (string.IsNullOrEmpty(JoueurNvx.Prenom)) || (string.IsNullOrWhiteSpace(JoueurNvx.Prenom))
                || (string.IsNullOrEmpty(JoueurNvx.Age.ToString())) || (string.IsNullOrWhiteSpace(JoueurNvx.Age.ToString()))
                || (string.IsNullOrEmpty(JoueurNvx.Poste)) || (string.IsNullOrWhiteSpace(JoueurNvx.Poste))
                || (string.IsNullOrEmpty(JoueurNvx.Image)) || (string.IsNullOrWhiteSpace(JoueurNvx.Image)))
    {
        await Shell.Current.DisplayAlert("Erreur Ajout Joueur", "Veuillez entrer de vraies valeurs", "OK");
    }
    else
    {
        // Ajoute le nouveau joueur à la liste
        Globals.MyJoueurList.Add(JoueurNvx);

        // Chemin d'accès complet au fichier JSON
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerDonnees", "Joueurs.json");

        // Récupère le contenu existant du fichier
        string jsonContent = File.ReadAllText(filePath);

        // Désérialise le contenu JSON en une liste
        var joueurs = JsonConvert.DeserializeObject<List<Joueur>>(jsonContent);

        // Ajoute le nouveau joueur à la liste désérialisée
        joueurs.Add(JoueurNvx);

        // Sérialise la liste mise à jour en JSON
        string updatedJsonContent = JsonConvert.SerializeObject(joueurs);


            try
            {
                // Écrit le contenu JSON sérialisé dans le fichier
                File.WriteAllText(filePath, updatedJsonContent);
            }
            catch (Exception e)
            {

                await Shell.Current.DisplayAlert("Ecriture non réaliser", e.Message, "OK");

            }
          

        await Shell.Current.DisplayAlert("Joueur ajouté", "Vous pouvez revenir en arrière.", "OK");
    }
}
}