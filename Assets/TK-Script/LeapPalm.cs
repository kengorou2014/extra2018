using UnityEngine;
using System.Collections;
using Leap;

public class LeapPalm : MonoBehaviour
{

    Controller controller = new Controller();

    public int PalmCount;
    public GameObject[] PalmObjects;

    void Start()
    {
    }

    void Update()
    {
        Frame frame = controller.Frame();
        PalmCount = frame.Fingers.Count;

        for (int i = 0; i < PalmObjects.Length; i++)
        {
            var leapPalm = frame.Hands[i];
            var unityPalm = PalmObjects[i];
            SetVisible(unityPalm, leapPalm.IsValid);
            if (leapPalm.IsValid)
            {
                Vector normalizedPosition = leapPalm.PalmPosition;
                Vector normalizedDirection = leapPalm.Direction;

                normalizedPosition.z = -normalizedPosition.z;

                unityPalm.transform.localPosition = ToVector3(normalizedPosition);
                unityPalm.transform.localRotation = Quaternion.Euler(ToVector3(normalizedDirection * 100));

            }
        }
    }

    void SetVisible(GameObject obj, bool visible)
    {
        foreach (Renderer component in obj.GetComponents<Renderer>())
        {
            component.enabled = visible;
        }
    }

    Vector3 ToVector3(Vector v)
    {
        return new UnityEngine.Vector3(v.x, v.y, v.z);
    }
}
