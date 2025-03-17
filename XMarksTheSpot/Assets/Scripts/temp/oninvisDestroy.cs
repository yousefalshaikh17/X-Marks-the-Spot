using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oninvisDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        Debug.Log("Invis");
        // Destroy(gameObject);
        // Debug.Log("Destroyed2");
    }

    void OnBecameVisible()
    {
        Debug.Log("Vis");
    }
}
