using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 25f;
    [SerializeField]
    private float rotationSpeed = 100f;
    [SerializeField]
    private float jumpSpeed = 5f;
    [SerializeField]
    private float distanceToGround = 0.1f;
    [SerializeField]
    private LayerMask groundLayer;
    private PlayerInputActions playerMovementControls;
    private Rigidbody _rigidBody;
    private CapsuleCollider _capsuleCollider;
    private float hInput;
    private float vInput;
    private GameManager gameManager;

    

    //private enum PlayerAction { attack, defend, fire, jump };

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        playerMovementControls = new PlayerInputActions();
        playerMovementControls.Player.Jump.performed += jumpContext => JumpPerformed();

    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {

        Vector2 inputVector = playerMovementControls.Player.Move.ReadValue<Vector2>();
        if (inputVector.x != 0f || inputVector.y != 0f) MovementPerformed(inputVector);

    }

    private void OnEnable()
    {

        playerMovementControls.Player.Move.Enable();
        playerMovementControls.Player.Jump.Enable();

    }

    private void OnDisable()
    {

        playerMovementControls.Player.Move.Disable();
        playerMovementControls.Player.Jump.Disable();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameManager.PlayerHP = gameManager.PlayerHP - 15;
        }
    }

    private void MovementPerformed(Vector2 inputVector)
    {

        // Se obtiene la velocidad
        hInput = inputVector.x * rotationSpeed;
        vInput = inputVector.y * movementSpeed;

        // Se utiliza la formula fisica de la distancia
        // distance = speed * time
        //this.transform.Translate(Vector3.forward * (vInput * Time.fixedDeltaTime));
        //this.transform.Rotate(Vector3.up * (hInput * Time.fixedDeltaTime));

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rigidBody.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        _rigidBody.MoveRotation(_rigidBody.rotation * angleRot);

    }

    private void JumpPerformed()
    {

        if(IsOnTheGround()) _rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    
    }

    private bool IsOnTheGround()
    {

        Vector3 capsuleBottom = new Vector3(_capsuleCollider.bounds.center.x, _capsuleCollider.bounds.min.y, _capsuleCollider.bounds.center.z);
        return  Physics.CheckCapsule(_capsuleCollider.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

    }

}
