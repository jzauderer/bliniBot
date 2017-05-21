using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blinibot
{
    class word
    {
        Random rand;

        //The actual text of the word
        string _text;

        //List of all the words that can follow
        List<string> _following = new List<string>();
        
        //Constructor taking only text
        public word(string text)
        {
            rand = new Random();
            _text = text;
        }

        //Constructor taking text as well as a word following
        public word(string text, string following)
        {
            rand = new Random();
            _text = text;
            _following.Add(following);
        }

        //Adds a string to list of words that can follow
        public void addFollowing(string following)
        {
            _following.Add(following);
        }
        
        //Returns a random word that can follow
        public string getRandomFollowing()
        {
            if(isFollowingEmpty())
            {
                return null;
            }
            else
            {
                return _following[rand.Next(_following.Count)];
            }
        }

        //Returns the text of the word
        public string getText()
        {
            return _text;
        }

        //Returns the list of following words
        public List<String> getFollowingWords()
        {
            return _following;
        }

        //Returns true if the List _following is empty. True otherwise
        public bool isFollowingEmpty()
        {
            if (_following.Count == 0)
                return true;
            else
                return false;
        }
    }
}
