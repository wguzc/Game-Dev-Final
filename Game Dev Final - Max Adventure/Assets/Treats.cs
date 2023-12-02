using UnityEngine;

public class Treats : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private TreatsManager treatsManager;

    private void Start(){
        treatsManager = TreatsManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            treatsManager.ChangeTreats(value);
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
        
    }
}
