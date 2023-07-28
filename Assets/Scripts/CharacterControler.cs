using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterControler : MonoBehaviour
{
    //public Vector3 movement = new Vector3(1,1,0);
    public GameObject Bullet;
    public GameObject ShootPoint1;
    public GameObject ShootPoint2;

    private PlayerControler controls;
    private Rigidbody body;
    private Animator animator;
    private void Awake()
    {
        controls = new PlayerControler();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.Shoot.performed += _ => Shoot();


        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,3,0);

        //Instantiate(Bullet, new Vector3(1,3,3), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, Vector3.forward);
    }

    private void Jump()
    {
        body.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        Debug.Log("Jump");
    }

    private bool isFirstPoint;

    private void Shoot()
    {
        if(isFirstPoint)
        {
            CreateBullet(ShootPoint1.transform.position);
            //var p = Instantiate(new GameObject(), transform);
            //p.transform.position = ShootPoint1.transform.position;
            //Debug.DrawLine(transform.position, p.transform.position);

        }
        else 
        {
            CreateBullet(ShootPoint2.transform.position);
        }
        isFirstPoint = !isFirstPoint;

        
        //Instantiate(Bullet, ShootPoint1.transform.position, Quaternion.identity);
        //Instantiate(Bullet, ShootPoint2.transform.position, Quaternion.identity);

    }

    private void CreateBullet(Vector3 position)
    {
        var bullet = Instantiate(Bullet, position, Quaternion.identity);
        var bulletBody = bullet.GetComponent<Rigidbody>();

        bulletBody.AddForce(transform.forward * 15, ForceMode.Impulse);
        Destroy(bullet, 5f);
    }

    private void FixedUpdate()
    {
        var moveDirection = controls.Player.Move.ReadValue<Vector2>();
        body.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y) * 3);
        //transform.position = transform.position + new Vector3(moveDirection.x,0,moveDirection.y) * Time.fixedDeltaTime;
        //;
        animator.SetFloat("Speed", body.velocity.magnitude / 3f);

        if (controls.Player.RotateLeft.ReadValue<float>() > 0.5f)
        {
            transform.Rotate(Vector3.up, -180 * Time.fixedDeltaTime);
        }
        else if (controls.Player.RotateRight.ReadValue<float>() > 0.5f)
        {
            transform.Rotate(Vector3.up, 180 * Time.fixedDeltaTime);
        }
        //Debug.Log(body.velocity.magnitude);

        //transform.LookAt(new Vector3(0,0,0));
        // Debug.Log("FixedUpdate");
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
