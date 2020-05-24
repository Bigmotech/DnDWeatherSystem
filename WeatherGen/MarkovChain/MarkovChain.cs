using System;
using System.Collections.Generic;
using System.Linq;
using WeatherGen.MarkovChain;

namespace WeatherGen
{
    /// <summary>
    /// Markov Chain
    /// </summary>
    /// <typeparam name="TKey">State</typeparam>
    /// <typeparam name="TInnerKey">Following State</typeparam>
    public class MarkovChain<TKey, TInnerKey>
    {
        Dictionary<TKey, MarkovInnerChain<TInnerKey, TItem<TInnerKey>>> Markov = new Dictionary<TKey, MarkovInnerChain<TInnerKey, TItem<TInnerKey>>>();
        
        

        public MarkovChain()
        {

        }
        
        public void Add(TKey item, TInnerKey chainItem)
        {
            MarkovInnerChain<TInnerKey, TItem<TInnerKey>> newerWorditem;




            if (Markov.TryGetValue(item, out MarkovInnerChain<TInnerKey, TItem<TInnerKey>> newWorditem))
            {
                TItem<TInnerKey> wordItem = new TItem<TInnerKey>();
                newWorditem.PropertyChanged += NewWorditem_PropertyChanged1;
                if (newWorditem.TryGetValue(chainItem, out wordItem))
                {
                    wordItem.Count++;
                    newWorditem.Total = newWorditem.Total + 1;
                    
                    
                    newWorditem[chainItem] = wordItem;
                }
                else
                {
                    TItem<TInnerKey> word = new TItem<TInnerKey>
                    {
                        Name = chainItem
                    };
                    newWorditem.Total = newWorditem.Total + 1;
                    newWorditem.Add(chainItem, word);
                }
                Markov[item] = newWorditem;
            }
            else
            {

                newerWorditem = new MarkovInnerChain<TInnerKey, TItem<TInnerKey>>();
                newerWorditem.PropertyChanged += NewWorditem_PropertyChanged1;
                TItem<TInnerKey> newerwordItem = new TItem<TInnerKey>
                {
                    Name = chainItem
                };
                newerWorditem[chainItem] = newerwordItem;
                newerWorditem.Total = newerWorditem.Total + 1;
                Markov[item] = newerWorditem;
            }
        }



        private void NewWorditem_PropertyChanged1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            foreach (KeyValuePair<TKey, MarkovInnerChain<TInnerKey, TItem<TInnerKey>>> keyValuePair in Markov)
            {
                foreach (KeyValuePair<TInnerKey, TItem<TInnerKey>> keyValue in keyValuePair.Value)
                {

                    keyValue.Value.Probability = Math.Round(keyValue.Value.Count / keyValuePair.Value.Total, 5);       
                }
            }
        }

        public System.Windows.Forms.TreeView ToTreeView()
        {
            System.Windows.Forms.TreeView tree = new System.Windows.Forms.TreeView();
            foreach(KeyValuePair<TKey, MarkovInnerChain<TInnerKey, TItem<TInnerKey>>> keyValuePair in Markov)
            {
                List<System.Windows.Forms.TreeNode> treeNodes = new List<System.Windows.Forms.TreeNode>();
                System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode(keyValuePair.Key.ToString());
                foreach(KeyValuePair<TInnerKey,TItem<TInnerKey>> keyValue in keyValuePair.Value)
                {
                    System.Windows.Forms.TreeNode innernode = new System.Windows.Forms.TreeNode(keyValue.Key.ToString());
                    System.Windows.Forms.TreeNode datanode = new System.Windows.Forms.TreeNode(keyValue.Value.ToString());
                    innernode.Nodes.Add(datanode);
                    treeNodes.Add(innernode);
                }
                node.Nodes.AddRange(treeNodes.ToArray<System.Windows.Forms.TreeNode>());
                tree.Nodes.Add(node);
            }
            


            return tree;
        }

        public bool TryGetProbability(TKey KeyState, TInnerKey ValueState, out double? probability)
        {
            MarkovInnerChain<TInnerKey, TItem<TInnerKey>> outInnerChain = new MarkovInnerChain<TInnerKey, TItem<TInnerKey>>();
            TItem<TInnerKey> outItem = new TItem<TInnerKey>();

            if (Markov.TryGetValue(KeyState, out outInnerChain))
            {
                if(outInnerChain.TryGetValue(ValueState, out outItem))
                {
                    probability = outItem.Probability;
                    return true;
                }
                probability = null;
                return false;
            }
            probability = null;
            return false;
        }
        public bool TryGetStateAggragateProbabilities(TKey KeyState, out TItem<TInnerKey>[] probability)
        {
            MarkovInnerChain<TInnerKey, TItem<TInnerKey>> outInnerChain = new MarkovInnerChain<TInnerKey, TItem<TInnerKey>>();
            List<TItem<TInnerKey>> items = new List<TItem<TInnerKey>>();
            if (Markov.TryGetValue(KeyState, out outInnerChain))
            {
                
                foreach(KeyValuePair<TInnerKey, TItem<TInnerKey>> w in outInnerChain)
                {
                    items.Add(w.Value);
                }
                probability = items.ToArray<TItem<TInnerKey>>();
                
                return true;
            }
            probability = null;
            return false;
        }
        public void ClearMarkov()
        {
            Markov.Clear();
        }
        /// <summary>
        /// Add a range of innereys for a single Outer Key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="innerKeys"></param>
        public void AddRange(TKey key, TInnerKey[] innerKeys)
        {
            foreach(TInnerKey inner in innerKeys)
            {
                Add(key, inner);
            }
        }
        /// <summary>
        /// Add a range of innerKeys to multiple keys
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="innerKeys"></param>
        public void AddRange(TKey[] keys, TInnerKey[,] innerKeys)
        {
            for(int i = 0; i < keys.Length; i++)
            {
                for(int j = 0; j < innerKeys.GetLength(0); j++)
                {
                    for (int k = 0; k < innerKeys.GetLength(1); k++)
                        Add(keys[i], innerKeys[j, k]);
                }
            }
        }

        public TInnerKey NextState(TKey firstState)
        {
            List<TItem<TInnerKey>> initial = new List<TItem<TInnerKey>>();
            TryGetStateAggragateProbabilities(firstState, out TItem<TInnerKey>[] items);
            var converted = new List<TItem<TInnerKey>>(items.Length);
            double sum = 0.0;

            Random r = new Random(DateTime.Now.GetHashCode());

            foreach(var i in items)
            {
                initial.Add(i);
            }
            foreach (var item in items)
            {
                sum += item.Probability;
                converted.Add(new TItem<TInnerKey> { Probability = sum, Name = item.Name, Count = item.Count });
            }
            converted.Add(new TItem<TInnerKey> { Probability = 1.0, Name = initial.Last().Name, Count =1 });

            
                var probability = r.NextDouble();
                var selected = converted.SkipWhile(i => i.Probability < probability).First();
            return selected.Name;


        }



    }

}
