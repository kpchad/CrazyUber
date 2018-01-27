using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 40f;
    [Tooltip("In m")] [SerializeField] float xRange = 30f;

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float XPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(XPos, transform.localPosition.y, transform.localPosition.z);
	}
}
