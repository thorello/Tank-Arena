using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CriarEEntrarEmSalas : MonoBehaviourPunCallbacks
{
    public InputField entrarNaSalaInput;
    public InputField criarSalaInput;

    public TextMeshProUGUI textMessage;

    void Start()
    {
        textMessage = GameObject.FindWithTag("textoConexao").GetComponent<TextMeshProUGUI>();
        criarSalaInput.text = "Sala Padrao";
        entrarNaSalaInput.text = "Sala Padrao";
    }

    public void CriarSala()
    {
        if (criarSalaInput.text == "")
        {
            textMessage.text = "A sala necessita de um nome para ser criada";
        }
        else
        {
            PhotonNetwork.CreateRoom(criarSalaInput.text);
        }
    }

    public void EntrarNaSala()
    {
        if (entrarNaSalaInput.text == "")
        {
            textMessage.text = "Você precisa dar um nome à sala";
        }
        else
        {
            PhotonNetwork.JoinRoom(entrarNaSalaInput.text);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Jogo");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        textMessage.text = "Sala inexistente ou falhou ao entrar na sala";
    }





}
