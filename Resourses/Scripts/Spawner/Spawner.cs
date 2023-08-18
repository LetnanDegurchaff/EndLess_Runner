using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnTransforms;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _poolVolume;

    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private ReapairBox _reapairBoxTemplate;

    private List<Vector3> _spawnPoints = new List<Vector3>();
    private EntityPool _entityPool = new EntityPool();

    private Coroutine _coroutine;

    private void Awake()
    {
        foreach (Transform spawnPoint in _spawnTransforms)
        {
            _spawnPoints.Add(spawnPoint.position);
        }

        CreateEntities(_poolVolume);
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    public void CreateEntities(int count)
    {
        int enemyCount = Convert.ToInt32(count * _entityPool.EnemyRatio);
        int repairBoxCount = count - enemyCount;

        for (int i = 0; i < enemyCount; i++)
        {
            CreateEntity(_enemyTemplate);
        }

        for (int i = 0; i < repairBoxCount; i++)
        {
            CreateEntity(_reapairBoxTemplate);
        }
    }

    private void CreateEntity(Entity template)
    {
        Entity newEntity = Instantiate(template);
        _entityPool.AddEntity(newEntity);
        newEntity.gameObject.SetActive(false);
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnDelay);
        System.Random random = new System.Random();

        while (true)
        {
            Vector3 spawnPoint = _spawnPoints[random.Next(_spawnPoints.Count)];
            _entityPool.TrySpawnEntity(spawnPoint);

            yield return waitForSeconds;
        }
    }
}