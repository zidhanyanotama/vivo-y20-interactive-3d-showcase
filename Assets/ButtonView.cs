using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private float duration = 0.5f; //waktu transisi

    private Coroutine rotateCoroutine;


    //fungsi untuk mengubah rotasi halus
    public void SetRotation(float x, float y, float z)
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Target Object Belum Di Assign!");
            return;
        }

        Quaternion targetRotation = Quaternion.Euler(x, y, z);

        //Hentikan couroutine lama 
        if (rotateCoroutine != null)
            StopCoroutine(rotateCoroutine);

        //jalankan animasi rotasi baru
        rotateCoroutine = StartCoroutine(RotateSmooth(targetRotation));
    }

    public void ViewFront()
    {
        SetRotation(0f, 0f, 0f);
    }

    public void ViewBack()
    {
        SetRotation(0f, 180f, 0f);
    }

    public void ViewRight()
    {
        SetRotation(0f, -90f, 0f);
    }

    public void ViewLeft()
    {
        SetRotation(0f, 90f, 0f);
    }

    public void ViewUp()
    {
        SetRotation(-90f, 0f, 0f);
    }

    public void ViewDown()
    {
        SetRotation(90f, 0f, 0f);
    }
    
    //Coroutine untuk rotasi halus
    private IEnumerator RotateSmooth(Quaternion targetRot)
    {
        Quaternion startRot = targetObject.transform.rotation;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            //interpolasi rotasi
            targetObject.transform.rotation = Quaternion.Slerp(startRot, targetRot, t);

            yield return null;
        }

        //pastikan rotasi sampai tujuan
        targetObject.transform.rotation = targetRot;
    }
}