using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QuestionDatabase : MonoBehaviour
{
    [SerializeField] private string fileName = "txtCoupleQuestions.txt";
    private List<string> questions = new List<string>();
    private List<int> unusedIndices = new List<int>();

    private void Awake()
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

        if (!File.Exists(path))
        {
            Debug.LogError($"Question file not found at: {path}");
            return;
        }

        foreach (string line in File.ReadAllLines(path))
        {
            string trimmed = line.Trim();
            if (!string.IsNullOrEmpty(trimmed))
                questions.Add(trimmed);
        }

        ResetPool();
        Debug.Log($"Loaded {questions.Count} questions.");
    }

    public string GetRandomQuestion()
    {
        if (questions.Count == 0) return "No questions loaded.";
        if (unusedIndices.Count == 0) ResetPool();

        int randomSlot = Random.Range(0, unusedIndices.Count);
        int questionIndex = unusedIndices[randomSlot];
        unusedIndices.RemoveAt(randomSlot);

        return questions[questionIndex];
    }

    private void ResetPool()
    {
        unusedIndices.Clear();
        for (int i = 0; i < questions.Count; i++)
            unusedIndices.Add(i);
    }
}