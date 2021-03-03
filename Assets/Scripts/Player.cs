using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
    [SerializeField]
    List<GameObject> targets;

    [SerializeField]
    float speed;

    int indexTarget;
    void Start()
    {
        targets = new List<GameObject>();
        targets.AddRange(GameObject.FindGameObjectsWithTag("Target"));
        indexTarget = 0;
    }
    void Update()
    {
        MovementToTarget();
    }

    //method of movement to the target
    void MovementToTarget() {
        gameObject.transform.LookAt(GetTarget(targets).transform);
        transform.position = Vector3.MoveTowards(transform.position, 
                             GetTarget(targets).transform.position, 
                             Time.deltaTime * speed);
        
    }

    // method, that sets a new target when the old one is reached
    GameObject GetTarget(List<GameObject> targets) {
        if (gameObject.transform.position == targets[indexTarget].transform.position) {
            indexTarget++;
            if (indexTarget == targets.Count) {
                indexTarget = 0;
            }
        }
        return targets[indexTarget];
    }
}
