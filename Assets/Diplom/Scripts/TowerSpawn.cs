using System;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public static event Action<GameObject> addHealthBarTowers;
    [field: SerializeField] public GameManager _gameManager { get; set; }
    [field: SerializeField] public ObjectManager _objectManager { get; set; }
    private GameObject _spawnTowersPrefab;

    private void Start() => gameObject.GetComponent<TowerSelection>().getSpawnPointObj += SetSpawnObj;

    private void OnDisable() {
        gameObject.GetComponent<TowerSelection>().getSpawnPointObj -= SetSpawnObj;
    }

    public void Spawn(GameObject obj)
    {
        if (_gameManager.CheckEnergy(obj.GetComponent<TowerHealth>()._price)) 
        {
            _gameManager._currentEnergy -= obj.GetComponent<TowerHealth>()._price;
            _gameManager.SetText(_gameManager._currentEnergy, _gameManager._energyText);
            GameObject tower = Instantiate(obj);
            addHealthBarTowers?.Invoke(tower.transform.Find("HealthBar").gameObject);
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

    private void CloseMenuSelectionTowers() => gameObject.GetComponent<TowerSelection>().SetControllerValue(false);
}
