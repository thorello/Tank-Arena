using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    private float xPos;
    private float zPos;

    void Start()
    {
        xPos = Random.Range(27, 39);
        zPos = Random.Range(20, 41);

        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(xPos, 0, zPos), transform.rotation * Quaternion.Euler(0f, -90f, 0f));
        //PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-35, 0, -25), transform.rotation * Quaternion.Euler(0f, -90f, 0f));
    }

}
