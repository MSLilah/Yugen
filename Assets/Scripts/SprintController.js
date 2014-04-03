#pragma strict

var walkSpeed: float = 6; // regular speed
var runSpeed: float = 20; // run speed
private var chMotor: CharacterMotor;
var stamina = 100f;
var noSprint = false;

function Start () {
	chMotor = GetComponent(CharacterMotor);
}

function Update () {
	if (chMotor.grounded && Input.GetKey("left shift") && (Input.GetKey("w") || Input.GetKey("up")) && !noSprint) {
		chMotor.movement.maxForwardSpeed = runSpeed; // set max speed
		stamina -= 0.5f;
		if (stamina <= 0) {
			noSprint = true;
		}
	}
	else {
		chMotor.movement.maxForwardSpeed = walkSpeed;
		if (stamina < 100f) {
			stamina += 0.3f;
		}
		if (stamina > 100f) {
			stamina = 100f;
		}
		if (stamina > 50) {
			noSprint = false;
		}
	}
}