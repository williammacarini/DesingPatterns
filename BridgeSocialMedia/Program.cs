namespace BridgeSocialMedia
{
    public class Program
    {
        static void Main()
        {
            var face = new PostFacebook(new Face());
            face.Do();
        }
    }

    public interface ISocialMedia
    {
        void Post();
    }

    public class Face : ISocialMedia
    {
        public void Post()
        {
            Console.WriteLine("Facebook!");
        }
    }

    public class Insta : ISocialMedia
    {
        public void Post()
        {
            Console.WriteLine("Instagram");
        }
    }

    public abstract class AbstractSocialMedia
    {
        protected readonly ISocialMedia _socialMedia;

        protected AbstractSocialMedia(ISocialMedia socialMedia)
        {
            _socialMedia = socialMedia;
        }

        public abstract void Do();
    }

    public sealed class PostFacebook : AbstractSocialMedia
    {
        public PostFacebook(ISocialMedia socialMedia) : base(socialMedia)
        {
        }

        public override void Do()
        {
            _socialMedia.Post();
        }
    }

    public sealed class PostInstagram : AbstractSocialMedia
    {
        public PostInstagram(ISocialMedia socialMedia) : base(socialMedia)
        {
        }

        public override void Do()
        {
            _socialMedia.Post();
        }
    }
}