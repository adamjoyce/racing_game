﻿using UnityEngine;
using System.Collections;

public class HealthRestore : MonoBehaviour {

    public float lifetime = 20.0f;
    private float startTime;

    public Component[] carPieces;

    // Use this for initialization
    void Start () {
        gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        this.GetComponent<Renderer>().enabled = false;
        startTime = Time.timeSinceLevelLoad;
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled &&
             (startTime + lifetime) < Time.timeSinceLevelLoad)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled && collider.gameObject.tag == "WrenchTag")
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            startTime = Time.timeSinceLevelLoad;

            carPieces = collider.gameObject.transform.root.GetComponentsInChildren<MeshChange>();
            foreach (MeshChange pieces in carPieces)
            {
                pieces.meshHealth = 101;
            }
        }
    }
}
