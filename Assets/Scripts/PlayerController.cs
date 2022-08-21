using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _torqueAmount = 5f;
    [SerializeField] float _boostSpeed = 20f;
    [SerializeField] float _baseSpeed = 10f;

    [SerializeField] private ParticleSystem _boostEffect;

    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D rb2d;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

        if (surfaceEffector2D == null) {
            Debug.LogError("SurfaceEffector2D is NULL.");
        }
        if (rb2d == null) {
            Debug.LogError("RigidBody2D is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        BoostPlayer();
    }

    private void BoostPlayer() {
        if (canMove && Input.GetKey(KeyCode.Space)) {
            surfaceEffector2D.speed = _boostSpeed;
            _boostEffect.Play();
        }
        else {
            surfaceEffector2D.speed = _baseSpeed;
        }
    }

    private void RotatePlayer() {
        if (canMove) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                rb2d.AddTorque(_torqueAmount);
            }
            else if (Input.GetKey(KeyCode.RightArrow)) {
                rb2d.AddTorque(-_torqueAmount);
            }
        }
    }

    public void DisableControl() {
        canMove = false;
    }
}
