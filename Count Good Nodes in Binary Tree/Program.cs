using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Good_Nodes_in_Binary_Tree
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }
    internal class Solution
    {
        public int GoodNodes(TreeNode root)
        {
            if (root == null) return 0;
            //Perform DFS
            return dfs(root, root.val);
        }

        private int dfs(TreeNode root, int maxValue)
        {
            if (root == null) return 0;

            int count = 0;
            //Update count if current node's value is greater than running maxValue up till this node
            if (root.val >= maxValue) count++;

            //Keep track of maximum value seen till this node
            int newMaxvalue = Math.Max(maxValue, root.val);

            count += dfs(root.left, newMaxvalue);
            count += dfs(root.right, newMaxvalue);

            return count;
        }
    }
     //* Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}
