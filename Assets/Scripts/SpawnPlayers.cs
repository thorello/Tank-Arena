using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    private float xPos;
    private float zPos;
    // Start is called before the first frame update
    void Start()
    {
        xPos = Random.Range(27, 39);
        zPos = Random.Range(20, 41);
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(xPos, 0, zPos), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
