using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToWalk : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private float _moveSpeed = 0.25f;

    private Rigidbody2D _rb;

    private Touch _touch;
    [SerializeField] private Vector3 _touchPosition, _whereToMove;
    private Vector3 _localScale;
    [SerializeField]  private bool _isMoving = false;
    private Animator _animator;

    private float _previousDistanceToTouchPos, _currentDistanceToTouchPos;
    
    
    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _rb = GetComponent<Rigidbody2D>();
        _localScale = gameObject.transform.localScale;
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        _animator = GetComponent<Animator>();

        if (_isMoving)
        {
            _currentDistanceToTouchPos = (_touchPosition - transform.position).magnitude;
        }

        if (GameObject.FindWithTag("MainLobbyCanvas").GetComponent<CanvasGroup>().interactable == true)
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);

                if (_touch.phase == TouchPhase.Began)
                {
                    _audioManager.Play(AudioManager.SoundName.BUTTON);
                    _previousDistanceToTouchPos = 0;
                    _currentDistanceToTouchPos = 0;
                    _isMoving = true;
                    _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
                    _touchPosition.z = 0;
                    _whereToMove = (_touchPosition - transform.position).normalized;
                    _rb.velocity = new Vector2(_whereToMove.x * _moveSpeed, _whereToMove.y * _moveSpeed);

                    if (_whereToMove.x > 0)
                    {
                        _localScale.x = 166;
                        transform.localScale = _localScale;
                        Debug.Log($"Right, facing right");
                    }
                    else if (_whereToMove.x < 0)
                    {
                        _localScale.x = -166;
                        transform.localScale = _localScale;
                        Debug.Log($"Left, facing left");
                    }
                }
            }
        }

        if (_currentDistanceToTouchPos > _previousDistanceToTouchPos)
        {
            _isMoving = false;
            _rb.velocity = Vector2.zero;
        }

        if (_isMoving)
        {
            _previousDistanceToTouchPos = (_touchPosition - transform.position).magnitude;
            //Play walking animation
            _animator.SetInteger("Move", 1);
        }
        else if (!_isMoving)
        {
            //Stop walking animation
            _animator.SetInteger("Move", 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "MainLobbyBackground")
        {
            _whereToMove = transform.position;
            _isMoving = false;
            _rb.velocity = Vector2.zero;
        }
    }
}
