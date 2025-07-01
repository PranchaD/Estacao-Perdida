using UnityEngine; using System.Collections; using UnityEngine.SceneManagement;

public class Follow : MonoBehaviour {

	public float speed = 4f;
	public float jetPackSpeed = 0.3f;
	public float jumpSpeed = 8f;
	public float gravity = 10;
    public int timer = 60 * 10;
    public AudioClip screamer;
    public AudioClip screamerSpy;
    public bool screamerEnable = false;

	private Transform _Player; 
	private CharacterController character;
	private Transform tr;
    private AudioSource audioSource;
    private Renderer rendererSource;
	private float vSpeed = 0f;
	public bool jump = false;
	
	void Start ()
	{
		_Player = GameObject.Find("Player").transform;
		character = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        rendererSource = GetComponent<Renderer>();
		tr = transform;
	}

    public static bool IsVisibleToCamera(Transform transform)
    {
        Vector3 visTest = Camera.main.WorldToViewportPoint(transform.position);
        return (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0;
    }

	void Update ()
	{	

        if(IsVisibleToCamera(tr)) {
            if (!screamerEnable) {
                audioSource.resource = screamer;
                audioSource.Play();
                audioSource.loop = false;
                audioSource.spatialBlend = 0;
                screamerEnable = true;
            }
        }
        else {
            if (!audioSource.isPlaying) {
                audioSource.resource = screamerSpy;
                audioSource.Play();
                audioSource.spatialBlend = 1;
                audioSource.loop = true;
                screamerEnable = false;
            }
        }

        // find the vector enemy -> player
		Vector3 chaseDir = _Player.position - tr.position;
		chaseDir.y = 0; // let only the horizontal direction
		float distance = chaseDir.magnitude;  // get the distance
		if (distance <= 2)
			SceneManager.LoadSceneAsync(2);
		else
		{	// find the player direction
			Quaternion rot = Quaternion.LookRotation(chaseDir);
			// rotate to his direction
			tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * 4);
			if (character.isGrounded){ // if is grounded...
				vSpeed = 0;  // vertical speed  is zero
				if (jump){    // if should jump...
					vSpeed = jumpSpeed; // aplly jump speed
					jump = false; // only jump once!
				}
			} 
			else // but if lost ground, check if it's an abyss
			if (!Physics.Raycast(tr.position, -tr.up, 20f)){ // if no ground below
				vSpeed = jetPackSpeed;  // use jetpack
			}
			vSpeed -= gravity * Time.deltaTime; // apply gravity
			// calculate horizontal velocity vector
			chaseDir = chaseDir.normalized * speed;
			chaseDir.y += vSpeed; // include vertical speed
			// and move the enemy
			character.Move(chaseDir * Time.deltaTime);
		}
	}
}