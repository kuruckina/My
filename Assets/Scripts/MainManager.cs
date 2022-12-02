using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static InventoryManager inventory;
    private static Messenger messenger;
    public static SceneChanger sceneChanger;
    public static GameManager game;

    public static Messenger Messenger
    {
        get
        {
            if (messenger == null) // инициализация по запросу
            {
                messenger = FindObjectOfType<Messenger>();
            }

            return messenger;
        }
        private set
        {
            messenger = value;
        }
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        sceneChanger = GetComponent<SceneChanger>();
        game = GetComponent<GameManager>();
    }

    public static InventoryManager Inventory
    {
        get
        {
            if (inventory == null)
            {
                inventory = FindObjectOfType<InventoryManager>();
            }

            return inventory;
        }
        private set
        {
            inventory = value;
        }
    }
}