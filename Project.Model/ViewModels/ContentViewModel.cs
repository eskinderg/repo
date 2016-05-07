using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Project.Model.Models;

namespace Project.Model.ViewModels
{
    //[JsonObject(IsReference = true)]
    //[DataContract(IsReference = true)]
    public class ContentViewModel 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string HTML { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public int XmlConfigId { get; set; }

        [DataMember]
        public int FolderId { get; set; }

        [DataMember]
        public Folder Folder { get; set; }
    }
}
