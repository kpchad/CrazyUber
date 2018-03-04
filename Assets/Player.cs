using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")][SerializeField] float translationSpeed = 70f;
    [Tooltip("In m")] [SerializeField] float xRange = 35f;
    [Tooltip("In m")] [SerializeField] float yMin = -15f;
    [Tooltip("In m")] [SerializeField] float yMax = 20f;

    [SerializeField] float positionPitchFactor = -.9f;
    [SerializeField] float controlPitchFactor = -5f;

    [SerializeField] float positionYawFactor = 0.7f;

    [SerializeField] float controlRollFactor = -5f;

    float xThrow;
    float yThrow;

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * translationSpeed * Time.deltaTime;
        float yOffset = yThrow * translationSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float XPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float YPos = Mathf.Clamp(rawYPos, yMin, yMax);

        transform.localPosition = new Vector3(XPos, YPos, transform.localPosition.z);
    }
}
