using System;
using UnityEngine;

public class PlayeController : MonoBehaviour
{
    public float velocidad;
    private Rigidbody rb;
    public GameManager cubeScript;
//
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject cubeObject = GameObject.Find("Game");
        cubeScript = cubeObject.GetComponent<GameManager>();
        RestaurarPosicion();
    }

    private void OnDestroy()
    {
        GuardarPosicion();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * velocidad);
        if (Input.GetKeyDown(KeyCode.C))
        {
            RestaurarPosicion();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardarPosicion();
        }
    }

    private void RestaurarPosicion()
    {
        GameDate datosLeidos = cubeScript.CargarDatos();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(new Vector3(datosLeidos.x, datosLeidos.y, datosLeidos.z));
    }

    private void GuardarPosicion()
    {
        GameDate datosAGuardar = new GameDate();
        datosAGuardar.x = rb.position.x;
        datosAGuardar.y = rb.position.y;
        datosAGuardar.z = rb.position.z;
        cubeScript.SaveGame(datosAGuardar);
    }
}


////