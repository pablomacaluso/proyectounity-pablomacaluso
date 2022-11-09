using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition; 

   // public GameObject deathEffect;

    private void Awake() 
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnWaiter");

    }
    // Respawn Waiter ( Dos Segundos al Morir )
    public IEnumerator RespawnWaiter()
    {
        PlayerController.instance.gameObject.SetActive(false);
    // Desactivar Camara al Morir
        CameraController.instance.cmBrain.enabled = false;

        UIManager.instance.fadeToBlack = true;

       // Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3 (0f, 1f, 0f), PlayerController.instance.transform.rotation);

        yield return new WaitForSeconds(2f);

        UIManager.instance.fadeFromBlack = true;

        PlayerController.instance.transform.position = respawnPosition;
    // Re Activar Camara
        CameraController.instance.cmBrain.enabled = true;

        PlayerController.instance.gameObject.SetActive(true);

        HealthManager.instance.ResetHealth();
    }


    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn Creado");
    }
}
