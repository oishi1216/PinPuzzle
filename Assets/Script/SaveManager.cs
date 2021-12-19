using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int clearStage;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    //�V���O���g����
    void Awake()
    {
        //instance�ɉ��������ĂȂ���΁ASaveManager������B���łɓ����Ă���ꍇ�͐V�����쐬����instance���폜
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //SaveManager���V�[���ׂ��Ŕj�󂵂Ȃ�
        DontDestroyOnLoad(gameObject);
    }

    //JSON�t�@�C����ۑ�����ꏊ�����߁A�����Ŏ擾�����l��JSON�t�@�C���ŕۑ�����
    public void Save(SaveData saveData)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(saveData);

        writer = new StreamWriter(Application.persistentDataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public SaveData Load()
    {
        //�Z�[�u�f�[�^���������ꍇ
        if (File.Exists(Application.persistentDataPath + "/savedata.json"))
        {
            //�udatastr�v�ɃZ�[�u�f�[�^����ǂݍ��񂾒l�����ASaveData�`���ł��̒l��Ԃ�
            string datastr = "";
            StreamReader reader;
            reader = new StreamReader(Application.persistentDataPath + "/savedata.json");
            datastr = reader.ReadToEnd();
            reader.Close();

            return JsonUtility.FromJson<SaveData>(datastr);
        }
        //�Z�[�u�f�[�^�����������ꍇ�ASaveData�`����0��Ԃ�
        SaveData saveData = new SaveData();
        saveData.clearStage = 0;

        return saveData;
    }

    public void LoadStage()
    {
        //�usaveData�v��Load�֐��œǂݍ��񂾒l���i�[
        SaveData saveData = Load();

        //�uclearStage�v��0�ł�������ustageNumber�v��1�𑫂��A�����łȂ�������A���̒l���ustageNumber�v�ɑ������
        if (saveData.clearStage == 0)
        {
            GameManager.instance.stageNumber++;
        }
        else
        {
            GameManager.instance.stageNumber = saveData.clearStage;
        }
    }

    //���݂̃X�e�[�W�����uclearStage�v�ɑ�����āA���̒l�������ɂ���Save�֐����Ăяo��
    public void SaveStage(int stageNumber)
    {
        SaveData saveData = new SaveData();
        saveData.clearStage = stageNumber;
        Save(saveData);
    }
}
