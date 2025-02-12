using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

// ����Ʈ�� Ÿ���� �����ϱ� ���� Enum
public enum VFXPoolObjType
{
    Dust_VFX, Good_VFX
}

// �ܺ� �ν�����â���� Ŭ���� ������ ������ �� �ְ� ���ִ� [Serializable]
[Serializable]
public class VFXPoolInfo
{
    // �ν����� â���� ������ ������
    public VFXPoolObjType Type;        // ������Ʈ �̸� (Ÿ��)
    public int objAmount = 0;       // ������ Ǯ�� ������Ʈ ����
    public GameObject prefab;       // ������ Ǯ�� ������Ʈ ������
    public GameObject container;    // ������ Ǯ��������Ʈ�� ���� �����̳�
    public Stack<GameObject> vfxPoolObj = new Stack<GameObject>();
}

public class VFXObjectPool : MonoBehaviour
{
    public static VFXObjectPool instance;

    private void Awake()
    {
        instance = this;
    }

    // ��ܿ� ������ VFXPoolInfo Ŭ������ �ν�����â���� �����ϱ� ���� [SerializeField]
    // �ν�����â���� ������ ������ŭ VFXPoolInfo�� Ŭ������ ���� List�� ���� �� ��
    // == �� ����Ʈ�� �����ϴ� �ε��� �ȿ� ������ ����Ʈ�� ������ ��
    [SerializeField]
    List<VFXPoolInfo> vfxPoolList;

    private void Start()
    {
        // ������ ������Ʈ Ǯ ������ŭ �ݺ�
        for (int i = 0; i < vfxPoolList.Count; i++)
        {
            // VFXPoolInfo Ŭ������ ��Ƶ� ������ �� poolList�� ��´�.
            FillPool(vfxPoolList[i]);
        }
    }


    //! ������ Ǯ��������Ʈ�� ȣ���� �޼ҵ�
    public GameObject GetPoolObj(VFXPoolObjType type)
    {
        // GetPoolByType() �޼ҵ�� �����ϰ� type ���� VFXPoolInfo Ŭ������ ����
        VFXPoolInfo select = GetPoolByType(type);

        // �ش��ϴ� Ÿ���� ����
        Stack<GameObject> pool = select.vfxPoolObj;

        // ��Ƶ� ���ӿ�����Ʈ �ʱ�ȭ
        GameObject objInstance;

        // ȣ���ϴ� ������Ʈ ���� �����ص� ������Ʈ�� ����ϴٸ�
        if (pool.Count > 0)
        {
            // �ش� ������Ʈ�� ���ӿ�����Ʈ�� ���
            objInstance = pool.Peek();
            // Stack �޸𸮿��� ���ش�.
            pool.Pop();
        }

        // ȣ���ϴ� ������Ʈ ���� ���� �� ���� ���ٸ�
        else
        {
            // Ǯ��������Ʈ�� ���� �������ش�.
            objInstance = Instantiate(select.prefab, select.container.transform);
        }

        // ��� ������Ʈ ��ȯ
        return objInstance;
    }       // GetPoolObj()

    //! ȣ��� Ǯ��������Ʈ�� Ǯ�� �ٽ� ��ȯ�ϴ� �޼ҵ�
    public void CoolObj(GameObject obj, VFXPoolObjType type)
    {
        VFXPoolInfo select = GetPoolByType(type);
        obj.SetActive(false);
        obj.transform.position = select.container.transform.position;
        Stack<GameObject> pool = select.vfxPoolObj;

        if (pool.Contains(obj) == false)
        {
            pool.Push(obj);
        }
    }


    // VFXPoolInfo Ŭ���� ���� �� ������� Ǯ��������Ʈ ����
    private void FillPool(VFXPoolInfo VFXPoolInfo)
    {
        // VFXPoolInfo Ŭ�������� ������ objAmount ��ŭ �ݺ�
        for (int i = 0; i < VFXPoolInfo.objAmount; i++)
        {
            // Ǯ���� ������Ʈ�� ���� ���� �ʱ�ȭ
            GameObject tempObj = default;

            // �ν��Ͻ�ȭ ��Ų ������Ʈ ��Ƴֱ�
            tempObj = Instantiate(VFXPoolInfo.prefab, VFXPoolInfo.container.transform);
            VFXPoolInfo.vfxPoolObj.Push(tempObj);
            // ������ ������Ʈ ��Ȱ��ȭ, ��ġ �ʱ�ȭ, �޸� �Ҵ��ϱ�
            tempObj.SetActive(false);
            tempObj.transform.position = VFXPoolInfo.container.transform.position;
        }
    }

    //! ȣ���ϴ� ������Ʈ ������ �����ϴ� �ݺ���
    private VFXPoolInfo GetPoolByType(VFXPoolObjType type)
    {
        // ������Ʈ Ǯ ������ŭ �ݺ���
        for (int i = 0; i < vfxPoolList.Count; i++)
        {
            // ȣ���ϴ� ������Ʈ�� Ÿ�԰� ��ġ�Ѵٸ�
            if (type == vfxPoolList[i].Type)
            {
                // �ش��ϴ� ������Ʈ Ǯ�� �ε����� ��ȯ.
                return vfxPoolList[i];
            }
        }

        // ��ġ�ϴ� Ÿ���� ���ٸ� null ����
        return null;
    }

}