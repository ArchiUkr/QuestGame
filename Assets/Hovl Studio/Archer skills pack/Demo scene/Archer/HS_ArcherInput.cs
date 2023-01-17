using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]
public class HS_ArcherInput : MonoBehaviour
{
    public float velocity = 9;
    [Space]

    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation = 0.1f;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;


    [Space]
    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    private float verticalVel;
    private Vector3 moveVector;
    public bool aimMoving = false;
    private float aimTimer = 0;
    public bool canMove;

    [Space]
    [Header("Effects")]
    public GameObject TargetMarker;
    public GameObject TargetMarker2;
    public GameObject[] Prefabs;
    public GameObject[] PrefabsCast;

    public GameObject[] Prefabs1;
    public GameObject[] PrefabsCast1;

    public float[] castingTime; //If 0 - can loop, if > 0 - one shot time
    public LayerMask collidingLayer = ~0; //Target marker can only collide with scene layer
    private Transform parentObject;

    [Space]
    [Header("Canvas")]
    public Image aim;
    public Vector2 uiOffset;
    public List<Transform> screenTargets = new List<Transform>();
    private Transform target;
    private bool activeTarger = false;
    public Transform FirePoint;
    public Transform FirePointEnd;

    public Transform IcePoint;
    public Transform IcePointEnd;

    public float fireRate = 0.1f;


    private AudioSource soundComponent; //Play audio from Prefabs
    private AudioClip clip;
    private AudioSource soundComponentCast; //Play audio from PrefabsCast

    [Space]
    [Header("Camera Shaker script")]
    public HS_CameraShaker cameraShaker;

    private float timerFire = 0f;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
        target = screenTargets[targetIndex()];
    }

    void Update()
    {
        UserInterface();
        //Disable moving and skills if alrerady using one
        if (aimTimer > 0)
        {
            aimTimer -= Time.deltaTime;
            aimMoving = true;
        }
        else
        {
            if (aimMoving) InputMagnitude();
            aimMoving = false;
        }

       


        target = screenTargets[targetIndex()];

        timerFire -= Time.deltaTime;

        if (Input.GetKey("1") && timerFire <= 0f && OpenFireMag.fireMagic == true)
        {
            PrefabsCast[2].GetComponent<ParticleSystem>().Play();
            GameObject projectile = Instantiate(Prefabs[4], FirePoint.position, FirePoint.rotation);
            projectile.GetComponent<TargetProjectile>().UpdateTarget(FirePointEnd, (Vector3)uiOffset);
            timerFire = 0.2f;
        }

        if (Input.GetKey("2") && timerFire <= 0f && OpenFireMag.iceMagic == true)
        {
            PrefabsCast1[2].GetComponent<ParticleSystem>().Play();
            GameObject projectile = Instantiate(Prefabs1[4], IcePoint.position, IcePoint.rotation);
            projectile.GetComponent<TargetProjectile>().UpdateTarget(IcePointEnd, (Vector3)uiOffset);
            timerFire = 0.2f;
        }




        InputMagnitude();

        //If you don't need the character grounded then get rid of this part. FHJEIDFIJEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEWOEIRJETTT
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel = 0;
        }
        else
        {
            verticalVel -= 1f * Time.deltaTime;
        }
        moveVector = new Vector3(0, verticalVel, 0);
        controller.Move(moveVector);
    }

   

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

       // var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        
        desiredMoveDirection = forward * InputZ + right * InputX;

       
        desiredMoveDirection.Normalize();

        if (blockRotationPlayer == false)
        {
            if (aimMoving)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward), desiredRotationSpeed);
                
                if (InputZ < -0.3)
                    controller.Move(desiredMoveDirection * Time.deltaTime * (velocity / 2.4f));
                else if (InputX < -0.1 || InputX > 0.1)
                    controller.Move(desiredMoveDirection * Time.deltaTime * (velocity / 2.2f));
                else
                    controller.Move(desiredMoveDirection * Time.deltaTime * velocity / 1.8f);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
                controller.Move(desiredMoveDirection * Time.deltaTime * velocity);
            }
        }
    }

    void InputMagnitude()
    {
       
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        anim.SetFloat("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        anim.SetFloat("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        
        anim.SetBool("AimMoving", aimMoving);

        
        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
        }
    }

    private void UserInterface()
    {
        Vector3 screenCenter = new Vector3(Screen.width, Screen.height, 0) / 2;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position + (Vector3)uiOffset);
        Vector3 CornerDistance = screenPos - screenCenter;
        Vector3 absCornerDistance = new Vector3(Mathf.Abs(CornerDistance.x), Mathf.Abs(CornerDistance.y), Mathf.Abs(CornerDistance.z));

        if (absCornerDistance.x < screenCenter.x / 3 && absCornerDistance.y < screenCenter.y / 3 && screenPos.x > 0 && screenPos.y > 0 && screenPos.z > 0 //If target is in the middle of the screen
            && !Physics.Linecast(transform.position + (Vector3)uiOffset, target.position + (Vector3)uiOffset * 2, collidingLayer)) //If player can see the target
        {
            aim.transform.position = Vector3.MoveTowards(aim.transform.position, screenPos, Time.deltaTime * 3000);
            if (!activeTarger)
                activeTarger = true;
        }
        else
        {
            aim.transform.position = Vector3.MoveTowards(aim.transform.position, screenCenter, Time.deltaTime * 3000);
            if (activeTarger)
                activeTarger = false;
        }
    }

    public int targetIndex()
    {
        float[] distances = new float[screenTargets.Count];

        for (int i = 0; i < screenTargets.Count; i++)
        {
            distances[i] = Vector2.Distance(Camera.main.WorldToScreenPoint(screenTargets[i].position), new Vector2(Screen.width / 2, Screen.height / 2));
        }

        float minDistance = Mathf.Min(distances);
        int index = 0;

        for (int i = 0; i < distances.Length; i++)
        {
            if (minDistance == distances[i])
                index = i;
        }
        return index;
    }
}
