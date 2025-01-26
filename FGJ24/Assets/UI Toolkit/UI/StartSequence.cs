using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartSequence : MonoBehaviour
{
        private UIDocument uiDoc;
        private VisualElement BackgroundEL;
        private VisualElement MemoryTestEL;
        private VisualElement CopyrightEL;
        private VisualElement Detect1EL;
        private VisualElement Detect2EL;
        private VisualElement Detect3EL;
        private VisualElement Detect4EL;

        private string activeClass= "opacity";
        private string activeClass1= "hidden";

    // Start is called before the first frame update
    void Start()
    {
        uiDoc = GetComponent<UIDocument>();

        BackgroundEL = uiDoc.rootVisualElement.Q("BackgroundEL");
        MemoryTestEL = BackgroundEL.Q<VisualElement>("MemorytestEL");
        CopyrightEL = BackgroundEL.Q<VisualElement>("CopyrightEL");
        Detect1EL = BackgroundEL.Q<VisualElement>("Detect1EL");
        Detect2EL = BackgroundEL.Q<VisualElement>("Detect2EL");
        Detect3EL = BackgroundEL.Q<VisualElement>("Detect3EL");
        Detect4EL = BackgroundEL.Q<VisualElement>("Detect4EL");

        StartCoroutine(Startup());
    }

    IEnumerator Startup()
    {
        yield return new WaitForSeconds(1);
        MemoryTestEL.AddToClassList(activeClass);
        yield return new WaitForSeconds(1);
        CopyrightEL.AddToClassList(activeClass);
        yield return new WaitForSeconds(1);
        Detect1EL.AddToClassList(activeClass);
        yield return new WaitForSeconds(1);
        Detect2EL.AddToClassList(activeClass);
        yield return new WaitForSeconds(1);
        Detect3EL.AddToClassList(activeClass);
        yield return new WaitForSeconds(1);
        Detect4EL.AddToClassList(activeClass);
        //yield return new WaitForSeconds(1);
        //BackgroundEL.AddToClassList(activeClass1);
        yield return new WaitForSeconds(2);
        StartGame();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
