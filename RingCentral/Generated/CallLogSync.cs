
using System.Threading.Tasks;
namespace RingCentral
{
    public partial class CallLogSync : Model
    {
        internal CallLogSync(Model parent) : base(parent, null) { }
        protected override string PathSegment
        {
            get
            {
                return "call-log-sync";
            }
        }
        public Task<GetResponse> Get(object queryParams)
        {
            return RC.Get<GetResponse>(Endpoint(false), queryParams);
        }
        public Task<GetResponse> Get(GetQueryParams queryParams = null)
        {
            return Get(queryParams as object);
        }
        public partial class GetQueryParams
        {
            // Type of synchronization. 'FSync' is a default value
            public string syncType { get; set; }
            // Value of syncToken property of last sync request response
            public string syncToken { get; set; }
            // The start datetime for resulting records in ISO 8601 format including timezone, for example 2016-03-10T18:07:52.534Z. The default value is the current moment
            public string dateFrom { get; set; }
            // For FSync the parameter is mandatory, it limits the number of records to be returned in response. For ISync it specifies with how many records to extend sync Frame to the past, the maximum number of records is 250
            public int? recordCount { get; set; }
            // Type of calls to be returned. The default value is 'All'
            public string statusGroup { get; set; }
        }
        public partial class GetResponse
        {
            // List of call log records with synchronization information. For ISync the total number of returned records is limited to 250; this includes both new records and the old ones, specified by the recordCount parameter
            public CallLogRecord[] records { get; set; }
            // Sync type, token and time
            public SyncInfo syncInfo { get; set; }
        }
    }
}
