using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;

    private void OnEnable()
    {
        stepped = false;

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)            
                obstacles[i].SetActive(true);
            else
                obstacles[i].SetActive(false);
        }
        /*foreach (GameObject i in obstacles)
        {
            i.SetActive(Random.Range(0, 3) == 0 ? true : false);
        }*/
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(10);
        }
    }
}
