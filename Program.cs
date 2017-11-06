/*******************************************************************************************
 *NAME: Ash Mahein, 11463887                                                               *
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
using System.IO;

namespace _321Assignment1
{
    class Program
    {
        public static int Main(String[] args)
        {
            Tree bst = new Tree(); //Tree object called BST.
            Console.WriteLine("Enter a collection of numbers in the range [0, 100], seperated by spaces: ");

            string[] token = Console.ReadLine().Split(' '); //get user input.
            int length = token.Length;

            for(int i = 0; i < length; i++) // for loop to parse the users input.
            {
                int numbers = int.Parse(token[i]);
                bst.addRc(numbers);
            }

            string sTree = "";
            bst.print(null, ref sTree); //function used to print out the tree in order from smallest to largest.

            Console.WriteLine("Tree Contents:" + sTree);

            Console.Write("Tree Statistics:\n"); //prints out the statistics of the tree.

            int totalItems = 0;
            bst.count(null, ref totalItems); //sums up number of elements in the tree using the sum function.
            Console.Write(" Number of elements: " + totalItems+ "\n");

            bst.treeHeight(totalItems); //function for getting the tree height.
           
            Console.ReadLine();            
            return 0;
        }
    }
}
