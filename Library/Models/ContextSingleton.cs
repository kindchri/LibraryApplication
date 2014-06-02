﻿///Version 1.0
///Written by ???
/// 2013-10-31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Models
{
    /// <summary>
    /// Keeps a singleton of the database context
    /// </summary>
    class ContextSingelton
    {
        static LibraryContext _context;

        /// <summary>
        /// Get the db-context instance
        /// </summary>
        public static LibraryContext GetContext()
        {
            if (_context == null)
                _context = new LibraryContext();

            return _context;
        }
    }
}