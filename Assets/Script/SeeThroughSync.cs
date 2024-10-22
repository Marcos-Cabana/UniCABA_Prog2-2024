using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughSync : MonoBehaviour
{
 
  [SerializeField] Material _wallMaterial;
  [SerializeField] Camera _camera;
  [SerializeField] LayerMask _layerMask;

    Vector3 _dir;
    RaycastHit[] _rayCasts;

    private Vector2 _cutoutPos;
    private Vector3 _offset;
    private Material[] _materials;

    // Update is called once per frame
    void Update()
    {
        _cutoutPos = _camera.WorldToViewportPoint(transform.position);
        _cutoutPos.y /= (Screen.width / Screen.height);
        
        
        _rayCasts = Physics.RaycastAll(transform.position, _cutoutPos.normalized, 100,_layerMask);

        for(int i = 0; i < _rayCasts.Length; i++)
        {
            _materials = _rayCasts[i].transform.GetComponent<Renderer>().materials;

            for(int j = 0; j < _materials.Length; j++)
            {
                _materials[j].SetVector("_PlayerPosition",_cutoutPos);
                _materials[j].SetFloat("_Size",0.01f);
            }
        }
    }
}
