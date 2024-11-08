using System;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    private string file;
    public GameDate datosJuego = new GameDate();

    private void Awake()
    {
        file = Application.persistentDataPath + "/GameData.json";
    }

    public GameDate CargarDatos()
    {
        if (File.Exists(file))
        {
            string contenido = File.ReadAllText(file);
            datosJuego = JsonUtility.FromJson<GameDate>(contenido);
            Debug.Log(datosJuego.x.ToString());
            Debug.Log(datosJuego.y.ToString());
            Debug.Log(datosJuego.z.ToString());
        }
        else
        {
            datosJuego.z = 0;
            datosJuego.x = 0;
            datosJuego.y = 0;
        }
        return datosJuego;

    }
    
    
    
    public void SaveGame(GameDate datosJuego)
    {
        string json = JsonUtility.ToJson(datosJuego);
        File.WriteAllText(file, json);
        Debug.Log(json);
    }
}
