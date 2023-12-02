using UnityEngine;
using TMPro;

public class TreatsManager : MonoBehaviour
{
    public static TreatsManager instance; // Corrected the class name

    private int treats;
    [SerializeField] private TMP_Text treatsDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {
        treatsDisplay.text = treats.ToString();
    }

    public void ChangeTreats(int amount)
    {
        treats += amount;
    }
}
