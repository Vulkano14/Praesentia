using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField] GameObject _player;
    public GameObject firstFlashLight;
    public float moveSpeed = 5f;

    public Transform groundChecker;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    bool isGrounded;

    public bool _canMove = true;
    [SerializeField] GameObject _crossHair;
    [SerializeField] GameObject _lightFlashLight;

    [SerializeField] GameObject _UT1;
    [SerializeField] GameObject _UT2;
    [SerializeField] GameObject _UT3;

    void Start()
    {
        _UT1.SetActive(false);
        _UT2.SetActive(false);
        _UT3.SetActive(false);

        _player.SetActive(false);
        firstFlashLight.SetActive(false);
        StartCoroutine(PlayerActivation());
    }

    void FixedUpdate()
    {
        if (GAMEMANAGEROPTION.Instance.optionSelectedCroshair)
        {
            _crossHair.SetActive(false);
            _UT1.SetActive(true);
        }

        if (GAMEMANAGEROPTION.Instance.optionSelectedFlashlight)
        {
            _lightFlashLight.SetActive(false);
            _UT2.SetActive(true);
        }

        if (GAMEMANAGEROPTION.Instance.optionSelectedSpeed)
        {
            moveSpeed = 2f;
            _UT3.SetActive(true);
        }



        if (_canMove)
        {
            isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
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
        
    }

    IEnumerator PlayerActivation()
    {
        yield return new WaitForSeconds(50);
        _player.SetActive(true);
    }
}
