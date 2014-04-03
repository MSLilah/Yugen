#pragma strict

private var maxStamina = 100f;
private var currStamina = 100f;
private var staminaBarLength;
private var style : GUIStyle;
private var texture : Texture2D;
function Start () {
	staminaBarLength = Screen.width / 2;
	style = new GUIStyle();
	texture = new Texture2D(128, 128);
}

function Update () {
	currStamina = GetComponent(SprintController).stamina;
	staminaBarLength = (Screen.width / 2) * (currStamina / maxStamina);
}

function OnGUI() {
	texture.SetPixel(0, 0, Color.white);
    texture.Apply();
    style.normal.background = texture;
    GUI.backgroundColor = new Color(0, 136, 0, 255);
	GUI.Box(new Rect(10, 10, staminaBarLength, 20), "", style);
	GUI.backgroundColor = Color.white;
}