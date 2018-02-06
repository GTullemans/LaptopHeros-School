using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    private float _Speed;
    private Vector3 _Direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(_Direction * _Speed * Time.fixedDeltaTime);
	}

    public void SetDir(Quaternion Rotation)
    {
        _Direction = Rotation * Vector3.forward;
        _Direction.Normalize();
    }
}
