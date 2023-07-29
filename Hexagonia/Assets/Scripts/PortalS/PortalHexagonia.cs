using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalHexagonia : MonoBehaviour
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

    public void OnClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = currentScene.buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}