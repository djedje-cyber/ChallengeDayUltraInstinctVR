using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

public class TeleportReplay : MonoBehaviour
{
    public TextAsset positionFile; // Permet de glisser un fichier texte dans l'inspecteur
    public float teleportDelay = 2f; // Temps entre chaque téléportation
    private List<Vector3> positions = new List<Vector3>();
    private int currentPositionIndex = 0;

    void Start()
    {
        ReadPositionsFromFile();

        if (positions.Count > 0)
        {
            StartCoroutine(TeleportToNextPosition());
        }
        else
        {
            Debug.LogWarning("Aucune position trouvée dans le fichier !");
        }
    }

    private void ReadPositionsFromFile()
    {
        if (positionFile == null)
        {
            Debug.LogError("❌ Aucun fichier position assigné !");
            return;
        }

        string[] lines = positionFile.text.Split('\n'); // Lire chaque ligne

        foreach (string line in lines)
        {
            string cleanedLine = line.Trim();
            if (string.IsNullOrEmpty(cleanedLine)) continue; // Ignore les lignes vides

            // Expression régulière pour extraire les nombres (supporte virgules et points décimaux)
            MatchCollection matches = Regex.Matches(cleanedLine, @"-?\d+([.,]\d+)?");

            if (matches.Count == 3) // Vérifie qu'on a bien 3 nombres (X, Y, Z)
            {
                try
                {
                    // Remplace les virgules par des points pour compatibilité float
                    string xStr = matches[0].Value.Replace(',', '.');
                    string yStr = matches[1].Value.Replace(',', '.');
                    string zStr = matches[2].Value.Replace(',', '.');

                    float x = float.Parse(xStr, CultureInfo.InvariantCulture);
                    float y = float.Parse(yStr, CultureInfo.InvariantCulture);
                    float z = float.Parse(zStr, CultureInfo.InvariantCulture);
                    positions.Add(new Vector3(x, y, z));

                    Debug.Log($"📌 Position chargée : ({x}, {y}, {z})");
                }
                catch (System.Exception e)
                {
                    Debug.LogError("❌ Erreur parsing ligne : " + cleanedLine + " - " + e.Message);
                }
            }
            else
            {
                Debug.LogWarning("⚠️ Format incorrect : " + cleanedLine);
            }
        }

        Debug.Log($"✅ Chargement terminé : {positions.Count} positions enregistrées !");
    }



    private IEnumerator TeleportToNextPosition()
    {
        while (currentPositionIndex < positions.Count)
        {
            transform.position = positions[currentPositionIndex];
            Debug.Log("Téléporté à : " + positions[currentPositionIndex]);

            yield return new WaitForSeconds(teleportDelay);
            currentPositionIndex++;
        }

        Debug.Log("Toutes les positions ont été atteintes !");
    }
}
