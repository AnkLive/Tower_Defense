using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [field: SerializeField]
    private GameObject _spawnTowersPrefab;

    private void Awake() => gameObject.GetComponent<TowerSelection>().getSpawnPointObj += SetSpawnObj;

    private void SpawnRailgun()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Railgun"));
        obj.transform.SetParent(_spawnTowersPrefab.transform);
        obj.transform.localPosition = new Vector3(
            Vector3.zero.x,
            Vector3.zero.y + 0.15f,
            Vector3.zero.z
        );
        CloseMenuSelectionTowers();
    }
    
    private void SpawnCannon()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Cannon"));
        obj.transform.SetParent(_spawnTowersPrefab.transform);
        obj.transform.localPosition = new Vector3(
            Vector3.zero.x,
            Vector3.zero.y + 0.15f,
            Vector3.zero.z
        );
        CloseMenuSelectionTowers();
    }

    private void SpawnMashinegun()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Mashinegun"));
        obj.transform.SetParent(_spawnTowersPrefab.transform);
        obj.transform.localPosition = new Vector3(
            Vector3.zero.x,
            Vector3.zero.y + 0.15f,
            Vector3.zero.z
        );
        CloseMenuSelectionTowers();
    }

    public void SetSpawnObj(GameObject obj) => _spawnTowersPrefab = obj;

    private void CloseMenuSelectionTowers() => gameObject.GetComponent<TowerSelection>().CloseMenuSelectionTowers();
}
