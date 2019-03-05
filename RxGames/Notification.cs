namespace RxGames
{
    class Notification
    {
        public string GroupId { get; }
        public string Data { get; }

        public Notification(string groupId, string data)
        {
            GroupId = groupId;
            Data = data;
        }
    }
}