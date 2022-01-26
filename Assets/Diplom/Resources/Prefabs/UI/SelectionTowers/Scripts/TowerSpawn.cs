using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
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
        GameObject obj = Instantiate(Resources.Load<GameObject>("Cannon"));
        obj.transform.SetParent(_spawnTowersPrefab.transform);
        obj.transform.localPosition = new Vector3(
            Vector3.zero.x,
            Vector3.zero.y + 0.15f,
            Vector3.zero.z
        );
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
