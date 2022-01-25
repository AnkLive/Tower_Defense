using UnityEngine;

public class spawnTowers : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnTowersPrefab;
    public void SpawnRailgun()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Railgun"));
        obj.transform.SetParent(_spawnTowersPrefab.transform);
        obj.transform.localPosition = Vector3.zero;
        CloseMenuSelectionTowers();
    }
    public void SpawnCannon()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Canon"));
        obj.transform.SetParent(_spawnTowersPrefab.transform);
        obj.transform.localPosition = Vector3.zero;
        CloseMenuSelectionTowers();
    }
    public void SpawnMashinegun()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Mashinegun"));
        obj.transform.SetParent(_spawnTowersPrefab.transform);
        obj.transform.localPosition = Vector3.zero;
        CloseMenuSelectionTowers();
    }

    public void CloseMenuSelectionTowers()
    {
        gameObject.GetComponent<TowerSelection>().CloseMenuSelectionTowers();
    }
}
