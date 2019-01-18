using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class SphereShoot : MonoBehaviour {
    
    [SerializeField] 
    private Camera cam;

    [SerializeField] 
    private LineRenderer line;

    private bool aiming;
    
    void Start() {

        line.startWidth = 0.05f;
        line.endWidth = 0.05f;

    }
    
    private void Update() {

        
        if (ClickedMainSphere()) 
            aiming = true;
        
        if (Input.GetMouseButtonUp(0))
            aiming = false;

        if (aiming) {
            Aim(cam.ScreenToWorldPoint(Input.mousePosition));
        }

    }

    private bool ClickedMainSphere() {
        
        if (Input.GetKeyDown(KeyCode.Mouse0)) {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);     
            if (Physics.Raycast(ray, out RaycastHit hit, 100)) {
                if (hit.transform.gameObject.layer == 9)
                    return true;
            }
        }

        return false;
    }

    private void Aim(Vector3 input) {

        input = input.WithValues(y: 0);
        
        line.enabled = true;
        Ray ray = new Ray(transform.position, transform.DirectionTo(input));

        if (Physics.Raycast(ray, out RaycastHit hit, 100)) {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.transform.position);
        }
        else {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.DirectionTo(input) * 100);
        }

    }
    
}