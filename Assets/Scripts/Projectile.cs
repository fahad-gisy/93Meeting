using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    
    [SerializeField] private Rigidbody rigidbody;

    public Vector3 moveDirection;
    public float moveSpeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.useGravity = false;
        rigidbody.velocity = moveDirection * moveSpeed;
    }
}
