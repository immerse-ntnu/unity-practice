using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

public class player_movement
{
    private PlayerMovement _player;

    [UnitySetUp]
    private IEnumerator setup()
    {
        yield return Helpers.LoadScene();
        _player = Object.FindObjectOfType<PlayerMovement>();
    }

    [UnityTest]
    public IEnumerator player_moves()
    {
        var originalPos = _player.transform.position;
        Assert.AreEqual(originalPos, _player.transform.position);
        _player.Move(Vector3.forward);
        yield return new WaitForFixedUpdate();
        Assert.AreNotEqual(originalPos, _player.transform.position);
    }
}