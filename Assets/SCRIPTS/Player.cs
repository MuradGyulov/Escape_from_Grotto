using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;
using YG;

public class Player : MonoBehaviour
{
    [Header("Player characteristics")]
    [SerializeField] [Range(1f, 10f)] float Running_speed;
    [SerializeField] [Range(50f, 700f)] float Jump_force;
    [SerializeField] [Range(-0.5f, 2f)] float Shooting_rate;
    [SerializeField] [Range(0f, 15f)] private float Bullet_speed;
    [SerializeField] private LayerMask WhatIs_ground;


    [Header("Player Sounds")]
    [SerializeField] AudioClip Shooting_sound;
    [SerializeField] AudioClip Jump_sound;
    [SerializeField] AudioClip Dead_sound;
    [SerializeField] AudioClip Win_sound;

    [Header("Player subsystems")]
    [SerializeField] Transform Ground_check;
    [SerializeField] Transform BulletLounchPositionPointer;
    [SerializeField] Transform SleveerLounchPositionPointer;

    [Header("Player subsystems characteristics")]
    [SerializeField] float GroundCheck_radius;

    

    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Sleveer;


    public static UnityEvent SendPlayerDead = new UnityEvent();
    public static UnityEvent SendPlayerWin = new UnityEvent();


    private enum State { Playing, Win, Dead }; State currentState = State.Playing;

    private float NextShoot;
    private bool playerGrounded;
    private bool playerFacingRight;
    private bool Shoot;
    private int bulletRot;
    private float horizontal;
    private bool IsFire = false;
    private bool isDesctop;

    private Rigidbody2D RB;
    private AudioSource AU;
    private Animator AN;


    public void MoveLeft() { horizontal = -1 * Running_speed; }
    public void MoveRight() { horizontal = 1 * Running_speed; }
    public void StopMovement() { horizontal = 0; }
    public void Jump() { PlayerJump(); }
    public void OpenFire() { IsFire = true; }
    public void StopFiring() { IsFire = false; }


    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AU = GetComponent<AudioSource>();
        AN = GetComponent<Animator>();

        isDesctop = YandexGame.EnvironmentData.isDesktop;
        AU.volume = YandexGame.savesData.soundsVolume;
    }

    private void Update()
    {
        if (isDesctop)
        {
            if (Input.GetMouseButton(0))
            {
                IsFire = true;
            }
            else { IsFire = false; }

            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayerJump();
            }

            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1 * Running_speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1 * Running_speed;
            }
            else
            {
                horizontal = 0;
            }
        }

        if (horizontal < 0 && !playerFacingRight)
        {
            PlayerFlip(); bulletRot = 180;
        }

        if (horizontal > 0 && playerFacingRight)
        {
            PlayerFlip(); bulletRot = 0;
        }

        if (Shoot)
        {
            horizontal = 0;
        }
    }

    private void FixedUpdate()
    {
        PlayerRun();

        playerGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(Ground_check.position, GroundCheck_radius, WhatIs_ground);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                playerGrounded = true;
            }
        }


        if (IsFire && playerGrounded && currentState == State.Playing)
        {
            Shoot = true;

            if (Time.time > NextShoot)
            {
                NextShoot = Time.time + Shooting_rate;
                AU.PlayOneShot(Shooting_sound);
                AN.SetBool("PlayerShoot", true);

                Instantiate(Bullet, BulletLounchPositionPointer.transform.position, Quaternion.Euler(new Vector3(0, 0, bulletRot)));
                Instantiate(Sleveer, SleveerLounchPositionPointer.transform.position, SleveerLounchPositionPointer.transform.rotation);
            }
        }
        else 
        { 
            AN.SetBool("PlayerShoot", false);
            Shoot = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Gates":
                if (currentState == State.Playing)
                {
                    Invoke("PlayerWin", 2);
                    AU.PlayOneShot(Win_sound);
                    currentState = State.Win;

                    int currentCompletedLevels = YandexGame.savesData.completedLevels;
                    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                    if(currentSceneIndex >= currentCompletedLevels)
                    {
                        YandexGame.savesData.completedLevels = currentSceneIndex + 1;
                        YandexGame.SaveProgress();
                    }
                    else if (currentSceneIndex == 31)
                    {
                        YandexGame.savesData.completedLevels = 31;
                        YandexGame.SaveProgress();
                    }

                    Time.timeScale = 0;
                    SendPlayerWin.Invoke();
                }               
                break;

            case "Slug":
                PlayerDead();
                break;

            case "Lava":
                PlayerDead();
                break;
        }

        if (collision.gameObject.tag != "Sleever")
        {
            AN.SetBool("PlayerJump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Stalagmit":
                PlayerDead();
                break;
            case "Canion Ammo":
                PlayerDead();
                break;
            case "Host":
                PlayerDead();
                break;
            case "Spike":
                PlayerDead();
                break;

        }
    }

    public void PlayerRun()
    {
        if(currentState == State.Playing)
        {
            RB.velocity = new Vector2(horizontal, RB.velocity.y);
            AN.SetFloat("PlayerSpeed", Mathf.Abs(horizontal));
        }
    }

    private void PlayerJump()
    {
        if (playerGrounded && currentState == State.Playing)
        {
            AU.PlayOneShot(Jump_sound);
            AN.SetBool("PlayerJump", true);
            { RB.AddForce(transform.up * Jump_force); }
        }
    }

    private void PlayerFlip()
    {
        if(currentState == State.Playing)
        {
            playerFacingRight = !playerFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void PlayerDead()
    {
        if (currentState == State.Playing)
        {
            RB.constraints = RigidbodyConstraints2D.FreezePositionX;
            RB.constraints = RigidbodyConstraints2D.FreezeRotation;
            currentState = State.Dead;
            AU.PlayOneShot(Dead_sound);
            RB.AddForce(transform.up * 8, ForceMode2D.Impulse);
            AN.SetBool("PlayerDead", true);
            SendPlayerDead.Invoke();
            currentState = State.Dead;
        }       
    }
}
