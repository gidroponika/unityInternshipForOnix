using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
    [SerializeField]
    List<GameObject> targets;
    [SerializeField]
    float speed;
    [SerializeField]
    Material material;
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
        if (gameObject.transform.position.Equals(targets[indexTarget].transform.position)) {
            indexTarget++;
            material.color = GetRandomColor();
            if (indexTarget == targets.Count) {
                indexTarget = 0;
            }
        }
        return targets[indexTarget];
    }
    Color32 GetRandomColor() {
        byte [] RGBA=new byte[3];
        for(int i = 0; i < RGBA.Length; i++) {
            RGBA[i] = (byte)Random.Range(0, 256);
        }
        Color32 color = new Color32(RGBA[0], RGBA[1], RGBA[2], 255);
        return color;
    }
}
