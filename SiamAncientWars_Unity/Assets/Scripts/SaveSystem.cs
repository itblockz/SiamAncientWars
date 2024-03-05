using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string path = Application.persistentDataPath + "/player.bin";

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new();
        FileStream stream = new(path, FileMode.Create);
        PlayerData data = new(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }

        Debug.Log("Save file not found in " + path);
        return null;
    }
}
