using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpearTrap2 : MonoBehaviour
{
    public float speed = 0.5f;
   
    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, -1, 0) * 120f * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}