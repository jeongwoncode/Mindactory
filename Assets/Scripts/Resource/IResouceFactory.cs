using UnityEngine;

public interface IResourceFactory
{
    GameObject CreateResource(ResourceData resourceData, Vector3 position);
}
