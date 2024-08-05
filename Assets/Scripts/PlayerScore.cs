using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviourPunCallbacks
{
    public int score = 0;
    private PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log($"Puntaje: {score}");

        if (photonView.IsMine)
        {
            string playerIdStr = photonView.Owner.UserId;

            // Intentar convertir
            if (int.TryParse(playerIdStr, out int playerId))
            {
                Debug.Log($"Jugador {playerId} con puntaje {score}");
                ScoreManager.Instance.SaveScore(playerId, score);
            }
            else
            {
                Debug.LogError($"Error: UserId '{playerIdStr}' no se pudo convertir a int.");
            }
        }
    }
}
