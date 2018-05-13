using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPool : MonoBehaviour
{

    public int starsPoolSize = 3;
    public GameObject starsPrefab;
    public float spawnRate = 1f;


    private GameObject[] stars;
    private Vector3 starsPoolPosition = new Vector3(-150, -250, 0);
    private float timeSinceLastSpawned;
    private int currentStar = 0;

    // Use this for initialization
    void Start()
    {
        stars = new GameObject[starsPoolSize];
        for (int i = 0; i < starsPoolSize; i++)
        {
            stars[i] = Instantiate(starsPrefab, starsPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (GameManager.Instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            stars[currentStar].transform.position = new Vector3(-15, -60, -13.5f);
            currentStar++;
            if (currentStar >= starsPoolSize)
            {
                currentStar = 0;
            }
        }

        if (spawnRate > 1)
        {
            spawnRate -= Time.deltaTime / 200;
        }
    }
}
