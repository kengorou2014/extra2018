/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

// The finger model for our rigid hand made out of various cubes.
public class TestSphere : MonoBehaviour
{
    public const int NUM_BONES = 4;

    protected HandController controller_;
    protected Finger finger_;
    protected Vector3 offset_ = Vector3.zero;
    protected bool mirror_z_axis_ = false;
    public GameObject[] bones = new GameObject[NUM_BONES];

    //public float filtering = 0.5f;

    //public GameObject sphere;
    //private GameObject _sphere;

    void Start()
    {
        
        //for (int i = 0; i < bones.Length; ++i)
        //{
        //    if (bones[i] != null)
        //    {
        //        bones[i].GetComponent<Rigidbody>().maxAngularVelocity = Mathf.Infinity;
        //    }
        //}
        //GameObject _sphere = (GameObject)Instantiate(sphere, sphere.transform.position, Quaternion.identity);
    }

    public Vector3 GetBoneCenter(int bone_type)
    {
        if (controller_ != null && finger_ != null)
        {
            Bone bone = finger_.Bone((Bone.BoneType)(bone_type));
            return controller_.transform.TransformPoint(bone.Center.ToUnityScaled(mirror_z_axis_)) + offset_;
        }
        if (bones[bone_type])
        {
            return bones[bone_type].transform.position;
        }
        return Vector3.zero;
    }

    public void Update()
    {
        transform.position = GetBoneCenter(2);
    }
}

