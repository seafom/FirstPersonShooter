using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator animator;
    private void Update()
    {
        animator.SetTrigger("CameraShake");

    }

}
