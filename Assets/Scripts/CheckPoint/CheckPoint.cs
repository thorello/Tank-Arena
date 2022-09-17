using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{

    public bool isInCheckpoint = false;
    public Canvas canvas;
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInCheckpoint)
        {
            canvas.enabled = false;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            // GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            // foreach (GameObject player in players)
            // {
            //     float xPos = Random.Range(27, 39);
            //     float zPos = Random.Range(20, 41);
            //     player.transform.position = new Vector3(xPos, 0, zPos);
            // }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        isInCheckpoint = true;
        canvas.enabled = true;
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in gos)
        {
            go.SetActive(false);
        }


    }
}
