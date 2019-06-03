using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    public float JumpForce;

    public float DistanceToCollision;
    public bool IsGrounded
    {
        get
        {
            RaycastHit rayhit;
            if(Physics.Raycast(transform.position, -transform.up, out rayhit, Mathf.Infinity))
            {
                return Vector3.Distance(transform.position, rayhit.point) <= 0.6f;
            }
            return false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded)
            {
                Debug.Log("Jump");
                GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        RaycastHit rayhit;
        if (Physics.Raycast(transform.position, -Vector3.up, out rayhit, Mathf.Infinity))
        {
            DistanceToCollision = Vector3.Distance(transform.position, rayhit.point);
            Gizmos.DrawLine(transform.position, rayhit.point);
        }
    }
}
