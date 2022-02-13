using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator AnimController;
    public GameObject Body;

    private void OnEnable() 
    {
        if(AnimController == null)
        {
            AnimController = this.GetComponent<Animator>();
        }
        //Body.transform.position = Body.transform.position + Vector3.up * 0;
        AnimController.enabled = false;
    }

    private void Update() {
        Body.transform.position = Body.transform.position + Vector3.up * 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            AnimController.enabled = true;
        }
    }
}
