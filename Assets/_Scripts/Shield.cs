using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour {
    [Header("Inscribed")]
    public float rotationsPerSecond = 0.1F;

    [Header("Dynamic")]
    public int levelShown = 0;

    Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
    }

    void Update() {
        int currentLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
        if(levelShown != currentLevel) {
            levelShown = currentLevel;
            mat.mainTextureOffset = new Vector2(0.2f*levelShown, 0);
        }

        float rZ = -(rotationsPerSecond*Time.time*360) % 360.0f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
