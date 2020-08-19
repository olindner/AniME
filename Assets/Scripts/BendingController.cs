using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BendingController : MonoBehaviour
{
    private XRGrabInteractable grabbable; 
    private List<InputDevice> rightHandDevice = new List<InputDevice>();
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevice);
    }

    void Update()
    {
        bool triggerValue;
        if(rightHandDevice.Count > 0 && rightHandDevice[0].TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            ShootFire();
        }
        else
        {
            particleSystem.Stop();
        }
    }

    public void ShootFire()
    {
        particleSystem.Play();
    }
}
