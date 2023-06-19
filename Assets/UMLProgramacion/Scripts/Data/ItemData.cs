using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Item", order = 0)]
    public class ItemData : ScriptableObject
    {
        public int ID => _id;
        public string Name => currentName;
        public GameObject Prefab => currentPrefab;
        
        [SerializeField] private int _id;
        [SerializeField] private string currentName;
        [SerializeField] private GameObject currentPrefab;
    }
}
