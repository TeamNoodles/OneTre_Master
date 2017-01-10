using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                    Debug.LogError(typeof(T) + "instance not found");
            }
            return instance;
        }
    }

    void Awake()
    {
        CheckInstance();
    }

    /// <summary>
    /// instanceの中身があるかどうか判定する
    /// </summary>
    /// <returns></returns>
    protected bool CheckInstance()
    {
        if (instance == null)
        {
            return true;
        }
        Destroy(this.gameObject);
        return false;
    }
}
