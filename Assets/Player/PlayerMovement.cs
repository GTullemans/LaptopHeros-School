using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float _Speed;
    [SerializeField]
    private float _JumpHight;
    [SerializeField]
    private XboxController Player;
    [SerializeField]
    private LayerMask _Mask;
    private Rigidbody _RigidBody;
    private bool _IsOnGround;
	// Use this for initialization
	void Start () {
        _RigidBody = GetComponent<Rigidbody>();
        _Mask = ~_Mask;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Tijdelijk
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += new Vector3(-_Speed * Time.fixedDeltaTime, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += new Vector3(_Speed * Time.fixedDeltaTime, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += new Vector3(0, 0, _Speed * Time.fixedDeltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += new Vector3(0, 0, -_Speed * Time.fixedDeltaTime);
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _RigidBody.AddForce(Vector3.up * _JumpHight, ForceMode.Impulse);
        //}

        transform.position += new Vector3(XCI.GetAxisRaw(XboxAxis.LeftStickX,Player) * _Speed * Time.fixedDeltaTime, 0, XCI.GetAxisRaw(XboxAxis.LeftStickY, Player) * _Speed * Time.fixedDeltaTime);

        if (XCI.GetAxisRaw(XboxAxis.RightStickX, Player) != 0 && XCI.GetAxisRaw(XboxAxis.RightStickY, Player) != 0)
        {
            float horizontal = XCI.GetAxisRaw(XboxAxis.RightStickX, Player) * Time.fixedDeltaTime;
            float vertical = XCI.GetAxisRaw(XboxAxis.RightStickY, Player) * Time.fixedDeltaTime;
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;

            gameObject.transform.eulerAngles = new Vector3(0, -angle, 0);

        }

        if (XCI.GetButtonDown(XboxButton.A, Player) && _IsOnGround)
        {
            _RigidBody.AddForce(Vector3.up * _JumpHight, ForceMode.Impulse);
        }

        if (Physics.Raycast(transform.position, Vector3.down, 0.6f, _Mask))
        {
            _IsOnGround = true;
        }
        else { _IsOnGround = false; }
        
    }
}
