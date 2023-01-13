using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace UAS_089
{
    class Node
    {
        public int nim;
        public string nama;
        public string jeniskel;
        public string kelas;
        public string kota;
        public Node next;
    }
    class list
    {
        Node START;

        public list()
        {
            START = null;
        }
        public void addNote()
        {
            int nim;
            string nm, jk, kl, kt;
            Console.WriteLine("\nMasukkan NIM :");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan Nama :");
            nm = Console.ReadLine();
            Console.WriteLine("\nMasukkan Jenis Kelamin :");
            jk = Console.ReadLine();
            Console.WriteLine("\nMasukkan Kelas :");
            kl = Console.ReadLine();
            Console.WriteLine("\nMasukkan Kota Asal :");
            kt = Console.ReadLine();

            Node newNode = new Node();

            newNode.nim = nim;
            newNode.nama = nm;
            newNode.jeniskel = jk;
            newNode.kelas = kl;
            newNode.kota = kt;
            if (START == null || nim <=START.nim)
            {
                if ((START != null)&& (nim == START.nim))
                {
                    Console.WriteLine("\n Duplikat NIM tidak boleh");
                    return;
                }
                newNode.next = START;
                START = newNode;
                return;
            }

            Node Previous, current;
            Previous = START;
            current = START;

            while ((current != null) && (nim >= current.nim))
            {
                if (nim == current.nim)
                {
                    Console.WriteLine("\nDuplikat kode tidak diperbolehkan");
                    return;
                }
                Previous = current;
                current = current.next;
            }
            newNode.next = current;
            Previous.next = newNode;
        }

        public void traverse()
        {
            if (ListEmpty())
                Console.WriteLine("List Tidak Ada \n");
            else
            {
                Console.WriteLine("\n List Data Siswa Tersedia ");
                Console.WriteLine("NIM" + "   " + "Nama" + "   " + "Jenkel" + "    " + "Kelas" + "   " + "Kota" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.nim + "  " + currentNode.nama + "  " + currentNode.jeniskel + "  " + currentNode.kelas + "  " + currentNode.kota + "\n");
                }
                Console.WriteLine();
            }
        }
        public void Search()
        {
          Node Previous, current;
            current = Previous = START;
            Console.Write("\nMasukkan NIM yang ingin dicari :");
            int nim = Convert.ToInt32(Console.ReadLine());

            if (nim != current.nim)
                Console.WriteLine("\n Record Not Found ");
            else
                Console.WriteLine("\n Record Found");

            while(current != null)
            {
                if(nim == current.nim)
                Console.WriteLine("\nNIM :" + current.nim);
                Console.WriteLine("\nNama :" + current.nama);
                Console.WriteLine("\nJenis Kelamin :" + current.jeniskel);
                Console.WriteLine("\nKelas :" + current.kelas);
                Console.WriteLine("\nKota Asal :" + current.kota);

            }
            current = current.next;
        }

       
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Add a new record to the list");
                    Console.WriteLine("2. view all the record from the list");
                    Console.WriteLine("3. Search data in the list ");
                    Console.WriteLine("4. EXIT ");
                    Console.Write("Enter your choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {


                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("List is Empty");
                                    break;
                                }
                                else
                                    obj.Search();
                            }
                            break ;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine(" INvalid Option");
                                break;
                            }
                    } 
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value entered");
                }
            }
        }

    }
}


// 2. Saya menggunakan algoritma Single Linked List, karena saya rasa lebih simple dari pada algoritma yang lain.
//    selain itu dengan algoritma ini saja sudah bisa mengurutkan, menampilkan ataupun mencari data


// 3.Ascending dan Descending

// 4.perbedaan array dan lingked list adalah saat adanya ascending dan descending

// 5.a.   10 adalah adalah parent dari 15 dan 5
//        30 adalah parent dari 20 dan 32
//   b.  inorder 
//       10,12,15,15,18,16,5   