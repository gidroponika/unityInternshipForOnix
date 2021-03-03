using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
    [SerializeField]
    List<GameObject> targets;
    [SerializeField]
    float speed;
    void Start()
    {
        targets = new List<GameObject>();
        targets.AddRange(GameObject.FindGameObjectsWithTag("Target"));
        print(targets.Count);
    }
    void Update()
    {
        
    }
    void MoveToTarget(IEnumerable<GameObject> targets) {

    }
}
