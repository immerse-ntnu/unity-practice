using System.Collections;
using UnityEngine.SceneManagement;

internal static class Helpers
{
	public static IEnumerator LoadScene()
	{
		var operation = SceneManager.LoadSceneAsync("SampleScene");
		while (!operation.isDone)
			yield return null;
	}
}