using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class DiconnectToServer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Conectar");
        
    }


}


