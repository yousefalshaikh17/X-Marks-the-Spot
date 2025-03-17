using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        //Debug.DrawRay(transform.position, transform.forward * 3);

        if(Physics.Raycast (transform.position, transform.forward, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "playerDoor")
            {
                Debug.Log("We are facing the door.");
            }
        }
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "playerDoor")
        {
            //Debug.Log("Walked into door.");
        }
    }
}
