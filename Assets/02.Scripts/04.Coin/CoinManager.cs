using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text CoinTextUI;
    private int _coin = 100;
    public int Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            if (value < 0)
            {
                return;
            }
            _coin = value;
            CoinTextUI.text = $"{_coin}";
        }
    }
    public static CoinManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
