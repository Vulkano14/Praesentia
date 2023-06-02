using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField] GameObject _player;
    public GameObject firstFlashLight;
    public float moveSpeed = 10f;

    public Transform groundChecker;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    bool isGrounded;

    void Start()
    {
        _player.SetActive(false);
        firstFlashLight.SetActive(false);
        StartCoroutine(PlayerActivation());
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
         
    }

    IEnumerator PlayerActivation()
    {
        yield return new WaitForSeconds(50);
        _player.SetActive(true);
    }
}
