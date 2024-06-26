﻿using Models;


namespace DTOs
{
    public class GetAllArticleDTO
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public DateOnly ArticleCreationDate {  get; set; }
        public string AuthorName { get; set; }
        public string TopicName { get; set; }
    }
}
