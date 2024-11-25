using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SetMaterials : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdv

    public string addressableKey;
    SpriteRenderer[] temp;
    private void Awake()
    {
        Addressables.LoadAssetAsync<Material>(addressableKey).Completed += OnResourceLoaded;
        temp = GetComponentsInChildren<SpriteRenderer>();


    }
    void Start()
    {
        
    }
    private void OnResourceLoaded(AsyncOperationHandle<Material> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            // 로드된 오브젝트를 인스턴스화
            foreach(SpriteRenderer t in temp)
            {
                t.material = obj.Result;
            }
        }
        else
        {
            Debug.LogError("Failed to load Addressable: " + addressableKey);
        }
    }

}
