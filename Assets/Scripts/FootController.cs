using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    public GameObject Balancer;
    public Rigidbody[] BodyParts;
    /*public void SwitchBalancer(bool trig)
    {
        Balancer.SetActive(trig);
    }*/

    public void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 8)
        {
            Debug.Log("On Platform");
            //SwitchBalancer(true);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        FreezeParts(true);
    }

    public void FreezeParts(bool trig)
    {
        if(BodyParts[0].freezeRotation == !trig)
        {
            foreach(Rigidbody hip in BodyParts)
            {
                hip.freezeRotation = trig;
            }
        }
    }
}
