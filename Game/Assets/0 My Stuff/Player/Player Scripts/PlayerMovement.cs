//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Creates public floating variables, which can be used later in the code. Public variables can have their value assigned within the Unity Editor.

    [Header("Movement Speeds")]

    [Range(0f, 24.0f)]
    public float baseSpeed;
    [Range(0f, 24.0f)]
    public float maxSprintSpeed;
    [Range(0f, 24.0f)]
    public float minSprintSpeed;
    [Range(0f, 24.0f)]
    public float jumpSpeed;


    [Header("Forces")]

    [Range(0f, 24.0f)]
    public float stickToGroundForce;

    [Range(0f, 24.0f)]
    public float gravityMultiplier;


    //Creates public variables other than floats, which can be used later in the code. Public variables can have their value assigned within the Unity Editor.

    //Creates public enumerations from Unity. 
    [Header("Links")]

    public AudioSource audioSource; //An audio source allows sound to be played into the game environment. An audio listener is required for the audio to be executed,
    public AudioClip[] walkingFootstepSounds; //An array of audio clips to be played when the player is walking. The audio files are chosen within the Unity Editor. Audio clips are then assigned to an audio source so they can be executed.
    public AudioClip[] runningFootstepSounds; //An array of audio clips to be played when the player is running. The audio files are chosen within the Unity Editor. Audio clips are then assigned to an audio source so they can be executed.
    public AudioClip jumpSound;

    //Creates private booleans, which can only have a value of true or false assigned to them.
    bool jump;
    bool isJumping;
    bool previouslyGrounded;


    CharacterController characterController; //A character controller allows the program to easily execute movement, without having to use a rigidbody.
    Vector3 moveDirection = Vector3.zero; //Creates a 3D vector that includes the values 0, 0, 0 and is called moveDirection. This allows three floats to be stored.
    CollisionFlags collisionFlags; //Creates collision flags called collisionFlags. Collision flags is a type of data that is sent by the character controller.
    Vector2 input; //Creates a 2D vector called input. This allows two floats to be stored.


    private void Awake() //This void only runs once in its lifetime and it initialises variables before the game actually starts.
    {
        
        characterController = GetComponent<CharacterController>(); //

	}
    private void Start() //This void only runs once in its lifetime and is executed before any of the Updates methods; after the Awake method.
	{

        isJumping = false; //Sets the isJumping boolean to false.

	}

    void Update() //This void runs once per frame.
    {


        jump = Input.GetKeyDown(KeyCode.Space); //If the user presses the space bar, then the jump boolean value will be set to true.

        if (!previouslyGrounded && characterController.isGrounded) //If the player was not previously grounded (in air) and now they are grounded (just landed).
        {
            //Landed
            moveDirection.y = 0f; //Stops the player from going up on the Y axis when they have landed.
            isJumping = false;

            print("Player Landed.");

        }

        if (!characterController.isGrounded && !isJumping && previouslyGrounded) //If the player is in the air, is not jumping and was previously grounded, they are falling.
        {

            //Falling
            moveDirection.y = 0f; //Stops the player from going up on the Y axis whiles they are falling.

            print("Player in air.");

        }

        previouslyGrounded = characterController.isGrounded; //Sets the boolean value within characterController.isGrounded as the boolean value in previouslyGrounded.


        MovePlayerV2(); //Tells the program to call the MovePlayerV2 method.

    }

    private void FixedUpdate()
    {

        Jump(); //Tells the program to call the Jump method.

    }

    private void Jump()
    {

        if (characterController.isGrounded) //If the player is on the ground (not in the air), then...
        {

            moveDirection.y = -stickToGroundForce;


            if (Input.GetButtonDown("Jump")) //If the user presses the space bar, then...
            {

                print("Player Jumped.");

                PlayJumpingSound();

                moveDirection.y = jumpSpeed; //Moves the player up on the Y axis at the speed of the jumpSpeed float.
                jump = false; //Sets the jump boolean to false.
                isJumping = true; //Sets the isJumping boolean to true, so the program knows the player is currently jumping.

            }
        }

        else //Else if the player is in the air, then...
        {

            moveDirection += Physics.gravity * gravityMultiplier * Time.deltaTime;

        }

        collisionFlags = characterController.Move(moveDirection * Time.deltaTime);

    }

	void MovePlayer()
    {

      //  float hAxis = Input.GetAxis("Horizontal");
      //  float vAxis = Input.GetAxis("Vertical");

      //  bool isRunning = (Input.GetKey(KeyCode.LeftShift) && vAxis > 0); //Creates a booleon when the left shift key is held down and the player is currently moving forward.
      //  playerSpeed = IsRunning ? maxSprintSpeed : baseSpeed; //If the booleon above is true, then set the playerSpeed as maxSprintSpeed, else set it as baseSpeed.

       // Vector3 moveDirectionSide = transform.right * hAxis * playerSpeed;
      //  Vector3 moveDirectionForward = transform.forward * vAxis * playerSpeed;

     //   characterController.SimpleMove(moveDirectionSide);
      //  characterController.SimpleMove(moveDirectionForward);


    }

    private void MovePlayerV2()
    {

        float playerSpeed; //Creates a float called playerSpeed;
        bool isRunning; //Creates a booleon called isRunning.
        GetInputs(out playerSpeed, out isRunning); //Calls two varibales that were calculated in the GetInputs method. These include the playerSpeed float and the isRunning boolean.

        Vector3 desiredMove = transform.forward * input.y + transform.right * input.x; //Creates a 3D vector called desiredMove, .....

        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, characterController.radius, Vector3.down, out hitInfo,
                               characterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;


        moveDirection.x = desiredMove.x * playerSpeed; //The player moves in their desired location on the X axis at the velocity of playerSpeed
        moveDirection.z = desiredMove.z * playerSpeed; //The player moves in their desired location on the Y axis at the velocity of playerSpeed

        //print("Moving on X axis: " + moveDirection.x + ".");
        //print("Moving on Z axis: " + moveDirection.z + ".");

        if (characterController.isGrounded == true && characterController.velocity.magnitude > 3f && audioSource.isPlaying == false) //If the player is on the ground (not in air), is currently moving, and there is currently no audio playing, then...
        {
            if (isRunning == true) //If the player is currently running, then...
            {

                PlayRunningFootstepSounds(); //Tells the program to call the PlayRunningFootstepSounds method.
                print("Player is sprinting.");

            }
            else //If the player is not currently running; walking, then...
            {

                PlayWalkingFootstepSounds(); //Tells the program to call the PlayWalkingFootstepSounds method.
                print("Player is walking.");

            }

        }

    }

    private void GetInputs(out float playerSpeed, out bool isRunning) //Outputs the float playerSpeed and the boolean isRunning outside of the method so they can be used by another method.
    {

        float hAxis = Input.GetAxis("Horizontal"); //Gets the current horizontal axis of the player.
        float vAxis = Input.GetAxis("Vertical"); //Gets the current vertical axis of the player.

        isRunning = ((Input.GetKey(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.JoystickButton8))) && vAxis > 0); //Creates a booleon when the left shift key is held down and the player is currently moving forward.
        playerSpeed = isRunning ? maxSprintSpeed : baseSpeed; //If the booleon above (playerSpeed) is true, then set the playerSpeed as maxSprintSpeed, else set it as baseSpeed.

        input = new Vector2(hAxis, vAxis); //Saves the two floats calculated earlier into a 2D vector so it can be accessed later.
    }

    void PlayWalkingFootstepSounds() //A method created to play footstep sounds when the player is walking.
    {

        int x = Random.Range(1, walkingFootstepSounds.Length); //Chooses a random value between 1 and the number of audio clips within the array and represents it with x.
        audioSource.clip = walkingFootstepSounds[x]; //The audio clip assigned with the integer value x is then inserted into the audioSource.
        audioSource.PlayOneShot(audioSource.clip); //The current audio clip within the audioSource is played once.
  
        walkingFootstepSounds[x] = walkingFootstepSounds[0]; //Sets the audio clip in the first value of the array as the audio clip to be used next time.
        walkingFootstepSounds[0] = audioSource.clip; //Sets the audio clip that was just used as the first array value so it is used next time.

    }

    void PlayRunningFootstepSounds() //A method created to play footstep sounds when the player is running.
    {

        int x = Random.Range(1, runningFootstepSounds.Length); //Chooses a random value between 1 and the number of audio clips within the array and represents it with x.
        audioSource.clip = runningFootstepSounds[x]; //The audio clip assigned with the integer value x is then inserted into the audioSource.
        audioSource.PlayOneShot(audioSource.clip); //The current audio clip within the audioSource is played once.

        runningFootstepSounds[x] = runningFootstepSounds[0]; //Sets the audio clip in the first value of the array as the audio clip to be used next time.
        runningFootstepSounds[0] = audioSource.clip; //Sets the audio clip that was just used as the first array value so it is used next time.

    }

    void PlayJumpingSound()
    {

        audioSource.clip = jumpSound;
        audioSource.PlayOneShot(audioSource.clip);

    }
}