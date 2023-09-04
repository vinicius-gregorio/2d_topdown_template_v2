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

    private Rigidbody2D rig;
    private Vector2 _direction;
    public Vector2 direction
    {
        get { return _direction; }  
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting { get => _isCutting; set => _isCutting = value; }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        speedMultiplier = 1.3f;
    }

    
    void Update()
    {
        OnInput();
        OnRun();
        OnRoll();
        OnCutting();
    }
    void FixedUpdate()
    {
       OnMove();
    }


    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);

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
            _isRolling = true;
            speed = runSpeed * speedMultiplier;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
            speed = initialSpeed;
        }
    }

    #endregion

    #region Actions
    void OnCutting()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _isCutting = true;
            speed = 0f;

        }if (Input.GetKeyUp(KeyCode.R))
        {
            _isCutting = false;
            speed = initialSpeed;

        }
    }
    #endregion
}
