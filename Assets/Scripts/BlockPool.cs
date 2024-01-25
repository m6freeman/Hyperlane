using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{

    public int blockPoolSize = 5;
    public GameObject blockPrefab;
    public float spawnSpeed = 1f;


    private GameObject[] blocks;
    private Vector3 blockPoolPosition = new Vector3(-15, -25, 0);
    private float timeSinceLastSpawned;
    public float spawnZPosition = 55f;
    private float[] blockXRange = new float[2] { 1.44f, 4.33f };
    private int currentBlock = 0;
    public float maxSpawnSpeed = 0.1f;
    public float increaseSpeedRate = 1250f;

    // Use this for initialization
    void Start()
    {
        blocks = new GameObject[blockPoolSize];
        for (int i = 0; i < blockPoolSize; i++)
        {
            blocks[i] = Instantiate(blockPrefab, blockPoolPosition, Quaternion.identity);
            blocks[i].GetComponentInChildren<SpriteRenderer>().material = GameManager.Instance.AssignObstacleColor(GameManager.Instance.ObstacleMaterials);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameManager.Instance.gameOver == false && timeSinceLastSpawned >= spawnSpeed)
        {
            timeSinceLastSpawned = 0;
            float spawnXPosition = blockXRange[Random.Range(0, 2)];
            blocks[currentBlock].transform.position = new Vector3(spawnXPosition, 0.6f, spawnZPosition);
            blocks[currentBlock].GetComponentInChildren<SpriteRenderer>().material = GameManager.Instance.AssignObstacleColor(GameManager.Instance.ObstacleMaterials);
            blocks[currentBlock].GetComponent<ScrollingObject>().wasHit = false;
            currentBlock++;
            if (currentBlock >= blockPoolSize)
            {
                currentBlock = 0;
            }
        }

        if (spawnSpeed > maxSpawnSpeed)
        {
            spawnSpeed -= Time.deltaTime / increaseSpeedRate;
        }
    }
}
