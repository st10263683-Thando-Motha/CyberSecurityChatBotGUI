/*
 * ChatBot Logic Class
 * Handles keyword recognition, memory, sentiment, and responses.
 *
 * Code Attribution:
 * - Microsoft Learn (C# collections, Dictionary, List usage)
 * - GeeksforGeeks (chatbot logic structure ideas)
 * - OpenAI ChatGPT used for structuring logic and debugging assistance
 *
 * All implementation is original and adapted for assignment requirements.
 */


using System;
using System.Collections.Generic;

public class ChatBot
{
    private string userName;
    private string favouriteTopic;
    private Random random = new Random();

    private Dictionary<string, List<string>> responses;

    public ChatBot()
    {
        responses = new Dictionary<string, List<string>>();

        responses["password"] = new List<string>
        {
            "Use strong passwords with numbers, symbols, and letters.",
            "Never reuse the same password across accounts.",
            "Enable two-factor authentication for better security."
        };

        responses["phishing"] = new List<string>
        {
            "Be careful of emails asking for personal information.",
            "Always check the sender before clicking links.",
            "Avoid downloading unknown attachments."
        };

        responses["privacy"] = new List<string>
        {
            "Review your privacy settings regularly.",
            "Limit personal information shared online.",
            "Be cautious with app permissions."
        };
    }

    // MEMORY
    public void SetUserName(string name)
    {
        userName = name;
    }

    public void SetFavouriteTopic(string topic)
    {
        favouriteTopic = topic;
    }

    // MAIN RESPONSE LOGIC
    public string GetResponse(string input)
    {
        input = input.ToLower();

        // GREETING
        if (input.Contains("hello"))
            return $"Hello {userName}! How can I help you today?";

        // MEMORY RECALL
        if (input.Contains("my name"))
            return $"Your name is {userName}.";

        if (input.Contains("favourite") || input.Contains("favorite"))
            return $"You are interested in {favouriteTopic}.";

        // SENTIMENT DETECTION
        if (input.Contains("worried"))
            return "It's okay to feel worried. I’ll help you stay safe online.";

        if (input.Contains("frustrated"))
            return "I understand. Cybersecurity can be confusing sometimes.";

        if (input.Contains("curious"))
            return "Great! Ask me anything about cybersecurity.";

        // CONVERSATION FLOW
        if (input.Contains("tell me more") || input.Contains("explain"))
            return "Sure! Ask me about passwords, phishing, or privacy.";

        // KEYWORD RECOGNITION + RANDOM RESPONSES
        foreach (var key in responses.Keys)
        {
            if (input.Contains(key))
            {
                var list = responses[key];
                return list[random.Next(list.Count)];
            }
        }

        // DEFAULT RESPONSE
        return "I didn’t understand that. Try asking about passwords, phishing, or privacy.";
    }
}