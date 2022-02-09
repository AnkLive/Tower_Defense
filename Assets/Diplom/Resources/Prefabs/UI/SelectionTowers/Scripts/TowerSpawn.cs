using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    private GameObject _spawnTowersPrefab;

    private void Awake() => gameObject.GetComponent<TowerSelection>().getSpawnPointObj += SetSpawnObj;

    public void SpawnTower(GameObject obj)
    {
        GameObject tower = Instantiate(obj);
        tower.transform.SetParent(_spawnTowersPrefab.transform);
        tower.transform.localPosition = new Vector3(
            Vector3.zero.x,
            Vector3.zero.y + 0.15f,
            Vector3.zero.z
        );
        CloseMenuSelectionTowers();
    }

    public void SetSpawnObj(GameObject obj) => _spawnTowersPrefab = obj;

    private void CloseMenuSelectionTowers() => gameObject.GetComponent<TowerSelection>().CloseMenuSelectionTowers();
}
