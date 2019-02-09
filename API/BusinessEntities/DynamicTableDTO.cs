using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class DynamicTableDTO
    {
        public DynamicTableDTO(DataTable dt)
        {
            this.DisplayName = (from dc in dt.Columns.Cast<DataColumn>()
                                select dc.ColumnName).ToArray();
            this.DisplayCaption = (from dc in dt.Columns.Cast<DataColumn>()
                                   select dc.ColumnName).ToArray();
            this.DisplayData = dt;
        }
        [DataMember]
        public String[] DisplayName { get; set; }

        [DataMember]
        public String[] DisplayCaption { get; set; }

        [DataMember]
        public int DisplayWidth { get; set; }

        [DataMember]
        public DataTable DisplayData { get; set; }
    }
}
