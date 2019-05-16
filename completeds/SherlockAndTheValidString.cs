using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorthims
{
    class Solution
    {
        static void Main(string[] args){
            var r = isValid("ibfdgaeadiaefgbhbdghhhbgdfgeiccbiehhfcggchgghadhdhagfbahhddgghbdehidbibaeaagaeeigffcebfbaieggabcfbiiedcabfihchdfabifahcbhagccbdfifhghcadfiadeeaheeddddiecaicbgigccageicehfdhdgafaddhffadigfhhcaedcedecafeacbdacgfgfeeibgaiffdehigebhhehiaahfidibccdcdagifgaihacihadecgifihbebffebdfbchbgigeccahgihbcbcaggebaaafgfedbfgagfediddghdgbgehhhifhgcedechahidcbchebheihaadbbbiaiccededchdagfhccfdefigfibifabeiaccghcegfbcghaefifbachebaacbhbfgfddeceababbacgffbagidebeadfihaefefegbghgddbbgddeehgfbhafbccidebgehifafgbghafacgfdccgifdcbbbidfifhdaibgigebigaedeaaiadegfefbhacgddhchgcbgcaeaieiegiffchbgbebgbehbbfcebciiagacaiechdigbgbghefcahgbhfibhedaeeiffebdiabcifgccdefabccdghehfibfiifdaicfedagahhdcbhbicdgibgcedieihcichadgchgbdcdagaihebbabhibcihicadgadfcihdheefbhffiageddhgahaidfdhhdbgciiaciegchiiebfbcbhaeagccfhbfhaddagnfieihghfbaggiffbbfbecgaiiidccdceadbbdfgigibgcgchafccdchgifdeieicbaididhfcfdedbhaadedfageigfdehgcdaecaebebebfcieaecfagfdieaefdiedbcadchabhebgehiidfcgahcdhcdhgchhiiheffiifeegcfdgbdeffhgeghdfhbfbifgidcafbfcd"); //aaaabbcc
            Console.WriteLine(r);
        }

        static string isValid(string s)
        {
            var dict = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            var grouped = dict.GroupBy(x => x.Value).ToList();

            if (grouped.Count() == 1)
            {
                return "YES";
            }
            else if (grouped.Count() > 2)
            {
                return "NO";
            }

            var first = grouped[0];
            var second = grouped[1];

            var firstCount = first.Count();
            var secondCount = second.Count();

            if(firstCount == secondCount){
                return Math.Abs(first.Key - second.Key) * firstCount > 1 ?"NO":"YES";
            }

            var costToRemoveFirst = (first.Key > second.Key? (first.Key - second.Key) : first.Key) * firstCount;

            var costToRemoveSecond = (second.Key > first.Key?second.Key - first.Key: second.Key) * secondCount;

            return (costToRemoveFirst>costToRemoveSecond?costToRemoveFirst:costToRemoveSecond)>1?"NO":"YES";

        }
    }
}