using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using UnityEngine;

public class JsonValidator : MonoBehaviour
{
    public TextAsset jsonSchemaFile;  // JSON 스키마 파일을 Unity 에디터에서 할당

    void Start()
    {
        // Resources 폴더에서 JSON 데이터 파일 로드
        TextAsset jsonFile = Resources.Load<TextAsset>("GameSettings");

        if (jsonFile == null)
        {
            Debug.LogError("GameSettings.json 파일을 찾을 수 없습니다.");
            return;
        }

        // JSON 데이터 파싱
        JObject jsonData = JObject.Parse(jsonFile.text);

        // JSON 스키마 파싱
        JSchema schema = JSchema.Parse(jsonSchemaFile.text);

        // JSON 데이터 검증
        IList<string> errorMessages;
        bool isValid = jsonData.IsValid(schema, out errorMessages);

        // 검증 결과 출력
        if (isValid)
        {
            Debug.Log("JSON 데이터가 유효합니다.");
        }
        else
        {
            Debug.LogError("JSON 데이터가 유효하지 않습니다:");
            foreach (string error in errorMessages)
            {
                Debug.LogError(error);
            }
        }
    }
}
