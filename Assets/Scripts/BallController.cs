using UnityEngine;
using UnityEngine.Events;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.Rendering.DebugUI.Table;
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    private bool isBallLaunched;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    private Rigidbody ballRB;
    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();
        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the
        // LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }
    private void LaunchBall()
    {
        // now your if check can be framed like a sentence
 // "if ball is launched, then simply return and do nothing"
    if (isBallLaunched) return;
        // "now that the ball is not launched, set it to true and launch the ball"
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
