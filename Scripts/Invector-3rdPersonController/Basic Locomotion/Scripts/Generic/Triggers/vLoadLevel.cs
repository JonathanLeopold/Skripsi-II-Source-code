using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif
namespace Invector.vCharacterController
{
    public class vLoadLevel : MonoBehaviour
    {
        [Tooltip("Write the name of the level you want to load")]
        public string levelToLoad;
        [Tooltip("True if you need to spawn the character into a transform location on the scene to load")]
        public bool findSpawnPoint = true;
        [Tooltip("Assign here the spawnPoint name of the scene that you will load")]
        public string spawnPointName;
         public GameObject loadingScreen;
        //public GameObject close;
        public Slider slider;
        public GameObject chara;
        //public GameObject hud;
        public GameObject dontdestroy;


        void OnTriggerEnter(Collider other)
        {
            //close.SetActive(false);
            

            StartCoroutine(LoadAsynchronously(levelToLoad));
            if (other.gameObject.tag.Equals("Player"))
            {
                var spawnPointFinderObj = new GameObject("spawnPointFinder");
                var spawnPointFinder = spawnPointFinderObj.AddComponent<vFindSpawnPoint>();
                //Debug.Log(spawnPointName+" "+gameObject.name);
                // if(spawnPointName == "MainMenu"){
                //     Destroy(GameObject.Find("Inventory_Melee(Clone)"));
                //     Destroy(GameObject.Find("vMeleeController_main_characters Instance"));
                //     Destroy(GameObject.Find("vUI"));
                //     Destroy(GameObject.Find("vGameController Instance"));
                //     Destroy(chara);
                    
                // }
                DontDestroyOnLoad(dontdestroy);

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