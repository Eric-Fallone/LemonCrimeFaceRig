using UnityEngine;

public class HelloClient : MonoBehaviour
{
    private HelloRequester _helloRequester;

    private void Start()
    {
        _helloRequester = new HelloRequester();
		Debug.Log("Starting Lisening for sever");
		_helloRequester.Start();
    }

    private void OnDestroy()
    {
        _helloRequester.Stop();
    }

	private void OnApplicationQuit()
	{
		_helloRequester.CleanupStuff();
	}
}