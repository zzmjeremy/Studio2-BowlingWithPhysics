using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

     //Areferencetoour ballController
     [SerializeField] private BallController ball;
     //Areferenceforour PinCollectionprefabwemade inSection 2.2
     [SerializeField] private GameObject pinCollection;
     //Areferenceforan emptyGameObject whichwe'll
     //useto spawnour pincollection prefab
     [SerializeField] private Transform pinAnchor;
     //Areferenceforour inputmanager
     [SerializeField] private InputManager inputManager;
     [SerializeField] private TextMeshProUGUI scoreText;
     private FallTrigger[] fallTriggers;
     private GameObject pinObjects;
     private FallTrigger[] pins;
    private void Start()
    {
        //We find all objects of type FallTrigger
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        //We then loop over our array of pins and add the
        // IncrementScore function as their listener
        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
            
        }
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

 private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }
private void SetPins()
    {
        //We firstmake surethat allthe previouspins havebeen destroyed

        //this isso thatwe don'tcreate anew collectionof
        //standing pinsontop ofalready fallenpins
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
            
        }
        // We then instatiate a new set of pins to our pin anchor transform
            pinObjects = Instantiate(pinCollection,
            pinAnchor.transform.position,
            Quaternion.identity, transform);

        // We add the Increment Score function as a listener to
        // the OnPinFall event each of new pins
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,
            FindObjectsSortMode.None);
            foreach (FallTrigger pin in fallTriggers)
            {
                pin.OnPinFall.AddListener(IncrementScore);
            }
        
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}