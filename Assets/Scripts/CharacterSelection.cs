using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    #region "Refrences"
    private int selectedCharacterIndex;
    private int selectedCharacterIndex2;
    private int selectedStageIndex;

    [Header("UI Refrences")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterIcon;
    [SerializeField] private TextMeshProUGUI characterName2;
    [SerializeField] private Image characterIcon2;
    [SerializeField] private TextMeshProUGUI stageName;
    [SerializeField] private Image stageIcon;

    [Header("Options")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();
    [SerializeField] private List<CharacterSelectObject> characterList2 = new List<CharacterSelectObject>();
    [SerializeField] private List<StageSelectObject> stageList = new List<StageSelectObject>();

    #endregion

    #region "Methods"
    private void Start()
    {
        //characterList = characterList2;
        UpdateCharacterSelectionUI();
    }

    private void UpdateCharacterSelectionUI()
    {
        characterIcon.sprite = characterList[selectedCharacterIndex].characterSprite;
        characterIcon2.sprite = characterList2[selectedCharacterIndex2].characterSprite;
        stageIcon.sprite = stageList[selectedStageIndex].stageSprite;
        characterName.text = characterList[selectedCharacterIndex].characterColor;
        characterName2.text = characterList2[selectedCharacterIndex2].characterColor;
        stageName.text = stageList[selectedStageIndex].stageTitle;
        
    }

    public void LeftArrow(int player)
    {
        if (player == 1)
        {
            selectedCharacterIndex--;
            if (selectedCharacterIndex < 0)
            {
                selectedCharacterIndex = characterList.Count - 1;
            }
        }
        if (player == 2)
        {
            selectedCharacterIndex2--;
            if (selectedCharacterIndex2 < 0)
            {
                selectedCharacterIndex2 = characterList2.Count - 1;
            }
        }
        if (player == 3)
        {
            selectedStageIndex--;
            if (selectedStageIndex < 0)
            {
                selectedStageIndex = stageList.Count - 1;
            }
        }
        UpdateCharacterSelectionUI();
    }
    public void RightArrow(int player)
    {
        if (player == 1)
        {
            selectedCharacterIndex++;
            if (selectedCharacterIndex == characterList.Count)
            {
                selectedCharacterIndex = 0;
            }
        }
        if (player == 2)
        {
            selectedCharacterIndex2++;
            if (selectedCharacterIndex2 == characterList2.Count)
            {
                selectedCharacterIndex2 = 0;
            }
        }
        if (player == 3)
        {
            selectedStageIndex++;
            if (selectedStageIndex == stageList.Count)
            {
                selectedStageIndex = 0;
            }
        }
        UpdateCharacterSelectionUI();
    }

    public void Confirm()
    {
        PlayerPrefs.SetString("Player1", characterList[selectedCharacterIndex].characterColor);
        PlayerPrefs.SetString("Player2", characterList2[selectedCharacterIndex2].characterColor);
        SceneManager.LoadScene(stageList[selectedStageIndex].stageTitle);
    }
    #endregion

    #region "Classes"
    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite characterSprite;
        public string characterColor;
    }
    [System.Serializable]
    public class StageSelectObject
    {
        public Sprite stageSprite;
        public string stageTitle;
    }
    #endregion

}
