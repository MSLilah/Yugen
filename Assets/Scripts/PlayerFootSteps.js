#pragma strict
var stepSound : AudioClip;
private var chMotor : CharacterMotor;
private var controller : CharacterController;
private var stepTimer = 0.888;
function Start () {
	chMotor = GetComponent(CharacterMotor);
	controller = GetComponent(CharacterController);
}

function Update () {

	if( controller.velocity.magnitude > 0 )
	{
		StepSound();
	}
	
	if(stepTimer > 0)
	{
		stepTimer -= Time.deltaTime;
	}
}
function StepSound()
{
	if(stepTimer <= 0)
	{
		audio.PlayOneShot(stepSound);
		stepTimer = 0.888;
	}
}