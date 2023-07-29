using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.SetCanMove(false);
            Scene currentScene = SceneManager.GetActiveScene();
            int nextSceneIndex = currentScene.buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
