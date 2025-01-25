using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OrbExplorer : MonoBehaviour
{

    private VisualElement site01;
    private const string site01Address = "site01address";
    private VisualElement site02;
    private const string site02Address = "site02address";
    private VisualElement site03;
    private const string site03Address = "site03address";

    private TextField addressBar;

    private Button goToAddressButton;
    private Button goBackButton;
    private Button goForwardButton;

    private Stack<VisualElement> goBackStack = new();
    private Stack<VisualElement> goForwardStack = new();

    private VisualElement currentSite;

    private Dictionary<VisualElement, string> siteAddressPairs = new();
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        site01 = root.Q<VisualElement>("Site01");
        site02 = root.Q<VisualElement>("Site02");
        site03 = root.Q<VisualElement>("Site03");

        addressBar = root.Q<TextField>("AddressText");
        goToAddressButton = root.Q<Button>("AddressGoButton");
        goBackButton = root.Q<Button>("BackButton");
        goForwardButton = root.Q<Button>("ForwardButton");

        goToAddressButton.RegisterCallback<ClickEvent>(GoToAddressButton);
        goBackButton.RegisterCallback<ClickEvent>(GoBackButton);
        goForwardButton.RegisterCallback<ClickEvent>(GoForwardButton);

        siteAddressPairs.Add(site01, site01Address);
        siteAddressPairs.Add(site02, site02Address);
        siteAddressPairs.Add(site03, site03Address);

        currentSite = site01;
        goForwardButton.style.opacity = 0.3f;

    }

    private void GoToAddressButton(ClickEvent clickEvent)
    {
        switch (addressBar.value.ToString().ToLower())
        {
            case site01Address:
                AddSiteToStack(site01);
                OpenSite(site01);
                break;
            case site02Address:
                AddSiteToStack(site02);
                OpenSite(site02);
                break;
            case site03Address:
                AddSiteToStack(site03);
                OpenSite(site03);
                break;
            default:
                Debug.Log("404, given address: " + addressBar.value.ToString().ToLower());
                break;
        }
    }

    private void AddSiteToStack(VisualElement site)
    {
        goBackStack.Push(currentSite);
        if (goForwardStack.Count > 0)
        {
            goForwardStack.Clear();
            goForwardButton.style.opacity = 0.3f;
        }
    }

    private void OpenSite(VisualElement site)
    {
        currentSite.style.display = DisplayStyle.None;
        currentSite = site;
        site.style.display = DisplayStyle.Flex;

        addressBar.value = siteAddressPairs[site];
    }

    private void GoBackButton(ClickEvent clickEvent)
    {
        Debug.Log("Going back");
        var nextSite = goBackStack.Pop();
        goForwardStack.Push(currentSite);
        goForwardButton.style.opacity = 1f;


        OpenSite(nextSite);
    }

    private void GoForwardButton(ClickEvent clickEvent)
    {
        Debug.Log("Going ahead");

        var nextSite = goForwardStack.Pop();
        goBackStack.Push(currentSite);

        if (goForwardStack.Count == 0)
        {
            goForwardButton.style.opacity = 0.3f;
        }

        OpenSite(nextSite);
    }

}
