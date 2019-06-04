using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBehaviour : MonoBehaviour
{
    public GameObject FollowTarget;
    public Vector3 OffSet;
    public float MovementSpeed;

    private void Update()
    {
        if (FollowTarget == null)
            return;
        transform.forward = (FollowTarget.transform.position + FollowTarget.transform.forward) - transform.position;
        Vector3 targetPosition = (FollowTarget.transform.position + FollowTarget.transform.forward) + OffSet;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Vector3.Distance(transform.position, targetPosition) * (Time.deltaTime * MovementSpeed));
    }

    private void OnDrawGizmos()
    {
        if (FollowTarget != null)
        {
            Vector3 position = (FollowTarget.transform.position + FollowTarget.transform.forward) + OffSet;
            //transform.position = position;
            Gizmos.DrawCube(position, new Vector3(1, 1, 1));
            Gizmos.DrawLine(position, FollowTarget.transform.position + FollowTarget.transform.forward);
        }
    }
}
