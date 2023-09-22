using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    private float initialSpeed;
    private float speedMultiplier;

    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;

    private Rigidbody2D rig;
    private Vector2 _direction;
    private int handlingObj;
    private PlayerItems playerItems;
   

    public bool IsCutting { get => _isCutting; set => _isCutting = value; }
    public bool IsDigging { get => _isDigging; set => _isDigging = value; }
    public bool IsRolling { get => _isRolling; set => _isRolling = value; }
    public bool isRunning { get => _isRunning; set => _isRunning = value; }
    public Vector2 direction { get => _direction; set => _direction = value; }
    public bool IsWatering { get => _isWatering; set => _isWatering = value; }
    public int HandlingObj { get => handlingObj; set => handlingObj = value; }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        speedMultiplier = 1.3f;
        playerItems = GetComponent<PlayerItems>();
    }

    
    void Update()
    {
        HandleTool();
        OnInput();
        OnRun();
        OnRoll();
        OnAction();
    }
    void FixedUpdate()
    {
       OnMove();
    }


    #region Movement

    void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void OnMove()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);

    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            IsRolling = true;
            speed = runSpeed * speedMultiplier;
        }
        if (Input.GetMouseButtonUp(1))
        {
            IsRolling = false;
            speed = initialSpeed;
        }
    }

    #endregion

    #region Actions

    void OnAction()
    {
        switch (HandlingObj)
        {
            case 1:
                OnCutting();
                break;
            case 2:
                OnDig();
                break;
            case 3:
                OnWattering();
                break;

            default:
                break;
        }
    }
    void OnCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCutting = true;
            speed = 0f;

        }if (Input.GetMouseButtonUp(0))
        {
            _isCutting = false;
            speed = initialSpeed;

        }
    } 
    void OnDig()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsDigging = true;
            speed = 0f;

        }if (Input.GetMouseButtonUp(0))
        {
            IsDigging = false;
            speed = initialSpeed;

        }
    }
    void OnWattering()
    {
            if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
            {
               
                _isWatering = true;
                speed = 0f;

            }
            if (Input.GetMouseButtonUp(0) || playerItems.currentWater <=0)
            {
                _isWatering = false;
                speed = initialSpeed;

            }
            if (_isWatering && playerItems)
            {
                playerItems.currentWater -= 0.01f;
            }
    }
    #endregion


    void HandleTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HandlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HandlingObj = 2;
        }  if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HandlingObj = 3;
        }
    }
}
