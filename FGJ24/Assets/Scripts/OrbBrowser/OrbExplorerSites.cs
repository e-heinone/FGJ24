using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OrbExplorerSites : MonoBehaviour
{
    private Label linkLabel;
    private OrbExplorer orbExplorer;

    private VisualElement site04;

    private void Awake()
    {
        orbExplorer = GetComponent<OrbExplorer>();
        
        var root = GetComponent<UIDocument>().rootVisualElement;

        linkLabel = root.Q<Label>("LinkkiText");


        linkLabel.AddManipulator(new Clickable(() =>
            {
                OnLabelLinkClicked();
            }));

    }

    private void OnLabelLinkClicked()
    {
      //  orbExplorer 
    }
}
