using UnityEngine;

namespace DefaultNamespace
{
    public interface IGameFactory
    {
        GameObject CreateElement(GameObject prefab, Vector3 at, Transform container);
        GameObject CreateElement(GameObject prefab, Transform container);
        GameObject CreateElement(GameObject prefab, Vector3 at);
        GameObject CreateElement(GameObject prefab);
    }
}