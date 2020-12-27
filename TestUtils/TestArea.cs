﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtils
{
    public class TestArea : IDisposable
    {
        public string Name { get; }

        public string TestFolder { get; }

        public TestArea(string name)
        {
            Name = name;
            TestFolder = Path.Combine(Path.GetTempPath(), nameof(TestArea), $"{name}-{Utils.RandomString(8)}");

            Directory.CreateDirectory(TestFolder);

            Debug.WriteLine($"Created test area '{name}' in folder '{TestFolder}'");

        }

        public TestArea() : this(new StackFrame(1).GetMethod()?.Name)
        {
            //
        }

        public void Dispose()
        {
            if (Directory.Exists(TestFolder))
                Directory.Delete(TestFolder, true);

            Debug.WriteLine($"Disposed test area '{Name}' in folder '{TestFolder}'");

        }
    }
}
