using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolsize = 5;
    public GameObject columnPrefab;
    public float spawnrate = 4f;
    public float columnMin = -1f;
    public float columnMax= 3.5f;
    

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;


    void Start()
    {
        columns = new GameObject[columnPoolsize];
        for (int i = 0; i < columnPoolsize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.GameOver == false && timeSinceLastSpawned >= spawnrate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolsize)
            {
                currentColumn = 0;
            }
        }
    }
}
