using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow Player")]
    public float followSpeed;
    public Transform target;

    [Header("Limit Camera Movement")]
    public Vector3 xLimit; // Limit the camera movement on the x-axis
    public Vector3 yLimit; // Limit the camera movement on the y-axis

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 newpos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newpos, followSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Vector3 clampedPosition = new Vector3(
        Mathf.Clamp(transform.position.x, xLimit.x, xLimit.y),
        Mathf.Clamp(transform.position.y, yLimit.x, yLimit.y),
        transform.position.z);
        
        transform.position = clampedPosition;
    }
}