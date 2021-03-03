using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
    [SerializeField]
    List<GameObject> targets;
    [SerializeField]
    float speed;
    
    Rigidbody rb;
    void Start()
    {
        targets = new List<GameObject>();
        targets.AddRange(GameObject.FindGameObjectsWithTag("Target"));
        rb = gameObject.GetComponent<Rigidbody>();
        print(targets.Count);
    }
    void Update()
    {
        MoveToTarget();
    }
    void MoveToTarget() {
        gameObject.transform.LookAt(GetTarget(targets).transform);
        //rb.MovePosition(transform.position + GetTarget(targets).transform.position * Time.fixedDeltaTime*0.1f);
        //transform.position += GetTarget(targets).transform.position * Time.deltaTime*speed;
        Vector3.MoveTowards(transform.position, GetTarget(targets).transform.position, Time.deltaTime * speed);
        print(GetTarget(targets).name);
    }
    GameObject GetTarget(List<GameObject> targets) {
        int indexTarget = 0;
        if(indexTarget != targets.Count - 1) {
            if (transform.position == targets[indexTarget].transform.position) {
                print("Final destination");
                indexTarget++;
                return targets[indexTarget];
            }
        }
        indexTarget = 0;
        return targets[indexTarget];
    }
}
