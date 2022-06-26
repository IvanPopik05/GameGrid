using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MovementOfElements
{
    private readonly List<Element> _listCloneElements;

    public MovementOfElements(List<Element> listCloneElements) => 
        _listCloneElements = listCloneElements;

    public void MoveElements()
    {
        InitialState();
        
        for (int i = 0; i < _listCloneElements.Count; i++)
        {
            int myIndex = FindMoveIndex();
            int targetIndex = FindFreeIndex();

            if (myIndex == targetIndex)
            {
                myIndex = FindMoveIndex();
                targetIndex = FindFreeIndex();
            }

            if ((myIndex == -1 || targetIndex == -1 ))
                return;

            _listCloneElements[myIndex].SetTarget(_listCloneElements[targetIndex]);
        }
    }

    private int FindFreeIndex()
    {
        int range = Random.Range(0,_listCloneElements.Count);

        if (_listCloneElements[range].IsFree)
        {
            _listCloneElements[range].ChangeStateOfFree(false);
            return range;
        }

        range = _listCloneElements.FindIndex(x => x.IsFree == true);
        if (range == -1)
            return -1;
        
        _listCloneElements[range].ChangeStateOfFree(false);
        return range;
    }

    private int FindMoveIndex()
    {
        int range = Random.Range(0,_listCloneElements.Count);

        if (_listCloneElements[range].IsMove)
        {
            _listCloneElements[range].ChangeStateOfMove(false);
            return range;
        }

        range = _listCloneElements.FindIndex(x => x.IsMove == true);
        if (range == -1)
            return -1;
        
        _listCloneElements[range].ChangeStateOfMove(false);
        return range;
    }

    private void InitialState()
    {
        for (int i = 0; i < _listCloneElements.Count; i++)
        {
            _listCloneElements[i].ChangeStateOfFree(true);
            _listCloneElements[i].ChangeStateOfMove(true);
        }
    }
}