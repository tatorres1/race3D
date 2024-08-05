using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveScore(int playerId, int score)
    {
        StartCoroutine(SendScore(playerId, score));
        Debug.Log("ingresa al save scre ");

    }

    IEnumerator SendScore(int playerId, int score)
    {
        WWWForm form = new WWWForm();
        Debug.Log("creo el wwwform " + playerId + " con score: " + score);

        form.AddField("playerId", playerId);
        Debug.Log("esta el player id " + playerId + " con score: " + score);

        form.AddField("score", score);

        Debug.Log("Enviando playerId: " + playerId + " con score: " + score);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/raceUnity3D/save_score.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Score saved successfully!");
            }
        }
    }
}
