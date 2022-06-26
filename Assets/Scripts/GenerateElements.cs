using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateElements : MonoBehaviour
{
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField _widthField;
    [SerializeField] private TMP_InputField _heightField;
    [Header("Buttons")]
    [SerializeField] private Button _generateBtn;
    [SerializeField] private Button _mixBtn;
    [Header("Additional Elements")]
    [SerializeField] private Element _prefabElement;
    [SerializeField] private GridLayoutGroup _grid;
    [SerializeField] private Transform _cloneContainer;
    [SerializeField] private float _timeMotion = 2f;
    
    private int _width;
    private int _height;
    private RectTransform _rect;
    private IGameFactory _gameFactory;
    private MovementOfElements _movementOfElements;

    private bool _isMixClick;
    
    private readonly List<Element> _listElements = new List<Element>();
    private readonly List<Element> _listCloneElements = new List<Element>();
    public void Initialize(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;
        _rect = GetComponent<RectTransform>();
        _movementOfElements = new MovementOfElements(_listCloneElements);
        
        _generateBtn.onClick.AddListener(() => Generate(_width,_height));
        _mixBtn.onClick.AddListener(() =>
        {
            if (!_isMixClick)
            {
                MixElements();
                StartCoroutine(CoroutineTimer(_timeMotion));
            }
        });
    }

    private void Generate(int width, int height)
    {
        if(String.IsNullOrEmpty(_widthField.text) || String.IsNullOrEmpty(_heightField.text))
            return;
        
        _grid.cellSize = new Vector2(_rect.rect.width, _rect.rect.height);
        
        ElementsCleaning(_listElements);
        if(_listCloneElements.Count > 0)
            ElementsCleaning(_listCloneElements);
        
        width = int.Parse(_widthField.text);
        height = int.Parse(_heightField.text);
        
        _grid.cellSize = new Vector2(_rect.rect.width / width, _rect.rect.height / height);

        CreateElements(width, height);
    }

    private void CreateElements(int width, int height)
    {
        int result = width * height;
        for (int x = 0; x < result; x++) 
            Create();
    }

    private void Create()
    {
        GameObject obj = _gameFactory.CreateElement(_prefabElement.gameObject, transform);
        Element newElement = obj.GetComponent<Element>();
        newElement.Initialize(_timeMotion);
        newElement.ChangeText();
        
        _listElements.Add(newElement);
    }

    private void MixElements()
    {
        if (_listElements.Count != _listCloneElements.Count)
        {
            ElementsCleaning(_listCloneElements);
            for (int i = 0; i < _listElements.Count; i++)
            {
                Element newClone = Instantiate(_listElements[i], _listElements[i].transform.position, Quaternion.identity,_cloneContainer);
                newClone.Initialize(_timeMotion);
                newClone.GetTextMeshPro().fontSize = _listElements[i].GetTextMeshPro().fontSize;
                newClone.GetTextMeshPro().enableAutoSizing = false;
                _listCloneElements.Add(newClone);
            }
        }

        _movementOfElements.MoveElements();
        IsActivateElements(false);
        _isMixClick = true;
    }

    private void IsActivateElements(bool isActive)
    {
        for (int i = 0; i < _listElements.Count; i++) 
            _listElements[i].gameObject.SetActive(isActive);
    }

    private void ElementsCleaning(List<Element> texts)
    {
        for (int i = 0; i < texts.Count; i++) 
            Destroy(texts[i].gameObject);

        texts.Clear();
    }

    private IEnumerator CoroutineTimer(float time)
    {
        yield return new WaitForSeconds(time);
        _isMixClick = false;
    }
}