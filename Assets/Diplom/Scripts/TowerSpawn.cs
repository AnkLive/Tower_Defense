using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [field: SerializeField] public GameManager _gameManager { get; set; }
    [field: SerializeField] public ObjectManager _objectManager { get; set; }
    private GameObject _spawnTowersPrefab;

    private void Awake() => gameObject.GetComponent<TowerSelection>().getSpawnPointObj += SetSpawnObj;

    public void Spawn(GameObject obj)
    {
        if (_gameManager.CheckEnergy(obj.GetComponent<EnemyHealth>()._numberOfCoins)) { //!!!!!!
            _gameManager._currentEnergy -= obj.GetComponent<EnemyHealth>()._numberOfCoins; //!!!!!!
            _gameManager.SetText(_gameManager._currentEnergy, _gameManager._energyText);
            GameObject tower = Instantiate(obj);
            _objectManager?.AddListObj(_objectManager._allTowersList, tower);
            tower.transform.SetParent(_spawnTowersPrefab.transform);
            tower.transform.localPosition = new Vector3(
                Vector3.zero.x,
                Vector3.zero.y + 0.15f,
                Vector3.zero.z
            );
            CloseMenuSelectionTowers();
        }
        else 
        {
            Debug.Log("No energy");
        }
    }

    public void SetSpawnObj(GameObject obj) => _spawnTowersPrefab = obj;

    private void CloseMenuSelectionTowers() => gameObject.GetComponent<TowerSelection>().CloseMenuSelectionTowers();
}
