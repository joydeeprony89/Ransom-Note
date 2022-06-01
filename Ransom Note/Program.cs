using System;
using System.Collections.Generic;
using System.Linq;

namespace Ransom_Note
{
  class Program
  {
    static void Main(string[] args)
    {
      string ransomNote = "aa"; string magazine = "ab";
      Solution s = new Solution();
      s.CanConstruct(ransomNote, magazine);
    }
  }

  public class Solution
  {
    public bool CanConstruct(string ransomNote, string magazine)
    {
      // create the freency DS for each char in the magazine
      Dictionary<char, int> fre = new Dictionary<char, int>();
      // O(n) - s is the length of magazine
      foreach (char c in magazine)
      {
        if (!fre.ContainsKey(c))
        {
          fre.Add(c, 0);
        }
        fre[c] += 1;
      }

      // O(m) - m is the length of ransomNote
      foreach (char c in ransomNote)
      {
        if (fre.ContainsKey(c))
        {
          // if found then decrement the frequency count by 1 to mark it as used
          fre[c] -= 1;
          if (fre[c] < 0) return false; // if thr frequency count went below 0 for any char, then we can not construct the ransomNote from magazine available chars
        }
        else return false; // if the char is not present in the magazine we can not ever able to creta the note from magazine value do return false
      }

      return true;
    }
  }
}
