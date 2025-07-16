using UnityEditor;
using UnityEngine;

public class FindMissingScripts : MonoBehaviour
{
    [MenuItem("Tools/Find Missing Scripts in Scene")]
    static void FindMissing()
    {
        GameObject[] go = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject g in go)
        {
            Component[] components = g.GetComponents<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"Missing script on: {g.name}", g);
                    count++;
                }
            }
        }

        Debug.Log($"Scan complete. Found {count} missing scripts.");
    }
}