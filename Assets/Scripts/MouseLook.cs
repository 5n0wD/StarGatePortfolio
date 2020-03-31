using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitiviy = 100f;
    public Transform playerBody;
    private float xRotation = 0f;

    public float range = 100f;
    public Camera fpsCam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //Brackeys code <3
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitiviy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitiviy * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // my own hacking + brackeys
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        /*RaycastHit hit;*/

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            Glyph glyph = hit.transform.GetComponent<Glyph>();

            if (glyph != null)
                glyph.Activate();


            /* after the "BigRedButton" is pressed, the address needs to be emptied, and the gate needs to be enabled.*/


            #region
            //for (int i = 0; i < constellationsList.Count; i++)
            //{
            //    if (constellationsList[i].name == constTarget)
            //    {
            //        Debug.Log(constellationsList[i].name + " " + "The Const Target is: " + constTarget);
            //    }
            //}
            #endregion


        }
    }

}