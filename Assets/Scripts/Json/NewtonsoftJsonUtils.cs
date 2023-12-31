using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public static class NewtonsoftJsonUtils
{
    // JSON化の設定
    // 参考 https://qiita.com/matchyy/items/b1cd6f3a2a93749774da#tldr
    public static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };

    public static readonly JsonSerializer SERIALIZER = JsonSerializer.CreateDefault(JSON_SETTINGS);

    public static string GetCurrentDirectory()
    {
        // 開発中は C:/Users/%USERNAME%/AppData/LocalLow/DefaultCompany/プロジェクト名
        return Application.persistentDataPath;
    }
    

    /// <summary>
    /// Jsonファイルを保存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filename">ファイル名</param>
    /// <param name="json"></param>
    /// /// <param name="directory">ディレクトリ（空の場合はApplication.persistentDataPathになる）</param>
    public static void SaveJson<T>(T json, string filename, string directory = "")
    {
        // ディレクトリの指定がない場合はカレント
        if (string.IsNullOrEmpty(directory)) {
            directory = GetCurrentDirectory();
        }

        // 参考
        // https://www.newtonsoft.com/json/help/html/SerializeWithJsonSerializerToFile.htm
        using (StreamWriter file = File.CreateText(Path.Combine(directory, filename)))
        {
            SERIALIZER.Serialize(file, json);
        }
    }

    /// <summary>
    /// Jsonファイルを読み込み
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filename"></param>
    /// <param name="directory">ディレクトリ（空の場合はApplication.persistentDataPathになる）</param>
    /// <returns></returns>
    public static T LoadJson<T>(string filename, string directory = "")
    {
        // ディレクトリの指定がない場合はカレント
        if (string.IsNullOrEmpty(directory)) {
            directory = GetCurrentDirectory();
        }

        using (StreamReader file = File.OpenText(Path.Combine(directory, filename)))
        {
            // なぜかジェネリックのメソッドが用意されてない
            return (T)SERIALIZER.Deserialize(file, typeof(T));
        }
    }
}
