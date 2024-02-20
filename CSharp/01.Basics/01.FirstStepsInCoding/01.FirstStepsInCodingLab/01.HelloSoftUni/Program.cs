using System;

namespace _01.HelloSoftUni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list1 = new ListNode(2);
            var list2 = new ListNode(1, new ListNode(2, new ListNode(4)));

            var r = MergeTwoLists(list1, list2);

            while (r != null)
            {
                Console.Write($"{r.val}, ");
                r = r.next;
            }
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var result = new ListNode();
            var copy = result;

            while (list1 != null || list2 != null)
            {
                if (list1 != null && list2 != null)
                {
                    if (list1.val > list2.val)
                    {
                        copy.next = new ListNode(list2.val);
                        list2 = list2.next;
                    }
                    else
                    {
                        copy.next = new ListNode(list1.val);
                        list1 = list1.next;
                    }
                }
                else
                {
                    if (list1 == null)
                    {
                        copy.next = new ListNode(list2.val);
                        list2 = list2.next;
                    }
                    else
                    {
                        copy.next = new ListNode(list1.val);
                        list1 = list1.next;
                    }
                }

                copy = copy.next;
            }

            return result.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
