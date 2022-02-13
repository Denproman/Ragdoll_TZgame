using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator AnimController;
    public GameObject Balancer;
    [Range(1, 500)] private float DistanceToGround;
    [Range(1, 500)] public float NeededDistance;
    public RagdollState ragdollState = RagdollState.Lower;
    //public Vector3 Offset;
    //public Muscle[] muscles;

    //public Transform[] Legs;
    void OnEnable()
    {
        ragdollState = RagdollState.Lower;
        if(AnimController == null)
        {
            AnimController = this.GetComponent<Animator>();
        }
    }

    void Update()
    {
        float delta = Mathf.Abs(NeededDistance - Balancer.transform.position.y);
        delta = Mathf.Pow(delta, 0.05f);

        if(Balancer.transform.position.y < NeededDistance)
        {
            Balancer.GetComponent<Rigidbody>().AddForce(Balancer.transform.up * 30 * delta, ForceMode.Impulse);
        }
        else if(Balancer.transform.position.y > NeededDistance - 0.2f)
        {
            Balancer.GetComponent<Rigidbody>().AddForce(-Balancer.transform.up * 30 * delta, ForceMode.Impulse);
        }
        else
        {
            Balancer.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if(Input.GetMouseButtonDown(0))
        {
            ragdollState = RagdollState.Upper;
            //AnimController.enabled = true;
            //AnimControl("Attack");
        }
        else if(Input.GetMouseButtonUp(0))
        {
            ragdollState = RagdollState.Lower;
            //AnimControl("idle");
            AnimController.enabled = false;
        }
        
        BodyHeight();
    }

    public void BodyHeight()
    {
        if(ragdollState == RagdollState.Lower)
        {
            NeededDistance = 211;
        }
        else if(ragdollState == RagdollState.Upper)
        {
            NeededDistance = 213;
        }
    }

    public void AnimControl(string AnimName)
    {
        if(AnimName == "idle")
        {
            AnimController.SetBool("Attack", false);
        }
        else if(AnimName == "Attack")
        {
            AnimController.SetBool("Attack", true);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 9) //enemy
        {
            AnimController.enabled = true;
        }
    }

    public enum RagdollState
    {
        Upper,
        Lower
    }

}

/*[System.Serializable]
public class Muscle
{
    public Rigidbody bone;
    public float RestRotation;
    public float Force;

    public void ActivateMuscle()
    {
        //bone.MoveRotation(Mathf.LerpAngle(bone.rotation, RestRotation, Force * Time.deltaTime));
    }
}*/
