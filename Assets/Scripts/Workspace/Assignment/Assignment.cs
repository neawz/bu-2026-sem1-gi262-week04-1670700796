using UnityEngine;
using System.Collections.Generic;
using System;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string, int> wordDict = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (wordDict.ContainsKey(words[i]))
                {
                    wordDict[words[i]]++;
                }
                else
                {
                    wordDict[words[i]] = 1;
                }
            }

            foreach (KeyValuePair<string, int> kvp in wordDict)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                Debug.Log($"word: '{key}' count = {value}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int, int> numberDict = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numberDict.ContainsKey(numbers[i]))
                {
                    numberDict[numbers[i]]++;
                }
                else
                {
                    numberDict[numbers[i]] = 1;
                }
            }

            foreach (var num in numberDict)
            {
                Debug.Log($"number: {num.Key} count: {num.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> brackets = new Dictionary<char, char>();
            brackets.Add('(', ')');
            LinkedList<char> stack = new LinkedList<char>();

            foreach (var letter in input)
            {
                if (letter == '(')
                {
                    stack.AddLast(letter);
                }
                else if (letter == ')')
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                    else if (brackets.ContainsKey(stack.Last.Value))
                    {
                        stack.RemoveLast();
                    }
                    else
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                }
            }

            Debug.Log(stack.Count == 0 ? "Valid" : "Invalid");
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            
            if (list.Count == 0)
            {
                Debug.Log("List is invalid");
                return;
            }

            var current = list.Last;

            while (current != null)
            {
                Debug.Log(current.Value);

                var next = current.Previous;
                current = next;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();

            if (list.Count == 0)
            {
                Debug.Log("List is Empty");
                return;
            }

            var slow = list.First;
            var fast = list.First;
            
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            
            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

            foreach (var entry in dict2)
            {
                if (mergedDictionary.ContainsKey(entry.Key))
                {
                    mergedDictionary[entry.Key] += entry.Value;
                }
                else
                {
                    mergedDictionary.Add(entry.Key, entry.Value);
                }
            }

            foreach (var entry in mergedDictionary)
            {
                Debug.Log($"key: {entry.Key}, value: {entry.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            Dictionary<int, bool> keepDict = new Dictionary<int, bool>();
            var current = list.First;

            while (current != null)
            {
                var next = current.Next;
                if (keepDict.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    keepDict.Add(current.Value, true);
                }

                current = next;
            }

            foreach (var entry in keepDict)
            {
                Debug.Log(entry.Key);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            Dictionary<int, int> numDict = new Dictionary<int, int>();

            if (numbers == null)
            {
                Debug.Log("Input array is empty");
                return;
            }

            foreach (var number in numbers)
            {
                if (numDict.ContainsKey(number))
                {
                    numDict[number]++;
                }
                else
                {
                    numDict[number] = 1;
                }
            }

            var highestCount = numDict[numbers[0]];
            var highestNumber = numbers[0];
            
            foreach (var number in numbers)
            {
                var count = numDict[number];

                if (count > highestCount)
                {
                    highestCount = count;
                    highestNumber = number;
                }
            }

            Debug.Log($"{highestNumber} count: {highestCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
            
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory[itemName] = quantity;
            }

            foreach (var item in inventory)
            {
                Debug.Log($"'{item.Key}: '{item.Value}'");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            
            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                var current = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                Debug.Log("Processing event: " + current.Name);
                Debug.Log("Remaining events in queue: " + eventQueue.Count);
                Debug.Log($"{current.EventType} event processed - {current.Name}");
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            
            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats[statName] = value;
            }
            
            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");

            foreach (var stat in playerStats)
            {
                Debug.Log($"{stat.Key}: {stat.Value}");
            }
        }

        #endregion
    }
}
