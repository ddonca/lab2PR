using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PR_Test
{
     class ThreadSafe
     {

          static CountdownEvent count1 = new CountdownEvent(1);
          static CountdownEvent count2 = new CountdownEvent(1);
          static CountdownEvent count3 = new CountdownEvent(1);
          static CountdownEvent count4 = new CountdownEvent(1);
          static CountdownEvent count5 = new CountdownEvent(1);
          static CountdownEvent count6 = new CountdownEvent(1);


          static void Main()
          {
               Thread th1 = new Thread(Show1);
               th1.Name = "Thread 1";
               th1.Start();

               Thread th2 = new Thread(Show2);
               th2.Name = "Thread 2";
               th2.Start();

               Thread th3 = new Thread(Show3);
               th3.Name = "Thread 3";
               th3.Start();

               Thread th4 = new Thread(Show4);
               th4.Name = "Thread 4";
               th4.Start();

               Thread th5 = new Thread(Show5);
               th5.Name = "Thread 5";
               th5.Start();

               Thread th6 = new Thread(Show6);
               th6.Name = "Thread 6";
               th6.Start();



               Console.ReadLine();
          }

          static void Show1()
          {
               Console.WriteLine("Start  .. " + Thread.CurrentThread.Name); Thread.Sleep(2000);
               count1.Signal();
               Console.WriteLine("End  .. " + Thread.CurrentThread.Name);
          }
          static void Show2()
          {
               count1.Wait();
               Console.WriteLine("Start  .. " + Thread.CurrentThread.Name); Thread.Sleep(2000);

               count2.Signal();
               Console.WriteLine("End  .. " + Thread.CurrentThread.Name);
          }
          static void Show3()
          {
               count2.Wait();
               Console.WriteLine("Start  .. " + Thread.CurrentThread.Name); Thread.Sleep(2000);

               count3.Signal();
               Console.WriteLine("End  .. " + Thread.CurrentThread.Name);
          }
          static void Show4()
          {
               count3.Wait();
               Console.WriteLine("Start  .. " + Thread.CurrentThread.Name); Thread.Sleep(2000);
               count4.Signal();
               Console.WriteLine("End  .. " + Thread.CurrentThread.Name);
          }
          static void Show5()
          {
               count4.Wait();
               Console.WriteLine("Start  .. " + Thread.CurrentThread.Name); Thread.Sleep(2000);
               count5.Signal();
               Console.WriteLine("End  .. " + Thread.CurrentThread.Name);

          }
          static void Show6()
          {
               count5.Wait();
               Console.WriteLine("Start  .. " + Thread.CurrentThread.Name); Thread.Sleep(2000);
               Console.WriteLine("End  .. " + Thread.CurrentThread.Name);
          }

     }
}
