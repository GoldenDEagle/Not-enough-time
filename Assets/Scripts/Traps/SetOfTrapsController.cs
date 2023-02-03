using Assets.Scripts.Traps;
using System.Collections;
using UnityEngine;

public class SetOfTrapsController : MonoBehaviour
{
    [SerializeField] private bool _trapsOnline = true;
    [SerializeField] private int _numOfTrapsWorkingTogether;
    [SerializeField] private float _activationInterval;
    [SerializeField] private FogTrap[] _traps;

    private int _currentGroupIndex;
    private Coroutine _coroutine;

    private void Start()
    {
        _currentGroupIndex = 0;
        _coroutine = StartCoroutine(TrapsWorking());
    }

    private IEnumerator TrapsWorking()
    {
        while (_trapsOnline)
        {
            for (int i = _currentGroupIndex; i < _currentGroupIndex + _numOfTrapsWorkingTogether; i++)
            {
                _traps[i].EnableTrap();
            }
            yield return new WaitForSeconds(_activationInterval);
            for (int j = _currentGroupIndex; j < _currentGroupIndex + _numOfTrapsWorkingTogether; j++)
            {
                _traps[j].DisableTrap();
            }

            _currentGroupIndex += _numOfTrapsWorkingTogether;
            if (_currentGroupIndex >= _traps.Length)
                _currentGroupIndex = 0;
        }
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
