//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace VSNodeManagement.Models
//{
//    public class NodeModel
//    {
//    }
//}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNode.Model
{
    public class NodeModel : INodeModel
    {

        public  Random _rnd;

        #region Properties
        // Basic properties
        public string NodeId { get;  set; }
        public string City { get;  set; }

        // State
        public DateTime OnlineTime { get; set; }
        public bool IsOnline { get;  set; }

        // Metrics
        public float UploadUtilization { get; set; }
        public float DownloadUtilization { get; set; }
        public float ErrorRate { get;  set; }
        public uint ConnectedClients { get;set; }
        #endregion

        #region Initialization

        public NodeModel() { }
        
        public NodeModel(string nodeId, string city)
        {
            NodeId =nodeId;
            City = city;

            OnlineTime = DateTime.Now;

            IsOnline = false;

            ResetMetrics();

        }
        public NodeModel(string nodeId, string city, Random rnd)
        {
            _rnd = rnd;

            NodeId = nodeId;
            City = city;

            OnlineTime = DateTime.Now;

            IsOnline = false;

            ResetMetrics();
        }

        #endregion

        #region Public Methods
        public void SetOnline()
        {
            IsOnline = true;

            SimulateRandomMetrics();
        }

        public void SetOffline()
        {
            IsOnline = false;

            ResetMetrics();
        }
        #endregion

        #region Private Methods
        private void ResetMetrics()
        {
            // Clear metrics back to 0.

            ConnectedClients = 0;

            UploadUtilization = 0.0f;
            DownloadUtilization = 0.0f;
            ErrorRate = 0.0f;
        }

        private void SimulateRandomMetrics()
        {
            // Generate random values to simulate metrics.

            ConnectedClients = (uint)_rnd.Next(1, 500);

            UploadUtilization = (float)_rnd.NextDouble();
            DownloadUtilization = (float)_rnd.NextDouble();
            ErrorRate = (float)_rnd.NextDouble();
        }
        #endregion


    }
}
