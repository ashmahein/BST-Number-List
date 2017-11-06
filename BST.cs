/*******************************************************************************************
 *NAME: Ash Mahein    11463887                                                             *
 *DATE: 9/4/17                                                                             *
 *Assignment: 1                                                                            *
 *Description: A simple BST that fills up with user input and supplies the user with       *
 *information about the numbers in the tree, levels, and minumum levels.                   *
 *                                                                                         *
 *Outside Sources: Youtube, StackOverflow.                                                 *
 *******************************************************************************************/

 //.NET Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _321Assignment1
{
    //Node class makes a node to place inside the BST.
    class Node
    {
        public int values; //stores the values.
        public Node left; //left pointer.
        public Node right; //right pointer.

        //constructor for the node class.
        public Node(int initial) 
        {
            values = initial;
            left = null;
            right = null;
        }
    }


    class Tree
    {
        Node Root; //Node objects which is the root of the tree.

        public Tree() //empty constructor that intializes the tree to null.
        {
            Root = null;
        }

        public Tree(int initial) //constructor for the tree class.
        {
            Root = new Node(initial);
        }

        public void addRc(int nodeValues) //a public function that calls addR to add nodes to the tree.
        {
            //call to the recursive addR function.
            addR(ref Root, nodeValues);
        }

        private void addR(ref Node N, int addValues) //private functions that adds nodes ot the trees.
        {
            //priavte recurisve search for where to add the new node. 
            if (N == null)
            {
                Node NewNode = new Node(addValues); //create a new node that holds a value read in from the users input.
                N = NewNode; //initialize N to the new node.
                return;
            }
            //check to see if the new value is less than the ones already in the tree.
            else if (addValues < N.values)
            {
                addR(ref N.left, addValues); //recursiverly check to see where the node can be added.
                return;
            }
            //check to see if the new value is greater than the ones already in the tree.
            else if (addValues > N.values)
            {
                addR(ref N.right, addValues); //recursiverly check to see where the node can be added.
                return;
            }
            

        }

        public void print(Node N, ref string newstring)
        {
            //write out the tree in sorted order to the string newstring
            //implemented using recursion.
            if (N == null)
            {
                N = Root; //intialize N to the root of the tree.
            }
            if (N.left != null)
            {
                print(N.left, ref newstring); //recuriverly get all the items in the tree
                newstring = newstring + N.values.ToString().PadLeft(3); //gather all the items into newstring and then print out newstring.
            }
            else
            {
                newstring = newstring + N.values.ToString().PadLeft(3);
            }
            if (N.right != null)
            {
                print(N.right, ref newstring); //recuriverly get all the items in the tree
            }
        }

        //this function sums up the number of nodes there are in the tree. 
        public void count(Node N, ref int sumNum)
        {
            if (N == null)
            {
                N = Root; //set N equal to the root of the tree.
                sumNum++; //add one if the the root exists.
            }
            if(N.left != null) //if the left side of the tree isn't null it will recursively traverse down the left side of the tree until all nodes are summed up.
            {
                count(N.left, ref sumNum);
                sumNum++;
            }
            if(N.right != null) //if the right side of the tree isn't null it will recursively traverse down the right side of the tree until all nodes are summed up.
            {
                count(N.right, ref sumNum); 
                sumNum++;
            }
        }

        //treeHeight gets the height of the tree. This function also gets the theoretical minimum levels there need to be in the tree.
        public void treeHeight(int totalNodes)
        {
            int totalLevels = levels(Root); //call to private function levels. 
            Console.Write(" Number of levels: " + totalLevels + "\n");


            double minLvls = Math.Log(totalNodes, 2); //calculation done to get the theoritical minimum number of levels in a tree. 
            int round = (int) Math.Ceiling(minLvls);
            

            Console.Write(" Minimum number of levels a tree with " + totalNodes + " nodes could have:" + round + "\n");
        }

        //a private function that is called in order to get the total number of levels in the tree recursively. 
        private int levels(Node N)
        {
            int height = 0;

            if(N != null)
            {
                height = Math.Max(levels(N.left), levels(N.right)) + 1; //gets the height of the tree recursively and gets the longest side.
            }
            return height;
        }
    }
}
