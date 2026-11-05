using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public static Hero S { get; private set;}
    [Header("Inscribed")]
    public float speed = 30;
    public float rollMult= -45;
    public float pitchMult = 30;

    [Header("Dynamic")] [Range(0,4)]
    public float shieldLevel = 1;
    private GameObject lastTriggerGo = null;

    void Awake(){
        if(S == null){
            S = this;
        } else {
            Debug.LogError("Hero.Awake() - Atteempted to assign second Hero.S!");
        }
    }

    void Update(){
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += hAxis * speed *Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(vAxis*pitchMult,hAxis*rollMult,0);

    }

    void OnTriggerEnter(Collider other) {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if(go == lastTriggerGo) return;
        lastTriggerGo = go;
        Enemy enemy = go.GetComponent<Enemy>();
        if(enemy != null){
            shieldLevel--;
            Destroy(go);
        }
        else {
            Debug.LogWarning("Shield trigger hit by non-Enemy: " + go.name);
        }

    }
}
