using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BendingController : MonoBehaviour
{
    public bool airBending = false;
    public bool waterBending = false;
    public bool earthBending = false;
    public bool fireBending = false;
    public GameObject earthWall;
    public float bendingCooldown = 1f;
    public GameObject xrRig;

    private XRGrabInteractable grabbable;
    private List<InputDevice> rightHandDevice = new List<InputDevice>();
    private ParticleSystem particleSystem;
    private bool currentlyBending;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevice);
    }

    void Update()
    {
        if (currentlyBending || xrRig == null) return;

        CheckForAirBending();
        CheckForWaterBending();
        CheckForEarthBending();
        CheckForFireBending();
    }

    private void CheckForAirBending()
    {
    }

    private void CheckForWaterBending()
    {
    }

    private void CheckForEarthBending()
    {
        bool triggerValue;
        if (rightHandDevice.Count > 0 && earthBending &&
            rightHandDevice[0].TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            currentlyBending = true;
            GameObject instantiatedWall = 
                Instantiate(earthWall, xrRig.transform.position + Vector3.forward * 3f + Vector3.up * 0.5f, Quaternion.identity);
            StartCoroutine(BendingDelay());
            instantiatedWall.GetComponent<Rigidbody>().AddForce(xrRig.transform.forward * 3000f);
            Destroy(instantiatedWall, 3f);
        }
    }

    private void CheckForFireBending()
    {
        bool triggerValue;
        if (rightHandDevice.Count > 0 && fireBending &&
            rightHandDevice[0].TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            particleSystem.Play();
        }
        else
        {
            particleSystem.Stop();
        }
    }

    IEnumerator BendingDelay()
    {
        yield return new WaitForSeconds(bendingCooldown);

        currentlyBending = false;
    }
}
