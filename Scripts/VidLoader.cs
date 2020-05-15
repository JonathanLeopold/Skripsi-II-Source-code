using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class VidLoader : MonoBehaviour
{
    // public GameObject VideoPlayer;
    public VideoPlayer Video;

    public GameObject Title;
    
     void Start() {
         

        // VideoPlayer.SetActive(false);
    }
    public void playvideo (){
        Video.loopPointReached += changeScene;
        Title.SetActive(false);
        // VideoPlayer.SetActive(true);
        
        
            // StartCoroutine(LoadAsynchronously(sceneIndex));
        
    }
    void changeScene(UnityEngine.Video.VideoPlayer vp){
        SceneManager.LoadScene(1);
    }
    // public void loadScene(int sceneIndex){
    //     Destroy(VideoPlayer, timeToStop);
    //         StartCoroutine(LoadAsynchronously(sceneIndex));
    // }
    // IEnumerator LoadAsynchronously (int sceneIndex)
    // {
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    //     loadingScreen.SetActive(true);

    //     while(!operation.isDone)
    //     {
    //         float progress = Mathf.Clamp01(operation.progress / .9f);
    //         slider.value = progress;
    //         yield return null;
    //     }
    // }
}
