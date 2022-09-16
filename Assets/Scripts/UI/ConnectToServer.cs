using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI tentandoConectarText;
    // Start is called before the first frame update

    public override void OnConnectedToMaster()
    {

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }


    public void Connect()
    {

        PhotonNetwork.ConnectUsingSettings();
        tentandoConectarText.text = "Tentando conectar ao servidor";
        if (PhotonNetwork.IsConnected)
        {
            tentandoConectarText.text = "Carregando";
        }
        else
        {
            tentandoConectarText.text = "Falha na Conexão";
        }
    }


}
