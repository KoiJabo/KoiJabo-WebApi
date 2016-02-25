using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo_models.Entity
{
    public class OptionsForDashBoardEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public OptionsForDashBoardEntity()
        {

        }
        public List<string> Cuisines { get; set; }
        public List<string> CreditCards { get; set; }
        public List<string> GoodFors { get; set; }
        public List<string> Attires { get; set; }
        public List<string> EstablishmentType { get; set; }
        public List<string> Area { get; set; }
    }
}
