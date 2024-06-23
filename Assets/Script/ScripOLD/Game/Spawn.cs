using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    public GameObject[] enemyPrefabs;
    [SerializeField]
    public int numberOfEnemiesToSpawn; // Số lượng enemy cần spawn
    [SerializeField]
    public Transform[] spawnPoints; // Danh sách các điểm spawn point

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        // Kiểm tra nếu số lượng enemy muốn spawn lớn hơn số lượng spawn point
        // Điều này đảm bảo không có quá nhiều enemy spawn tại cùng một điểm
        int numberOfSpawnPoints = spawnPoints.Length;
        int spawnCount = Mathf.Min(numberOfEnemiesToSpawn, numberOfSpawnPoints);

        // Tạo danh sách chứa các chỉ số spawn point
        int[] spawnIndices = new int[numberOfSpawnPoints];
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            spawnIndices[i] = i;
        }

        // Randomize danh sách spawnIndices
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            int randomIndex = Random.Range(i, numberOfSpawnPoints);
            int temp = spawnIndices[i];
            spawnIndices[i] = spawnIndices[randomIndex];
            spawnIndices[randomIndex] = temp;
        }

        // Spawn enemy tại các điểm spawn point đã được randomize
        for (int i = 0; i < spawnCount; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnIndex = spawnIndices[i];
            GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        }
        
    }
}
