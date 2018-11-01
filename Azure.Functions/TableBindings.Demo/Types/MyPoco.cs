using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

namespace MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types
{
    /// <summary>
    /// Example Class representing a table row.
    /// <para>MyPoco inherits TableEntity which adds the Partition Key, RowKey, TimeStamp and eTag.</para>
    /// </summary>
    public class MyPoco : TableEntity
    {
        /// <summary>
        /// Example Property
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Example Property
        /// </summary>
        public string Job { get; set; }
    }
}
