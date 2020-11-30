﻿using Boa.Constrictor.Utilities;
using System.IO;

namespace Boa.Constrictor.Dumping
{
    /// <summary>
    /// Parent class for dumpers.
    /// </summary>
    public abstract class AbstractDumper : IDumper
    {
        #region Properties

        /// <summary>
        /// Private dump directory path used by the DumpDir property.
        /// </summary>
        private string _DumpDir;

        /// <summary>
        /// The output directory for dumped files.
        /// The directory is created automatically when this property is set.
        /// Dumping is inactive if this property is null.
        /// </summary>
        public string DumpDir
        {
            get
            {
                return _DumpDir;
            }
            private set
            {
                _DumpDir = value;

                if (_DumpDir != null && !Directory.Exists(_DumpDir))
                    Directory.CreateDirectory(_DumpDir);
            }
        }

        /// <summary>
        /// A descriptive name for the dumper.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">A descriptive name for the dumper.</param>
        /// <param name="dumpDir">The output directory for dumped files.</param>
        public AbstractDumper(string name, string dumpDir)
        {
            Name = name;
            DumpDir = dumpDir;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Concatenates the dump file path.
        /// </summary>
        /// <param name="token">The token name for the file.</param>
        /// <param name="extension">The file extension. (blank by default)</param>
        /// <param name="suffix">An optional suffix for the filename.</param>
        /// <returns></returns>
        protected string GetDumpFilePath(string token, string extension = "", string suffix = null)
        {
            string name = Names.ConcatUniqueName(token, suffix) + extension;
            string path = Path.Combine(DumpDir, name);

            return path;
        }

        /// <summary>
        /// Returns the name of the dumper.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;

        #endregion
    }
}
