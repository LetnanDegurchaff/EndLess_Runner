using System.Collections.Generic;
using UnityEngine;

public class EntityPool
{
    private List<Entity> _spawnedEntities = new List<Entity>();
    private List<Entity> _notSpawnedEntities = new List<Entity>();

    public float EnemyRatio { get; private set;}

    public EntityPool() => EnemyRatio = 0.85f;

    public void AddEntity(Entity entity)
    {
        _notSpawnedEntities.Add(entity);
    }

    public void TrySpawnEntity(Vector3 position)
    {
        if (_notSpawnedEntities.Count == 0)
            return;

        Entity spawningEntity =
            _notSpawnedEntities[Random.Range(0, _notSpawnedEntities.Count)];

        spawningEntity.transform.position = position;
        spawningEntity.gameObject.SetActive(true);

        _notSpawnedEntities.Remove(spawningEntity);
        _spawnedEntities.Add(spawningEntity);
        spawningEntity.Died += AddInDespawnedList;
    }

    public void OnEnable()
    {
        foreach (var entity in _spawnedEntities)
        {
            entity.Died += AddInDespawnedList;
        }
    }

    public void OnDisable()
    {
        foreach (var entity in _spawnedEntities)
        {
            entity.Died -= AddInDespawnedList;
        }
    }

    private void AddInDespawnedList(Entity entity)
    {
        _notSpawnedEntities.Add(entity);
        _spawnedEntities.Remove(entity);

        entity.Died -= AddInDespawnedList;
    }
}