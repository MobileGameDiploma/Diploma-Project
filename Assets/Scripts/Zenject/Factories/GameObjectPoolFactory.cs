using UnityEngine;
using Zenject;

public class GameObjectPoolFactory : IFactory<GameObject, PoolSettings, GameObjectPool>
{
    public GameObjectPool Create(GameObject param1, PoolSettings param2)
    {
        return new GameObjectPool(param1, param2);
    }
}