using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Video> videos = new Dictionary<string, Video>();

        public bool Contains(User user)
        {
            return users.ContainsKey(user.Id);
        }

        public bool Contains(Video video)
        {
            return users.ContainsKey(video.Id);
        }

        public void DislikeVideo(User user, Video video)
        {
            if (!users.ContainsKey(user.Id) || !videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            videos[video.Id].Dislikes++;
            user.LikedOrDislikedVideos.Add(video);
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            return users.Values
                .Where(u => u.WatchedVideos.Count == 0 & u.LikedOrDislikedVideos.Count == 0);
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            return users.Values
                .OrderByDescending(u => u.WatchedVideos.Count)
                .ThenByDescending(u => u.LikedOrDislikedVideos.Count)
                .ThenBy(u => u.Username);
        }

        public IEnumerable<Video> GetVideos()
        {
            return videos.Values;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            return videos.Values
                .OrderByDescending(v => v.Views)
                .ThenByDescending(v => v.Likes)
                .ThenBy(v => v.Dislikes);
        }

        public void LikeVideo(User user, Video video)
        {
            if (!users.ContainsKey(user.Id) || !videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            videos[video.Id].Likes++;
            user.LikedOrDislikedVideos.Add(video);
        }

        public void PostVideo(Video video)
        {
            videos.Add(video.Id, video);
        }

        public void RegisterUser(User user)
        {
            users.Add(user.Id, user);
        }

        public void WatchVideo(User user, Video video)
        {
            if (!users.ContainsKey(user.Id) || !videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            videos[video.Id].Views++;
            user.WatchedVideos.Add(video);
        }
    }
}
