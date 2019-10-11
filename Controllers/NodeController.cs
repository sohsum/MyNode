using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyNode.Model;

namespace MyNode.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    public class NodesController : ControllerBase
    {
        
        public static  List<INodeModel> _nodes = new List<INodeModel> ();

        [HttpGet]
        [Route("api/nodes/AllNodes")]
        [EnableCors("MyPolicy")]
        public IEnumerable<INodeModel> Get()
        {
            return _nodes;
        }

        [HttpGet]
        [Route("api/nodes/GetNodeById")]
        [EnableCors("MyPolicy")]
        public INodeModel Get(string id)
        {
            return _nodes.FirstOrDefault(x => x.NodeId == id);
        }

        [HttpPost]
        [Route("api/nodes/AddNode")]
        [EnableCors("MyPolicy")]
        public void Post(string nodeId,string city)
        {
            NodeModel node = new NodeModel(nodeId, city);

            _nodes.Add(node);
           

        }

        [HttpPut]
        [Route("api/nodes/UpdateNode")]
        [EnableCors("MyPolicy")]
        public void Put(string nodeId,string city,string onlineTime, bool isOnline, string uploadUtilization, string downloadUtilization,string errorRate, string connectedClients)
        {
         INodeModel node =  _nodes.Find(x => x.NodeId == nodeId);

            node.City = city;
            node.OnlineTime =Convert.ToDateTime(onlineTime);
            node.IsOnline = isOnline;
            node.UploadUtilization = float.Parse(uploadUtilization);
            node.DownloadUtilization = float.Parse(downloadUtilization);
            node.ErrorRate = float.Parse(errorRate);
            node.ConnectedClients = uint.Parse(connectedClients);
                                  
        }

        [HttpDelete]
        [Route("api/nodes/RemoveNode")]
        [EnableCors("MyPolicy")]
        public void Delete(string id)
        {

            var existingNode = Get(id);

            if (existingNode != null)
            {
                _nodes.Remove(existingNode);
            }
            else
            {
               throw new Exception(string.Format("Cannot remove node. NodeId {0} does not exist", id));
              
            }
           
        }


    }
}

