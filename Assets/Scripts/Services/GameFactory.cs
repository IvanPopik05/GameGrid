using UnityEngine;

namespace DefaultNamespace
{
    public class GameFactory : IGameFactory
    {
        public GameObject CreateElement(GameObject prefab, Vector3 at, Transform container)
        {
            GameObject player = GameObject.Instantiate(prefab, at, Quaternion.identity,container);
            return player;
        }
        public GameObject CreateElement(GameObject prefab,Vector3 at)
        {
            GameObject player = GameObject.Instantiate(prefab,at,Quaternion.identity);
            return player;
        }

        public GameObject CreateElement(GameObject prefab,  Transform container)
        {
            GameObject player = GameObject.Instantiate(prefab,container);
            return player;
        }
        
        public GameObject CreateElement(GameObject prefab)
        {
            GameObject player = GameObject.Instantiate(prefab);
            return player;
        }

    }
}