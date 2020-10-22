using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using UnityEngine;

public class bulb2on : MonoBehaviour
{
    public Button yourButton;
    public Text displaytext;

    void Start ()
    {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(task);
    }
    void task()
    {
	StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
    	
	UnityWebRequest www = UnityWebRequest.Get("http://madblocks.tech/dashboard/device_push.php?device_api_key=602b11493d6a19159cb8eb7809bd80e8&device_status=on2");
     yield return www.SendWebRequest();
         
         if(www.isNetworkError || www.isHttpError)
         {
            Debug.Log(www.error);
         }
         else
         {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
         }
     }
}
