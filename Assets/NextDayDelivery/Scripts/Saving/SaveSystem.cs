using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //public static void SavePlayerMovement (Movement movement)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/playermovement.fun";
    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    PlayerMovementData movementData = new PlayerMovementData(movement);

    //    formatter.Serialize(stream, movementData);
    //    stream.Close();


    //}

    //public static PlayerMovementData LoadMovementData ()
    //{
    //    string path = Application.persistentDataPath + "/playermovement.fun";
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        PlayerMovementData movementData = formatter.Deserialize(stream) as PlayerMovementData;
    //        stream.Close();

    //        return movementData;
    //    }
    //    else
    //    {
    //        Debug.LogError("Save file not found in " + path);
    //        return null;
    //    }
    //}

}
