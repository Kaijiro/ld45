using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    public Transform targetToFollow;
    public float moveSpeed;
    
    void LateUpdate()
    {
        if (targetToFollow != null)
        {
            Vector3 cameraPosition = transform.position;
            Vector3 targetPosition = targetToFollow.position;
            Vector3 targetPositionVector = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);

            Vector3 velocity = (targetPositionVector - cameraPosition) * moveSpeed;
            transform.position = Vector3.SmoothDamp(cameraPosition, targetPositionVector, ref velocity, 1.0f, Time.deltaTime);
        }
    }
}
