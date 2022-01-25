using System.Collections.Generic;
using UnityEngine;

public class objectReferences : MonoBehaviour
{
    public List<GameObject> objIDRef = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBot"))
        {
            objIDRef.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        objIDRef.Remove(objIDRef[0]);
    }

    public void isNull()
    {
        objIDRef.Remove(objIDRef[0]);
    }
}
