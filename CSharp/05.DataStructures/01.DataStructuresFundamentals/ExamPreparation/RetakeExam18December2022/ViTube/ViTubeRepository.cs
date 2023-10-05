using System;
using System.Collections.Generic;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        public bool Contains(User user)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Video video)
        {
            throw new NotImplementedException();
        }

        public void DislikeVideo(User user, Video video)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Video> GetVideos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            throw new NotImplementedException();
        }

        public void LikeVideo(User user, Video video)
        {
            throw new NotImplementedException();
        }

        public void PostVideo(Video video)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public void WatchVideo(User user, Video video)
        {
            throw new NotImplementedException();
        }
    }
}
