using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // for movement
    public float moveSpeed;
    float xInput, yInput;

    // Start is called before the first frame update
    void Start() {

        
    }

    // Update is called once per frame
    void Update() {

        
    }

    private void FixedUpdate() {
        // define the axes
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);
        
    }

}
