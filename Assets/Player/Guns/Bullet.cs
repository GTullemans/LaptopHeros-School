using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    private float _Speed;
    private Vector3 _Direction;
    private float _Dammage;
    private float _Time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(_Direction * _Speed * Time.fixedDeltaTime);
	}
    private void Update()
    {
        _Time += Time.deltaTime;
        if(_Time > 60)
        {
            gameObject.SetActive(false);
            _Time = 0;
        }
    }

    public void SetDir(Quaternion Rotation)
    {
        _Direction = Rotation * Vector3.forward;
        _Direction.Normalize();
    }

    public Vector3 GetDir
    {
        get { return _Direction; }
    }

    public float Dammage
    {
        get { return _Dammage; }
        set { _Dammage = value; }
    }
}
