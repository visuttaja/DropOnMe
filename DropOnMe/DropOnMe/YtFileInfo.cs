namespace DropOnMe
{
    public class YtFileInfo
    {
        public string _type { get; set; }
        public string ie_key { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public object description { get; set; }
        public int duration { get; set; }
        public string channel_id { get; set; }
        public string channel { get; set; }
        public string channel_url { get; set; }
        public Thumbnail[] thumbnails { get; set; }
        public object timestamp { get; set; }
        public object release_timestamp { get; set; }
        public object availability { get; set; }
        public int view_count { get; set; }
        public object live_status { get; set; }
        public object __x_forwarded_for_ip { get; set; }
        public string webpage_url { get; set; }
        public string original_url { get; set; }
        public string webpage_url_basename { get; set; }
        public string webpage_url_domain { get; set; }
        public string extractor { get; set; }
        public string extractor_key { get; set; }
        public int playlist_count { get; set; }
        public string playlist { get; set; }
        public string playlist_id { get; set; }
        public string playlist_title { get; set; }
        public string playlist_uploader { get; set; }
        public string playlist_uploader_id { get; set; }
        public int n_entries { get; set; }
        public int playlist_index { get; set; }
        public int __last_playlist_index { get; set; }
        public int playlist_autonumber { get; set; }
        public string duration_string { get; set; }
        public int epoch { get; set; }
        public string filename { get; set; }
        public string urls { get; set; }
        public _Version _version { get; set; }
    }
    /*
    public class _Version
    {
        public string version { get; set; }
        public object current_git_head { get; set; }
        public string release_git_head { get; set; }
        public string repository { get; set; }
    }
    */
    /*
    public class Thumbnail
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }
    */
}