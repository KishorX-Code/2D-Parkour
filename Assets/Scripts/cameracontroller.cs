using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    private float currentPosx;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;
    [SerializeField] private float aheaddistance;
    [SerializeField] private float cameraSpeed;

    private void Start()
    {
        currentPosx = transform.position.x;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position,
            new Vector3(currentPosx, transform.position.y, transform.position.z), ref velocity, speed);

    }
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosx = _newRoom.position.x;
    }
}
