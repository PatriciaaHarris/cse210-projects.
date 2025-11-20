using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear videos
            Video video1 = new Video("Learning C#", "Patricia", 300);
            video1.AddComment(new Comment("Alice", "Great video!"));
            video1.AddComment(new Comment("Bob", "Thanks for the explanation."));
            video1.AddComment(new Comment("Carol", "Very helpful!"));

            Video video2 = new Video("Classes and Objects", "Patricia", 420);
            video2.AddComment(new Comment("Dave", "Really clear explanation!"));
            video2.AddComment(new Comment("Eva", "I finally understood this topic."));

            // Lista de videos
            List<Video> videos = new List<Video>() { video1, video2 };

            // Mostrar información
            foreach (Video v in videos)
            {
                Console.WriteLine($"Title: {v.Title}");
                Console.WriteLine($"Author: {v.Author}");
                Console.WriteLine($"Length (seconds): {v.LengthSeconds}");
                Console.WriteLine($"Number of comments: {v.GetNumberOfComments()}");

                Console.WriteLine("Comments:");
                foreach (Comment c in v.GetComments())
                {
                    Console.WriteLine($" - {c.CommenterName}: {c.Text}");
                }

                Console.WriteLine();
            }
        }
    }
}
