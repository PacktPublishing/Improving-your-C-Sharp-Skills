using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTPL
{
    abstract class Program
    {


        static byte[] fileBytes;

        static void Main(string[] args)
        {
            // Task t = Task.Run(()=>ExecuteLongRunningTask(5000));
            // t.Wait();

            //Task t = Task.Factory.StartNew(() => ExecuteLongRunningTask());x
            //t.Wait();

            //var progressHandler = new Progress<string>(value =>
            //{
            //    Console.WriteLine(value);
            //});

            //var progress = progressHandler as IProgress<string>;

            //CancellationTokenSource tokenSource = new CancellationTokenSource();
            //CancellationToken token = tokenSource.Token;

            //var t= Task.Factory.StartNew(() => SaveFileAsync(null, token, progress));
            //t.Wait();
            //Console.WriteLine("Executing...");

            //Console.WriteLine("Executing...");
            //tokenSource.Cancel();
            //Console.WriteLine("Executing...");
            //Task t1 = Task.Run(() => ReadFile());

            //Task t2 = t1.ContinueWith(task2 => WriteFile(@"D:\ClientFiles\" + Guid.NewGuid() + ".txt"));
            //new Thread(new ThreadStart(ExecuteLongRunningTask)).Start();

            //Task.WaitAll(new Task[]{t1,t2});

            //var t = ExecuteLongRunningOperationAsync(100000);
            //Console.WriteLine("Called ExecuteLongRunningOperationAsync method, now waiting for it to complete");
            //t.Wait();
            //Console.Read();

            //var t = ExecuteTask();
            //t.Wait();

            //var watch = Stopwatch.StartNew();
            //List<Document> docs = GetUserDocuments();

            //var query = from doc in docs.AsParallel()
            //            select ManageDocument(doc);





            //Parallel.ForEach(docs, (doc) =>
            //{
            //    ManageDocument(doc);
            //});

            //foreach (var doc in docs)
            //{
            //    Thread.Sleep(1000);
            //    File.WriteAllBytes(@"C:\docs\" + doc.DocumentName, doc.DocumentContent);

            //}

            //Console.WriteLine($"Took {watch.ElapsedMilliseconds} milli seconds");
            //Console.Read();

            //List<Template> templates = GetTemplates();
            //IEnumerable<Task> asyncDocs = from template in templates select GenerateDocument(template);
            //try
            //{
            //    Task.WaitAll(asyncDocs.ToArray());

            //}catch(Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            //Task<int> t1 = Task.Factory.StartNew(() => 
            //                { return CreateUser(); });

            //var t2=t1.ContinueWith((antecedent) => { return InitiateWorkflow(antecedent.Result); });
            //var t3 = t2.ContinueWith((antecedant) => { return SendEmail(antecedant.Result); });

            //Task<int> t1 = Task.Factory.StartNew(() => { return Task1(); });
            //Task<int> t2 = Task.Factory.StartNew(() => { return Task2(); });
            //Task<int> t3 = Task.Factory.ContinueWhenAll(new[] { t1, t2 }, (tasks) => { return Task3(); });
            //Task<int> t4 = t3.ContinueWith((antecendent) => { return Task4(); });
            //Task<int> t5 = t3.ContinueWith((antecendent) => { return Task5(); });

            int maxColl = 10;
            var blockingCollection = new BlockingCollection<int>(maxColl);
            var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);

            Task producer = taskFactory.StartNew(() =>
            {
                if (blockingCollection.Count <= maxColl)
                {
                    int imageID = ReadImageFromDB();
                    blockingCollection.Add(imageID);
                    blockingCollection.CompleteAdding();
                }
            });


            Task consumer = taskFactory.StartNew(() =>
            {
                while (!blockingCollection.IsCompleted)
                {
                    try
                    {
                        int imageID = blockingCollection.Take();
                        ProcessImage(imageID);
                    }
                    catch (Exception ex)
                    {
                        //Log exception
                    }
                }
            });

            Console.Read();

        }

        public async Task<int> ExecuteAsync()
        {
            throw new NotImplementedException();

        }


        private static async Task<int> GenerateDocument(Template template)
        {
            //To automate long running operation
            Thread.Sleep(1000);
            //Throwing exception intentionally
            throw new Exception();
        }


        private static Document ManageDocument(Document doc)
        {
            Thread.Sleep(1000);
            return doc;
        }

        public static List<Document> GetUserDocuments()
        {
            byte[] toBytes = Encoding.ASCII.GetBytes("This is a sample content");

            List<Document> lst = new List<Document>();
            lst.Add(new Document { DocumentName = "Item1.txt", DocumentContent = toBytes });
            lst.Add(new Document { DocumentName = "Item2.txt", DocumentContent = toBytes });
            lst.Add(new Document { DocumentName = "Item3.txt", DocumentContent = toBytes });
            lst.Add(new Document { DocumentName = "Item4.txt", DocumentContent = toBytes });
            lst.Add(new Document { DocumentName = "Item5.txt", DocumentContent = toBytes });
            lst.Add(new Document { DocumentName = "Item6.txt", DocumentContent = toBytes });
            lst.Add(new Document { DocumentName = "Item7.txt", DocumentContent = toBytes });
            lst.Add(new Document { DocumentName = "Item8.txt", DocumentContent = toBytes });
            lst.Add(new Document { DocumentName = "Item9.txt", DocumentContent = toBytes });
            return lst;

        }

        public static List<Template> GetTemplates()
        {
            byte[] toBytes = Encoding.ASCII.GetBytes("This is a sample content");

            List<Template> lst = new List<Template>();
            lst.Add(new Template { TemplateID = "Item1.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item2.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item3.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item4.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item5.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item6.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item7.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item8.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item9.txt", TemplateContent = toBytes });
            lst.Add(new Template { TemplateID = "Item10.txt", TemplateContent = toBytes });

            return lst;

        }
        static Task<int> SaveFileAsync(byte[] fileBytes, CancellationToken cancellationToken, IProgress<string> progress)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                progress.Report("Cancellation is called");
                Console.WriteLine("Cancellation is requested...");
            }

            progress.Report("Saving File");
            //Do some file save operation
            //string str = string.Empty;
            //for (int i = 0; i < 1000000; i++)
            //{
            //    str = "Counter is " + i;
            //    Console.WriteLine(str);
            //}
            progress.Report("File Saved");
            return Task.FromResult<int>(0);

        }

        static Task<int> SaveFileAsync(byte[] fileBytes, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation is requested...");
            }
            //Do some file save operation
            string str = string.Empty;
            for (int i = 0; i < 1000000; i++)
            {
                str = "Counter is " + i;
                Console.WriteLine(str);
            }
            return Task.FromResult<int>(0);
            
        }

        public static Task<int> ExecuteTask()
        {
            var tcs = new TaskCompletionSource<int>();
            Task<int> t1 = tcs.Task;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    ExecuteLongRunningTask(10000);
                    tcs.SetResult(1);
                }catch(Exception ex)
                {
                    tcs.SetException(ex);
                }
             }
            );
            return tcs.Task;

        }

        public static void ExecuteLongRunningTask(int millis)
        {
            Thread.Sleep(millis);
            Console.WriteLine("Executed");
        }


        public static int ReadImageFromDB()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Image is read");
            return 1;
        }

        public static void ProcessImage(int imageID)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Image is processed");
            
        }


        public static int Task1()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 1 is executed");
            return 1;
        }

        public static int Task2()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 is executed");
            return 1;
        }

        public static int Task3()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 3 is executed");
            return 1;
        }

        public static int Task4()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 4 is executed");
            return 1;
        }

        public static int Task5()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 5 is executed");
            return 1;
        }


        public static int CreateUser()
        {
            //Create user, passing hardcoded user ID as 1
            Thread.Sleep(1000);
            Console.WriteLine("User created");
            return 1;
        }

        public static int InitiateWorkflow(int userId)
        {
            //Initiate Workflow
            Thread.Sleep(1000);
            Console.WriteLine("Workflow initiates");

            return userId;
        }

        public static int SendEmail(int userId)
        {
            //Send email
            Thread.Sleep(1000);
            Console.WriteLine("Email sent");

            return userId;
        }


        public static void ReadFile()
        {
            //Read file from DB
            fileBytes= File.ReadAllBytes(@"D:\ClientFiles\Sample.txt");
        }

        public static void WriteFile(string path)
        {
            //Read file from DB
            File.WriteAllBytes(path, fileBytes);
        }

        public static void ExecuteLongRunningTask()
        {
            string str = string.Empty;
            for(int i = 0; i < 1000000; i++)
            {
                str ="Counter is "+ i;
                Console.WriteLine(str);
            }          
        }
        public static async Task<int> ExecuteLongRunningOperationAsync(int millis)
        {
            Task t = Task.Factory.StartNew(() => RunLoopAsync(millis));
            await t;
            Console.WriteLine("Executed RunLoopAsync method");
            return 0;
        }

        public static void RunLoopAsync(int millis)
        {
            Console.WriteLine("Inside RunLoopAsync method");
            for(int i=0;i< millis; i++)
            {
                Debug.WriteLine($"Counter = {i}");
            }
            Console.WriteLine("Exiting RunLoopAsync method");
        }
    }
}
