﻿//
// checksum
// Copyright(C) Stéphane VANPOPERYNGHE
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or(at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
//

using System;
using System.IO;
using System.Reflection;

namespace Shared.Helpers
{
    /// <summary>
    /// Helper class for the console.
    /// </summary>
    public sealed class ConsoleHelper
    {
        /// <summary>
        /// Don't display anything. Just return the code.
        /// </summary>
        public static bool Status { get; set; }

        #region Constructors
        /// <summary>
        /// Static constructor.
        /// </summary>
        static ConsoleHelper()
        {
            Status = false;
        }

        /// <summary>
        /// Static calls only.
        /// </summary>
        private ConsoleHelper()
        {
        }
        #endregion

        /// <summary>
        /// Log an error to the console.
        /// </summary>
        /// <param name="msg">The message to show.</param>
        /// <param name="data">The data to mix with the message.</param>
        public static void LogError(string msg, params object[] data)
        {
            if (Status) return;

            // Retrieve the name of the program
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string name = Path.GetFileName(codeBase);

            Console.Error.WriteLine(name + " : " + string.Format(msg, data));
        }

        /// <summary>
        /// Log an info to the console.
        /// </summary>
        /// <param name="msg">The message to show.</param>
        /// <param name="data">The data to mix with the message.</param>
        public static void LogInfo(string msg, params object[] data)
        {
            if (Status) return;

            Console.WriteLine(string.Format(msg, data));
        }
    }
}
