using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateRight : MonoBehaviour
{

    public float speed = 1f;
    private Vector3 pos_1 = new Vector3(199.79f, 32.44f, 778.2f);
    private Vector3 pos_2 = new Vector3(196.04f, 32.44f, 784.6952f);

    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.Lerp(pos_1, pos_2, Mathf.PingPong(Time.time * speed, 1f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
