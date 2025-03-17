using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell : MonoBehaviour {

    public float rotationSpeed = 100.0f;
    public float translationSpeed = 0.5f;
    public float translationHeight = 0.5f;
    private float originalHeight;
    private int directionMultiplier = 1;
    public int stopDuration = 10;
    private int idleFrameDuration = 0;

	// Use this for initialization
	void Start () {
		originalHeight = transform.position.y;
        //Debug.Log("Starting power cell");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        //transform.Translate(0,0.5f,0);
        if (idleFrameDuration <= 0)
        {
            if (transform.position.y > translationHeight + originalHeight)
            {
                directionMultiplier = -1;
                idleFrameDuration = stopDuration;
            } else if (transform.position.y < originalHeight)
            {
                directionMultiplier = 1;
                idleFrameDuration = stopDuration;
                gameObject.GetComponentInChildren<ParticleSystem>().Play();
            }
        }
        else {
            idleFrameDuration--;
        }

        if (idleFrameDuration <= 0)
            transform.Translate(0,directionMultiplier * Time.deltaTime * translationSpeed,0);
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("LOL");
            col.gameObject.SendMessage("CellPickup");
            Destroy(gameObject);
        }
    }
}
