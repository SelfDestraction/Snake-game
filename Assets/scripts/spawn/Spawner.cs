using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("general")]
    [SerializeField] private Transform _container;
    [SerializeField] private int _repeatCount;
    [SerializeField] private int _distanceBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;
    [Header("block")]
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private int _blockSpawnChance;
    [Header("wall")]
    [SerializeField] private Wall _WallTempLate;
    [SerializeField] private int _wallSpawnChance;
    [Header("heal")]
    [SerializeField] private Heal _healTempLate;
    [SerializeField] private int _healSpawnChance;

    private BlockSpawnPoint[] _blockSpawnPoints;
    private WallSpawnPoint[] _wallSpawnPoints;
    private HealSpawnPoint[] _healSpawnPoints;

    private void Start()
    {
        _blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        _healSpawnPoints = GetComponentsInChildren<HealSpawnPoint>();

        for (int i = 0; i < _repeatCount; i++)
        {
            MoveSpawner(_distanceBetweenFullLine);
            GenerateRandomElements(_wallSpawnPoints, _WallTempLate.gameObject, _wallSpawnChance);
            GenerateFullLine(_blockSpawnPoints, _blockTemplate.gameObject);
            GenerateRandomElements(_healSpawnPoints, _healTempLate.gameObject, _healSpawnChance);
            MoveSpawner(_distanceBetweenRandomLine);
            GenerateRandomElements(_wallSpawnPoints, _WallTempLate.gameObject, _wallSpawnChance);
            GenerateRandomElements(_blockSpawnPoints, _blockTemplate.gameObject, _blockSpawnChance);
            GenerateRandomElements(_healSpawnPoints, _healTempLate.gameObject, _healSpawnChance);
        }
    }

    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generatedElement)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateElement(spawnPoints[i].transform.position, generatedElement);
        }
    }

    private void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generatedElement, int spawnChance)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0,100) < spawnChance)
            {
                GameObject element = GenerateElement(spawnPoints[i].transform.position, generatedElement);
            }
        }
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject generatedElement)
    {
        spawnPoint.y -= generatedElement.transform.localScale.x;
        return Instantiate(generatedElement, spawnPoint, Quaternion.identity, _container);
    }

    private void MoveSpawner(int distance)
    {
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
    }
}
