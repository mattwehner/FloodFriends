#pragma strict
var movement = 0;
var movementSpeed = 0.3;

function Start () {

};

function Update () {
    
    if (Input.GetKeyDown(KeyCode.W)) {
        movement = 1;
    };
    if (Input.GetKeyDown(KeyCode.S)) {
        movement = 2;
    };
    if (movement == 0) {
        transform.Translate(new Vector3(0,0,0));
    };
    if (movement == 1) {
        transform.Translate(Vector3.forward * movementSpeed);
    };
    if (movement == 2) {
        transform.Translate(Vector3.back * movementSpeed);
    };
};