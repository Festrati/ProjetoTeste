using UnityEngine;
using System.Collections;


[@RequireComponent(typeof(BoxCollider2D))]

public class PlayerScript : MonoBehaviour {

	public float velocidade = 1.0f;

	// components
	RaycastHit2D hit;
	BoxCollider2D boxCollider;

	private Vector2 movement;
	private Animator anim;

	private void Awake () 
	{
		movement = Vector2.zero;
		boxCollider = GetComponent<BoxCollider2D>();
	
	}

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		if (inputX != 0 || inputY != 0) {

			anim.SetBool ("IsWalking", true);

			if ( inputX > 0 ) {
				movement = Vector2.right;
//				var direction = movimento * velocidade * Time.deltaTime;
				anim.SetInteger ("Direction", 1);
			} 

			if ( inputX < 0 ) {
					movement = -Vector2.right;
//					var direction = movimento * velocidade * Time.deltaTime;
					anim.SetInteger ("Direction", 3);
			}

			if ( inputY > 0 ) {
					movement = Vector2.up;
//					var direction = movimento * velocidade * Time.deltaTime;
					anim.SetInteger ("Direction", 0);
			}

			if ( inputY < 0 ) {
					movement = -Vector2.up;
//					var direction = movimento * velocidade * Time.deltaTime;
					anim.SetInteger ("Direction", 2);
			}

			// force to zero movement vector
			if (!Input.anyKey){
				anim.SetBool ("IsWalking", false);
				movement = Vector2.zero;	
			}

//			hit = Physics2D.BoxCast (transform.position, boxCollider.size, 0, new Vector2 (0, direction.y), Mathf.Abs (direction.y));

//			if (hit.collider == null) {
//					transform.Translate (0, direction.y, 0);
//			}
//			hit = Physics2D.BoxCast (transform.position, boxCollider.size, 0, new Vector2 (direction.x, 0), Mathf.Abs (direction.x));
//
//			if (hit.collider == null) {
//					transform.Translate (direction.x, 0, 0);
//			}

		} else {
			anim.SetBool ("IsWalking", false);
			movement = Vector2.zero;	
		}

	}
	public void FixedUpdate()
	{
		rigidbody2D.velocity = movement;

	}

}
