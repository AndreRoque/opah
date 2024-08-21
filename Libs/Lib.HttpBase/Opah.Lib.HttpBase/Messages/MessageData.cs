using System.Runtime.Serialization;

namespace Opah.Lib.HttpBase.Messages
{
    [DataContract]
    public class MessageData
    {
        #region Public Constructors

        public MessageData(string content, string trackCode)
        {
            Content = content;
            TrackCode = trackCode;

            DateTime = DateTime.Now;
        }

        #endregion Public Constructors

        #region Public Properties

        [DataMember(Name = "trackCode")]
        public string TrackCode { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "dateTime")]
        public DateTime DateTime { get; set; }

        #endregion Public Properties
    }
}