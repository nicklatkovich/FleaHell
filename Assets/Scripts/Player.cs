using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float MaxSpeed = 1f;
    public float Dir = 0f;
    public float Pitch = 6f;

    private Transform camera;
    private Transform spot;

    void Start( ) {
        camera = this.transform.FindChild("Main Camera");
        spot = this.transform.FindChild("Spotlight");
    }

    void Update( ) {
        Dir += Input.GetAxis("TargetX") * 2f * Time.deltaTime;
        Pitch += Input.GetAxis("TargetZ") * 4f * Time.deltaTime;

        Vector3 v = new Vector3(Input.GetAxis("MoveX"), 0f, Input.GetAxis("MoveZ"));
        Vector3 norm = new Vector3(Mathf.Cos(Dir), 0f, Mathf.Sin(Dir));

        //this.transform.position

        this.transform.position += (new Vector3(norm.z * v.z, 0f, norm.x * v.z) + new Vector3(norm.x * v.x, 0f, -norm.z * v.x)) * MaxSpeed * Time.deltaTime;

        Vector3 anti_norm = new Vector3(norm.z, 0f, norm.x);

        spot.rotation = Quaternion.LookRotation(anti_norm, Vector3.up);

        camera.localPosition = new Vector3(-norm.z, 0f, -norm.x) * Pitch + new Vector3(0f, camera.localPosition.y, 0f);

        camera.rotation = Quaternion.LookRotation(-camera.localPosition, Vector3.up);
    }
}
