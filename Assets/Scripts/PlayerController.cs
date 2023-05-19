using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider[] pizzaColliders = null;

    private RaycastHit groundRay;
    private RaycastHit colliderRay;

    private Vector3? startPos = null;

    private float moveSpeed = 3f;
    private float jumpVelocity = 0;
    private float pizzaRadius = 0.46f;

    private const float maxJumpVelocity = 5; // 3 Default

    [SerializeField] private bool debugGizmos = false;

    private bool isOnGround = false;
    private bool hitSomething = false;

    private const int PizzaLayerMask = 1 << 9; // Pizza layer is Layer 9


    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {

        Debug.Log(jumpVelocity);
        if (GameData.isPaused)
        {
            return;
        }
        
        isOnGround = Physics.Raycast(transform.position + new Vector3(0, 0.05f, 0), Vector3.down, out groundRay, 0.06f);

        if (isOnGround)
        {
            Debug.Log("Grounded");
            jumpVelocity = 0;

            transform.position = new Vector3(transform.position.x, groundRay.point.y, transform.position.z);

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Jump Pressed");
                jumpVelocity = maxJumpVelocity;
            }
        }
        else if (jumpVelocity == 0)
        {
            jumpVelocity -= Time.deltaTime * maxJumpVelocity * 2;
        }

        if (jumpVelocity !=0)
        {
            jumpVelocity -= Time.deltaTime * maxJumpVelocity * 2;
            transform.Translate(jumpVelocity * Time.deltaTime * Vector3.up);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        pizzaColliders = Physics.OverlapSphere(transform.position + new Vector3(0, 0.3f, 0), pizzaRadius, PizzaLayerMask);

        if (pizzaColliders != null && pizzaColliders.Length > 0)
        {
            for (int i = 0; i < pizzaColliders.Length; i++)
            {
                if (pizzaColliders[i].TryGetComponent(out Pizza _collectedPizza))
                {
                    _collectedPizza.Collect();
                }

                if (pizzaColliders[i].TryGetComponent(out Star _collectedStar))
                {
                    _collectedStar.Collect();
                }
            }
        }

        if (hitSomething && colliderRay.collider.CompareTag("End"))
        {
            GameController.Instance.LevelComplete();
        }
    }
    
    private void MoveRight()
    {
        Debug.Log("moving right");
        transform.rotation = Quaternion.Euler(0, 0, 0);
        hitSomething = Physics.Raycast(transform.position + new Vector3(0, 0.05f, 0), Vector3.right, out colliderRay, 0.4f);

        if (!hitSomething || !colliderRay.collider.CompareTag("Obstacle"))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
        }
    }

    private void MoveLeft()
    {
        Debug.Log("moving left");
        transform.rotation = Quaternion.Euler(0, 180, 0);
        hitSomething = Physics.Raycast(transform.position + new Vector3(0, 0.05f, 0), Vector3.right, out colliderRay, 0.4f);

        if (!hitSomething || !colliderRay.collider.CompareTag("Obstacle"))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.left * -1); 
        }
    }

    public void ResetPlayer()
    {
        if (!startPos.HasValue)
        {
            startPos = transform.position;
        }

        jumpVelocity = 0;
        transform.position = startPos.Value;
        hitSomething = false;
    }

    private void OnDrawGizmos()
    {
        if (debugGizmos)
        {
            Gizmos.DrawSphere(transform.position + new Vector3(0, 0.3f, 0), pizzaRadius);
        }
    }
}
