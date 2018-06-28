using UnityEngine;
using System.Collections;
using Leap;

public class PalmOrbit : MonoBehaviour
{

    Controller controller = new Controller();

    public int PalmCount;
    public GameObject[] PalmObjects;
    public float speed;

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
                Vector offset = new Vector(2, 1, 2);
                Vector axis = normalizedPosition + offset;

                unityPalm.transform.localPosition = ToVector3(normalizedPosition);
                transform.RotateAround(ToVector3(axis), ToVector3(normalizedPosition), speed * Time.deltaTime);

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
