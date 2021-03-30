using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)] public float smoothFactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        transform.position = smoothPosition;
    }

}
