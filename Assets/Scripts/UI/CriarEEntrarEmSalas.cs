using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CriarEEntrarEmSalas : MonoBehaviourPunCallbacks
{

    public InputField entrarNaSalaInput;
    public InputField criarSalaInput;

    public void CriarSala(){
        PhotonNetwork.CreateRoom(criarSalaInput.text);
    }

    public void EntrarNaSala(){
        PhotonNetwork.JoinRoom(entrarNaSalaInput.text);
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("Jogo");
    }





}
