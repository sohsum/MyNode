//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace VSNodeManagement.Models
//{
//    interface INodeModel
//    {
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyNode
{
    public interface INodeModel
    {
        string NodeId { get; set; }
        string City { get; set; }

        /// <summary>
        /// Timestamp of the node's last online time
        /// </summary>
        DateTime OnlineTime { get; set; }

        /// <summary>
        /// State of node
        /// </summary>
        bool IsOnline { get; set; }

        /// <summary>
        /// Current % of upstream bandwidth utilization
        /// </summary>
        float UploadUtilization { get; set; }

        /// <summary>
        /// Current % of downstream bandwidth utilization
        /// </summary>
        float DownloadUtilization { get; set; }

        /// <summary>
        /// Current % of network transfer errors 
        /// </summary>
        float ErrorRate { get; set; }

        /// <summary>
        /// Number of clients connected to this node
        /// </summary>
        uint ConnectedClients { get; set; }

        /// <summary>
        /// Bring the node online
        /// </summary>
        void SetOnline();

        /// <summary>
        /// Bring the node offline
        /// </summary>
        /// <returns></returns>
        void SetOffline();
    }
}
