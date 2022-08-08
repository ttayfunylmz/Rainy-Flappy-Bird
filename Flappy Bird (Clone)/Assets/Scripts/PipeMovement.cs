using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float pipeSpeed = 0.5f;

    private void Start()
    {
        Destroy(gameObject, 15);
    }

    private void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
    }
}
