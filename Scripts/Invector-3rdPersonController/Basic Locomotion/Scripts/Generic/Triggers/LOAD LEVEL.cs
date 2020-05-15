using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif
namespace Invector.vCharacterController{
public class LOADLEVEL : MonoBehaviour
{
    [Tooltip("Write the name of the level you want to load")]
        public string levelToLoad;
        [Tooltip("True if you need to spawn the character into a transform location on the scene to load")]
        public bool findSpawnPoint = true;
        [Tooltip("Assign here the spawnPoint name of the scene that you will load")]
        public string spawnPointName;
         public GameObject loadingScreen;
        public GameObject close;
        public Slider slider;
        public GameObject chara;
        public GameObject hud;


        void OnTriggerEnter(Collider other)
        {
            // close.SetActive(false);
            Destroy(chara);
            Destroy(hud);
            Destroy (GameObject.Find("Inventory_Melee(Clone)"));
            StartCoroutine(LoadAsynchronously(levelToLoad));
            if (other.gameObject.tag.Equals("Player"))
            {
                var spawnPointFinderObj = new GameObject("spawnPointFinder");
                var spawnPointFinder = spawnPointFinderObj.AddComponent<vFindSpawnPoint>();
                if(spawnPointName == "MainMenu"){
                    
                }
                //Debug.Log(spawnPointName+" "+gameObject.name);

                spawnPointFinder.AlighObjetToSpawnPoint(other.gameObject, spawnPointName);

#if UNITY_5_3_OR_NEWER
                SceneManager.LoadScene(levelToLoad);
#else
        		Application.LoadLevel(levelToLoad);
#endif
            }
        }
        IEnumerator LoadAsynchronously (string levelToLoad)
        {
             AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
             loadingScreen.SetActive(true);

             while(!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                yield return null;
            }
}
}
}

