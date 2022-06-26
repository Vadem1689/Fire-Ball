using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBilder))]

public class Tower : MonoBehaviour
{
    private TowerBilder _towerBilder;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdate;
    
    private void Start()
    {
        _towerBilder = GetComponent<TowerBilder>();
       _blocks= _towerBilder.Build();

        
        foreach (var block in _blocks)
        {
            
            block.BulletHit += OnBulletHit;
        }
        SizeUpdate?.Invoke(_blocks.Count);
    }
    private void OnBulletHit(Block hiteBlock)
    {

        hiteBlock.BulletHit -= OnBulletHit;

        _blocks.Remove(hiteBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
        SizeUpdate?.Invoke(_blocks.Count);
    }
}
