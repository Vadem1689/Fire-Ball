using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _bloak;
    [SerializeField] private Color[] _colors;

    private List<Block> _blocks;

    //private void Start()
    //{
    //    Build();
    //}

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _buildPoint;
        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;

        }
        return _blocks;
    }
    private  Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_bloak, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }
    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / 2 + _bloak.transform.localScale.y / 2, _buildPoint.position.z);
    }
}
