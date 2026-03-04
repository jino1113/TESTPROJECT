using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerStatus.IsSafe = true;
            Debug.Log("IsSafe");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStatus.IsSafe = false;
        }
    }
}

public static class PlayerStatus
{
    public static bool IsSafe = false;
}
