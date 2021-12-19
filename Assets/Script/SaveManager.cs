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

    //シングルトン化
    void Awake()
    {
        //instanceに何も入ってなければ、SaveManagerを入れる。すでに入っている場合は新しく作成したinstanceを削除
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //SaveManagerをシーン跨ぎで破壊しない
        DontDestroyOnLoad(gameObject);
    }

    //JSONファイルを保存する場所を決め、引数で取得した値をJSONファイルで保存する
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
        //セーブデータがあった場合
        if (File.Exists(Application.persistentDataPath + "/savedata.json"))
        {
            //「datastr」にセーブデータから読み込んだ値を入れ、SaveData形式でその値を返す
            string datastr = "";
            StreamReader reader;
            reader = new StreamReader(Application.persistentDataPath + "/savedata.json");
            datastr = reader.ReadToEnd();
            reader.Close();

            return JsonUtility.FromJson<SaveData>(datastr);
        }
        //セーブデータが無かった場合、SaveData形式で0を返す
        SaveData saveData = new SaveData();
        saveData.clearStage = 0;

        return saveData;
    }

    public void LoadStage()
    {
        //「saveData」にLoad関数で読み込んだ値を格納
        SaveData saveData = Load();

        //「clearStage」が0であったら「stageNumber」に1を足し、そうでなかったら、その値を「stageNumber」に代入する
        if (saveData.clearStage == 0)
        {
            GameManager.instance.stageNumber++;
        }
        else
        {
            GameManager.instance.stageNumber = saveData.clearStage;
        }
    }

    //現在のステージ数を「clearStage」に代入して、その値を引数にしてSave関数を呼び出す
    public void SaveStage(int stageNumber)
    {
        SaveData saveData = new SaveData();
        saveData.clearStage = stageNumber;
        Save(saveData);
    }
}
