Install-Package WindowsAzure.Storage -Version 9.3.3
-Above needs to be imported to solution for cloud Storage

byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b,0,b.Length) > 0) 
            {
                Console.WriteLine(temp.GetString(b));
            }