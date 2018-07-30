using UnityEngine;
/// <summary>
/// this class enables hand controller object to cast a ray to point ui elements
/// </summary>
/// 
[RequireComponent(typeof(LineRenderer))]
public class Pointer_SteamVR : MonoBehaviour {

    [SerializeField]
    private LineRenderer pointerLine;
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private Transform viewPoint;

    private IPointableUIElement lastPointedElement;
    
    private void Update () {
        
        CastPointer();
	}

    private void DisplayPointerLine(float lineLength = 5f)
    {
        Vector3 endPos = transform.position + transform.forward * lineLength;
        Vector3[] points = { transform.position, endPos };
        pointerLine.SetPositions(points);
    }

    private void DisplayPoint(bool activated, Vector3 pos)
    {
        point.SetActive(activated);
        point.transform.position = pos;
        point.transform.LookAt(viewPoint);
        point.transform.Rotate(new Vector3(0f, 180f, 0f));
    }

    private RaycastHit FindNearestHit(RaycastHit[] hits)
    {
        if(hits.Length == 1) { return hits[0]; }

        RaycastHit nearestHit = hits[0];
        for (int i = 1; i < hits.Length; i++)
        {
            if (hits[i].distance > hits[i-1].distance) { continue; }
            nearestHit = hits[i];
        }

        return nearestHit;
    }

    private IPointableUIElement FindPointables(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            IPointableUIElement pointable = hits[i].collider.GetComponent<IPointableUIElement>();
            if(pointable != null) { return pointable; }
        }

        return null;
    }

    private void CastPointer() {
        RaycastHit[]  hits = Physics.RaycastAll(transform.position, transform.forward);
        if(hits.Length < 1) {
            DisplayPointerLine();
            Vector3 tempPointPos = Vector3.zero;
            DisplayPoint(false, tempPointPos);

            if (lastPointedElement == null) { return; }
            lastPointedElement.OnPointerLeft();
            lastPointedElement = null;
            return;
        }
        RaycastHit nearestHit = FindNearestHit(hits);
        DisplayPointerLine(nearestHit.distance);
        DisplayPoint(true, nearestHit.point);
        
        IPointableUIElement pointableElement = FindPointables(hits);

        // call feedbacks when the pointer left a interactable UI element
        if (pointableElement == null) {
            if (lastPointedElement == null) { return; }
            lastPointedElement.OnPointerLeft();
            lastPointedElement = pointableElement;
            return;
        }

        // call feedbacks when the pointer hits a interactable UI element
        if (pointableElement != lastPointedElement) {
            pointableElement.OnPointed();
            lastPointedElement = pointableElement;
        }

        var trackedObject = GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        bool isClicked = device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger);
        if (!isClicked) { return; }
        device.TriggerHapticPulse(500);
        pointableElement.OnClicked();
        
    }
}
