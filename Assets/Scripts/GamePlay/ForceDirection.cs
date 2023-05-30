using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDirection : MonoBehaviour
{
    public float sensitivity= 9.0f;
    public float minimum = -45.0f;
    public float maximum = 45.0f;
    private float Rot = 0;

    [SerializeField] GameObject topVector;
    [SerializeField] GameObject bottomVector;
    [SerializeField] GameObject force_slider;
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX =1,
        MouseY = 2

    }
   void Update(){
            Rot += Input.GetAxis("Mouse X") * sensitivity;
            Rot = Mathf.Clamp(Rot, minimum, maximum);
            transform.localEulerAngles = new Vector3(0,Rot,  0);


            if (Input.GetMouseButtonDown(0)){
                Vector3 direction = topVector.transform.position - bottomVector.transform.position;
                Strikeforce.direction = direction;
                Debug.Log(Strikeforce.direction);
                gameObject.SetActive(false);
                force_slider.SetActive(true);

//                Debug.Log("give magniture");
            }

   } 

    

}
