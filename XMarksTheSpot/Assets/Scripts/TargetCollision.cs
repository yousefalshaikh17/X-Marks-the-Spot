using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (AudioSource))]

public class TargetCollision : MonoBehaviour {

    bool beenHit = false;
    Animation targetRoot;
    public AudioClip hitSound;
    public AudioClip resetSound;
    public float resetTime = 3.0f;

	// Use this for initialization
	void Start () {
        targetRoot = transform.parent.transform.parent.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision theObject)
    {
        if(beenHit==false && theObject.gameObject.name == "coconut")
        {
            StartCoroutine("targetHit");
        }
    }

    IEnumerator targetHit()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(hitSound);
        targetRoot.Play("down");
        Debug.Log("Target Down!");
        beenHit = true;
        CoconutWin.targets++;
        yield return new WaitForSeconds(resetTime);
        gameObject.GetComponent<AudioSource>().PlayOneShot(resetSound);
        targetRoot.Play("up");
        Debug.Log("Target Up!");
        beenHit = false;
        CoconutWin.targets--;
    }
}
