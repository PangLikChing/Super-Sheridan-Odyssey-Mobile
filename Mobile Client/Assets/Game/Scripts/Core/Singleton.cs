using UnityEngine;
using System.Collections;

/// <summary>
/// Simple singleton interface with support for any type.
/// Note that this will create a new instance if no instance set.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	// Static reference to instance
	protected static T instance;

	protected bool initialized;

	protected static bool applicationClosing = false;

	/// <summary>
	/// 
	/// </summary>
	public static T Instance {
		get {

			if (applicationClosing) 
			{
				return null;
			}

			if (instance == null)
			{
				instance = (T)FindObjectOfType(typeof(T));

				if (instance == null)
				{
					GameObject go = new GameObject(typeof(T).Name, typeof(T));
					instance = go.GetComponent<T>();
				}
			}
           // DontDestroyOnLoad(instance);
			Debug.Assert(instance != null, "Instance is null for type: " + typeof(T).ToString());
			return instance;
		}
	}

	/// <summary>
	/// Returns true if this has a reference to a valid instance.
	/// </summary>
	/// <returns></returns>
	public static bool IsValidSingleton()
	{
		return instance != null;
	}

	/// <summary>
	/// 
	/// </summary>
    public static void MakeNull()
    {
        Debug.LogWarning("made null");
        instance = null;
    }

	private void OnApplicationQuit()
	{
		applicationClosing = true;
	}

}
