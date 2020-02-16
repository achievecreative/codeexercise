
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Program
    {
        static int[] findIndex(string a, string b){
            
            var index = a.IndexOf(b);
            if(index<0){
                return null;
            }

            var indexes = new List<int>(){index};

            //找出所有可能的位置，因为有可能存在相同的字符，所以必须逐个比对
            do{
                index++;

               var _index = a.IndexOf(b, index);
                
                if(_index>=0){
                    indexes.Add(index);
                }

            }while(index<=(a.Length - b.Length));

            return indexes.ToArray();
        }

        static string gridSearch(string[] G, string[] P)
        {
            if (G == null || P == null)
            {
                return "NO";
            }

            if (G.Length < P.Length)
            {
                return "NO";
            }

            var index = 0;
            do
            {
                IEnumerable<int> availableIndexes = findIndex(G[index], P[0]);
                if(availableIndexes == null){
                    index++;
                    continue;
                }

                var found = true;
                for(var j = 1; j<P.Length; j++){
                    var indexes = findIndex(G[index+j], P[j]);
                    if(indexes == null){
                        found = false;
                        break;
                    }

                    availableIndexes = indexes.Intersect(availableIndexes).ToArray();
                    if(!availableIndexes.Any()){
                        found = false;
                        break;
                    }
                }

                if(found){
                    return "YES";
                }

                index++;
                
            } while (index <= (G.Length - P.Length));

            return "NO";
        }

        static void Main(string[] args){
            var G = new []{"123412","561212","123634","781288"};
            var P = new []{"12","34"};

            var r = gridSearch(G, P);

            Console.WriteLine(r);

            G = new string[]{"7283455864","6731158619","8988242643","3830589324","2229505813","5633845374","6473530293","7053106601","0834282956","4607924137"};
            P = new string[]{"9505","3845","3530"};

            r = gridSearch(G,P);
            Console.WriteLine(r);
        }
    }
}