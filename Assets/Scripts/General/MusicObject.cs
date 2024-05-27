/*
   Singleton script
   Script to make the linked object remain in all scenes
   It will also be in charge of changing the music when necessary

   Info used:
   - Detecting when a scene is loaded:
   https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
   - Singleton:
   https://gamedevbeginner.com/singletons-in-unity-the-right-way/
   https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html

Gilberto Echeverria
2023-01-31      Use ScriptableObjects to simplify the management of new levels
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicObject : MonoBehaviour {

    [SerializeField] MusicListSO musicLists;

    private static MusicObject instance = null;
    private AudioSource audioSource;

    public static MusicObject Instance {
        get { return instance; }
    }

    // Called once at the start of the scene
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;

            // Get a reference to the Audio Source component
            audioSource = GetComponent<AudioSource>();
        }
        // Keep this object from being destroyed
        DontDestroyOnLoad(this.gameObject);
    }

    // Define a method to call when loading a scene
    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Detect when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Variable to determine which clip to play
        bool play_default = true;
        // Loop over the list of scenes
        // The first audio clip is used by default
        for (int i=1; i<musicLists.scenes.Length; i++) {
            if (scene.name == musicLists.scenes[i]) {
                play_default = false;
                audioSource.clip = musicLists.samples[i];
                // Play the selected song
                audioSource.Play();
            }
        }
        // If the default is selected
        if (play_default) {
            // Start playing again only if comming from a different scene
            if (audioSource.clip != musicLists.samples[0]) {
                audioSource.clip = musicLists.samples[0];
                // Play the selected song
                audioSource.Play();
            }
        }
    }

}