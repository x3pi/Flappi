using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int columnPoolSize = 5;
    private GameObject[] columns;
    public GameObject columnPrefab;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    public float spawnRate = 2f;
    private float timeSinceLastSpawned;

    public float columnMin = -0.4f;
    public float columnMax = 0.6f;
    private int currentColumn = 0;
    public float spawnXPosition = 1f;
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }

    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControll.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(columnMin, columnMax);

            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }

    }
}
