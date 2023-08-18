using System.Collections.Generic;
using UnityEngine;

public class EntityPool
{
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

        _notSpawnedEntities.Remove(spawningEntity);

        spawningEntity.transform.position = position;
        spawningEntity.gameObject.SetActive(true);
        spawningEntity.Died += AddInDespawnedList;
    }

    private void AddInDespawnedList(Entity entity)
    {
        _notSpawnedEntities.Add(entity);

        entity.Died -= AddInDespawnedList;
    }
}