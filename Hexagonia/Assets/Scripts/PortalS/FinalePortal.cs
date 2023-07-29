using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalePortal: MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {    
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            if (IsPlayerNearPortal())
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.SetCanMove(false);
                }

                Scene currentScene = SceneManager.GetActiveScene();
                int nextSceneIndex = currentScene.buildIndex + 1;
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }

    private bool IsPlayerNearPortal()
    {
        Collider playerCollider = player.GetComponent<Collider>();
        if (playerCollider != null && GetComponent<Collider>() != null)
        {
            return playerCollider.bounds.Intersects(GetComponent<Collider>().bounds);
        }
        return false;
    }
}
